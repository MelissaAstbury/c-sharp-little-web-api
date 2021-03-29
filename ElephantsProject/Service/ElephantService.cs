using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
//using System.Web.HttpException;


namespace ElephantsProject
{
    public class ElephantService : IElephantService
    {
        public ElephantService()
        {
            string elephants = File.ReadAllText("./Elephants.json");
            listOfElephants = JsonConvert.DeserializeObject<List<Elephant>>(elephants);
        }

        List<Elephant> listOfElephants;

        public List<Elephant> GetElephants()
        {
            return listOfElephants;
        }


        public Elephant GetElephant(string id)
        {
            Elephant elephant = listOfElephants.First(e => e.id == id);
            
            return elephant;

            //throw new HttpException(404, "Elephant not found", e);
            //return new StatusCodesResponse() { elephant = elephant, StatusCode = 404 };
            //return new StatusCodesResponse() { StatusCode = 404 };
            //return HttpContext.Current.Response.StatusCode = 404;
            //return null;

        }


        public Elephant AddElephant(Elephant elephant)
        {
            listOfElephants.Add(elephant);
            return elephant;
        }


        public Elephant DeleteElephant(string id)
        {
            Elephant elephantToRemove = listOfElephants.First(e => e.id == id);
            listOfElephants.Remove(elephantToRemove);
            return elephantToRemove;

        }
    }
}
