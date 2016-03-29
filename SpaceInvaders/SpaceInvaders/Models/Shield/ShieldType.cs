using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShieldType:GameObject
    {
        public ShieldType.Type type;
        public enum Type
        {
            Uninitialized, 
            ShieldRoot,
            ShieldColumn,
            ShieldBrick,

            ShieldTopLeftEmptySmall,
            ShieldTopLeftEmptyLarge,

            ShieldTopRightEmptySmall,
            ShieldTopRightEmptyLarge,

            ShieldBottomLeftEmpty,
            ShieldBottomRightEmpty,
        }

        protected ShieldType(ShieldType.Type type, GameObject.Name name, Sprite.Name sName, int index)
            : base(name, sName, index)
        {
            this.type = type;
        }

        public static GameObject selectShieldType(GameObject a, GameObject b)
        {
            GameObject result = null;
            if (a is ShieldType)
            {
                result = a;
            }
            else
            {
                result = b;
            }

            return result;
        }
        public override void Accept(Visitor v)
        {
            throw new NotImplementedException();
        }

    }
}

