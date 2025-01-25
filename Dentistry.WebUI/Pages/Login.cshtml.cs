using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Dentistry.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Dentistry.WebUI.Pages
{

    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public bool LoginFailed { get; set; }

        public void OnGet()
        {
            // نمایش فرم ورود
        }

        public async Task<IActionResult> OnPostAsync(string ReturnUrl)
        {
            // اینجا می‌توانید چک کنید که اطلاعات ورود صحیح است یا خیر.
            // برای سادگی، فرض می‌کنیم که نام کاربری "admin" و رمز عبور "password" درست است.
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == UserName && u.Password == Password);
            if (user!=null)
            {
                var claims = new[] {
                new Claim(ClaimTypes.Name, user.FullName),
                // سایر Claims به دلخواه
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToPage($"{ReturnUrl}"); // بعد از ورود به صفحه اصلی هدایت می‌شود
            }

            LoginFailed = true;
            return Page(); // اگر اطلاعات غلط بود، مجدداً فرم ورود را نمایش می‌دهد
        }
    }

}
