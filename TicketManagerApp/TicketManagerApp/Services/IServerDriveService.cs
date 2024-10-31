namespace TicketManagerApp.Services
{
    public interface IServerDriveService
    {
        public Task<bool> CreateReportTypeFolderStructure(int ticketId);
        public Task<List<(string FolderPath, string FileName)>> GetListOfFilesInFolder(List<string> foldersPath, string documentCodeNumber);
    }
}
