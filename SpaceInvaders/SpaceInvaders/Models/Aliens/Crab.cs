using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Crab:Alien
    {
        /**
         * Crab Constructor
         * */
        public Crab(float x, float y, int index)
            : base(Alien.Type.Crab, GameObject.Name.Crab, Sprite.Name.Crab, index)
        {
         //   Debug.WriteLine("Crab Constructor Method was called.");
            this.x = x;
            this.y = y;
            this.index = index;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            //turnOFFCollisionBox();
            this.pointsAwarded = 20;
        }

        public override void Update()
        {
            base.Update();
        }
        /**
         * Crab Accept Method
         * */
        public override void Accept(Visitor v)
        {
          //  Console.WriteLine("MISSILE HIT ALIEN_______________________________________________");
            v.visitAlien(this);
        }

        public override void Remove()
        {
         //   Player p = PlayerManager.getCurrentPlayer();
           // p.UpdateScore(this.pointsAwarded);
            
            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            this.Update();
            
            GameObject parent = (GameObject)this.parent;
            parent.Update();

            //ProxySprite explosion = ProxySpriteManager.Add(Sprite.Name.AlienExplosion);
            //explosion.x = this.x;
            //explosion.y = this.y;
            //SpriteBatch ex = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            //ex.Attach(explosion);
            //Command deleteEx = new DeleteAlienExplosion(explosion);
            //TimerManager.Add(TimerEvent.Name.DeleteAlienExplosion, 0.22f, deleteEx);

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

        

        public override void visitMissile(Missile m)
        {
          //  Console.WriteLine("Crab.");
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(m, this);
            // m.shootOutOfSky();
            cp.NotifyListeners();
            Sound alienExplosion = SoundManager.Find(Sound.Name.AlienKilled);
            alienExplosion.activateSound();
        }
    }
}
