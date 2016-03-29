using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GridHorizontalSwitchObs:Observer
    {
        private Grid grid;
        private WallType wall;

        public GridHorizontalSwitchObs()
        {
            this.grid = null;
            this.wall = null;
        }

        public GridHorizontalSwitchObs(GridHorizontalSwitchObs g)
        {
            this.grid = g.grid;
            this.wall = g.wall;
        }

        public override void Notify()
        {
            //Console.WriteLine("GridHorizontalswitchObs.NOtify was called.");
            CollisionGroup g = this.getGroup();
            this.grid = Grid.selectGrid(g.getObjA(), g.getObjB());
            this.wall = (WallType)WallType.selectWall(g.getObjA(), g.getObjB());

            Debug.Assert(this.grid != null);
            Debug.Assert(this.wall != null);

            if (this.wall.type == WallType.Type.RightWall)
            {
                this.grid.rightWall = true;
            }
            else if (this.wall.type == WallType.Type.LeftWall)
            {
                this.grid.leftWall = true;
            }
            else
            {
                this.grid.BottomWall = true; 
            }
            if (this.grid.isDelayed == false)
            {
                this.grid.isDelayed = true;
                GridHorizontalSwitchObs ghso = new GridHorizontalSwitchObs(this);
                DelayedManager.attachObserver(ghso);
            }

            
        }

        public override void Execute()
        {
            //Console.WriteLine("GridHOrizontalSwitchObs.Execute was called.");

        //    if (this.grid.callCount < 1)
        //    {
         //       this.grid.callCount += 1;
                this.grid.ChangeDirection();
         //   }

           // if (this.grid.leftWall == true || this.grid.rightWall == true)
          //  {
                this.grid.callCount += 1;
          //  }
        }
    }
}
