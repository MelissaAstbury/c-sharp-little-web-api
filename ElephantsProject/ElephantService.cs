using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ElephantsProject
{
    public class ElephantService : IElephantService
    {
        public List<Elephant> GetElephants()
        {
            string elephants = File.ReadAllText("./Elephants.json");
            List<Elephant> listOfElephants = JsonConvert.DeserializeObject<List<Elephant>>(elephants);

            return listOfElephants;
        }


        public Elephant GetElephant(string id)
        {
            string elephants = File.ReadAllText("./Elephants.json");
            List<Elephant> listOfElephants = JsonConvert.DeserializeObject<List<Elephant>>(elephants);
            //Elephant elephant = (Elephant)listOfElephants.Where(e => e.id == id);

            Elephant elephant = null;
            foreach (Elephant el in listOfElephants)
            {
                if (el.id == id)
                {
                    elephant = el;
                }
            }

            return elephant;
        }
    }
}
