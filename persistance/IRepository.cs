using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistance
{
    interface IRepository<E,ID>
    {
        long size();
        void save(E entity);
        void delete(ID id);
        void update(ID id, E entity);
        E findOne(ID id);
        IEnumerable<E> findAll();
    }
    interface IRepositoryLog<E,ID> : IRepository<E,ID>
    {
        int login(String user, String pass);
    }
}
