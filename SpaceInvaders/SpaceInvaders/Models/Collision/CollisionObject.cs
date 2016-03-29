using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class CollisionObject
    {
        public CollisionRect collisionRect;
        public SpriteBox proxyBox;


        /**
         * Collision Object Constructor Method
         * */
        public CollisionObject(ProxySprite proxySprite)
        {
         //   Debug.WriteLine("CollisionObject Constructor Method was called.");
            //We need to add a spritebox to the box manager 

            Debug.Assert(proxySprite != null);
            
            this.collisionRect = new CollisionRect(proxySprite.pSprite.getScreenRect());
            Debug.Assert(this.collisionRect != null);
           // this.collisionRect.setSpriteBatchNode(proxySprite.getSpriteBatchNode());
            this.proxyBox = SpriteBoxManager.Add(this.collisionRect);
            Debug.Assert(this.proxyBox != null);
            this.proxyBox.swapColors(0.0f, 0.5f, 1.0f);

        }

        /**
         * Collision Object UpdateLocation Method
         * */
        public void UpdateLocation(float x, float y)
        {
         //   Debug.WriteLine("CollisionObject UpdateLocation Method was called.");
            this.collisionRect.x = x;
            this.collisionRect.y = y;
            this.proxyBox.x = this.collisionRect.x;
            this.proxyBox.y = this.collisionRect.y;

            this.proxyBox.swapScreenRect(this.proxyBox.x, this.proxyBox.y, this.collisionRect.width, this.collisionRect.height);
            this.proxyBox.Update();
        }
    }
}
