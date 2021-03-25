using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ElephantsProject
{
    public class ElephantService : IElephantService
    {
        public List<Elephant> GetElephants()
        {
            var jsonElephants = File.ReadAllText("./Elephants.json");
            var amendedElephants = JsonConvert.DeserializeObject<List<Elephant>>(jsonElephants);
            return amendedElephants;
        }
    }
}
