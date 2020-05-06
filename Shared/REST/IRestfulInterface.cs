using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsWeNeed.Shared.REST
{
    public interface IRestfulInterface<T>
    {
        T Get(int id);

        ICollection<T> GetCollection();

        T Create(T toCreate);

        T Delete(int id);

        T Update(T updated);
    }
}
