using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
        Task Send(string message);
    }
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(string user,  string message)
            => await Clients.All.ReceiveMessage(user, message);
        public async Task SendPrivateMessage(string user, string message, string toUser)
            => await Clients.User(toUser).ReceiveMessage(user, message);
        public async Task SendMessageToCaller(string user, string message)
            => await Clients.Caller.ReceiveMessage(user, message);
        public async Task SendMessageToGroup(string user, string message)
            => await Clients.Group("SignalR Users").ReceiveMessage(user, message);
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).Send($"{Context.ConnectionId} has joined the group {groupName}.");
        }
        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).Send($"{Context.ConnectionId} has left the group {groupName}.");
        }
        //public override async Task OnConnectedAsync()
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
        //    await base.OnConnectedAsync();
        //}
        //public override async Task OnDisconnectedAsync(Exception? exception)
        //{
        //    await base.OnDisconnectedAsync(exception);
        //}

    }
}
