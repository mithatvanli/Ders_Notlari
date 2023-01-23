using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepostory<T>//buraya bir Tdeğeri gönderdik 1. adım  Bu yapının adı Generic Yapı
    {
        List<T> List();//T değeri biz ne gönderiyorsak o
        void Insert(T p);//T'Den gelen p değerini alacağız
        void Update(T p);
        T Get(Expression<Func<T, bool>>filter);// silinecek değeri filtreleme ile bulduruyoruz sonra silme işlemi yapıyoruz
        void Delete(T p);
        List<T> Liste(Expression<Func<T,bool>> filter);// filtreleme yapar , benim istediğim değeri getirir ,bu değerleri t aracılığı ile göndeririz
        
    }
}
