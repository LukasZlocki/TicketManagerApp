﻿using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public class ServerDriveService : IServerDriveService
    {
        private string _serverPathToDatabase = @"C:\\VirtualServer\Tickets\";

        private readonly IReportTypeService _reportTypeService;
        private readonly ITicketService _ticketService;
        private readonly IReportStructureService _reportStructureService;

        public ServerDriveService(IReportTypeService reportTypeService, ITicketService ticketService, IReportStructureService reportStructureService)
        {
            _reportTypeService = reportTypeService;
            _ticketService = ticketService;
            _reportStructureService = reportStructureService;
        }

        public async Task<bool> CreateReportTypeFolderStructure(int ticketId)
        {
            // Retrieve ticket from server
            Ticket ticket = await _ticketService.GetTicketDetails(ticketId);

            // Create main report folder with name {ReportTypeDescription+TicketId}
            string? mainFolderName = ticket.ReportType.ReportShortType + ticketId;
            string? mainPathToReportFolder = _serverPathToDatabase + mainFolderName;

            try
            {
                if (!Directory.Exists(mainPathToReportFolder))
                {
                    Directory.CreateDirectory(mainPathToReportFolder);
                }
            }
            catch (Exception ex)
            {
                // ToDo : Print exception here ...
                return false;
            }

            // Create subfolders according to report structure
            int reportTypeId = ticket.ReportType.ReportTypeId;
            var subFoldersStructure = await _reportStructureService.GetReportFoldersStructureByReportTypeId(reportTypeId);

            try
            {
                foreach (var subFolder in subFoldersStructure)
                {
                    string subFolderPath = Path.Combine(mainPathToReportFolder, subFolder);
                    if (!Directory.Exists(subFolderPath))
                    {
                        Directory.CreateDirectory(subFolderPath);
                    }
                }
            }
            catch (Exception ex)
            {
                // ToDo : Print exception here ...
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get list of files in specific folder
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>List<string> of files</string></returns>
        public async Task<List<(string FolderPath, string FileName)>> GetListOfFilesInFolder(List<string> folderPaths, string ticketCodeNumber)
        {
            var files = new List<(string folderPath, string fileName)>();

            foreach (var folderPath in folderPaths)
            {
                var _fullFolderPath = _serverPathToDatabase + ticketCodeNumber + @"\" + folderPath;
                try
                {
                    if (Directory.Exists(_fullFolderPath))
                    {
                        var fileEntries = Directory.GetFiles(_fullFolderPath);
                        foreach (var filePath in fileEntries)
                        {
                            string fileName = Path.GetFileName(filePath);
                            files.Add((folderPath, fileName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ToDo : Print exception here ...
                }
            }
            return files;
        }

        /// <summary>
        /// Saving file to target folder at server 
        /// </summary>
        /// <param name="fileStream">file data</param>
        /// <param name="fileName">file name</param>
        /// <param name="targetFolderPath">target path/folder to save file</param>
        /// <returns></returns>
        public async Task SaveFileToFolder(Stream fileStream, string fileName, string targetFolderPath, string reportNumber)
        {
            //var filePath = Path.Combine(_serverPathToDatabase, targetFolderPath, fileName);
            var filePath = _serverPathToDatabase + reportNumber + @"\" + targetFolderPath + @"\" + fileName;
            using (var fileStreamCopy = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fileStreamCopy);
            }
        }

        public string GetServerPathToDatabaseFolder()
        {
            return this._serverPathToDatabase;
        }

        public async Task DeleteFileFromFolder(string fileName, string targetFolderPath, string documentCodeNumber)
        {
            var filePath = _serverPathToDatabase + documentCodeNumber + @"\" + targetFolderPath + @"\" + fileName;

            // Check if the file exists
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"{fileName} has been deleted.");
            }
            else
            {
                Console.WriteLine($"{fileName} does not exist in the specified folder.");
            }
        }
    }
}
