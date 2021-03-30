using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ElephantsProject.Repo
{
    public class ElephantRepo : IElephantRepo
    {
        public ElephantRepo()
        {

        }

        public async Task<List<Elephant>> GetAll()
        {
            var elephants = File.ReadAllText("./Elephants.json");
            return await Task.Run(() => JsonConvert.DeserializeObject<List<Elephant>>(elephants));
        }
    }
}
