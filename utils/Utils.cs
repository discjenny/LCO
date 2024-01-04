using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCO.Utils
{
    public class Employee
    {
        public int level;
        public int hitpoints;
        public float hpRegenScale;
        public float damageDealtScale;
        public float runRegenScale;
        public float stamina;
        public float speed;
        public float jumpForce;
        public float batteryLifeScale;
        public float oxygenScale;
        public float radarDistanceScale;
        //climb speed
        //grab distance

        public void Init()
        {
            level = 1;
            hitpoints = 150;
            hpRegenScale = (float)0.5;
            damageDealtScale = 0;
            runRegenScale = 0;
            stamina = 11;
            speed = (float)4.6;
            jumpForce = 13;
            batteryLifeScale = 0;
            oxygenScale = 0;
            radarDistanceScale = 0;
        }
    }
}