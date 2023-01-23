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
    public class GenericRepostory<T> : IRepostory<T> where T : class  // bir  Tdeğeri alacaksın . T değeri alırken Tdeğeri alan Irepostory interface'ini kullanacaksın- ben sana şart belirttim T bir class olacak
    {
        Context c = new Context();
        DbSet<T> _object; //T değeri benim gönderecğim sınıf ama hangi sınıfı  gönderdiğimi anlaması için yapıcı metod kullanmam lazım
        public GenericRepostory()//bu yapıcı metod ile hangi sınıfı gönderdiğimizi bilecek
        {
            _object=c.Set<T>();//Context'e bağlı olarak gönderilen T değeri  _object olacak
        }

     

        public void Delete(T p)
        {
            var DeletedEntity = c.Entry(p);//entitystate modülü ile yaptık - dbset yaklaşımı dursun istedik farklılık açısından
            DeletedEntity.State=EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
           return _object.SingleOrDefault(filter);// singleordefault metodu listede veya dizide geriye sadece bulunan bir tane değeri döndürür (Bize Id lazım)
        }

        public void Insert(T p)
        {
            var AddedEntity = c.Entry(p);// ebtitystate metdu ile yaptık
            AddedEntity.State = EntityState.Added;  
           // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> Liste(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();// filterdan gelen değer ne ise onu listele
        }

        public void Update(T p)
        {
            var UpdetedEntity = c.Entry(p);
            UpdetedEntity.State= EntityState.Modified;  
           c.SaveChanges();
        }
    }
}
