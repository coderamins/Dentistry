using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Domain.Entity
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string StatusDesc { get; set; }
    }
}
