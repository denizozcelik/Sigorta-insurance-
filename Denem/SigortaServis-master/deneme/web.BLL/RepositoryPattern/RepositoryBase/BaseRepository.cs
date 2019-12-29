using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using web.BLL.RepositoryPattern.RepositoryInterface;
using web.BLL.SingletonPattern;
using web.DAL.Context;
using web.MODEL.Entities;


namespace web.BLL.RepositoryPattern.RepositoryBase
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MyDBContext db;

        public BaseRepository()
        {
            db = DBTool.DBInstance;
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbValEx)
            {
                var outputLines = new StringBuilder();
                foreach (var eve in dbValEx.EntityValidationErrors)
                {
                    outputLines.AppendFormat("{0}: Entity of type '{ 1}' in state '{ 2}' has the following validation errors:"
                      , DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendFormat("- Property: '{ 0}', Error: '{ 1}'"
                         , ve.PropertyName, ve.ErrorMessage);
                    }
                }

                //Tools.Notify(this, outputLines.ToString(),"error");
                throw new DbEntityValidationException(string.Format("Validation errorsrn{0}", outputLines.ToString()), dbValEx);
            }
            
        }


        public void Add(T item)
        {
            
            try
            {
                db.Set<T>().Add(item);
                //Save();
            }
            catch (DbEntityValidationException dbValEx)
            {
                var outputLines = new StringBuilder();
                foreach (var eve in dbValEx.EntityValidationErrors)
                {
                    outputLines.AppendFormat("{0}: Entity of type '{ 1}' in state '{ 2}' has the following validation errors:"
                      , DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendFormat("- Property: '{ 0}', Error: '{ 1}'"
                         , ve.PropertyName, ve.ErrorMessage);
                    }
                }

                //Tools.Notify(this, outputLines.ToString(),"error");
                throw new DbEntityValidationException(string.Format("Validation errorsrn{0}", outputLines.ToString()), dbValEx);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public T Default(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public void Delete(T item)
        {
            item.Status = MODEL.Enums.DataStatus.Deleted;
            //Save();
        }

        public T GetByID(int id)
        {
            return db.Set<T>().Find(id);
        }

        public int GetLastAdded()
        {
            return db.Set<T>().OrderByDescending(x => x.ID).FirstOrDefault().ID;
        }

        public object ListAnonymus(Expression<Func<T, object>> exp)
        {
            return db.Set<T>().Select(exp).ToList();
        }

        public List<T> SelectActives()
        {
            return db.Set<T>().Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> SelectAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> SelectDeleteds()
        {
            return db.Set<T>().Where(x => x.Status == MODEL.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> SelectModifieds()
        {
            return db.Set<T>().Where(x => x.Status == MODEL.Enums.DataStatus.Updated).ToList();
        }

        public void SpecialDelete(int id)
        {
            db.Set<T>().Remove(GetByID(id));
            Save();
        }

        public void Update(T item)
        {
            item.Status = MODEL.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T toBeUpdated = GetByID(item.ID);

            db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            //Save();
        }
    }
}
