using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMJSON
{
    class Player
    {
        // Initializing the get and set for the Player values
        public int CurrentHP = 20;
        public int CurrentAttack;
        public double Potions;
        public int Experience;
        public int Level;
        public int ExpNeeded;
        public int DefEnemies;

        public string CURRENT_HP
        {
            get { return CurrentHP.ToString(); }
            set { CURRENT_HP = CurrentHP.ToString(); }
        }
       
    }
}
