using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class UpdateMothershipScore:Observer
    {
        private Mothership ship;

        public UpdateMothershipScore()
        {
            this.ship = null;
        }

        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.ship = (Mothership)MothershipType.selectMothership(g.getObjA(), g.getObjB());

            Debug.Assert(this.ship != null);

            Player player = PlayerManager.getCurrentPlayer();
            player.UpdateScore(this.ship.pointsAwarded);
        }
    }
}
