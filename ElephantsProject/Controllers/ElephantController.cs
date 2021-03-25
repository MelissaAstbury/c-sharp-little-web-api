using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ElephantsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ElephantController : ControllerBase
    {
        private IElephantService _elephantService;

        public ElephantController(IElephantService elephantService)
        {
            _elephantService = elephantService;
        }

        
        [HttpGet]
        [Route("greeting")]
        public string Get()
        {
          return "Hello Elephants";
        }


        [HttpGet]
        public List<Elephant> GetAllElephants()
        {
          return _elephantService.GetElephants();
        }
    }
}
