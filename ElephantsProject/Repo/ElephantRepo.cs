using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ElephantsProject.Repo
{
    public class ElephantRepo : IElephantRepo
    {
        public ElephantRepo()
        {
            //string elephants = File.ReadAllText("./Elephants.json");
            //var listOfElephants = JsonConvert.DeserializeObject<List<Elephant>>(elephants);
        }

        public async Task<List<Elephant>> GetAll()
        {
            var elephants = File.ReadAllText("./Elephants.json");
            return await Task.Run(() => JsonConvert.DeserializeObject<List<Elephant>>(elephants));
        }

        public async Task<Elephant> Get(string id)
        {
            var fileOfElephants = File.ReadAllText("./Elephants.json");
            var elephants = await Task.Run(() => JsonConvert.DeserializeObject<List<Elephant>>(fileOfElephants));
            return elephants.First(e => e.id == id);
        }

        public async Task<Elephant> Add(Elephant elephant)
        {
            var fileOfElephants = File.ReadAllText("./Elephants.json");
            var elephants = await Task.Run(() => JsonConvert.DeserializeObject<List<Elephant>>(fileOfElephants));
            elephant.id = Guid.NewGuid().ToString();
            elephants.Add(elephant);
            return elephant;
        }

        public async Task<Elephant> Delete(string id)
        {
            var fileOfElephants = File.ReadAllText("./Elephants.json");
            var elephants = await Task.Run(() => JsonConvert.DeserializeObject<List<Elephant>>(fileOfElephants));
            var elephantToRemove = elephants.First(e => e.id == id);
            elephants.Remove(elephantToRemove);
            return elephantToRemove;
        }
    }
}
