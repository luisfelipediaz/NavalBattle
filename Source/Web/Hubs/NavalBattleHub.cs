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

        public override Task OnConnectedAsync()
        {
            NavalBattleGame game = games.AddPlayer(Context.ConnectionId);
            Clients.Client(Context.ConnectionId).InvokeAsync("onAssignGame", game);
            ProcessGame(game);

            return base.OnConnectedAsync();
        }

        public List<Boat> GetBoatsOfPlayer()
        {
            return games.GetPlayer(Context.ConnectionId).Boats;
        }

        public void SendMove(int x, int y)
        {
            NavalBattleGame game = games.GetGameOfPlayer(Context.ConnectionId);
            Player actualPlayer = game.GetPlayer(Context.ConnectionId);
            Player otherPlayer = game.GetOpponent(Context.ConnectionId);

            PointBoat move = new PointBoat(x, y);

            if (game.SendMoveToPlayer(actualPlayer, otherPlayer, move) is false)
            {
                ChangeTurn(otherPlayer);
            }

            Clients.Client(actualPlayer.Id).InvokeAsync("onMyMovesChange", actualPlayer.Moves);
            Clients.Client(otherPlayer.Id).InvokeAsync("onOppositeMovesChange", actualPlayer.Moves);
        }

        void ChangeTurn(Player otherPlayer)
        {
            InvokeChangeTurn(otherPlayer.Id, true);
            InvokeChangeTurn(Context.ConnectionId, false);
        }



        void ProcessGame(NavalBattleGame game)
        {
            if (game.AllPlayersOnline)
            {
                NotifyGameFull(game);

                InvokeChangeTurn(game.Players.First().Id, true);
                InvokeChangeTurn(game.Players.Last().Id, false);
            }
        }

        void NotifyGameFull(NavalBattleGame game)
        {
            game.Players.ToList().ForEach(player =>
            {
                Clients.Client(player.Id).InvokeAsync("onGameFull", game);
            });
        }

        void InvokeChangeTurn(string IdPlayer, bool itsTurn)
        {
            Clients.Client(IdPlayer)
                   .InvokeAsync("changeTurn", itsTurn);
        }
    }
}
