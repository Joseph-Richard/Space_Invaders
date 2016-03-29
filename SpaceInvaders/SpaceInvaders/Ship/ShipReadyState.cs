using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShipReadyState:ShipState
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
            //Create Missile Using a Manager
        //    Console.WriteLine("Ship.x = {0} --------------", ship.x);
       //     Console.WriteLine("Ship.y = {0}---------------", ship.y);
            Missile m = ShipManager.createMissile();
            m.updateLocation(ship.x, ship.y + 40);
            m.setIsAlive(true);

            Sound fire = SoundManager.Find(Sound.Name.MissileFire);
            fire.activateSound();
        //    Console.WriteLine("Missile.x = {0} --------------", m.x);
       //     Console.WriteLine("Missile.y = {0}---------------", m.y);
            this.Handle(ship);
        }

        /**
         * ShipReadyState Handle Method
         * */
        public override void Handle(Ship ship)
        {
            ship.setState(ShipManager.State.Shooting);
        }
    }
}
