using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteMissileObs:Observer
    {
        private GameObject missile;
        //private Ship ship;

        public DeleteMissileObs()
        {
            this.missile = null;
           // this.ship = null;
        }
        public DeleteMissileObs(DeleteMissileObs o)
        {
            this.missile = o.missile;
          //  this.ship = null;
        }

        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.missile = MissileType.selectMissile(g.getObjA(), g.getObjB());

            Debug.Assert(this.missile != null);
            if (this.missile.isDead == false)
            {
                this.missile.isDead = true;
                DeleteMissileObs obs = new DeleteMissileObs(this);
                DestructionManager.attachObserver(obs);
            }

        }

        public override void Execute()
        {
            this.missile.Remove();
        }

    }
}
