namespace TicketManager.Models.Models
{
    public class CustomFile
    {
        public int CustomFileId { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileContent { get; set; }
        public string? ContentType { get; set; }

        public int TicketId { get; set; } // Foreign key to the related ticket.
    }
}
