using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string name)
        {
            string time = DateTime.Now.ToString("HH:mm");
            await this.Clients.All.SendAsync("Send", message, name, time);
        }
    }
}
