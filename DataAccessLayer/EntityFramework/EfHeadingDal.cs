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
    public class EfHeadingDal : GenericRepostory<Heading>, IHeadingDal 
    {
    
    }
    
}
