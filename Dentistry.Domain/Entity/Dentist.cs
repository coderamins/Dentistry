using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Domain.Entity
{
    public class Dentist
    {
        [Key]
        public int Id { get; set; } // شناسه یکتا برای دندان‌پزشک
        public string DentistFullName { get; set; } = string.Empty; // نام دندان‌پزشک
        public string Specialty { get; set; } = string.Empty; // تخصص دندان‌پزشک (مثل پروتز، ارتودنسی و...)
        public string MobileNo { get; set; } = string.Empty; //شماره موبایل
        public string EmailAddress { get; set; } = string.Empty; //آدرس ایمیل

        public virtual ICollection<DentalOrder> DentalOrders { get; set; }
    }
}
