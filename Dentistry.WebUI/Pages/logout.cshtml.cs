using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

namespace Dentistry.WebUI.Pages
{
    public class logoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // خروج از سیستم و حذف کوکی‌های احراز هویت
            await HttpContext.SignOutAsync();

            // هدایت به صفحه اصلی یا هر صفحه دلخواه بعد از خروج
            return RedirectToPage("/Index"); // یا هر صفحه‌ای که بخواهید
        }
    }

}
