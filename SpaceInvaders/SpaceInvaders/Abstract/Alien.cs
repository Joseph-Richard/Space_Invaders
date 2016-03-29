using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class Alien:GameObject
    {
        /**
         * Fields
         * */
        public Alien.Type type;
        public int pointsAwarded; 
        public enum Type {Uninitialized, Crab, Octo, Squid, Grid, Column,AlienExplosion,  Missile}
        public Boolean isBottom;
        /**
         * Alien Constructor
         * */
        protected Alien(Alien.Type type, GameObject.Name name, Sprite.Name sName, int index):base(name, sName, index)
        {
            this.type = type;
            this.isBottom = false;
        }

        public static GameObject selectAlien(GameObject a, GameObject b)
        {
            GameObject theRealSlimAlien = null;
            if (a is Alien)
            {
                theRealSlimAlien = a;
            }
            else
            {
                theRealSlimAlien = b;
            }

            Debug.Assert(theRealSlimAlien is Alien);
            return theRealSlimAlien;
        }
    }
}
