using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AlienExplosion:Alien
    {

        public AlienExplosion(float x, float y, int index)
            : base(Alien.Type.AlienExplosion, Name.AlienExplosion, Sprite.Name.AlienExplosion, index)
        {
            this.x = x;
            this.y = y;
            
        }

        public override void Accept(Visitor v)
        {
            
        }
    }
}
