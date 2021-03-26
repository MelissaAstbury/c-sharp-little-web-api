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


        [HttpGet]
        [Route("{id}")]
        public Elephant GetElephantById(string id)
        {
            return _elephantService.GetElephant(id);
        }


        [HttpPost]
        public Elephant AddNewElephant(Elephant elephant)
        {
            return _elephantService.AddElephant(elephant);
        }

    }
}
