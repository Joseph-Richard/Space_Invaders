using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class BottomWallEndGameObs:Observer
    {
        private Grid grid;
        private WallType wall;
        private Boolean bottomWallHit;
        
        public BottomWallEndGameObs()
        {
            this.grid = null;
            this.wall = null;
            this.bottomWallHit = false;
        }

        public BottomWallEndGameObs(BottomWallEndGameObs g)
        {
            this.grid = g.grid;
            this.wall = g.wall;
            this.bottomWallHit = g.bottomWallHit;
        }

        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.grid = Grid.selectGrid(g.getObjA(), g.getObjB());
            this.wall = (WallType)WallType.selectWall(g.getObjA(), g.getObjB());

            Debug.Assert(this.grid != null);
            Debug.Assert(this.wall != null);


            if (this.wall.type == WallType.Type.BottomWall)
            {
                this.grid.BottomWall = true;
            }


            if (this.grid.BottomWall ==true)
            {
                this.grid.isDelayed = true;
                BottomWallEndGameObs bweg = new BottomWallEndGameObs(this);
                DelayedManager.attachObserver(bweg);
            }
        }

        public override void Execute()
        {
            Player currentPlayer = PlayerManager.getCurrentPlayer();

                Ship s = ShipManager.getShip();
                s.setState(ShipManager.State.End);
                TimerManager.Pause();
                BombRoot br = (BombRoot)GameObjectManager.Find(GameObject.Name.BombRoot, 0);
                br.Pause();
                MothershipRoot mr = (MothershipRoot)GameObjectManager.Find(GameObject.Name.MothershipRoot, 0);
                mr.Pause();
                currentPlayer.playerLives = 0;
            
        }
    }
}
