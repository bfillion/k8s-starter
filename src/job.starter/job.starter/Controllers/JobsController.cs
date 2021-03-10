using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace job.starter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : Controller
    {
        readonly IConfiguration _configuration;
        readonly IJob _job;

        public JobsController(IConfiguration configuration, IJob job)
        {
            _configuration = configuration;
            _job = job;
        }

        // POST jobs
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _job.StartAsync(value);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] string value)
        {
            using (StreamReader reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();

                foreach (var item in HttpContext.Request.Headers)
                {
                    Console.WriteLine($"Header : {item.Key} | value : {item.Value}");
                }

                Console.WriteLine($"Body : {body}");
            }

            return Ok();
        }
    }
}
