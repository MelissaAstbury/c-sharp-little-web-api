using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElephantsProject
{
    public interface IElephantService
    {
        Task<List<Elephant>> GetAll();

        Task<Elephant> Get(string id);

        Task<Elephant> Add(Elephant elephant);

        Task<Elephant> Delete(string id);
    }
}
