using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class ShipType:GameObject
    {
        public ShipType.Type type; 

        public enum Type
        {
            Uninitialized, 
            ShipRoot,
            Ship
        }
        public Boolean isDelayed;
        //Just the same As Alien.cs
         protected ShipType(ShipType.Type type, GameObject.Name name, Sprite.Name sName, int index):base(name, sName, index)
        {
            this.type = type;
            this.isDelayed = false;
        }


         public static GameObject selectShip(GameObject a, GameObject b)
         {
             Debug.Assert(a != null);
             Debug.Assert(b != null);

             GameObject result = null;
             if (a is ShipType)
             {
                 result = a;
             }
             else
             {
                 result = b;
             }
             return result;
         }
    }
}
