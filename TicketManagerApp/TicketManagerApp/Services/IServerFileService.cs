using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IServerFileService
    {
        public Task SaveFileToServer(CustomFile customFile);
        public Task<CustomFile> LoadFileByTicketId(string ticketId);
    }
}
