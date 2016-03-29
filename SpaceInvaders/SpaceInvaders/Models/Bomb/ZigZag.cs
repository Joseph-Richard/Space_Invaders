using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ZigZag:BombType
    {

        public ZigZag(float x, float y, int index)
            : base(BombType.Type.ZigZag, Name.ZigZag, Sprite.Name.ZigZag, index)
        {
            this.x = x;
            this.y = y;
        }


        public override void Update()
        {
            this.y -= 1;
            base.Update();
        }
        public override void Accept(Visitor v)
        {
            v.visitZigZag(this);
        }
    }
}
