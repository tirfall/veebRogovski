using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veebRogovski.Models;

namespace veebRogovski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);

        // GET: api/toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }

        // GET: api/toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = _toode.Price + 1;
            return _toode;
        }

        // GET: api/toode/muuda-aktiivsust
        [HttpGet("muuda-aktiivsust")]
        public Toode MuudaAktiivsust()
        {
            _toode.IsActive = !_toode.IsActive;
            return _toode;
        }

        // GET: api/toode/muuda-nimi/{nimi}
        [HttpGet("muuda-nimi/{nimi}")]
        public Toode MuudaNimi(string nimi)
        {
            _toode.Name = nimi;
            return _toode;
        }

        // GET: api/toode/muuda-hinda/{kordaja}
        [HttpGet("muuda-hinda/{kordaja}")]
        public Toode MuudaHinda(double kordaja)
        {
            _toode.Price *= kordaja;
            return _toode;
        }
    }
}
