using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public interface IClient
    {
        Task<string> GetMessage();
    }
    public class ClientHub : Hub<IClient>
    {
        public async Task<string> WaitForMessage(string connectionId)
        {
            string message = await Clients.Client(connectionId).GetMessage();
            return message;
        }
    }
}
