using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShipManager
    {
        //----------------------------------------------
        private static ShipManager instance;
        private Ship ship;
        private Missile missile;
        //private State state;
        private ShipReadyState ReadyState;
        private ShipEndState EndState;
        private ShipShootingState ShootingState;


        public enum State
        {
            Ready, Shooting, End, Uninitialized
        }
        //-----------------------------------------------

        /**
         * ShipManager Constructor (Private)
         * */
        private ShipManager()
        {
            //Constructor
            ship = null;
            //state = State.Uninitialized;
            ReadyState = new ShipReadyState();
            ShootingState = new ShipShootingState();
            EndState = new ShipEndState();
        }

        /**
         * ShipManager Create Method (static)
         * */
        public static void Create()
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new ShipManager();
            }
            instance.ship = createShip();
            instance.ship.setState(ShipManager.State.Ready);
        }

        /**
         * ShipManager getShip Method (static)
         * */
        public static Ship getShip()
        {
            ShipManager sm = ShipManager.getInstance();
            Debug.Assert(sm.ship != null);
            return sm.ship;
        }


        public static Missile getMissile()
        {
            ShipManager sm = ShipManager.getInstance();
            Debug.Assert(sm.missile != null);
            return sm.missile;
        }

        /**
         * ShipManager getState Method (static)
         * */
        public static ShipState getState(ShipManager.State state)
        {
            ShipManager sm = ShipManager.getInstance();
            ShipState sState = null;

            //Find out which state we need to switch to. 
            switch(state)
            {
                case ShipManager.State.Ready:
                    sState = sm.ReadyState;
                    break;
                case ShipManager.State.Shooting:
                    sState = sm.ShootingState;
                    break;
                case ShipManager.State.End:
                    sState = sm.EndState;
                    break;
                default:
                    Debug.Assert(false);
                    break;
                
            }
            Debug.Assert(sState != null);
            return sState;
        }

        /**
         * ShipManager AttachShip Method (static)
         * */
        public static void attachShip(Ship ship)
        {
            Debug.Assert(ship != null);
            ShipManager sm = ShipManager.getInstance();
            sm.ship = ship;
        }

        /**
         * ShipManager CreateShip Method (static)
         * */
        public static Ship createShip()
        {
            ShipManager sm = ShipManager.getInstance();
            sm.ship = new Ship(435, 85, 0);
            sm.ship.setState(ShipManager.State.Ready);
            SpriteBatch PlayerShipBatch = SpriteBatchManager.Find(SpriteBatch.Name.PlayerShip);
            Debug.Assert(PlayerShipBatch != null);
            PlayerShipBatch.Attach(sm.ship.proxySprite);
            sm.ship.attachCollisionBox(SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes));
            PCSTree shipTree = GameObjectManager.getTree();

            GameObject fryshipRoot = GameObjectManager.Find(GameObject.Name.FryshipRoot);
            Debug.Assert(fryshipRoot != null);
            shipTree.Insert(sm.ship, fryshipRoot);


            return sm.ship;
        }

        /**
         * ShipManager CreateMissile Method (static)
         * */
        public static Missile createMissile()
        {
            ShipManager sm = ShipManager.getInstance();
            sm.missile = new Missile(400,100,0);

            //Attach to missile root
            PCSTree missileTree = GameObjectManager.getTree();




            SpriteBatch Bombs = SpriteBatchManager.Find(SpriteBatch.Name.Bombs);
            SpriteBatch Boxes = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);

            //attach collisionbox and sprite
            sm.missile.attachSprite(Bombs);
            sm.missile.attachCollisionBox(Boxes);

            GameObject mRoot = GameObjectManager.Find(GameObject.Name.MissileRoot);
            //Get ahold of tree and insert with Missile root as parent
            missileTree.Insert(sm.missile, mRoot);

            return sm.missile;

            
            
            
            
            
        }

        /**
         * ShipManager getInstance Method (static)
         * */
        public static ShipManager getInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static void Nullify()
        {
            instance = null;
        }

    
    }
}
