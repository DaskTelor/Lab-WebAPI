using Lab_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalComputerController : ControllerBase
    {
        private static List<PersonalComputerData> _memCache = new List<PersonalComputerData>();

        [HttpGet]
        public ActionResult<IEnumerable<PersonalComputerData>> Get()
        {
            return _memCache;
        }

        [HttpGet("{id}")]
        public ActionResult<PersonalComputerData> Get(int id)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            return _memCache[id];
        }

        [HttpPost]
        public void Post([FromBody] PersonalComputerData value)
        {
            _memCache.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PersonalComputerData value)
        {
            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _memCache[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            if (_memCache.Count <= id) throw new IndexOutOfRangeException("Нет такого у нас");

            _memCache.RemoveAt(id);
        }
    }

}
