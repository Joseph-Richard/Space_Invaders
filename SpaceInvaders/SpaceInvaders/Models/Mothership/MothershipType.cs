using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class MothershipType:GameObject
    {

        public MothershipType.Type type;

        public enum Type
        {
            Uninitialized,
            MothershipRoot,
            Mothership
        }

        //Just the same As Alien.cs
         protected MothershipType(MothershipType.Type type, GameObject.Name name, Sprite.Name sName, int index):base(name, sName, index)
        {
            this.type = type;
        }



         public static GameObject selectMothership(GameObject a, GameObject b)
         {
             GameObject result = null;
             if (a is MothershipType)
             {
                 result = a;
             }
             else
             {
                 result = b;
             }
             Debug.Assert(result is MothershipType);
             return result;
         }
    }
}
