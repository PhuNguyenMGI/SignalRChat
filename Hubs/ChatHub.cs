using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
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
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

    }
}
