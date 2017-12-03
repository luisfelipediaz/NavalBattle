using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Codifico.Senior.Web.Hubs
{
    public class NavalBattle : Hub
    {
        public Task Send(string data)
        {
            return Clients.All.InvokeAsync("Send", data);
        }
    }
}
