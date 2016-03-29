using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteBombObs:Observer
    {
        private GameObject bomb;
        private Boolean isPlayerMissile;
        //private Ship ship;

        public DeleteBombObs()
        {
            this.bomb = null;
            this.isPlayerMissile = false;
           // this.ship = null;
        }
        public DeleteBombObs(DeleteBombObs o)
        {
            this.bomb = o.bomb;
            this.isPlayerMissile = o.isPlayerMissile;
        }

        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.bomb = BombType.selectBomb(g.getObjA(), g.getObjB());
            GameObject m = MissileType.selectMissile(g.getObjA(), g.getObjB());
            if (m is MissileType)
            {
                this.isPlayerMissile = true;
            }
            Debug.Assert(this.bomb != null);
            if (this.bomb.isDead == false)
            {
                this.bomb.isDead = true;
                DeleteBombObs obs = new DeleteBombObs(this);
                DestructionManager.attachObserver(obs);
            }

        }

        public override void Execute()
        {
            if (this.isPlayerMissile)
            {
                ProxySprite explosion = ProxySpriteManager.Add(Sprite.Name.AlienExplosion);
                explosion.x = this.bomb.x;
                explosion.y = this.bomb.y;
                SpriteBatch ex = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
                ex.Attach(explosion);
                Command deleteEx = new DeleteAlienExplosion(explosion);
                TimerManager.Add(TimerEvent.Name.DeleteAlienExplosion, 0.22f, deleteEx);
            }
            this.bomb.Remove();
        }
    }
}
