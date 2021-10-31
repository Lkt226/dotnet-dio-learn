using System.Collections.Generic;
namespace CadastroDeSeries.Interfaces
{
    public interface iRepository<T>
    {
        List<T> list();
        T ReturnForId(int id);
        void Insert(T entidade);
        void Update(int id, T entidade);
        void Delete(int id);

        int NextId();
    }
}