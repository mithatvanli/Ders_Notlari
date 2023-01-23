using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this._writerDal = writerDal;
        }

        public Writer GetById(int Id)
        {
            return _writerDal.Get(x => x.Id==Id);
        }      

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAddBL(Writer writer)
        {
            _writerDal.Insert(writer);
        }       

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }

       
    }
}
