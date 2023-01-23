using DataAccessLayer.Abstract;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.concrete.RepoStories
{
    public class CategoryRepostory : ICategoryDal
    {
        Context c = new Context();    // sınıfı kullanabilmek için türettik
        DbSet<Category> _object;  //category sınıfının dosyasını oluşturduk

        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
          _object.Add(p);
            c.SaveChanges();
        }

        public List<Category> List()
        {
           return _object.ToList();   //ojectten gelen veriyi to list ile listeleyip dönderecek
        }

        public List<Category> Liste(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            throw new NotImplementedException();
        }
    }
}
