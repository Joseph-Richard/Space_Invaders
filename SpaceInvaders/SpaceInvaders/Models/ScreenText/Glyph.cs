using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Glyph:DLink
    {
        public FontStyle fontStyle;
        public Texture texture;
        public Azul.Rect subRect;
        public int key;
        public enum FontStyle
        {
            Consolas36pt,
            Other, 
            FakeObject,
            Uninitialized
        }


        public Glyph()
        {
            this.fontStyle = FontStyle.Uninitialized;
            this.texture = null;
            this.subRect = new Azul.Rect();
            this.key = 0;
        }



        public void Set(int key, Glyph.FontStyle fstyle, Texture.Name tName, float x, float y, float width, float height)
        {
            Debug.Assert(this.subRect != null);
            this.key = key;

            this.fontStyle = fstyle;

            this.texture = TextureManager.Find(tName);

            Debug.Assert(this.subRect != null);
            this.subRect.Set(x, y, width, height);
        }
    }
}
