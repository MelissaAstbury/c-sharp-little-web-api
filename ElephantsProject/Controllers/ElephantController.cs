using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using System.Web.HttpException;
//using Microsoft.EntityFrameworkCore;

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
            DateTime timeStamp = DateTime.Now;
            return timeStamp  + " Hello Elephants";
        }


        [HttpGet]
        public List<Elephant> GetAllElephants()
        {
          return _elephantService.GetElephants();
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Elephant> GetElephantById(string id)
        {
            if (id == "1")
            {
                return NotFound();
            }
            try
            {
               return Ok(_elephantService.GetElephant(id));
            }
            catch(Exception e)
            {
                //if (elephant == null)
                //{
                    //throw new HttpException(404, "Elephant not found");
                    return null;
                //} 
            }
        }


        [HttpPost]
        public Elephant AddNewElephant(Elephant elephant)
        {
            return _elephantService.AddElephant(elephant);
        }


        [HttpDelete]
        [Route("{id}")]
        public Elephant DeleteElephantById(string id)
        {
            return _elephantService.DeleteElephant(id);
        }
    }
}
