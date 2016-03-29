using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Dagger:BombType
    {

        public Dagger(float x, float y, int index)
            : base(BombType.Type.Dagger, GameObject.Name.Dagger, Sprite.Name.Dagger, index)
        {
            this.x = x;
            this.y = y;
        }

        public override void Update()
        {
            this.y -= 0.3f;
            base.Update();
        }
        public override void Accept(Visitor v)
        {
            v.visitDagger(this);
        }
    }
}
