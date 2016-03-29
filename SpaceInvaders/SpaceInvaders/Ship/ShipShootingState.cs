using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShipShootingState:ShipState
    {


        /**
   * ShipReadyState MoveLeft Method
   * */
        public override void MoveLeft(Ship ship)
        {
            ship.x -= ship.speed;
        }

        /**
         * ShipReadyState MoveRight Method
         * */
        public override void MoveRight(Ship ship)
        {
            ship.x += ship.speed;
        }

        /**
         * ShipReadyState Shoot Method
         * */
        public override void Shoot(Ship ship)
        {

        }

        /**
         * ShipReadyState Handle Method
         * */
        public override void Handle(Ship ship)
        {
            
        }


    }
}
