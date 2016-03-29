using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteShieldBrickObs:Observer
    {
        private GameObject brick;

        public DeleteShieldBrickObs()
        {
            this.brick = null;
        }

        public DeleteShieldBrickObs(DeleteShieldBrickObs d)
        {
            this.brick = d.brick;
        }
        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.brick = ShieldType.selectShieldType(g.getObjA(), g.getObjB());

            Debug.Assert(this.brick != null);
            if (this.brick.isDead == false)
            {
                this.brick.isDead = true;
                DeleteShieldBrickObs dsbo = new DeleteShieldBrickObs(this);
                DestructionManager.attachObserver(dsbo);
            }
        }

        public override void Execute()
        {
            this.brick.Remove();
        }
    }
}
