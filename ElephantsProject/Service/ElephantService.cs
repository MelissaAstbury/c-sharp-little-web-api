using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

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
        }


        public Elephant AddElephant(Elephant elephant)
        {
            listOfElephants.Add(elephant);
            return elephant;
        }
    }
}
