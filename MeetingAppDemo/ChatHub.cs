namespace MeetingAppDemo
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// A SignalR Hub class
    /// </summary>
    public class ChatHub: Hub
    {
        /// <summary>
        /// Method to send the message to all clients.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task SendMessage(string message, string status)
        {
            Console.WriteLine($"New Message: {message} {status}");
            await Clients.All.SendAsync("ReceiveMessage", message, status);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("A client is connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("A client is disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
