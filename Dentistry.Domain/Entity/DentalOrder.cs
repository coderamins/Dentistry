using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Domain.Entity
{
    public class DentalOrder
    {
        [Key]
        public int Id { get; set; }
        public int DentistId { get; set; }
        public int PatientId { get; set; }
        public string RequestMessage { get; set; } = string.Empty;
        public int OrderStatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Dentist Dentist { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }

}
