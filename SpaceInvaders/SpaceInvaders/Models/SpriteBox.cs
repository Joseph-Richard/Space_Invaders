using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpriteBox:SpriteBase
    {
        /**
         * Fields
         * */
        private Azul.SpriteBox pAzulSpriteBox;
        private Azul.Color pColor;
        public  SpriteBox.Name name;
        private Azul.Rect ScreenRect;

        public enum Name{Uninitialized, 
                         SpriteBox}
        
        /**
         * SpriteBox Constructor Method
         * */
        public SpriteBox()
            : base()
        {
       //     Debug.WriteLine("SpriteBox Constructor Method was called.");
            this.name = SpriteBox.Name.Uninitialized;
            this.pColor = new Azul.Color(0.5f, 0.4f, 0.3f);
            this.ScreenRect = new Azul.Rect();
            this.pAzulSpriteBox = new Azul.SpriteBox();

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }

        /**
         * SpriteBox Render Method
         * */
        override public void Render()
        {
       //     Debug.WriteLine("SpriteBox Render Method was called.");
            Debug.Assert(this.pAzulSpriteBox != null);
            this.pAzulSpriteBox.Render();
        }

        /**
         * SpriteBox Update Method
         * */
        override public void Update()
        {
        //    Debug.WriteLine("SpriteBox Update Method was called.");
            Debug.Assert(this.pAzulSpriteBox != null);

            this.pAzulSpriteBox.x = this.x;
            this.pAzulSpriteBox.y = this.y;
            this.pAzulSpriteBox.sx = this.sx;
            this.pAzulSpriteBox.sy = this.sy;
            
            this.pAzulSpriteBox.angle = this.angle;
            this.pAzulSpriteBox.SwapColor(this.pColor);

            this.pAzulSpriteBox.Update();
        }

        /**
         * SpriteBox UpdateColor Method
         * */
        public void updateColor(Azul.Color color)
        {
        //    Debug.WriteLine("SpriteBox updateColor Method was called.");
            Debug.Assert(color != null);
            this.pColor = color;
            this.pAzulSpriteBox.SwapColor(this.pColor);

        }
        public void swapScreenRect(float x, float y, float width, float height){
         //   Debug.WriteLine("SpriteBox swapScreenRect Method was called.");
            this.ScreenRect.Set(x, y, width, height);
            this.pAzulSpriteBox.SwapScreenRect(this.ScreenRect);
        }

        public void swapColors(float r, float g, float b, float a = 1.0f)
        {
         //   Debug.WriteLine("SpriteBox swapColors Method was called.");
            this.pColor.Set(r, g, b, a);
        }
        /**
         * SpriteBox Set Method
         * */
        public void Set(SpriteBox.Name sName, float x, float y, float width, float height)
        {
       //     Debug.WriteLine("SpriteBox Set Method was called.");
            Debug.Assert(this.ScreenRect != null);
            this.name = sName;

            //Update the ScreenRect
            this.ScreenRect.Set(x, y, width, height);

            //Update the Azul.SpriteBox
            this.pAzulSpriteBox.Swap(this.ScreenRect, this.pColor);
            this.angle = pAzulSpriteBox.angle;
            this.sx = pAzulSpriteBox.sx;
            this.sy = pAzulSpriteBox.sy;
            this.x = pAzulSpriteBox.x;
            this.y = pAzulSpriteBox.y;
        }

        /**
         * SpriteBox GetName Method
         * */
        override public Enum getName()
        {
        //    Debug.WriteLine("SpriteBox getName Method was called.");
            return this.name;
        }
    }
}
