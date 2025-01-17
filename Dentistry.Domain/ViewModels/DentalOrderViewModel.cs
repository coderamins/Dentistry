using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Domain.ViewModels
{
    public class DentalOrderViewModel
    {
        public int Id { get; set; }
        public string RequestMessage { get; set; } = string.Empty;
        public int OrderStatusId { get; set; }
        public string OrderStatusDesc { get; set; } = string.Empty;
        public string CreatedDate { get; set; }

        public string PatientNationalId { get; set; } = string.Empty;
        public string PatientFullName { get; set; } = string.Empty;
        public string PatientMobileNo { get; set; } = string.Empty;
        public string PatientAddress { get; set; } = string.Empty;

        public string DentistFullName { get; set; } = string.Empty; // نام دندان‌پزشک
        public string DentistSpecialty { get; set; } = string.Empty; // تخصص دندان‌پزشک (مثل پروتز، ارتودنسی و...)
        public string DentistMobileNo { get; set; } = string.Empty; //شماره موبایل
        public string DentistEmailAddress { get; set; } = string.Empty; //آدرس ایمیل


    }
}
