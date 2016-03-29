using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpriteFont:SpriteBase
    {
        private Glyph.FontStyle fontStyle;
        public ScreenText.Name name; 
        private Azul.Sprite pAzulSprite;
        private Azul.Rect screenRect;
        private Azul.Color fontColor;
        
        private String currentText;

        
        public SpriteFont()
            : base()
        {
            this.fontStyle = Glyph.FontStyle.Uninitialized;
            this.fontColor = new Azul.Color(1, 1, 1);
            this.currentText = null;
            this.x = 0;
            this.y = 0;
            this.screenRect = new Azul.Rect();
            this.pAzulSprite = new Azul.Sprite();
        }

        public void Set(String newText, ScreenText.Name sTName, Glyph.FontStyle fstyle, float x, float y)
        {
            Debug.Assert(newText != null);
            Debug.Assert(x >= 0);
            Debug.Assert(y >= 0);

            this.fontStyle = fstyle;
            this.name = sTName;
            this.currentText = newText;
            this.x = x;
            this.y = y;

            this.fontColor.Set(1, 1, 1);
        }

        public void UpdateText(String newText)
        {
            this.currentText = newText;
        }

        public void UpdateColor(float r, float g, float b, float a = 1.0f)
        {
            this.fontColor.Set(r, g, b, a);
        }


        public override Enum getName()
        {
            return this.name;
        }
        public override void Render()
        {
            Debug.Assert(this.fontColor != null);
            Debug.Assert(this.pAzulSprite != null);
            Debug.Assert(this.screenRect != null);
            Debug.Assert(this.currentText != null);
            Debug.Assert(this.currentText.Length > 0);

            float tmpX = this.x;
            float tmpY = this.y;
            float EndX = this.x;

            for (int i = 0; i < this.currentText.Length; i++)
            {
                int key = Convert.ToByte(currentText[i]);
                Glyph glyph = GlyphManager.Find(key, this.fontStyle);
                Debug.Assert(glyph != null);

                tmpX = EndX + glyph.subRect.width / 2;
                this.screenRect.Set(tmpX, tmpY, glyph.subRect.width, glyph.subRect.height);

                pAzulSprite.Swap(glyph.texture.pAzulTexture,glyph.subRect,this.screenRect, this.fontColor);

                this.pAzulSprite.Update();
                this.pAzulSprite.Render();

                EndX = glyph.subRect.width / 2 + tmpX;



            }
        }

        public override void Update()
        {
            Debug.Assert(this.pAzulSprite != null);
        }



    }
}
