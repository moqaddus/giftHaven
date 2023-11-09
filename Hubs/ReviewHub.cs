using Microsoft.AspNetCore.SignalR;

namespace WebWebWeb.Hubs
{
    public class ReviewHub:Hub
    {
        public async Task SendMessage(string name, string review, int rating) //Receives the mesage from Client side using chat.js
        {
            //await Clients.All.SendAsync("ReceiveMessage", m);
            //await Clients.Caller.SendAsync("ReceiveMessage", m);
            await Clients.All.SendAsync("ReceiveMessage", name, review, rating);
        }
            

    }
}
