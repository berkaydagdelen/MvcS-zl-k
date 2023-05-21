using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussiensLayer.Abstract
{
    public interface IAdminService
    {
        Admin GetAdmin(string Username);
        Admin GetByID(string Username, string UserPassword);


        List<Admin> GetList();
        void AdminAddBl(Admin admin);
        Admin AdminGetByID(int id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
