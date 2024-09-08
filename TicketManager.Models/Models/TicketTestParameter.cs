using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class TicketTestParameter
    {
        [Key]
        public int TicketTestParameterId { get; set; }
        public double ParameterValue { get; set; }

        public int TestParameterId { get; set; }
        public TestParameter? TestParameter { get; set; }

        public int TicketTestId { get; set; }
    }
}
