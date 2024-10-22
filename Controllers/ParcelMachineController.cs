using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace veebRogovski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelMachineController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ParcelMachineController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetParcelMachines()
        {
            var response = await _httpClient.GetAsync("https://www.omniva.ee/locations.json");
            var responseBody = await response.Content.ReadAsStringAsync();
            return Content(responseBody, "application/json");
        }
    }
}
