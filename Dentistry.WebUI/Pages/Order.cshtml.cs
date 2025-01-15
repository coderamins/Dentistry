using Dentistry.Domain.Entity;
using Dentistry.Domain.Enums;
using Dentistry.Infrastructure;
using Dentistry.WebUI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dentistry.WebUI.Pages
{
    public class OrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DentalOrderDto Order { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                DentalOrder dentalOrder = new DentalOrder();

                var checkDentist=_context.Dentists.FirstOrDefault(d=>d.MobileNo.Trim()==Order.DentistMobileNo.Trim());
                if (checkDentist == null)
                {
                    Dentist dentist = new Dentist();

                    //dentist.EmailAddress =Order.Ema
                    dentist.MobileNo = Order.DentistMobileNo;
                    dentist.DentistFullName = Order.DentistName;
                    dentist.Specialty = Order.Specialty;

                    dentalOrder.DentistId=_context.Dentists.Add(dentist).Entity.Id;
                }
                else
                    dentalOrder.DentistId=checkDentist.Id;

                var checkPatient = _context.Patients.FirstOrDefault(d => d.NationalId.Trim() == Order.PatientNationalId.Trim());
                if (checkPatient == null)
                {
                    Patient patient = new Patient();

                    patient.NationalId = Order.PatientNationalId;
                    patient.FullName = Order.PatientFullName;
                    patient.MobileNo = Order.PatientMobileNo;

                    dentalOrder.PatientId = _context.Patients.Add(patient).Entity.Id;
                }
                else
                    dentalOrder.PatientId=checkPatient.Id;


                dentalOrder.RequestMessage = Order.Description;
                dentalOrder.CreatedDate = DateTime.Now;
                dentalOrder.OrderStatusId = (int)EOrderStatus.Pending; 

                _context.DentalOrders.Add(dentalOrder);
                _context.SaveChanges();

                return RedirectToPage("./Order");
            }

            return Page();
        }
    }

}
