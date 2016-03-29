using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ImageManager:Manager
    {
        //DATA------------------------------------
        /** Inherited Data
         public int mTotalNodes; 
         public int mNumInReserve;
         public int mNumInActive;
         public int mGrowthRate;
         public DLink pReserve;
         public DLink pActive;
         * */
        private static ImageManager pInstance;
        private Image referenceNode;

        //constructor, add, remove, create, compare, createnode, find, getInstance

        /**
         * ImageManager Constructor
         * */
        private ImageManager(int reserveNum, int growthRate): base(reserveNum,growthRate)
        {
            this.referenceNode = (Image)this.CreateNode();
        }
        /**
         * ImageManager Add Function
         * */
        public static Image Add(Image.Name name, Texture.Name text, float sx, float sy, float width, float height)
        {
            ImageManager IMan = ImageManager.getInstance();
            Image pNode = (Image)IMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.set(name, text, sx, sy, width, height);

            return pNode;
        }

        /**
         * ImageManager Remove Function
         * */
        public void Remove(Image pNode)
        {
            Debug.Assert(pNode != null);
            this.baseRemove(pNode);
        }

        /**
         * ImageManager Compare Function
         * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
            Debug.Assert(pNodeA != null && pNodeB != null);
            Image pImageA = (Image)pNodeA;
            Image pImageB = (Image)pNodeB;
            Boolean status = false;
            if (pImageA.name == pImageB.name)
            {
                status = true;
            }
            return status;
        }

        /**
         * ImageManager Create Function
         * */
        public static void Create(int reserveNum, int growthRate)
        {
            Debug.Assert(reserveNum > 0 && growthRate > 0);
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new ImageManager(reserveNum, growthRate);
                Image image = ImageManager.Add(Image.Name.FakeObject, Texture.Name.FakeObject, 0, 0, 1, 1);
                Debug.Assert(image != null);
            }
        }

        /**
         * TODO: ImageManager Create Node Function
         * */
        override protected DLink CreateNode()
        {
            DLink pLink = new Image();
            return pLink;
        }

        /*
         * ImageManager DumpNode Function
         * */
        public void DumpNode(Image pNode)
        {
            pNode.dump();
        }


        /**
         * ImageManager Find Function
         * */
        public static Image Find(Image.Name name)
        {
            ImageManager imageMan = ImageManager.getInstance();
            imageMan.referenceNode.name = name;
            Image pLink = (Image)imageMan.baseFind(imageMan.referenceNode);
            return pLink;
        }


        /**
         * ImageManager GetInstance()
         * */
        public static ImageManager getInstance()
        {
            return pInstance;
        }

        protected override bool Sort(DLink pLinkA, DLink pLinkB)
        {
            return false;
        }
    }
}
