using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Sprite:SpriteBase
    {
       /**
        * Fields
        * */
        public Azul.Sprite pAzulSprite;
        private Azul.Color pColor;
        public  Image pImage;
        public  Sprite.Name name;
        private Image.Name pImageName;
        public Azul.Rect ScreenRect;

        public enum Name {Uninitialized, 
                            Crab,
                            Octo,
                            Squid,
                            Mothership,
                            MothershipBomb, 
                            Fryship,
                            FryshipExplosion,
                            FakeObject,
                            Missile,
                            Dagger,
                            ZigZag,
                            LineBomb, 
                            ShieldBrick,
                            AlienExplosion, 
                            ShieldTopLeftEmptySmall,
                            ShieldTopLeftEmptyLarge,

                            ShieldTopRightEmptySmall,
                            ShieldTopRightEmptyLarge,

                            ShieldBottomLeftEmpty,
                            ShieldBottomRightEmpty,
        }

        /**
         * Sprite Constructor
         * */
        public Sprite()
            : base()
        {
        //    Debug.WriteLine("Sprite Constructor Method was called.");
            this.name = Sprite.Name.Uninitialized;
            this.ScreenRect = new Azul.Rect();
            this.pAzulSprite = new Azul.Sprite();
            this.pColor = new Azul.Color(1.0f, 1.0f, 1.0f);
            this.pImage = null;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
            
        }


        /**
         * Sprite Render Function
         * */
        override public void  Render()
        {
        //    Debug.WriteLine("Sprite Render Method was called.");
            Debug.Assert(this.pAzulSprite != null);
            this.pAzulSprite.Render();
        }

        /**
         * Sprite  Update Function
         * */
        override public void Update()
        {
        //    Debug.WriteLine("Sprite Update Method was called.");
            Debug.Assert(this.pAzulSprite != null);

            //Udpate Azul Sprite with the newest data. 
            this.pAzulSprite.sx = this.sx;
            this.pAzulSprite.sy = this.sy;
            this.pAzulSprite.x = this.x;
            this.pAzulSprite.y = this.y;
            this.pAzulSprite.angle = this.angle;

            this.pAzulSprite.SwapColor(this.pColor);
            this.pAzulSprite.Update();
        }


        /**
         * Sprite SwapColor Function
         * */
        public void SwapColor(Azul.Color c)
        {
         //   Debug.WriteLine("Sprite SwapColor Method was called.");
            Debug.Assert(c != null);
            this.pColor = c;
            
        }

        /**
         * Sprite SetColor Function
         * */
        public void SetColor(float red, float green, float blue)
        {
         //   Debug.WriteLine("Sprite SetColor Method was called.");
            Debug.Assert(this.pColor != null && red >= 0.0 && green >= 0.0 && blue >= 0.0);
            this.pColor.Set(red, green, blue);
        }

        /**
         *Sprite SwapImage Function
         * */
        public void SwapImage(Image nImage) 
        {
        //    Debug.WriteLine("Sprite SwapImage Method was called.");
            Debug.Assert(nImage != null);
            this.pImage = nImage;
            this.pAzulSprite.SwapTexture(this.pImage.pTexture.pAzulTexture);
            this.pAzulSprite.SwapTextureRect(this.pImage.pRect);
        }


        /**
         * Sprite Set Function
         * */
        public void Set(Sprite.Name sName, Image.Name iName, float sx, float sy, float width, float height )
        {
         //   Debug.WriteLine("Sprite Set Method was called.");
            Debug.Assert(this.pAzulSprite != null);
            Debug.Assert(this.ScreenRect != null);
            this.name = sName;
            this.pImageName = iName;
            this.ScreenRect.Set(sx, sy, width, height);

            Image image = ImageManager.Find(iName);
            Debug.Assert(image != null);

            this.pAzulSprite.Swap(image.pTexture.pAzulTexture, image.pRect, this.ScreenRect, this.pColor);
            this.sx = this.pAzulSprite.sx;
            this.sy = this.pAzulSprite.sy;
            this.x = this.pAzulSprite.x;
            this.y = this.pAzulSprite.y;
            this.angle = this.pAzulSprite.angle;
        }

        public void updateLocation(float sx, float sy, float width, float height)
        {
            this.sx = sx;
            this.sy = sy;
            this.x = x;
            this.y = y;
        }

        /**
         * Sprite getName Method
         * */
        override public Enum getName()
        {
         //   Debug.WriteLine("Sprite getName Method was called.");
            return this.name;
        }
        public Azul.Rect getScreenRect()
        {
            Debug.Assert(this.ScreenRect != null);
            return this.ScreenRect;
        }
        /**
         * Sprite getColor method
         * */
        public Azul.Color getColor()
        {
        //    Debug.WriteLine("Sprite getColor Method was called.");
            return this.pColor;
        }

        /**
         * Sprite Dump Method
         * */
        public void Dump()
        {
        //    Debug.WriteLine("Sprite Dump Method was called.");
            Console.WriteLine("SPRITE DUMP METHOD CALLED: --------------");

        }
    }
}
