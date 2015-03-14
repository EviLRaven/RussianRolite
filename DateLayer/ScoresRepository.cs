using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DateLayer
{
    public class ScoresRepository
    {
        private BDKillShotEntities _Context;

        public List<ScoreSet> List
        {
            get
            {
                return _Context.ScoreSet.OrderByDescending(x => x.Points).ToList();

            }
        }

        public ScoresRepository(BDKillShotEntities context)
        {
            _Context = context;
        }



        public void AddScores(string name, int point, int id_admin)
        {
            ScoreSet scores = new ScoreSet()
            {
                Name = name,
                Points = point,
                Admin_Id_admin = id_admin
            };
            _Context.ScoreSet.Add(scores);
            _Context.SaveChanges();
        }

        public virtual bool AddScore(string name, int point,int id_admin)
        {
            try
            {
                ScoreSet scores = new ScoreSet()
                {
                    Name = name,
                    Points = point,
                    Admin_Id_admin = id_admin
                };
                _Context.ScoreSet.Add(scores);
                return _Context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public void AppScore(int id_record, string name, int point)
        {
            var record = _Context.ScoreSet.Find(new object[] { id_record });
            record.Name = name;
            record.Points = point;

            _Context.SaveChanges();
        }

        public void DeleteScore(int id_record)
        {
            var record = _Context.ScoreSet.Find(new object[] { id_record });
            _Context.ScoreSet.Remove(record);
            _Context.SaveChanges();
        
        }

    }
}
