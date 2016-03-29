using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteAlienExplosion:Command
    {
        private ProxySprite proxy; 
        public DeleteAlienExplosion(ProxySprite sprite)
            :base()
        {
            Debug.Assert(sprite != null);
            this.proxy = sprite;
        }

        public override void Execute(float executeTime)
        {
            SpriteBatch aliens = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            proxy.pSprite.SetColor(1,1,1);
            aliens.Remove(proxy.getSpriteBatchNode());
            ProxySpriteManager.Remove(proxy);
        }
    }
}
