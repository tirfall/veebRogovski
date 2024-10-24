using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace veebRogovski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public KasutajaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
