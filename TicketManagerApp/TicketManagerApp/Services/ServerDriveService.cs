using TicketManager.Models.Models;

namespace TicketManagerApp.Services
{
    public class ServerDriveService
    {
        private string _serverPathToDatabas = @"C:\VirtualServer\Tickets";

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
            string? mainPathToReportFolder = _serverPathToDatabas + @"\" + mainFolderName;

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
            var subFoldersStructure = await _reportStructureService.GetReportStructureByReportTypeId(reportTypeId);

            try
            {
                foreach (var subFolder in subFoldersStructure)
                {
                    string subFolderPath = Path.Combine(mainPathToReportFolder, subFolder.FolderDescription);
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
    }
}
