using System.IO;
using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public class ServerDriveService : IServerDriveService
    {
        private string _serverPathToDatabase = @"\\plbie01fi02\appl\Application_TicketManager\";

        private readonly IReportTypeService _reportTypeService;
        private readonly IReportStructureService _reportStructureService;
        private readonly ILogger<ServerDriveService> _logger;

        public ServerDriveService(IReportTypeService reportTypeService, IReportStructureService reportStructureService, ILogger<ServerDriveService> logger)
        {
            _reportTypeService = reportTypeService;
            _reportStructureService = reportStructureService;
            _logger = logger;
        }

        /// <summary>
        /// Create report folder structure base on ticker report type
        /// </summary>
        /// <param name="ticketCodeNumber">Code number of ticket ex MER12345</param>
        /// <returns>Bolean true if creation of folder structure done correctly</returns>
        public async Task<bool> CreateReportTypeFolderStructure(string ticketCodeNumber)
        {
            var separatedTicketCodeNumber = SeparateTicketCodeNumber(ticketCodeNumber);

            // Create  path to database type location where document need to be stored
            string _reportTypeFolder = separatedTicketCodeNumber.reportPrefix;

            // Create main report folder with name {Report identyfication code}
            string? mainFolderName = ticketCodeNumber;

            // Create final string path {server path + report type short + report identification code}
            string? mainPathToReportFolder = _serverPathToDatabase + _reportTypeFolder + @"\" + mainFolderName;

            // Create main folder with name of ticketCodeNumber
            try
            {
                if (!Directory.Exists(mainPathToReportFolder))
                {
                    Directory.CreateDirectory(mainPathToReportFolder);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating main directory for ticket code number : {ticketCodeNumber}", ticketCodeNumber);
                return false;
            }

            // Retrive subfolders structure
            int reportTypeId = await _reportTypeService.GetReportTypeIdByReportTypeShortDescription(separatedTicketCodeNumber.reportPrefix);
            var subFoldersStructure = await _reportStructureService.GetReportFoldersStructureByReportTypeId(reportTypeId);

            // Create subfolders of report according to retrives subfolder structure
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
                _logger.LogError(ex, "Error creating subdirectories for ticket {ticketCodeNumber}", ticketCodeNumber);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get list of files in specific folder
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>List<string> of files</string></returns>
        public async Task<List<(string FolderPath, string FileName)>> GetListOfFilesInFolder(List<string> folderPaths, string reportTypeShortDescr, string ticketCodeNumber)
        {
            var files = new List<(string folderPath, string fileName)>();

            foreach (var folderPath in folderPaths)
            {
                var _fullFolderPath = _serverPathToDatabase + reportTypeShortDescr + @"\" + ticketCodeNumber + @"\" + folderPath;
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
        public async Task SaveFileToFolder(Stream fileStream, string fileName, string reportType, string targetFolderPath, string reportNumber)
        {
            //var filePath = Path.Combine(_serverPathToDatabase, targetFolderPath, fileName);
            var filePath = _serverPathToDatabase + reportType + @"\" + reportNumber + @"\" + targetFolderPath + @"\" + fileName;
            using (var fileStreamCopy = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fileStreamCopy);
            }
        }

        public string GetServerPathToDatabaseFolder()
        {
            return this._serverPathToDatabase;
        }

        public async Task DeleteFileFromFolder(string fileName, string reportType, string targetFolderPath, string documentCodeNumber)
        {
            var filePath = _serverPathToDatabase + reportType + @"\" + documentCodeNumber + @"\" + targetFolderPath + @"\" + fileName;

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

        /// <summary>
        /// Retrive last ticket report number from folder were sertain report types are stored.
        /// </summary>
        /// <param name="reportType">Type of report</param>
        /// <returns>String as name of ticket report code number</returns>
        public string GetLastTicketNumber(string reportType)
        {
            string lastTicketNumber;
            List<string> subfolders = new List<string>();

            // Assembly final path to folder with proper reports
            string pathToFinalFolderWithSubfolders = _serverPathToDatabase + @"//" + reportType;

            // REtrive list of subfolders. The subfolders are reports(tickets) code numbers
            if (Directory.Exists(pathToFinalFolderWithSubfolders))
            {
                string[] directories = Directory.GetDirectories(pathToFinalFolderWithSubfolders);
                foreach (string directory in directories)
                {
                    subfolders.Add(directory);
                }
            }
            if (subfolders == null || subfolders.Count == 0)
            {
                return null;
            }

            // Sort the list of subfolders
            subfolders.Sort();
            // Get last subfolder name. It is last ticket report number
            lastTicketNumber = subfolders.Last();

            return lastTicketNumber;
        }

        /// <summary>
        /// Separate ticket code number to format XXX / 00000 
        /// </summary>
        /// <param name="ticketCodeNumber">Ticket Code number to separate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private (string reportPrefix, string reportNumber) SeparateTicketCodeNumber(string ticketCodeNumber)
        {
            if (string.IsNullOrEmpty(ticketCodeNumber) || ticketCodeNumber.Length < 3)
            {
                throw new ArgumentException("Invalid ticket code.");
            }

            string prefix = ticketCodeNumber.Substring(0, 3);
            string number = ticketCodeNumber.Substring(3);

            return (prefix, number);
        }
    }
}