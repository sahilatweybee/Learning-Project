using Learning_Project.DTO;
using Microsoft.AspNetCore.SignalR;

namespace Learning_Project.API
{
    public class ChatHub : Hub
    {
        [HubMethodName("NotifyAsync")]
        public async Task NotifyAsync(string userName, string messageText)
        {
            var message = new ChatMessage()
            {
                Content = messageText,
                UserName = userName,
                TimeStamp = DateTimeOffset.UtcNow
            };

            await Clients.All.SendAsync("GetNotification", 
                                        message.UserName, 
                                        message.Content, 
                                        message.TimeStamp);
        }
    }
}
