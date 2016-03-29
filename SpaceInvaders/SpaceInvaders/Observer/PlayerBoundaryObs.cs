using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class PlayerBoundaryObs:Observer
    {
        private Ship playerShip;
        private WallType colWall; 
        private Boolean rightWallFlag;
        private Boolean leftWallFlag; 
        public PlayerBoundaryObs()
        {
            this.playerShip = null;
            this.rightWallFlag = false;
            this.leftWallFlag = false;
            this.colWall = null;
        }

        public PlayerBoundaryObs(PlayerBoundaryObs o)
        {
            this.playerShip = o.playerShip;
            this.rightWallFlag = o.rightWallFlag;
            this.leftWallFlag = o.leftWallFlag;
            this.colWall = o.colWall;
        }

        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.playerShip = (Ship)ShipType.selectShip(g.getObjA(), g.getObjB());
            this.colWall = (WallType)WallType.selectWall(g.getObjA(), g.getObjB());

            if (this.colWall.type == WallType.Type.LeftWall)
            {
                this.leftWallFlag = true;
                this.rightWallFlag = false;
                this.playerShip.leftWallFlag = true;
                this.playerShip.rightWallFlag = false;
            }
            else
            {
                this.rightWallFlag = true;
                this.leftWallFlag = false;
                this.playerShip.rightWallFlag = true;
                this.playerShip.leftWallFlag = false;
            }


        }


        public override void Execute()
        {
            
        }
    }
}
