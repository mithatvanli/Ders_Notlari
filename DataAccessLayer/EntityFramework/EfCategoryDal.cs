using DataAccessLayer.Abstract;
using DataAccessLayer.concrete.RepoStories;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepostory<Category>,ICategoryDal//concrete katmanındaki somut halde olan GenericRepostory class'ını aldık ve ona Category class'ını gönderdik ve ICategoryDal içerisindeki değerleri de aldırdık
    {

    }
}
