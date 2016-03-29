using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteUserExplosion:Command 
    {
         private ProxySprite proxy; 
        public DeleteUserExplosion(ProxySprite sprite)
            :base()
        {
            Debug.Assert(sprite != null);
            this.proxy = sprite;
        }

        public override void Execute(float executeTime)
        {
            SpriteBatch ships = SpriteBatchManager.Find(SpriteBatch.Name.PlayerShip);
            
            ships.Remove(proxy.getSpriteBatchNode());
            ProxySpriteManager.Remove(proxy);
            Player player = PlayerManager.getCurrentPlayer();
            if (player.playerLives > 0)
            {
                ShipManager.createShip();
            }
        }
    }
}
