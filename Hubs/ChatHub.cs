using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace SignalRChat.Hubs
{
  public class ChatHub : Hub
  {
    private ILogger logger;

    public ChatHub(ILoggerFactory factory)
    {
      this.logger = factory.CreateLogger("ChatHub");
    }
    public async Task SendMessage(string user, string message)
    {
      logger.LogInformation(user);
      logger.LogInformation(message);
      await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
  }
}