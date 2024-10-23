namespace TicketManagerApp.Services
{
    public interface IServerDriveService
    {
        public Task<bool> CreateReportTypeFolderStructure(int ticketId);
    }
}
