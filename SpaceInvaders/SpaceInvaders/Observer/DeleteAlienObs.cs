using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteAlienObs:Observer
    {
        private GameObject alien;

        public DeleteAlienObs()
        {
            this.alien = null;
        }

        public DeleteAlienObs(DeleteAlienObs dao)
        {
            this.alien = dao.alien;
        }
        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.alien = Alien.selectAlien(g.getObjA(), g.getObjB());

            Debug.Assert(this.alien != null);
            if (this.alien.isDead == false)
            {
                this.alien.isDead = true;
                DeleteAlienObs dao = new DeleteAlienObs(this);
                DestructionManager.attachObserver(dao);
            }
        }

        public override void Execute()
        {
            this.alien.collisionObj.collisionRect.Set(0, 0, 0, 0);
            this.alien.Remove();
            ProxySprite explosion = ProxySpriteManager.Add(Sprite.Name.AlienExplosion);
            explosion.x = this.alien.x;
            explosion.y = this.alien.y;
            SpriteBatch ex = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            ex.Attach(explosion);
            Command deleteEx = new DeleteAlienExplosion(explosion);
            TimerManager.Add(TimerEvent.Name.DeleteAlienExplosion, 0.22f, deleteEx);
        }
    }
}
