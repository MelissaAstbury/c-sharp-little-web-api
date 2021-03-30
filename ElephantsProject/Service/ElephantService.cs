using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElephantsProject.Repo;
using Newtonsoft.Json;


namespace ElephantsProject
{
    public class ElephantService : IElephantService
    {
        private IElephantRepo _elephantRepo;

        public ElephantService(IElephantRepo elephantRepo)
        {
            _elephantRepo = elephantRepo;
        }

        public async Task<List<Elephant>> GetAll()
        {
            var result = await _elephantRepo.GetAll();
            return result;
        }

        public async Task<Elephant> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Elephant> Add(Elephant elephant)
        {
            throw new NotImplementedException();
        }

        public async Task<Elephant> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
