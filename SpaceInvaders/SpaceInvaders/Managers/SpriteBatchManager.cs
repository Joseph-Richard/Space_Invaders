using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpriteBatchManager:Manager
    {
        private static SpriteBatchManager pInstance;
        private SpriteBatch pRefNode; 
        //constructor, add, remove, create, compare, createnode, find, getInstance
        //NOTE for me: PRETTY MUCH A DIRECT COPY OF THE OTHER MANAGERS. SOME CHANGES NECESSARY. 
        /**
         * TextureManager Constructor
         * */
        private SpriteBatchManager(int reserveNum, int growthRate): base(reserveNum,growthRate)
        {
        //    Debug.WriteLine("SpriteBatchManager Private Constructor 1 was called.");
            this.pRefNode = (SpriteBatch)this.CreateNode();
        }

        /**
         *SpriteBatchManager Add Function
         * */
        public static SpriteBatch Add(SpriteBatch.Name sName, int reserveNum, int growthRate)
        {
         //   Debug.WriteLine("SpriteBatchManager Add Method was called.");
            SpriteBatchManager sBMan = SpriteBatchManager.getInstance();
            SpriteBatch pNode = (SpriteBatch)sBMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(sName,reserveNum, growthRate);
            Debug.Assert(pNode != null);

            return pNode;


        }


        public static void RenderInvisible(SpriteBatch.Name name)
        {
            SpriteBatch sb = SpriteBatchManager.Find(name);
            sb.RenderInvisible();
            Debug.Assert(sb.isInvisible == true);
        }

        public static void MakeVisible(SpriteBatch.Name name)
        {
            SpriteBatch sb = SpriteBatchManager.Find(name);
            sb.MakeVisible();
            Debug.Assert(sb.isInvisible == false);
        }



        /**
         *SpriteBatchManager Remove Function
         * */
        public static void Remove(SpriteBatch pNode)
        {
            SpriteBatchManager sbm = SpriteBatchManager.getInstance();
         //   Debug.WriteLine("SpriteBatchManager Remove Method was called.");
            Debug.Assert(pNode != null);
            sbm.baseRemove(pNode);
        }

        public static void Remove(SpriteBatchNode pNode)
        {
            Debug.Assert(pNode != null);
            SpriteBatchManager sbm = SpriteBatchManager.getInstance();
            SpriteBatch sb = pNode.spriteBatch;
            sb.Remove(pNode);
            
        }
        /**
         *SpriteBatchManager Create Function
         * */
        public static void Create(int reserveNum, int growthRate)
        {

         //   Debug.WriteLine("SpriteBatchManager Create Method was called.");
            Debug.Assert(reserveNum > 0 && growthRate > 0);
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new SpriteBatchManager(reserveNum, growthRate);
            }
        }
        /**
         *SpriteBatchManager Compare Function
         * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
        //    Debug.WriteLine("SpriteBatchManager Compare Method was called.");
            Debug.Assert(pNodeA != null && pNodeB != null);
            SpriteBatch pSBatchA = (SpriteBatch)pNodeA;
            SpriteBatch pSBatchB = (SpriteBatch)pNodeB;
            Boolean status = false;
            if (pSBatchA.name == pSBatchB.name)
            {
                status = true;
            }
            return status;
        }
        /**
        *SpriteBatchManager CreateNode Function
        * */
        protected override DLink CreateNode()
        {
        //    Debug.WriteLine("SpriteBatchManager CreateNode Method was called.");
            DLink pLink = new SpriteBatch(SpriteBatch.Name.Uninitialized);
            return pLink;
        }
        /**
         *SpriteBatchManager Find Function
         * */
        public static SpriteBatch Find(SpriteBatch.Name name)
        {
         //   Debug.WriteLine("SpriteBatchManager Find Method was called.");
            SpriteBatchManager sBMan = SpriteBatchManager.getInstance();
            sBMan.pRefNode.Set(name, 0, 0);
            SpriteBatch pLink = (SpriteBatch)sBMan.baseFind(sBMan.pRefNode);
            return pLink;
        }

        /*
         * SpriteBatchManager DumpNode Function
         * */
        public void DumpNode(SpriteBatch pNode)
        {
         //   Debug.WriteLine("SpriteBatchManager DumpNode Method was called.");
            Debug.Assert(pNode != null);
            pNode.Dump();
        }

          public static void Draw()
        {
         //   Debug.WriteLine("SpriteBatchManager Draw Method was called.");
            SpriteBatchManager sbm = SpriteBatchManager.getInstance();
            SpriteBatchNode sbn = null;
            //Cast to SpriteBatch from DLink
            SpriteBatch sb = (SpriteBatch)sbm.pActive;
            //get a batch of sprites
            //Iterate through them and call Render()

                while (sb != null)
                {
                    if (sb.isInvisible == false)
                    {
                        sbn = (SpriteBatchNode)sb.pActive;
                        while (sbn != null)
                        {
                            sbn.pSpriteBase.Render();
                            sbn = (SpriteBatchNode)sbn.pCNext;
                        }
                    }
                    sb = (SpriteBatch)sb.pNext;
                }
            
        }
        /**
         *SpriteBatchManager GetInstance Function
         * */
        public static SpriteBatchManager getInstance()
        {
        //    Debug.WriteLine("SpriteBatchManager getInstance Method was called.");
            Debug.Assert(pInstance != null);
            return pInstance;
        }

        protected override bool Sort(DLink pLinkA, DLink pLinkB)
        {
        //    Debug.WriteLine("SpriteBatchManager Sort Method was called. Not Implemented");
            return false;
        }
    }
}
