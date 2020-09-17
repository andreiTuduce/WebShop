using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        [HttpGet("[action]")]
        public string Get()
        {
            return "Testing Get";
        }

        [HttpGet("[action]")]
        public List<string> GetList(int id)
        {
            return new List<string>
            {
                "Data",
                "Das12"
            };
        }

    }
}
