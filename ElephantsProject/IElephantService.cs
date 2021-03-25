using System.Collections.Generic;

namespace ElephantsProject
{
    public interface IElephantService
    {
        List<Elephant> GetElephants();

        //Elephant GetElephant(Guid id);

        //Elephant AddElephent();

        //Elephant DeleteElephant(Guid id);
    }
}
