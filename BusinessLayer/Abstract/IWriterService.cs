using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAddBL(Writer writer);
        Writer GetById(int Id);//Silinecek Id bulma--sonra solidde blok içerisini yazdık
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
