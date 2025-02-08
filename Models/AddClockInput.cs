using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class AddClockInput
    {
        public string? DetailNo { get; set; }

        public SaleInfo SaleInfo { get; set; }

        public int Number { get; set; } = 1;
        public long ArtificerId { get; set; }

        public long ProjectId { get; set; }
    }
}
