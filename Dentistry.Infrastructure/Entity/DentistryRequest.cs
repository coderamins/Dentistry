using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Infrastructure.Entity
{
    public class DentistryRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestMessage { get; set; }

        public virtual Customer Customer { get; set; }
    }

}
