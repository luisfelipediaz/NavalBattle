using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using Codifico.Senior.Core.Entities;

namespace Codifico.Senior.Web.Hubs
{
    public class NavalBattleHub : Hub
    {
        public static GamesRoom games = new GamesRoom();

        public Task Send(string data)
        {
            return Clients.All.InvokeAsync("Send", data);
        }

        public override Task OnConnectedAsync()
        {
            NavalBattleGame game = games.AddPlayer(Context.ConnectionId);
            Clients.Client(Context.ConnectionId).InvokeAsync("onAssignGame", game.Id);
            Groups.AddAsync(Context.ConnectionId, game.Id);
            return base.OnConnectedAsync();
        }
    }
}
