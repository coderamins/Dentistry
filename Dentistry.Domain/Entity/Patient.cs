using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Domain.Entity
{
    public class Patient
    {
        public int Id { get; set; }
        public string NationalId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string PatientAddress { get; set; } = string.Empty;

        public virtual ICollection<DentalOrder> DentalOrders { get; set; }
    }
}
