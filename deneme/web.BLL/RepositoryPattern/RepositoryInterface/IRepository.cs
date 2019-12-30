using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using web.MODEL.Entities;

namespace web.BLL.RepositoryPattern.RepositoryInterface
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);

        void Delete(T item);

        void Update(T item);

        List<T> SelectAll();

        List<T> Where(Expression<Func<T, bool>> exp);

        T GetByID(int id);

        object ListAnonymus(Expression<Func<T, object>> exp);

        List<T> SelectActives();

        T Default(Expression<Func<T, bool>> exp);

        int GetLastAdded();

        bool Any(Expression<Func<T, bool>> exp);

        List<T> SelectDeleteds();

        List<T> SelectModifieds();

        void SpecialDelete(int id);
    }
}
