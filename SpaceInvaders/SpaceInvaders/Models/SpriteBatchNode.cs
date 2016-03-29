using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpriteBatchNode:ContainerLink
    {
        /**
         * Fields
         * */
        public Sprite.Name name;
        public int index; 
        public SpriteBase pSpriteBase;
        public SpriteBatch spriteBatch;

        /**
        * SpriteBatchNode Constructor(Empty) Method
        * */
        public SpriteBatchNode(SpriteBatch sb)
        {
         //   Debug.WriteLine("SpriteBatchNode Constructor Method was called.");
            this.name = Sprite.Name.Uninitialized;
            this.pSpriteBase = null;
            this.spriteBatch = sb;
        }

        /**
        * SpriteBatchNode Constructor(Full) Method
        * */
        public SpriteBatchNode(Sprite.Name name, SpriteBatch batch, int index)
            : base()
        {
        //    Debug.WriteLine("SpriteBatchNode Constructor Method2 was called.");
            this.Set(name, batch, index);
        }


        /**
         * SpriteBatchNode Set Method (SpriteName, index)
         * */
        public void Set(Sprite.Name name,SpriteBatch batch,  int index)
        {
         //   Debug.WriteLine("SpriteBatchNode Set Method was called.");
            this.name = name;
            this.pSpriteBase = SpriteManager.Find(name);
            this.pSpriteBase.setSpriteBatchNode(this);
            this.index = index; 
        }

        /**
         * SpriteBatchNode Set Method (SpriteBase)
         * */
        public void Set(SpriteBase pNode, SpriteBatch Batch)
        {
         //   Debug.WriteLine("SpriteBatchNode Set Method2 was called.");
            Debug.Assert(pNode != null);
            pNode.setSpriteBatchNode(this);
            this.pSpriteBase = pNode;
            this.spriteBatch = Batch;
            
        }

        /**
        * SpriteBatchNode Render Method
         * */
        public void Render()
        {
         //   Debug.WriteLine("SpriteBatchNode Render Method was called.");
            this.pSpriteBase.Render();
        }

        /**
         * SpriteBatchNode Compare Function
         * */
        public bool Compare(ContainerLink pCLinkA, ContainerLink pCLinkB)
        {
          //  Debug.WriteLine("SpriteBatchNode Compare Method was called.");
            SpriteBatchNode pCLA = (SpriteBatchNode)pCLinkA;
            SpriteBatchNode pCLB = (SpriteBatchNode)pCLinkB;
            if (pCLinkA == pCLinkB) return true;
            Boolean status = false;
            if (pCLA.name == pCLB.name && pCLA.index == pCLB.index)
            {
                status = true;
            }
            return status;
        }


        /**
        * SpriteBatchNode Set Method
        * */
        public void dump()
        {
         //   Debug.WriteLine("SpriteBatchNode Dump Method was called.");
            Console.WriteLine("SpriteBatchNode Dump\n" + "----------------");
            Console.WriteLine("this.name = " + this.name);
            Console.WriteLine("this.pSpriteBase = " + this.pSpriteBase);
            Console.WriteLine("this.index = " + this.index);
        }
    }
}
