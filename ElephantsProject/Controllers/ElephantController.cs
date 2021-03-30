using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ElephantsProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class ElephantController : ControllerBase
    {
        private IElephantService _elephantService;

        public ElephantController(IElephantService elephantService)
        {
            _elephantService = elephantService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new {
                timestamp = DateTime.UtcNow,
                elephants = await _elephantService.GetAll()
            });
        }


        [HttpGet]
        [Route("greeting")]
        public string Get()
        {
            DateTime timeStamp = DateTime.Now;
            return $"{timeStamp} Hello Elephants";
        }


        [HttpGet]
        [Route("elephant/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _elephantService.Get(id));
        }


        [HttpPost]
        [Route("elephant")]
        public async Task<IActionResult> Post(Elephant elephant)
        {
            return Ok(await _elephantService.Add(elephant));
        }


        [HttpDelete]
        [Route("elephant/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _elephantService.Delete(id));
        }
    }
}
