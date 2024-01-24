using EX2.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EX2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            Vacation o = new Vacation();
            return  o.Read();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public int Post([FromBody] Vacation order)
        {
            return order.Insert();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //a routing to a method that will return all the orders between start and end dates 

        [HttpGet("getByDates/{startDate}/{endDate}")]
        public IEnumerable<Vacation> getOrdersByDates([FromRoute] DateTime startDate,[FromRoute] DateTime endDate)
        {     
            return Vacation.getOrdersByDates(startDate, endDate);
        }
    }
}
