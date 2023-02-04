using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            writerDal.Add(writer);
        }
    }
}
