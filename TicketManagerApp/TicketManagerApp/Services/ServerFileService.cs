using TicketManager.Models.Models;
using TicketManagerApp.Data;

namespace TicketManagerApp.Services
{
    public class ServerFileService : IServerFileService
    {
        private readonly ApplicationDbContext _db;

        public ServerFileService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CustomFile> LoadFileByTicketId(string ticketId)
        {
            try
            {
                var customFile = await _db.CustomFiles.FindAsync(ticketId);
                if (customFile == null)
                {
                    // Handle the case where no file is found
                    Console.WriteLine("No file found for the given TicketId.");
                }
                return customFile ?? new CustomFile();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
                return new CustomFile();
            }
        }

        public async Task SaveFileToServer(CustomFile customFile)
        {
            try
            {
                _db.CustomFiles.Add(customFile);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }
        }


    }
}
