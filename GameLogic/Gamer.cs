using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateLayer;

namespace GameLogic
{
    public class Gamer
    {
        private static Gamer _insteance;

        public static Gamer Insteance
        {
            get
            {
                if (_insteance == null)
                {
                    _insteance = new Gamer();
                }
                return _insteance;
            }

        }
        public virtual int Points
        {
            get;
            set;
        }

        public virtual int ShotNum
        {
            get;
            set;
        }

        private Gun Gun;

        private Gamer()
        {
            Gun = new Gun();

        }

        public virtual void StartGame()
        {
            ShotNum = 0;
            Points = 0;
        }

        public virtual void RollDrayer()
        {
            Gun.DoRollDryer();
        }

        public virtual bool Shot()
        {
            var result = Gun.DoShot();
            ShotNum++;
            if (!result)
            {
                this.AddsPoints();
            }

            return result;
        }

        public virtual bool SavePoints(string Name)
        {
            return DateManager.ScoresRepository.AddScore(Name, Points,1);
        }

        public virtual void AddsPoints()
        {
            Points += 100;
            if (ShotNum >= 3)
            {
                Random rnd = new Random();
                int increaseNum = rnd.Next(2, 5);
                Points *= increaseNum;
            }
        }


        public virtual List<ScoreSet> ShowScores()
        {
            var scores = DateManager.ScoresRepository.List;
            return scores;
        }

    }
}
