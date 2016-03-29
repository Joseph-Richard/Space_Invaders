using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class BombType:GameObject
    {

        private BombType.Type type;
        public enum Type
        {
            Uninitialized,BombRoot, Dagger, ZigZag, LineBomb, MothershipBomb
        }

        protected BombType(BombType.Type type, GameObject.Name name, Sprite.Name sName, int index)
            : base(name, sName, index)
        {
            this.type = type;
        }

        public static GameObject selectBomb(GameObject a, GameObject b)
        {
            GameObject realSlimBomb;

            if (a is BombType)
            {
                realSlimBomb = a; 
            }
            else
            {
                realSlimBomb = b;
            }
            Debug.Assert(realSlimBomb is BombType);
            return realSlimBomb;
        }
    }
}
