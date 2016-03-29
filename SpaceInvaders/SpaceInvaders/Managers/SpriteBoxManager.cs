using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpriteBoxManager:Manager
    {
        private static SpriteBoxManager pInstance;
        private SpriteBox referenceBox;
        //TODO: DO i need to add an index for each sprite box?

        /**
         * Sprite Box Manager Constructor
         * */
        private SpriteBoxManager(int reserveNum, int growthRate): base(reserveNum,growthRate)
        {
        //    Debug.WriteLine("SpriteBoxManager Private Constructor 1 was called.");
            this.referenceBox = (SpriteBox)this.CreateNode();
        }

        /**
         * Sprite Box Manager Create Method
         * */
        public static void Create(int reserveNum, int growthRate)
        {
        //    Debug.WriteLine("SpriteBoxManager Create Method was called.");
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new SpriteBoxManager(reserveNum, growthRate);
                //SpriteBox fakeSpriteBox = SpriteBoxManager.Add(new Azul.Rect());

            }
        }

        /**
         * Sprite Box Manager Create Method
         * */
        public static SpriteBox Add(Azul.Rect rect)
        {
         //   Debug.WriteLine("SpriteBoxManager Add Method was called.");
            SpriteBoxManager sbm = SpriteBoxManager.getInstance();
            Debug.Assert(sbm != null);
            SpriteBox sBox = (SpriteBox)sbm.baseAdd();
            sBox.Set(SpriteBox.Name.SpriteBox, rect.x, rect.y, rect.width, rect.height);
            return sBox;  

        }

        public static SpriteBox Add(SpriteBox.Name name, float x, float y, float width, float height)
        {
            SpriteBoxManager sbm = SpriteBoxManager.getInstance();
            SpriteBox sBox = (SpriteBox)sbm.baseAdd();
            sBox.Set(name, x, y, width, height);
            return sBox;
        }

        /**
        *SpriteBoxManager CreateNode Function
        * */
        override protected DLink CreateNode()
        {
         //   Debug.WriteLine("SpriteBoxManager Create Node Method was called.");
            DLink pLink = new SpriteBox();
            return pLink;
        }

        /**
         * Sprite Box Manager Compare Method
         * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
         //   Debug.WriteLine("SpriteBoxManager Compare Method was called.");
            Debug.Assert(pNodeA != null && pNodeB != null);
            SpriteBox pSBoxA = (SpriteBox)pNodeA;
            SpriteBox pSBoxB = (SpriteBox)pNodeB;
            Boolean status = false;
            if (pSBoxA.getName() == pSBoxB.getName())
            {
                status = true;
            }
            return status;
        }

        /**
         * SpriteBox Manager Find Function
         * */
        public static Sprite Find(SpriteBox.Name name)
        {
        //    Debug.WriteLine("SpriteBoxManager Find Method was called.");
            //Fake node to compare names with
            SpriteBoxManager sbm = SpriteBoxManager.getInstance();

            sbm.referenceBox.name = name;
            Sprite pLink = (Sprite)sbm.baseFind(sbm.referenceBox);
            return pLink;
        }


        /**
         * SpriteBoxManager Sort Method (Not Implemented)
         * */
        protected override bool Sort(DLink pLinkA, DLink pLinkB)
        {
         //   Debug.WriteLine("SpriteBoxManager Sort Method was called. Not Implemented");
            return false;
        }


        /**
        * SpriteBoxManager Remove Function
        * */
        public static void Remove(SpriteBox pNode)
        {
         //   Debug.WriteLine("SpriteBoxManager Remove Method was called.");
            SpriteBoxManager sbm = SpriteBoxManager.getInstance();
            Debug.Assert(pNode != null);
            sbm.baseRemove(pNode);
        }

        /**
         * SpriteBoxManager getInstance Method
         * */
        public static SpriteBoxManager getInstance()
        {
        //    Debug.WriteLine("SpriteBoxManager get Instance Method was called.");
            return pInstance;
        }
    }
}
