using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace DealSe.Hubs
{
    public class NotificationUserHub : Hub
    {
        //Called when a connection with the hub is started.
        public override async Task OnConnectedAsync()
        {
            //Get OperatorCompanyId to set group name
            var httpContext = this.Context.GetHttpContext();
            var admin = httpContext.Request.Query["admin"];

            //Add operator in group
            await Groups.AddToGroupAsync(Context.ConnectionId, "group_" + admin);
            await base.OnConnectedAsync();
        }

        //Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            //Get OperatorCompanyId to disconnect from connected group
            var httpContext = this.Context.GetHttpContext();
            var admin = httpContext.Request.Query["admin"];

            //Remove operator from group
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "group_" + admin);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
