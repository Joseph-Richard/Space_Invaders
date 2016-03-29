using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AnimationSprite:Command
    {
        /**
         * Fields
         * */
        private sLink images;
        private sLink firstImage;
        private Sprite pSprite;
        private Image imageReference;
        private ImageHolder ihReference;
        private GameObject grid;
        /**
         * AnimationSprite Constructor
         * */
        public AnimationSprite(Sprite.Name name, GameObject g):base()
        {
         //   Debug.WriteLine("AnimationSprite Constructor Method was called.");
            this.pSprite =SpriteManager.Find(name);
            this.firstImage = null;
            this.grid = g;
            this.spriteTest = this.pSprite;
        }

        
        /**
         * AnimationSprite Attach Method
         * */
        public void Attach(Image.Name name)
        {
         //   Debug.WriteLine("AnimationSprite Attach Method was called.");
            this.imageReference = ImageManager.Find(name);
            Debug.Assert(this.imageReference != null);
            this.ihReference = new ImageHolder(this.imageReference);

            if (firstImage == null)
            {
                firstImage = this.ihReference;
            }
            else
            {
                this.ihReference.pNext = firstImage;
                firstImage = this.ihReference;
            }
            this.images = this.ihReference;
        }

        public void Set(GameObject g)
        {
            Debug.Assert(g != null);
            this.grid = g;
        }
        /**
         * AnimationSprite Execute Function
         * */
        public override void Execute(float deltaTime)
        {
         //   Debug.WriteLine("AnimationSprite Execute Method was called.");
         //   Debug.Assert(this.grid != null);
            if (this.grid.child != null)
            {
                Debug.Assert(deltaTime > 0);
                Debug.Assert(this.images != null);
                this.ihReference = (ImageHolder)this.images.pNext;
                if (this.ihReference == null)
                {
                    this.ihReference = (ImageHolder)this.firstImage;
                }
                this.images = this.ihReference;
                Console.WriteLine("Sprite animation(" + this.pSprite.name + ")" + "is animation now(" + deltaTime + ")");
                // deltaTime = deltaTime + (deltaTime / this.grid.totalAliens);
                Debug.Assert(this.pSprite != null);
                this.pSprite.SwapImage(this.ihReference.image);
                TimerManager.Add(TimerEvent.Name.SpriteAnimation, deltaTime, this);
            }
        }
    }
}
