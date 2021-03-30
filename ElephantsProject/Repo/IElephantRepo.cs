using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElephantsProject.Repo
{
    public interface IElephantRepo
    {
        Task<List<Elephant>> GetAll();
    }
}
