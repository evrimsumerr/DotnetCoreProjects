using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly INumGenerator numGenerator;
        public TestController(INumGenerator numGenerator)
        {
            this.numGenerator = numGenerator;
        }

        [HttpGet]
        public string Get()
        {
            int number = numGenerator.GetRandomNumber();
            return number.ToString();
        }
    }
}
