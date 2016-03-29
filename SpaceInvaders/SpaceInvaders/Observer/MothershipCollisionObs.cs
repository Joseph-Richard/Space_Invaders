using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class MothershipCollisionObs:Observer
    {
        public Mothership mothership;
        
        public MothershipCollisionObs()
        {
            this.mothership = null;
            
        }

        public MothershipCollisionObs(MothershipCollisionObs msco)
        {
            this.mothership = msco.mothership;
            
        }

        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.mothership = (Mothership)MothershipType.selectMothership(g.getObjA(), g.getObjB());
            WallType wall = (WallType)WallType.selectWall(g.getObjA(), g.getObjB());

            if (wall is LeftWall)
            {
                this.mothership.leftWall = true;
            }
            else if (wall is RightWall)
            {
                this.mothership.rightWall = true;
            }

            if (this.mothership.isSwitchingDirection == false)
            {
                this.mothership.isSwitchingDirection = true;
                MothershipCollisionObs mco = new MothershipCollisionObs(this);
                DelayedManager.attachObserver(mco);

            }
        }

        public override void Execute()
        {
            Console.WriteLine("Count is currently: " + this.mothership.count);
            if (this.mothership.count >= 3)
            {
                this.mothership.Remove();
            }
            else
            {
                this.mothership.updateLocation();
                this.mothership.count+=1;
            }
        }
    }
}
