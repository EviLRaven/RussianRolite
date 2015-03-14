using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DateLayer
{
    public static class DateManager
    {
        private static ScoresRepository _scoresRepository;
        private static AdminRepository _adminRepository;
        private static ActorRepository _actorRepository;
        private static BDKillShotEntities _Context;
        static DateManager()
        {
            _Context = new BDKillShotEntities();
            _Context.ActorSet.Load();
            _Context.ScoreSet.Load();
            _Context.AdminSet.Load();
        }
        public static ScoresRepository ScoresRepository
        {
            get
            {
                if (_scoresRepository == null)
                {
                    _scoresRepository = new ScoresRepository(_Context);
                }
                return _scoresRepository;
            }
        }

        public static ActorRepository ActorRepository
        {
            get
            {
                if (_actorRepository == null)
                {
                    _actorRepository = new ActorRepository(_Context);
                }
                return _actorRepository;
            }
        }

        public static AdminRepository AdminRepository
        {
            get
            {
                if (_adminRepository == null)
                {
                    _adminRepository = new AdminRepository(_Context);
                }
                return _adminRepository;
            }
        }

    }

	}
