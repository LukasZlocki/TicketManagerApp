namespace TicketManagerApp.Services
{
    public interface IServerDriveService
    {
        public Task<bool> CreateReportTypeFolderStructure(int ticketId);
        public Task<List<(string FolderPath, string FileName)>> GetListOfFilesInFolder(List<string> foldersPath, string documentCodeNumber);
        public Task SaveFileToFolder(Stream fileStream, string fileName, string targetFolderPath, string DocumentCodeNumber);
        public Task DeleteFileFromFolder(string fileName, string targetFolderPath, string DocumentCodeNumber);
        public string GetServerPathToDatabaseFolder();
    }
}
