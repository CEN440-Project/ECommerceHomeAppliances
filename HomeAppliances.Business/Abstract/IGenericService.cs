using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppliances.Business.Abstract
{
    public interface IGenericService<T>
    {
        T TGetById(int id);
        List<T> TGetAll();
        void TCreate(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
    }
}
