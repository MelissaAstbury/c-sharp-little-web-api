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
            //string fileOfElephants = File.ReadAllText("./Elephants.json");
            //var elephants = JsonConvert.DeserializeObject<List<Elephant>>(elephants);
        }

        public async Task<List<Elephant>> GetAll()
        {
            var fileOfElephants = File.ReadAllText("./Elephants.json");
            return await Task.Run(() => JsonConvert.DeserializeObject<List<Elephant>>(fileOfElephants));
        }

        public async Task<Elephant> Get(string id)
        {
            var fileOfElephants = File.ReadAllText("./Elephants.json");
            var elephants = await Task.Run(() => JsonConvert.DeserializeObject<List<Elephant>>(fileOfElephants));
            var result = elephants.FirstOrDefault(e => e.id == id);
            return result;
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
            var elephantToRemove = elephants.FirstOrDefault(e => e.id == id);
            if (elephantToRemove == null)
            {
                return null;
            }
            elephants.Remove(elephantToRemove);
            return elephantToRemove;
        }
    }
}
