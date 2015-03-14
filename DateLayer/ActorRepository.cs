using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;

namespace DateLayer
{
   public class ActorRepository
    {
       private BDKillShotEntities _Context;

        public System.ComponentModel.BindingList<ActorSet> List
        {
            get
            {
                return _Context.ActorSet.Local.ToBindingList();

            }
        }

        public ActorRepository(BDKillShotEntities context)
        {
            _Context = context;
        }

        public void AddActor(string login, string password,int id_admin)
        {
            ActorSet actor = new ActorSet() { Login = login, Passowrd = password , Admin_Id_admin = id_admin};
            _Context.ActorSet.Add(actor);
            _Context.SaveChanges();
        }

        public void AppActor(int id_actor,string login, string password)
        {            
            var actor = _Context.ActorSet.Find(new object[] { id_actor });
            actor.Login = login;
            actor.Passowrd = password;

            _Context.SaveChanges();
        }

        public void DeleteActor(int id_actor)
        {
            var actor = _Context.ActorSet.Find(new object[] { id_actor });
            _Context.ActorSet.Remove(actor);
            _Context.SaveChanges();
        }

        public bool CheckActor(string login, string password)
        {
            BindingList<ActorSet> List_Actor = DateManager.ActorRepository.List;

            bool q = false;
            int i = 0;

            while (i < List_Actor.Count && !q)
            {
                if (List_Actor[i].Login == login && List_Actor[i].Passowrd == password)
                    q = true;
                else i++;
            }

            return q;
        }

        public bool CheckActor(string login)
        {
            BindingList<ActorSet> List_Actor = DateManager.ActorRepository.List;

            bool q = false;
            int i = 0;

            while (i < List_Actor.Count && !q)
            {
                if (List_Actor[i].Login == login )
                    q = true;
                else i++;
            }

            return q;
        }


    }
}
