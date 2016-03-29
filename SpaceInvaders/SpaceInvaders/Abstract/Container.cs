using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{   /**
     * Not much different from the Manager functions
     * */
    abstract class Container:DLink
    {
        /**
         * Fields
         * */
        public ContainerLink pReserve;
        public ContainerLink pActive;
        public int mCNumInReserve;
        public int mCNumInActive;
        public int mCGrowthRate;
        public int mCTotalNodes; 

        /**
         * Abstract Methods
         * */
        abstract protected Boolean Compare(ContainerLink pCLinkA, ContainerLink pCLinkB);
        abstract protected ContainerLink CreateNode();
        

        /**
         * Container Constructor Method
         * --Calls base DLink constructor
         * */
        protected Container(int reserveNum=3, int growthRate=2):base()
         {
             Debug.Assert(reserveNum > 0 && growthRate > 0);

             this.mCGrowthRate = growthRate;
             this.mCNumInReserve = 0;
             this.mCNumInActive = 0;
             this.mCTotalNodes = 0;
             this.pActive = null;
             this.pReserve = null;
             this.hiddenFillReservedPool(reserveNum);
         }

        /**
         * Container baseAdd Method
         * */
        protected ContainerLink baseAdd()
        {
            if (pReserve == null)
            {
                this.hiddenFillReservedPool(this.mCGrowthRate);
            }
            ContainerLink pLink = this.hiddenPullFromReserve();
            Debug.Assert(pLink != null);

            pLink.clear();
            this.hiddenAddToActive(pLink);
            return pLink;

        }

        /**
         * Container BaseFind Function
         * */
        protected ContainerLink baseFind(ContainerLink pNode)
        {
            ContainerLink pLink = this.pActive;
            while (pLink != null)
            {
                if (Compare(pNode, pLink))
                {
                    break;
                }
                pLink = pLink.pCNext;
            }
            return pLink;
        }

        /**
          * Container BaseRemove Function
          * */
        protected void baseRemove(ContainerLink pNode)
        {
            Debug.Assert(pNode != null && pActive != null);
            this.hiddenRemoveFromActive(pNode);
            this.hiddenAddToReserve(pNode);

        }
        


         /**
          * Container hiddenFillReservedPool Method
          * --Fill the Reserve pool with the correct number of new nodes. NOT DONE
          * */
         protected void hiddenFillReservedPool(int count)
         {
             Debug.Assert(count > 0);

             this.mCTotalNodes += count;
             for (int i = 0; i < count; i++)
             {
                 ContainerLink pNode = this.CreateNode();

                 Debug.Assert(pNode != null && pNode.status == ContainerLink.Status.Uninitialized);
                 this.hiddenAddToReserve(pNode);
             }
         }

         /**
          * Container hiddenRemoveFromActive Method
          * --Remove a node from the Active List NOT DONE
          * */
         protected void hiddenRemoveFromActive(ContainerLink pNode)
         {
             Debug.Assert(pNode != null);

             this.hiddenRemoveNode(ref this.pActive, pNode);
             pNode.status = ContainerLink.Status.Uninitialized;

             mCNumInActive--;
         }

         /**
          * Container hiddenAddToActive Method
          * --Add a Node to the active List
          * */
         protected void hiddenAddToActive(ContainerLink pNode)
         {
             Debug.Assert(pNode != null && pNode.status == ContainerLink.Status.Uninitialized);
             hiddenAddToFront(ref this.pActive, pNode);
             pNode.status = ContainerLink.Status.Active;
             mCNumInActive++;
         }

         /**
          * Container hiddenAddToReserve Method
          * --Add a node to the Reserve List
          * */
         protected void hiddenAddToReserve(ContainerLink pNode)
         {
             Debug.Assert(pNode != null && pNode.status == ContainerLink.Status.Uninitialized);
             hiddenAddToFront(ref this.pReserve, pNode);
             pNode.status = ContainerLink.Status.Reserve;
             mCNumInReserve++;
         }


         /**
          *Container hiddenPullFromActive Method
          * --uses the general pull from front method and passes it the Active Linked List to retrieve and remove the Node from the front of that List. 
         * */
         protected ContainerLink hiddenPullFromActive()
         {
             Debug.Assert(this.pActive != null);
             ContainerLink pNode = hiddenPullFromFront(ref this.pActive);

             Debug.Assert(pNode != null);
             Debug.Assert(pNode.status == ContainerLink.Status.Reserve);
             pNode.status = ContainerLink.Status.Uninitialized;

             this.mCNumInActive--;
             return pNode;
         }

         /**
          * Container hiddenPullFromReserve Method
          * uses the general pull from front method and passes it the Reserve Linked List to retrieve and remove the Node from the front of that List. 
          * */
         protected ContainerLink hiddenPullFromReserve()
         {
             Debug.Assert(this.pReserve != null);
             ContainerLink pNode = hiddenPullFromFront(ref pReserve);

             Debug.Assert(pNode != null);
             Debug.Assert(pNode.status == ContainerLink.Status.Reserve);
             pNode.status = ContainerLink.Status.Uninitialized;

             this.mCNumInReserve--;
             return pNode;

         }

         /**
          * Container hiddenPullFromFront Method
          * --This method takes any linked list as a parameter and removes the head Node and makes the Head.Next node the new Head Node. It returns the original Head Node. 
          * --WE NEED "ref" in the parameter so that when we update it, that the Linked list it is referencing is updated, not just a local copy.
          * */
         protected ContainerLink hiddenPullFromFront(ref ContainerLink pHead)
         {
             Debug.Assert(pHead != null);

             ContainerLink pNode = pHead;

             pHead = pHead.pCNext;

             if(pHead != null){
                 pHead.pCPrev = null;
             }

             pNode.pCPrev =null;
             pNode.pCNext = null;
             return pNode;
         }

         /**
          * Container hiddenAddToFront Method
          * --This method takes any linked list as a parameter, along with another node of the same type and adds the node that was passed to the front of the passed linked list. 
          * --WE NEED "ref" in the parameter so that when we update it, that the Linked list it is referencing is updated, not just a local copy.
          * */
         protected void hiddenAddToFront(ref ContainerLink pHead, ContainerLink pNodeToAdd)
         {
             Debug.Assert(pNodeToAdd != null);
             if (pHead == null)
             {
                 pHead = pNodeToAdd;
                 pHead.pCPrev = null;
                 pHead.pCNext = null;
             }
             else
             {
                 //Connect the two nodes
                 pHead.pCPrev = pNodeToAdd;
                 pNodeToAdd.pCNext = pHead;
                 pNodeToAdd.pCPrev = null;
                 //check to make sure the current pHead has a previous node now attached to it
                 Debug.Assert(pHead.pCPrev != null);

                 //make the added node the new head of the Linked List
                 pHead = pNodeToAdd;
             }

         }

         private void hiddenRemoveNode(ref ContainerLink pHead, ContainerLink nodeToRemove)
         {
             Debug.Assert(nodeToRemove != null);
             if (nodeToRemove.pCPrev != null)
             {
                 nodeToRemove.pCPrev.pCNext = nodeToRemove.pCNext;
             }
             else
             {
                 pHead = nodeToRemove.pCNext;
             }

             if (nodeToRemove.pCNext != null)
             {
                 nodeToRemove.pCNext.pCPrev = nodeToRemove.pCPrev;
             }
         }

    }
}
