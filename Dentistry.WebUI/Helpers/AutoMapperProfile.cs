using AutoMapper;
using Dentistry.Domain.Entity;
using Dentistry.Domain.ViewModels;
using System.Globalization;

namespace Dentistry.WebUI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // تبدیل مدل‌های DentalOrder به DentalOrderViewModel
            CreateMap<DentalOrder, DentalOrderViewModel>()
                .ForMember(d => d.DentistEmailAddress, opt => opt.MapFrom(s => s.Dentist.EmailAddress))
                .ForMember(d => d.DentistFullName, opt => opt.MapFrom(s => s.Dentist.DentistFullName))
                .ForMember(d => d.DentistMobileNo, opt => opt.MapFrom(s => s.Dentist.MobileNo))
                .ForMember(d => d.DentistSpecialty, opt => opt.MapFrom(s => s.Dentist.Specialty))

                .ForMember(d => d.PatientMobileNo, opt => opt.MapFrom(s => s.Patient.MobileNo))
                .ForMember(d => d.PatientFullName, opt => opt.MapFrom(s => s.Patient.FullName))
                .ForMember(d => d.PatientAddress, opt => opt.MapFrom(s => s.Patient.PatientAddress))
                .ForMember(d => d.PatientNationalId, opt => opt.MapFrom(s => s.Patient.NationalId))
                
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => ConvertToShamsi(src.CreatedDate))); // تاریخ را به فرمت رشته تبدیل می‌کنیم
        }

        public static string ConvertToShamsi(DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            int year = persianCalendar.GetYear(date);
            int month = persianCalendar.GetMonth(date);
            int day = persianCalendar.GetDayOfMonth(date);

            return $"{year}/{month:00}/{day:00}"; // فرمت تاریخ شمسی
        }
    }

}
