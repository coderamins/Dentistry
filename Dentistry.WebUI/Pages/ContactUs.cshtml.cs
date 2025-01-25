using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dentistry.WebUI.Pages
{
    public class ContactUsModel : PageModel
    {
        [BindProperty]
        public ContactForm Contact { get; set; }

        public class ContactForm
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Message { get; set; }
        }

        // متد GET
        public void OnGet()
        {
            // می‌توانید اینجا داده اولیه بگذارید
        }

        // متد POST برای پردازش داده‌های فرم
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // در اینجا می‌توانید داده‌ها را ذخیره کرده یا ایمیل ارسال کنید
                // برای مثال:
                // ارسال ایمیل یا ذخیره در پایگاه داده
                // یا نمایش پیغام موفقیت

                TempData["SuccessMessage"] = "پیام شما با موفقیت ارسال شد.";
                return RedirectToPage("/ContactUs"); // هدایت مجدد به صفحه خود برای نمایش پیغام موفقیت
            }

            return Page(); // در صورت خطا، صفحه دوباره بارگذاری می‌شود
        }
    }

}
