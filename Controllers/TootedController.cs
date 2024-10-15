using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veebRogovski.Models;

namespace veebRogovski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new List<Toode>{
        new Toode(1,"Koola", 1.5, true),
        new Toode(2,"Fanta", 1.0, false),
        new Toode(3,"Sprite", 1.7, true),
        new Toode(4,"Vichy", 2.0, true),
        new Toode(5,"Vitamin well", 2.5, true)
        };


        // api/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }


        // GET api/tooted/kustuta/{index}
        [HttpGet("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }

        // GET api/tooted/kustuta2/{index}
        [HttpGet("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooted.RemoveAt(index);
            return "Kustutatud!";
        }

        // GET api/tooted/lisa/{id}/{nimi}/{hind}/{aktiivne}
        [HttpGet("lisa/{id}/{nimi}/{hind}/{aktiivne}")]
        public List<Toode> Add(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpGet("lisa")]
        // GET api/tooted/lisa?id=1&nimi=Koola&hind=1.5&aktiivne=true
        public List<Toode> Add2([FromQuery] int id, [FromQuery] string nimi, [FromQuery] double hind, [FromQuery] bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpGet("hind-dollaritesse/{kurss}")]
        // GET api/tooted/hind-dollaritesse/1.5
        public List<Toode> Dollaritesse(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }

        // või foreachina:

        [HttpGet("hind-dollaritesse2/{kurss}")]
        // GET api/tooted/hind-dollaritesse2/1.5
        public List<Toode> Dollaritesse2(double kurss)
        {
            foreach (var t in _tooted)
            {
                t.Price = t.Price * kurss;
            }

            return _tooted;
        }

        // Kustutab kõik tooted
        [HttpGet("kustuta-kõik")]
        public List<Toode> DeleteAll()
        {
            _tooted.Clear();
            return _tooted;
        }

        // Muudab kõikide toodete aktiivsuse väära peale
        [HttpGet("aktiivne-vääraks")]
        public List<Toode> SetAllToFalse()
        {
            foreach (var t in _tooted)
            {
                t.IsActive = false;
            }
            return _tooted;
        }

        // Tagastab ühe toote - vastavalt kelle järjekorranumber on lisatud URL muutujasse
        [HttpGet("toode/{index}")]
        public Toode GetToode(int index)
        {
            if (index >= 0 && index < _tooted.Count)
            {
                return _tooted[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Toode ei eksisteeri");
            }
        }

        // Tagastab ühe toote - kõige suurema hinnaga toote
        [HttpGet("kõige-suurem-hind")]
        public Toode GetToodeWithHighestPrice()
        {
            if (_tooted.Count == 0)
            {
                throw new InvalidOperationException("Tooteid ei eksisteeri");
            }
            return _tooted.OrderByDescending(t => t.Price).FirstOrDefault();
        }
    }
}
