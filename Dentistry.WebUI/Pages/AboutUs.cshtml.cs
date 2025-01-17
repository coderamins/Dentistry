using Dentistry.Domain.Entity;
using Dentistry.Domain.Enums;
using Dentistry.Infrastructure;
using Dentistry.WebUI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.WebUI.Pages
{
    public class AboutUsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AboutUsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DentalOrderDto Order { get; set; }

        public void OnGet()
        {
        }

        public async void OnPost() {
            if (ModelState.IsValid)
            {
                DentalOrder dentalOrder = new DentalOrder();

                var checkDentist = _context.Dentists.FirstOrDefault(d => d.MobileNo.Trim() == Order.DentistMobileNo.Trim());
                if (checkDentist == null)
                {
                    Dentist dentist = new Dentist();

                    //dentist.EmailAddress =Order.Ema
                    dentist.MobileNo = Order.DentistMobileNo;
                    dentist.DentistFullName = Order.DentistName;
                    dentist.Specialty = Order.Specialty;

                    _context.Dentists.Add(dentist);
                    var newDentist= await _context.Dentists.AddAsync(dentist);
                    dentalOrder.Dentist = newDentist.Entity;
                }
                else
                    dentalOrder.DentistId = checkDentist.Id;

                var checkPatient = _context.Patients.FirstOrDefault(d => d.NationalId.Trim() == Order.PatientNationalId.Trim());
                if (checkPatient == null)
                {
                    Patient patient = new Patient();

                    patient.NationalId = Order.PatientNationalId;
                    patient.FullName = Order.PatientFullName;
                    patient.MobileNo = Order.PatientMobileNo;

                    dentalOrder.Patient = _context.Patients.Add(patient).Entity;
                }
                else
                    dentalOrder.PatientId = checkPatient.Id;


                dentalOrder.RequestMessage = Order.Description;
                dentalOrder.CreatedDate = DateTime.Now;
                dentalOrder.OrderStatusId = (int)EOrderStatus.Pending;

                _context.DentalOrders.Add(dentalOrder);
                _context.SaveChanges();

                //return RedirectToPage("./Order");
            }

            //return Page();

        }
    }
}
