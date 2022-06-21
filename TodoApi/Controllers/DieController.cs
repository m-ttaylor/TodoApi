using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    
    [ApiController]
    public class DieController : ControllerBase
    {
        // GET: api/Die
        [Route("api/[controller]")]
        [HttpGet]
        public int GetDie()
        {

            Random random = new Random();
            return random.Next(6);

        }

        // GET: api/Die/5
        [Route("api/[controller]")]
        [HttpGet("{sides}")]
        public ActionResult<int> GetXSidedDie(int sides)
        {
            if (sides > 20)
            {
                return BadRequest();
            }

            Random random = new Random();
            return random.Next(sides);

        }

        [Route("api/diealways3")]
        [HttpGet]
        public int GetRiggedDie()
        {
            return 3;
        }
    }
}
