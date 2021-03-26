using System.Collections.Generic;

namespace ElephantsProject
{
    public interface IElephantService
    {
        List<Elephant> GetElephants();

        Elephant GetElephant(string id);

        //Elephant AddElephent(Elephant elephant);

        //Elephant DeleteElephant(Guid id);
    }
}
