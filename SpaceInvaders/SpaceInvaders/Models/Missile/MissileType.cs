using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class MissileType:GameObject
    {
        private MissileType.Type type;
        public enum Type
        {
            Uninitialized, MissileRoot, Missile
        }

        protected MissileType(MissileType.Type type, GameObject.Name name, Sprite.Name sName, int index)
            : base(name, sName, index)
        {
            this.type = type;
        }

        public static GameObject selectMissile(GameObject a, GameObject b)
        {
            GameObject realSlimMissile;

            if (a is MissileType)
            {
                realSlimMissile = a; 
            }
            else
            {
                realSlimMissile = b;
            }
            //Debug.Assert(realSlimMissile is MissileType);
            return realSlimMissile;
        }
        
    }
}
