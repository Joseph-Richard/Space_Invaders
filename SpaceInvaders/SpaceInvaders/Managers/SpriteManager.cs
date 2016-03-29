using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpriteManager:Manager
    {
        //DATA----------------------------------------------------------
        //constructor, add, remove, create, compare, createnode, find, getInstance

        /**
         public int mTotalNodes; 
         public int mNumInReserve;
         public int mNumInActive;
         public int mGrowthRate;
         public DLink pReserve;
         public DLink pActive;
         * */
        private static SpriteManager pInstance;
        private Sprite pRefNode;

        /**
         * SpriteManager Constructor
         * */
        private SpriteManager(int reserveNum, int growthRate): base(reserveNum,growthRate)
        {
         //   Debug.WriteLine("SpriteManager Private Constructor 1 was called.");
            this.pRefNode = (Sprite)this.CreateNode();
        }



        /**
         * SpriteManager Add Function
         * */
        public static Sprite Add(Sprite.Name sName, Image.Name iName, float x, float y, float width, float height)
        {
        //    Debug.WriteLine("SpriteManager Add Method was called.");
            SpriteManager sm = SpriteManager.getInstance();

            Sprite sprite = (Sprite)sm.baseAdd();
            Debug.Assert(sprite != null);

            sprite.Set(sName, iName, x, y, width, height);
            return sprite;


        }



        /**
         * SpriteManager Compare Function
         * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
          //  Debug.WriteLine("SpriteManager Compare Method was called.");
            Debug.Assert(pNodeA != null && pNodeB != null);
            Sprite pSpriteA = (Sprite)pNodeA;
            Sprite pSpriteB = (Sprite)pNodeB;
            Boolean status = false;
            if (pSpriteA.name == pSpriteB.name)
            {
                status = true;
            }
            return status; 
        }

        /**
         * SpriteManager Create Function
         * */
        public static void Create(int reserveNum, int growthRate)
        {
          //  Debug.WriteLine("SpriteManager Create Method was called.");
            Debug.Assert(reserveNum > 0 && growthRate > 0);
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new SpriteManager(reserveNum, growthRate);
                Sprite fakeSprite = SpriteManager.Add(Sprite.Name.FakeObject, Image.Name.FakeObject, 0, 0, 1, 1);
            }
        }

        /**
         *SpriteManager CreateNode Function
         * */
        override protected DLink CreateNode()
        {
         //   Debug.WriteLine("SpriteManager CreateNode Method was called.");
            DLink pLink = new Sprite();
            return pLink;
        }

        /**
         * SpriteManager DumpNode Function
         * */
        public void DumpNode(Sprite pNode)
        {
         //   Debug.WriteLine("SpriteManager DumpNode Method was called.");
            pNode.Dump();
        }

        /**
         * SpriteManager Find Function
         * */
        public static Sprite Find(Sprite.Name name)
        {
        //    Debug.WriteLine("SpriteManager Find Method was called.");
            //Fake node to compare names with
            SpriteManager sMan = SpriteManager.getInstance();

            sMan.pRefNode.name = name; 
            Sprite pLink = (Sprite)sMan.baseFind(sMan.pRefNode);
            return pLink;
        }

        /**
         * SpriteManager Remove Function
         * */
        public static void Remove(Sprite pNode)
        {
        //    Debug.WriteLine("SpriteManager Remove Method was called.");
            SpriteManager sMan = SpriteManager.getInstance();
            Debug.Assert(pNode != null);
            sMan.baseRemove(pNode);
        }

        public static SpriteManager getInstance()
        {
        //    Debug.WriteLine("SpriteManager getInstance Method was called.");
            return pInstance;
        }

        protected override bool Sort(DLink pLinkA, DLink pLinkB)
        {
        //    Debug.WriteLine("SpriteManager Sort Method was called. Not Implemented");
            return false;
        }
    }
}
