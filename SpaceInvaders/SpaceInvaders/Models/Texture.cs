using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Texture:DLink
    {

        /**
         * Fields
         * */
        public Texture.Name name;
        public Azul.Texture pAzulTexture;
        public string fname;
        public enum Name
        {
            Uninitalized,
            Consolas36pt, 
            FakeObject,
            Aliens,
            Shield,
            Other, 
            Bullets, 
        }

        /**
         * Texture Constructor
         * */
        public Texture(Texture.Name name, String fname):base()
        {
            this.name = Texture.Name.Uninitalized;
            this.pAzulTexture = new Azul.Texture();
            Debug.Assert(this.pAzulTexture != null);
        }

        /**
         * Texture Base Constructor
         * */
        public Texture():base()
        {
            this.name = Name.Uninitalized;
            this.fname = null;
            this.pAzulTexture = new Azul.Texture();
        }

        /**
         * Texture Dump Method
         * */
        public void dump()
        {
            Console.WriteLine("Texture Dump\n" + "----------------");
            Console.WriteLine("Image.Name = " + this.name);
            Console.WriteLine("Azul.Rect = " + this.pAzulTexture);
            Console.WriteLine("----------------------------------");
        }

        /**
         * Texture Set Method
         * */
        public void Set(Texture.Name name, string fnames, Azul.Texture_Filter minFilter, Azul.Texture_Filter magFilter )
        {
            Debug.Assert(fnames != null);
            Debug.Assert(pAzulTexture != null);
            this.name = name;
            this.fname = fnames;
            
            this.pAzulTexture.Set(fnames, minFilter, magFilter);
            Debug.Assert(pAzulTexture != null);
        }
    }
}
