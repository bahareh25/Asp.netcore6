using Microsoft.AspNetCore.SignalR;

namespace MySignalRSample.Hubs
{
    public class ChatHubs:Hub
    {
        public async Task SendMessage(string UserName,string message)
        {
            await Clients.All.SendAsync("ReceivedMessage",UserName,message);
        }
    }
}
