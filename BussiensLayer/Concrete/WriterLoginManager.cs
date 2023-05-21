using BussiensLayer.Abstract;
using DataAccessLAyer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussiensLayer.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerDal.Get(p => p.WriterMail == username && p.WriterPassword == password);
        }
    }
}
