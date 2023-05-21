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
    public class AdminManager : IAdminService
    {
        IAdminsDal _adminsDal;

        public AdminManager(IAdminsDal adminsDal)
        {
            _adminsDal = adminsDal;
        }

        public void AdminAddBl(Admin admin)
        {
            _adminsDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminsDal.Delete(admin);
        }

        public Admin AdminGetByID(int id)
        {
            return _adminsDal.Get(p => p.AdminID == id);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminsDal.Update(admin);
        }

        public Admin GetAdmin(string Username)
        {
            return _adminsDal.Get(p => p.AdminUserName == Username);
        }
        public Admin GetByID(string Username, string UserPassword)
        {
            return _adminsDal.Get(p => p.AdminUserName == Username && p.AdminPassword == UserPassword);
        }

        public List<Admin> GetList()
        {
            return _adminsDal.List();


        }
    }
}
