using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications.Repository
{
    public interface IRepository<T>
    {
        ICollection<T> GetData();
     //   T Get(int id);
     //   void Add(T item);
    //    void Update(T item);
    }
}
