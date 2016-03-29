using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class WallType:GameObject
    {
        public WallType.Type type;
        public enum Type
        {
            Uninitialized, WallRoot, LeftWall, RightWall, TopWall, BottomWall
        }

        protected WallType(WallType.Type type, GameObject.Name name, Sprite.Name sName, int index)
            : base(name, sName, index)
        {
            this.type = type;
        }

       

        public static GameObject selectWall(GameObject a, GameObject b)
        {
            GameObject realSlimWall;

            if (a is WallType)
            {
                realSlimWall = a; 
            }
            else
            {
                realSlimWall = b;
            }
            Debug.Assert(realSlimWall is WallType);
            return realSlimWall;
        }
    }
}
