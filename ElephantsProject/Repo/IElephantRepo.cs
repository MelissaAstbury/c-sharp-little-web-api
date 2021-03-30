using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElephantsProject.Repo
{
    public interface IElephantRepo
    {
        Task<List<Elephant>> GetAll();

        Task<Elephant> Get(string id);

        Task<Elephant> Add(Elephant elephant);

        Task<Elephant> Delete(string id);
    }
}
