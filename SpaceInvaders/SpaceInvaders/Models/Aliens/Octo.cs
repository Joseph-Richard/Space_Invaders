using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Octo:Alien
    {
        /**
         * Octo Constructor
         * */
        public Octo(float x, float y, int index)
            : base(Alien.Type.Octo, GameObject.Name.Octo, Sprite.Name.Octo, index)
        {
        //    Debug.WriteLine("Octo Constructor Method was called.");
            this.x = x;
            this.y = y;
            this.index = index;
            this.pointsAwarded = 10;
            //turnOFFCollisionBox();
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }

        public override void Remove()
        {
           // Player p = PlayerManager.getCurrentPlayer();
           // p.UpdateScore(this.pointsAwarded);

            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            this.collisionObj.collisionRect.x = 0;
            this.collisionObj.collisionRect.y = 0;
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


        public override void Update()
        {
            base.Update();
        }

        /**
         * Octo Accept Method
         * */
        public override void Accept(Visitor v)
        {
            Console.Write("Octo hit -> ");
        }

        public override void visitMissile(Missile m)
        {
            Console.WriteLine("Octo.");
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(m, this);
           // m.shootOutOfSky();
            cp.NotifyListeners();
            Sound alienExplosion = SoundManager.Find(Sound.Name.AlienKilled);
            alienExplosion.activateSound();
        }
    }
}
