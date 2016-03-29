using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Squid:Alien
    {
        /**
         * Squid Constructor
         * */
        public Squid(float x, float y, int index)
            : base(Alien.Type.Squid, GameObject.Name.Squid, Sprite.Name.Squid, index)
        {
            Debug.WriteLine("Squid Constructor Method was called.");
            this.x = x;
            this.y = y;
            this.index = index;
            //turnOFFCollisionBox();
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            this.pointsAwarded = 30;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Remove()
        {
         //   Player p = PlayerManager.getCurrentPlayer();
         //   p.UpdateScore(this.pointsAwarded);
            Console.WriteLine("Squid.Remove() was called.");
            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            this.Update();
            
            GameObject parent = (GameObject)this.parent;
            parent.Update();




            if (this.parent.parent != null)
            {
                Grid g = (Grid)this.parent.parent;
                g.totalAliens -= 1;
            }

            base.Remove();
            if (parent.child == null)
            {
                parent.Remove();
            }
            
        }

        /**
         * Squid Accept Method
         * */
        public override void Accept(Visitor v)
        {
           // Console.Write("Squid hit-> ") ;
        }



        public override void visitMissile(Missile m)
        {
          //  Console.WriteLine("Squid.");
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(m, this);
            
            cp.NotifyListeners();
            Sound alienExplosion = SoundManager.Find(Sound.Name.AlienKilled);
            alienExplosion.activateSound();
            
        }
    }
}
