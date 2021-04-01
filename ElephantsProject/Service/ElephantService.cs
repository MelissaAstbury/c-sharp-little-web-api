using System.Collections.Generic;
using System.Threading.Tasks;
using ElephantsProject.Repo;


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
            return await _elephantRepo.GetAll();
        }

        public async Task<Elephant> Get(string id)
        {
            return await _elephantRepo.Get(id);
        }

        public async Task<Elephant> Add(Elephant elephant)
        {
            return await _elephantRepo.Add(elephant);
        }

        public async Task<Elephant> Delete(string id)
        {
            return await _elephantRepo.Delete(id);
        }
    }
}
