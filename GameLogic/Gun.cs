using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Gun
    {
        private bool KillPosition;
        private int BullePosition;

        public virtual bool DoShot()
        {
            return KillPosition;
        }

        public virtual void DoRollDryer()
        {
            Random rnd = new Random();
            var rollResult = rnd.Next(1, 6);
            KillPosition = rollResult == BullePosition;

        }

        public Gun()
        {
            Random rnd = new Random();
            var rollResult = rnd.Next(1, 6);
        }

    }
}
