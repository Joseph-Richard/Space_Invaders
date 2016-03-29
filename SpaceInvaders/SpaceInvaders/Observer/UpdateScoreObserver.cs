using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class UpdateScoreObserver:Observer
    {

        private Alien alien; 
        public UpdateScoreObserver()
        {
            this.alien = null;
        }

        public UpdateScoreObserver(UpdateScoreObserver uso)
        {
            this.alien = uso.alien;
        }

        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.alien = (Alien)Alien.selectAlien(g.getObjA(), g.getObjB());

            Debug.Assert(this.alien != null);

            Player player = PlayerManager.getCurrentPlayer();
            player.UpdateScore(this.alien.pointsAwarded);

            //if (this.alien.isDead == false)
            //{
            //    this.alien.isDead = true;
            //    UpdateScoreObserver uso = new UpdateScoreObserver(this);
            //    DestructionManager.attachObserver(uso);
            //}
        }


        public override void Execute()
        {

        }
    }
}
