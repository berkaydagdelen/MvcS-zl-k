using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussiensLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string usermail);
        List<Message> GetListSendInbox(string usermail);
        Message GetByID(int id);
        void MessageUpdate(Message message);
        void MessageAdd(Message message);
        void MessageDelete(Message message);

    }
}
