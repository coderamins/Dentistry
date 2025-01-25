using System.Net;

namespace Dentistry.WebUI.Dtos
{
    public class DentalOrderDto
    {
        public string PatientNationalId{get;set;}=string.Empty;
        public string PatientFullName{get;set;}=string.Empty;
        public string PatientMobileNo{get;set;}=string.Empty;
        public required string DentistName{get;set;}
        public required string DentistMobileNo{get;set;}
        public string Specialty{get;set;}=string.Empty;
        public string Address{get;set;}=string.Empty;
        public required string Description { get; set; } 

    }
}
