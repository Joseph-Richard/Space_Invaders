using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class TextureManager:Manager
    {
        //DATA--------------------------------------------------------------------------
        /**inherited fields
         public int mNumTotalNodes; 
         public int mNumInReserve;
         public int mNumInActive;
         public int mReserveGrowth;
         public DLink pReserve;
         public DLink pActive;
         * 
         * */
        private static TextureManager pInstance;
        private Texture referenceNode;
        //private Texture pRefNode;

        /**
         * TextureManager Constructor
         * */
                private TextureManager(int reserveNum, int growthRate): base(reserveNum,growthRate)
        {
            this.referenceNode = (Texture)this.CreateNode();
        }

        /**
         * Add Function-------------------------------------------------------------------------------
         * */
                public static Texture Add(Texture.Name name, String fname, Azul.Texture_Filter minFilter = Azul.Texture_Filter.NEAREST, Azul.Texture_Filter magFilter = Azul.Texture_Filter.NEAREST) 
        {
            TextureManager textMan = TextureManager.getInstance();
            Texture pNode = (Texture)textMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, fname, minFilter, magFilter);

            return pNode;

        }

        /**
         * Remove Function------------------------------------------------------------------------------
         * */
        public static void Remove(Texture pNode)
        {
            TextureManager textMan = TextureManager.getInstance();
            Debug.Assert(pNode != null);
            textMan.baseRemove(pNode);
        }

        /**
         * Compare Function-----------------------------------------------------------------------------
         * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);
            Texture pTextA = (Texture)pNodeA;
            Texture pTextB = (Texture)pNodeB;
            Boolean status = false;
            if (pTextA.name == pTextB.name)
            {
                status = true;
            }
            return status;
        }

        /**
         * Create Function--------------------------------------------------------------------------
         * */
        public static TextureManager Create(int reserveNum = 3, int growthRate = 2)
        {
            Debug.Assert(reserveNum > 0 && growthRate > 0);
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new TextureManager(reserveNum, growthRate);
                Texture fakeText = TextureManager.Add(Texture.Name.FakeObject, "aliens.tga");
            }
            return pInstance;
            
        }

        /**
         * Create Node Function----------------------------------------------------------------------
         * */
        override protected DLink CreateNode()
        {
            DLink pLink = new Texture();
            return pLink;
        }

        /**
         * Dump Node Function------------------------------------------------------------------------------
         * */
        public static void DumpNode(Texture pNode)
        {
            pNode.dump();
        }

        /**
         * Find Function-----------------------------------------------------------------------------------
         * */
        public static Texture Find(Texture.Name name) 
        {
            TextureManager textMan = TextureManager.getInstance();
            textMan.referenceNode.name = name;
            //DLink pDLink = (DLink)pNodeA;
            Texture pLink = (Texture)textMan.baseFind(textMan.referenceNode);
            return pLink; 
        }

        public static TextureManager getInstance()
        {
            return pInstance;
        }

        protected override bool Sort(DLink pLinkA, DLink pLinkB)
        {
            return false;
        }

    }
}
