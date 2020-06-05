using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_ProgressBar_MVC5.SignalR
{
    public class ProgressHub : Hub
    {
        public void NotifyProgress(int progress)
        {
            Clients.Caller.NotifyUser(progress);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}