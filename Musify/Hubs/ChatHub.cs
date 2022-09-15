using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musify.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.Others.addNewMessageToPage(name, message);
        }

        public void Recieve(string name, string message)
        {
            Clients.Caller.recieveNewMessageToPage(name, message);
        }

        public void Write()
        {
            Clients.Others.showWriting();
        }

        public void Stopwrite()
        {
            Clients.Others.stopWriting();
        }
    }
}