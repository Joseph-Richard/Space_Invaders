using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Image:DLink
    {

        /**
         * Fields
         * */
        public Image.Name name;
        public Azul.Rect pRect;
        public Texture pTexture;
        public enum Name { Uninitalized, 
                            Crab1, 
                            Crab2,
                            Octo1,  
                            Octo2,
                            Squid1,
                            Squid2,
                            Mothership,
                            MothershipBomb,
                            AlienExplosion, 
                                    
                            Fryship,
                            FryshipExplosion, 
                            Missile,
                            ZigZag1,
                            ZigZag2,
                            Dagger1,
                            Dagger2,
                            LineBomb1,
                            LineBomb2, 

                            ShieldBrick,
            
                            ShieldTopLeftEmptySmall,
                            ShieldTopLeftEmptyLarge,

                            ShieldTopRightEmptySmall,
                            ShieldTopRightEmptyLarge,
                            
                            ShieldBottomLeftEmpty,
                            ShieldBottomRightEmpty, 
                            
                            FakeObject }
        /**
         * Image Constructor
         * */
        public Image(Image.Name name,Texture.Name tName, float sx, float sy, float width, float height):base()
        {
         //   Debug.WriteLine("Image Constructor Method was called.");


            this.name = Name.Uninitalized;
            this.pTexture = null;
            this.pRect = new Azul.Rect();
            
        }

        /**
         * Image Base Constructor
         * */
        public Image()
            : base()
        {
        //    Debug.WriteLine("Image Constructor Method2 was called.");
            this.name = Name.Uninitalized;
            this.pRect = new Azul.Rect();
            this.pTexture = null;
        }
        /**
         * Image Set Method
         * */
        public void set(Image.Name name, Texture.Name texture, float sx, float sy, float width, float height)
        {
        //    Debug.WriteLine("Image Set Method was called.");
            Texture text = TextureManager.Find(texture);
            Debug.Assert(text != null);

            this.name = name;
            this.pRect = new Azul.Rect(sx, sy, width, height);
            this.pTexture = text;
        }

        /**
         * Image Dump Method
         * */
        public void dump()
        {
         //   Debug.WriteLine("Image Dump Method was called.");
            Console.WriteLine("Image Dump\n"+"----------------");
            Console.WriteLine("Image.Name = "+this.name);
            Console.WriteLine("Azul.Rect = " + this.pRect);
            Console.WriteLine("Texture = "+ this.pTexture);
        }
    }
}
