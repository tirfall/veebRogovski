using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace veebRogovski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {
        // GET: api/primitiivid/hello-world
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: api/primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }

        // GET: api/primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }

        // GET: api/primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }

        // GET: api/primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }

        // GET: api/Primitiivid/random/{min}/{max}
        [HttpGet("random/{min}/{max}")]
        public int RandomNumber(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        // GET: api/Primitiivid/age/{birthYear}/{birthMonth}/{birthDay}
        [HttpGet("age/{birthYear}/{birthMonth}/{birthDay}")]
        public string CalculateAge(int birthYear, int birthMonth, int birthDay)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);

            DateTime thisYearBirthday = new DateTime(currentYear, birthMonth, birthDay);


            bool hasHadBirthdayThisYear = DateTime.Now >= thisYearBirthday;

            if (hasHadBirthdayThisYear)
            {
                return $"You are {age} years old.";
            }
            else
            {
                return $"You are {age - 1} years old.";
            }
        }

    }
}
