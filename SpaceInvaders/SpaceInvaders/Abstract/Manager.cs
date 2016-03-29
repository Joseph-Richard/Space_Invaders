using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
     abstract class Manager
    {

         /**
          * Fields
          * */
         public int mTotalNodes; 
         public int mNumInReserve;
         public int mNumInActive;
         public int mGrowthRate;
         public DLink pReserve;
         protected DLink pActive;


         /**
          * Manager Constructor 
          * */
         protected Manager(int reserveNum, int growthRate) 
         {
             Debug.Assert(reserveNum > 0 && growthRate > 0);

             this.mGrowthRate = growthRate;
             this.mNumInReserve = 0;
             this.mNumInActive = 0;
             this.mTotalNodes = 0;
             this.pActive = null;
             this.pReserve = null;
             this.hiddenFillReservedPool(reserveNum);
         }

         /**
          * Manager BaseAdd Function
          * */
         protected DLink baseAdd()
         {
             if (pReserve == null)
             {
                 hiddenFillReservedPool(this.mGrowthRate);
             }
             DLink pLink = hiddenPullFromReserve();
             Debug.Assert(pLink != null);

             pLink.clear();
             hiddenAddToActive(pLink);
             return pLink;

         }

         /**
          * Manager BaseCreateNoAdd Method. 
          * --Does everything the baseAdd() does except that it does not add to the active DLink list. 
          * --This allows us to remove one from the reserve, and get ahold of that DLink. We can then pass it to baseAddSorted, that can add the 
          *   DLink to the approapriate location in the active list. 
          * */
         protected DLink baseCreateNoAdd()
         {
             if (pReserve == null)
             {
                 hiddenFillReservedPool(this.mGrowthRate);
             }
             DLink pLink = hiddenPullFromReserve();
             Debug.Assert(pLink != null);

             pLink.clear();
             //hiddenAddToActive(pLink);
             return pLink;
         }
         /**
          *Manager BaseAddSorted Function
          * */
         protected DLink baseAddSorted(DLink pHead)
         {
             Debug.Assert(pHead != null);
             hiddenAddToListSorted(ref pActive, pHead);
             Debug.Assert(pActive != null);
             this.mNumInActive++;
             pHead.status = DLink.Status.Active;
             return pHead;
         }
         /**
          * Manager BaseRemove Function
          * */
         protected void baseRemove(DLink pNode)
         {
             Debug.Assert(pNode != null);
             Debug.Assert(pActive != null);
             this.hiddenRemoveFromActive(pNode);
             this.hiddenAddToReserve(pNode);

         }
         /**
          * Manager BaseFind Function
          * */
         protected DLink baseFind(DLink pNode) 
         {
             DLink pLink = this.pActive;
             while (pLink != null)
             {
                 if (Compare(pNode, pLink))
                 {
                     break;
                 }
                 pLink = pLink.pNext;
             }
             return pLink; 
         }

         

         /**
          * Abstract Classes that need to be implemented in subclasses
          * */
         abstract protected DLink CreateNode();
         abstract protected Boolean Compare(DLink pLinkA, DLink pLinkB);
         virtual protected Boolean Sort(DLink dlListNode, DLink dlNodeToAdd)
         {
             return false;
         }



         /**
          * Manager hiddenFillReservedPool Method
          * --Fill the Reserve pool with the correct number of new nodes. NOT DONE
          * */
         protected void hiddenFillReservedPool(int count)
         {
             Debug.Assert(count > 0);

             this.mTotalNodes += count;
             for (int i = 0; i < count; i++)
             {
                 DLink pNode = this.CreateNode();

                 Debug.Assert(pNode != null && pNode.status == DLink.Status.Uninitialized);
                 this.hiddenAddToReserve(pNode);
             }
         }

         /**
          * Manager hiddenRemoveFromActive Method
          * --Remove a node from the Active List
          * */
         protected DLink hiddenRemoveFromActive(DLink pNode)
         {
             Debug.Assert(pNode != null);
             //Debug.Assert(pNode.status == DLink.Status.Active);

             this.hiddenRemoveNode(ref this.pActive, pNode);
             pNode.status = DLink.Status.Uninitialized;
             this.mNumInActive--;
             return pNode;
         }

         /**
          * Manager hiddenAddToActive Method
          * --Add a Node to the active List
          * */
         protected void hiddenAddToActive(DLink pNode)
         {
             Debug.Assert(pNode != null && pNode.status == DLink.Status.Uninitialized);
             hiddenAddToFront(ref this.pActive, pNode);
             pNode.status = DLink.Status.Active;
             mNumInActive++;
         }

         /**
          * Manager hiddenAddToReserve Method
          * --Add a node to he reserve List
          * */
         protected void hiddenAddToReserve(DLink pNode)
         {
             Debug.Assert(pNode != null);
             Debug.Assert(pNode.status == DLink.Status.Uninitialized);

             hiddenAddToFront(ref this.pReserve, pNode);
             pNode.status = DLink.Status.Reserve;
             mNumInReserve++;
         }


         /**
          * Manager hiddenRemoveFromReserve Method
          * --Remove a node from the Reserve List
          * */
         private void hiddenRemoveFromReserve(DLink pNode)
         {
             Debug.Assert(pNode != null);
             Debug.Assert(pNode.status == DLink.Status.Reserve);

             this.hiddenRemoveNode(ref this.pReserve, pNode);
             pNode.status = DLink.Status.Uninitialized;
             mNumInReserve--;
         }

         /**
          * Manager hiddenRemoveNode Method
          * --Remove a node from a specified DLink list
          * */
         private void hiddenRemoveNode(ref DLink pHead, DLink pNode)
         {
             Debug.Assert(pNode != null);

             if (pNode.pPrev != null)
             {
                 pNode.pPrev.pNext = pNode.pNext;
             }
             else
             {
                 pHead = pNode.pNext;
             }

             if (pNode.pNext != null)
             {
                 pNode.pNext.pPrev = pNode.pPrev;
             }
         }

         /**
          * Manager hiddenPullFromActive Method
          * --uses the general pull from front method and passes it the Active Linked List to retrieve and remove the Node from the front of that List. 
          * */
         protected DLink hiddenPullFromActive()
         {
             Debug.Assert(this.pActive != null);
             DLink pNode = hiddenPullFromFront(ref this.pActive);

             Debug.Assert(pNode != null);
             Debug.Assert(pNode.status == DLink.Status.Reserve);
             pNode.status = DLink.Status.Uninitialized;

             this.mNumInActive--;
             return pNode;
         }

         /**
          * Manager hiddenPullFromReserve Method
          * --uses the general pull from front method and passes it the Reserve Linked List to retrieve and remove the Node from the front of that List. 
          * */
         protected DLink hiddenPullFromReserve()
         {
             Debug.Assert(this.pReserve != null);
             DLink pNode = hiddenPullFromFront(ref pReserve);

             Debug.Assert(pNode != null);
             Debug.Assert(pNode.status == DLink.Status.Reserve);
             pNode.status = DLink.Status.Uninitialized;

             this.mNumInReserve--;
             return pNode;

         }

         /**
          * Manager hiddenPullFromFront Method
          * --This method takes any linked list as a parameter and removes the head Node and makes the Head.Next node the new Head Node. It returns the original Head Node. 
          * --WE NEED "ref" in the parameter so that when we update it, that the Linked list it is referencing is updated, not just a local copy.
          * */
         protected DLink hiddenPullFromFront(ref DLink pHead)
         {
             Debug.Assert(pHead != null);

             DLink pNode = pHead;

             pHead = pHead.pNext;

             if(pHead != null){
                 pHead.pPrev = null;
             }

             pNode.pPrev =null;
             pNode.pNext = null;
             return pNode;
         }

         /**
          * Manager hiddenAddToFront Method
          * --This method takes any linked list as a parameter, along with another node of the same type and adds the node that was passed to the front of the passed linked list. 
          * --WE NEED "ref" in the parameter so that when we update it, that the Linked list it is referencing is updated, not just a local copy.
          * */
         protected void hiddenAddToFront(ref DLink pHead, DLink pNodeToAdd)
         {
             Debug.Assert(pNodeToAdd != null);
             if (pHead == null){
                 pHead = pNodeToAdd;
                 pHead.pPrev = null;
                 pHead.pNext = null;
             }
             else
             {
                 //Connect the two nodes
                 pNodeToAdd.pPrev = null;
                 pNodeToAdd.pNext = pHead;
                 pHead.pPrev = pNodeToAdd;
                 
                 
                 //check to make sure the current pHead has a previous node now attached to it
                 Debug.Assert(pHead.pPrev != null);

                 //make the added node the new head of the Linked List
                 pHead = pNodeToAdd;
             }
         }

         /*
          * Manager HiddenAddToListSorted Method. 
          * --Takes a DLink Head and the DLink node to be added to that list in a sorted way. 
          * --Can technically be used for any DLink List, but right now is just used with Active.
          * */
         protected void hiddenAddToListSorted(ref DLink pHead, DLink pNodeToAdd)
         {
             Debug.Assert(pNodeToAdd != null);
             Debug.Assert(pNodeToAdd.status == DLink.Status.Uninitialized);
             DLink pFirst = pHead;
             DLink pPrevious = null;

             if (pHead == null)
             {
                 pHead = pNodeToAdd;
                 pHead.pPrev = null;
                 pHead.pNext = null;
             }
             else
             {
                 Debug.Assert(pHead != null);

                 //Go through the list until a place to put the new node is found, or the end of the list is found. 
                 while (pHead != null&&(Sort(pHead, pNodeToAdd)) == false)
                 {
                     pPrevious = pHead;
                     pHead = pHead.pNext;
                 }
                 //Console.WriteLine(pHead.);

                 if (pHead == null)         //If pHead==null this means we reached the end of the list, so add pNodeToAdd to the end of that list.
                 {
                     Debug.Assert(pPrevious!= null);
                     pPrevious.pNext = pNodeToAdd;
                     pNodeToAdd.pPrev = pPrevious;
                     pNodeToAdd.pNext = null;
                     pHead = pFirst;
                 }
                 else if(pPrevious == null)                           //If pPrevious == null this means that pNodeToAdd has the lowest time. 
                 {
                     Debug.Assert(pHead != null);
                     pNodeToAdd.pPrev = null;
                     pNodeToAdd.pNext = pHead;
                     pHead.pPrev = pNodeToAdd;
                     pHead = pNodeToAdd;
                 }
                 else                                              //this means that pNodeToAdd is between two nodes that have values.
                 {
                     pPrevious.pNext = pNodeToAdd;
                     pNodeToAdd.pPrev = pPrevious;
                     pNodeToAdd.pNext = pHead;
                     pHead.pPrev = pNodeToAdd;
                     pHead = pFirst;
                 }                
             }

         }
    }
}
