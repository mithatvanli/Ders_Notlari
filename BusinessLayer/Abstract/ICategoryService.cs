using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAddBL(Category category);
        Category GetById(int Id);//Silinecek Id bulma--sonra solidde blok içerisini yazdık
        void CategoryDelete(Category category);//sen Category bir category parametresi alacaksın
        void CategoryUpdate(Category category);
    }
}
