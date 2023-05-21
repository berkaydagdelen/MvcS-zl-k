using BussiensLayer.Abstract;
using DataAccessLAyer.Abstract;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussiensLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(p => p.MessageID == id);
        }


        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> GetListInbox(string UserName)
        {
            
            return _messageDal.List(p => p.ReceiverMail == UserName);
        }

        public List<Message> GetListSendInbox(string UserName)
        {
            return _messageDal.List(p => p.SenderMail == UserName);
        }
    }
}
