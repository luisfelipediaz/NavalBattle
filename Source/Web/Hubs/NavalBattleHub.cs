using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using Core.Entities;
using Core;
using System.Drawing;

namespace Web.Hubs
{
    public class NavalBattleHub : Hub
    {
        public static GamesRoom games = new GamesRoom();

        public Task Send(string data)
        {
            return Clients.All.InvokeAsync("Send", data);
        }

        public List<Boat> GetBoatsOfPlayer()
        {
            return games.GetPlayer(Context.ConnectionId).Boats;
        }

        public void SendMove(int x, int y)
        {
            NavalBattleGame game = games.GetGameOfPlayer(Context.ConnectionId);
            Player otherPlayer = game.Players.First(player => !player.Id.Equals(Context.ConnectionId));

            Player actualPlayer = game.GetPlayer(Context.ConnectionId);
            PointBoat move = new PointBoat(x, y);

            if (otherPlayer.HitMarket(new Point(x, y)))
            {
                move.Beaten = true;
            }
            else
            {
                Clients.Client(otherPlayer.Id).InvokeAsync("changeTurn", true);
                Clients.Client(Context.ConnectionId).InvokeAsync("changeTurn", false);
            }

            actualPlayer.Moves.Add(move);
            Clients.Client(actualPlayer.Id).InvokeAsync("onMyMovesChange", actualPlayer.Moves);
            Clients.Client(otherPlayer.Id).InvokeAsync("onOppositeMovesChange", actualPlayer.Moves);
        }

        public override Task OnConnectedAsync()
        {
            NavalBattleGame game = games.AddPlayer(Context.ConnectionId);
            Clients.Client(Context.ConnectionId).InvokeAsync("onAssignGame", game);

            if (game.AllPlayersOnline)
            {
                game.Players.ToList().ForEach(player =>
                {
                    Clients.Client(player.Id).InvokeAsync("onGameFull", game);
                });

                Clients.Client(game.Players.First().Id)
                       .InvokeAsync("changeTurn", true);

                Clients.Client(game.Players.Last().Id)
                       .InvokeAsync("changeTurn", false);
            }

            return base.OnConnectedAsync();
        }
    }
}
