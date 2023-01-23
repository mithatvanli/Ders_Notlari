using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.concrete.RepoStories;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.concrete
{
    public class CategoryManager : ICategoryService// ctrl ve. tuşuna bas generate constructor
    {
        ICategoryDal _categoryDal;//tanımladık ama değer ataması yapmamız gerek bunun için yapıcı metod kullanacağız  --dependency injection--

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);// ıcategory service  interface den gönderdiğimiz değer olan object i eklettik
        }

        public void CategoryDelete(Category category)
        {
           _categoryDal.Delete(category);   
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int Id)
        {
            return _categoryDal.Get(x => x.Id == Id);//Mavi olan Id değeri IcategoryService de tanımladığımız
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();//DAL klasöründeki metodların tanımlandığı IRepostory inteface'ini yine o klasörlerde tanımlanan bütün tabloların interface leri kalıtım olarak aldılar. sonra bunları somut hale geetirmek için yani canlandırmak için concrete kolasöründeki GenericRepostory class'ına kalıtım aldırtarak metodları açtık ve kodlarını yazdık. Bunları dbset ler halinde tanımladık fakat dbset hangi classın geleceğini tanımayacağından ona gelecek olan class ı yapıcı metod aracılığı ile tanıttık
        }
    }
}
