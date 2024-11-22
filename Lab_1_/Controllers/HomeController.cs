using Lab_1_.Models;
using Lab_1_.Resources.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Globalization;

namespace Lab_1_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<SharedResources> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture)
        {
            var supportedCultures = new[] { "en", "uk" };
            if (supportedCultures.Contains(culture))
            {
                var requestCulture = new RequestCulture(culture);
                CultureInfo.CurrentCulture = requestCulture.Culture;
                CultureInfo.CurrentUICulture = requestCulture.UICulture;

                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(requestCulture),
                    new CookieOptions { Expires = DateTime.Now.AddYears(1) }
                );
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}