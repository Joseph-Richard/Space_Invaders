using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class UserDeathObs:Observer
    {
        private Ship playerShip;
        private ShipRoot shipRoot;
        public UserDeathObs()
        {
            this.playerShip = null;
            this.shipRoot = null;
        }

        public UserDeathObs(UserDeathObs udo)
        {
            this.playerShip = udo.playerShip;
            this.shipRoot = udo.shipRoot;
        }
        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.playerShip = (Ship)ShipType.selectShip(g.getObjA(), g.getObjB());

            if (this.playerShip.isDelayed == false)
            {
                this.playerShip.isDelayed = true;
                UserDeathObs udo = new UserDeathObs(this);
                DelayedManager.attachObserver(udo);
            }
        }


        public override void Execute()
        {
            Player currentPlayer = PlayerManager.getCurrentPlayer();
            this.playerShip.Remove();



            if (currentPlayer.playerLives == 1)
            {
                Ship s = ShipManager.getShip();
                s.setState(ShipManager.State.End);
                TimerManager.Pause();
                BombRoot br = (BombRoot)GameObjectManager.Find(GameObject.Name.BombRoot, 0);
                br.Pause();
                MothershipRoot mr = (MothershipRoot)GameObjectManager.Find(GameObject.Name.MothershipRoot, 0);
                mr.Pause();
                currentPlayer.loseLife();
            }
            else
            {
                currentPlayer.loseLife();

                ProxySprite explosion = ProxySpriteManager.Add(Sprite.Name.FryshipExplosion);
                explosion.x = this.playerShip.x;
                explosion.y = this.playerShip.y;
                explosion.pSprite.SetColor(0, 1, 0);
                SpriteBatch ex = SpriteBatchManager.Find(SpriteBatch.Name.PlayerShip);
                ex.Attach(explosion);
                Command deleteEx = new DeleteUserExplosion(explosion);
                TimerManager.Add(TimerEvent.Name.DeleteUserExplosion, 0.5f, deleteEx);
                this.playerShip.isDelayed = false;
            }
        }
    }
}
