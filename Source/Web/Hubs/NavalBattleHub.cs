﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using Core.Entities;
using Core;

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
            return games.GetGameOfIdPlayer(Context.ConnectionId).GetPlayer(Context.ConnectionId).Boats;
        }

        public override Task OnConnectedAsync()
        {
            NavalBattleGame game = games.AddPlayer(Context.ConnectionId);
            Clients.Client(Context.ConnectionId).InvokeAsync("onAssignGame", game);
            return base.OnConnectedAsync();
        }
    }
}