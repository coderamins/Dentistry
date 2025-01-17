using AutoMapper;
using Dentistry.Domain.Entity;
using Dentistry.Domain.ViewModels;
using Dentistry.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.WebUI.Pages
{
    public class OrderListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderListModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public string DentistNameFilter { get; set; } // فیلتر نام دندانپزشک

        [BindProperty(SupportsGet = true)]
        public DateTime? StartDateFilter { get; set; } // فیلتر تاریخ شروع

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDateFilter { get; set; } // فیلتر تاریخ پایان

        public List<DentalOrderViewModel> Orders { get; set; }

        public void OnGet()
        {
            var allOrders = _context.DentalOrders
                .Include(o => o.OrderStatus)
                .Include(o => o.Patient)
                .Include(o => o.Dentist);

            var mappedOrders=_mapper.Map<List<DentalOrderViewModel>>(allOrders);

            Orders = mappedOrders;
        }
    }
}
