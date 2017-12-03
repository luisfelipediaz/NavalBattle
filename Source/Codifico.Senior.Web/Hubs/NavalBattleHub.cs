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
        public static List<NavalBattleGame> games = new List<NavalBattleGame>();

        public Task Send(string data)
        {
            return Clients.All.InvokeAsync("Send", data);
        }

        public override Task OnConnectedAsync()
        {
            NavalBattleGame groupAlone = games.FirstOrDefault(game => game.Player2 is null);

            if (groupAlone.Player1 is null)
            {
                groupAlone.Player1 = new Player { Id = Context.ConnectionId };
                games.Add(groupAlone);
            }
            else
            {
                groupAlone.Player2 = new Player { Id = Context.ConnectionId };
            }

            Clients.Client(Context.ConnectionId).InvokeAsync("onAssignGroup", groupAlone.GetHashCode());

            return base.OnConnectedAsync();
        }
    }
}
