using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpriteBatch:Container
    {

        /**
         * Fields
         * */
        public SpriteBatch.Name name;
        public Boolean isInvisible;
        public enum Name { Uninitialized, 
                            Aliens,
                            StupidColumns,
                            SpriteBoxes,
                            Background,
                            Foreground,
                            Shields,
                            UFO, 
                            Bombs, 
                            PlayerShip, 
                            ScreenText,
                            
                            SelectScreenText, 
                            GameScreenText, 
                            GameOverScreenText,     
                            Walls, 
                            Explosions, 
                            Score }

        /**
         * SpriteBatch Constructor
         * */
        public SpriteBatch(SpriteBatch.Name name, int reserveNum=3, int growthRate=2):base(reserveNum, growthRate)
        {
        //    Debug.WriteLine("SpriteBatch Constructor Method was called.");
            this.name = name;
            this.isInvisible = false;
        }

        /**
         * SpriteBatch Set Method
         * */
        public void Set(SpriteBatch.Name name, int reserveNum, int growthRate){
          //  Debug.WriteLine("SpriteBatch Set Method was called.");
            this.name = name;
            this.mCNumInReserve = reserveNum;
            this.mCGrowthRate = growthRate;
            this.isInvisible = false;
        }

        /**
         * SpriteBatch Compare Method
         * */
        protected override bool Compare(ContainerLink pCLinkA, ContainerLink pCLinkB)
        {
        //    Debug.WriteLine("SpriteBatch Compare Method was called.");
            throw new NotImplementedException();
        }

        /**
         * SpriteBatch CreateNode Method
         * */
        protected override ContainerLink CreateNode()
        {
         //   Debug.WriteLine("SpriteBatch CreateNode Method was called.");
            SpriteBatchNode pSBNode = new SpriteBatchNode(this);
            Debug.Assert(pSBNode != null);
            return pSBNode;
        }

        /**
         * SpriteBatch Attach Method
         * */
        public void Attach(SpriteBase sb)
        {
         //   Debug.WriteLine("SpriteBatch Attach Method was called.");
            SpriteBatchNode pSBNode = (SpriteBatchNode)this.baseAdd();
            Debug.Assert(pSBNode != null);
            pSBNode.Set(sb, this);
        }

        /**
         * SpriteBatch Attach Method
         * */
        public void Attach(ProxySprite node)
        {
        //    Debug.WriteLine("SpriteBatch Attach Method was called.");
            SpriteBatchNode spriteBatchNode = (SpriteBatchNode)this.baseAdd();
            Debug.Assert(spriteBatchNode != null);
            Debug.Assert(node != null);
            spriteBatchNode.Set(node, this);
        }

        public void Remove(SpriteBatchNode node)
        {
            this.baseRemove(node);
        }

        /**
         * SpriteBatch Dump Method
         * */
        public void Dump()
        {
         //   Debug.WriteLine("SpriteBatch Dump Method was called.");
            Console.WriteLine("SpriteBatch Dump--------------");
            Console.WriteLine("this.name = "+this.name);
            Console.WriteLine("SpriteBatch Dump Ended--------------");
        }

        public void RenderInvisible()
        {
            this.isInvisible = true; 
        }

        public void MakeVisible()
        {
            this.isInvisible = false;
        }
        
    }
}
