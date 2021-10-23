using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Vejrudsigten.Services;

namespace Vejrudsigten.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task OnGetAsync()
        {
            var key = _configuration["key"];

            var city = "Aarhus";

            if (string.IsNullOrEmpty(key))
            {
                ViewData.Add("Vejrudsigten", "Hov! Du har glemt at angive nøglen i appsettings.local.json. Gå tilbage til opgavebeskrivelsen og se hvordan");
            }
            else if (string.IsNullOrEmpty(city))
            {
                ViewData.Add("By", "Du skal angive en by i Index.cshtml.cs!");
            }
            else
            {
                ViewData.Add("Vejrudsigten", await WeatherForecast.GetForecastAsync(key, city));
                ViewData.Add("By", city);
            }
        }
    }
}
