using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public interface IServerDriveService
    {
        public Task<bool> CreateReportTypeFolderStructure(string ticketCodeNumber);
        public Task<List<(string FolderPath, string FileName)>> GetListOfFilesInFolder(List<string> folderPaths, string reportTypeShortDescr, string ticketCodeNumber);
        public Task SaveFileToFolder(Stream fileStream, string fileName, string reportType, string targetFolderPath, string reportNumber);
        public Task DeleteFileFromFolder(string fileName, string reportType, string targetFolderPath, string documentCodeNumber);
        public string GetServerPathToDatabaseFolder();
        public string GetLastTicketNumber(string reportType);
    }
}
