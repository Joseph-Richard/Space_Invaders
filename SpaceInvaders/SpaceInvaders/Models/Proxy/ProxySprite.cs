using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ProxySprite:SpriteBase
    {
        /**
         * Fields
         * */
        private Sprite.Name name;
        public Sprite pSprite;


        /**
         * ProxySprite Constructor Method
         * */
        public ProxySprite()
            : base()
        {
       //     Debug.WriteLine("ProxySprite Constructor Method was called.");
            this.name = Sprite.Name.Uninitialized;
            this.x = 0;
            this.y = 0;
            this.pSprite = null;
        }

        /**
         * ProxySprite Constructor Method (Sprite.Name)
         * */
        public ProxySprite(Sprite.Name name)
        {
        //    Debug.WriteLine("ProxySprite Constructor Method2 was called.");
            this.name = name;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pSprite = SpriteManager.Find(name);
            Debug.Assert(this.pSprite != null);
        }
        /**
         * ProxySprite Set Method
         * */
        public void set(Sprite.Name n)
        {
        //    Debug.WriteLine("ProxySprite Set Method was called.");
            Sprite temp = (Sprite)SpriteManager.Find(n);
            Debug.Assert(temp != null);
            pSprite = temp;
            
        }

        /**
         * ProxySprite pushToSprite Method
         * */
        private void pushToSprite()
        {
        //    Debug.WriteLine("ProxySprite pushToSprite Method was called.");
            Debug.Assert(this.pSprite != null);
            this.pSprite.x = this.x;
            this.pSprite.y = this.y;
        }

        /**
         * ProxySprite Update Method
         * */
        public override void Update()
        {
        //    Debug.WriteLine("ProxySprite Update Method was called.");
            Debug.Assert(this.pSprite != null);
            this.pushToSprite();
            this.pSprite.Update();
        }

        public void UpdateLocation(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.Update();
        }

        /**
         * ProxySprite Render Method
         * */
        public override void Render()
        {
        //    Debug.WriteLine("ProxySprite Render Method was called.");
            Debug.Assert(this.pSprite != null);
            this.pushToSprite();
            this.pSprite.Update();
            this.pSprite.Render();
        }

        /**
         * ProxySprite GetName Method
         * */
        public override Enum getName()
        {
        //    Debug.WriteLine("ProxySprite GetName Method was called.");
            return this.name;
        }


        
    }
}
