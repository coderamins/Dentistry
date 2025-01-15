using System.Net;

namespace Dentistry.WebUI.Dtos
{
    public class DentalOrderDto
    {
        public string PatientNationalId{get;set;}=string.Empty;
        public string PatientFullName{get;set;}=string.Empty;
        public string PatientMobileNo{get;set;}=string.Empty;
        public string DentistName{get;set;}=string.Empty;
        public string DentistMobileNo{get;set;}=string.Empty;
        public string Specialty{get;set;}=string.Empty;
        public string Address{get;set;}=string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
