using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;

namespace DateLayer
{
    public class AdminRepository
    {
        private BDKillShotEntities _Context;

        public System.ComponentModel.BindingList<AdminSet> List
        {
            get
            {
                return _Context.AdminSet.Local.ToBindingList();

            }
        }

        public AdminRepository(BDKillShotEntities context)
        {
            _Context = context;
        }

        public bool CheckAdmin(string login, string password)
        {
           BindingList<AdminSet>List_Admin =  DateManager.AdminRepository.List;
           
           bool q = false;
           int i = 0;

           while (i < List_Admin.Count && !q)
           {
               if (List_Admin[i].Login == login && List_Admin[i].Password == password)
                   q = true;
               else i++;
           }


           return q;
        }
    }
}
