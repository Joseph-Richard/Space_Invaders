using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class TreeIterator
    {
       // private PCSNode rootNode;
       // private PCSNode currentNode;
        private static GameObject root;
        private static GameObject current;
        private static GameObject wrongParent;
        /**
         * TreeIterator Constructord Method
         * */
        public static void Calculate(GameObject pRootNode)
        {
         //   Console.WriteLine("Entering Calculate inside TreeIterator.cs");


            Debug.Assert(pRootNode != null);
            TreeIterator.root = pRootNode;
            TreeIterator.wrongParent = (GameObject)pRootNode.parent;

            TreeIterator.current = TreeIterator.root;

            GameObject pPrevGameObject = (GameObject)pRootNode;
           
            GameObject pGameObject = (GameObject)pRootNode;

            while (pGameObject != null)
            {
                pPrevGameObject = pGameObject;

                pGameObject = TreeIterator.getNext();
                pPrevGameObject.Forward = pGameObject;
                
                if (pGameObject != null)
                {
                    pGameObject.Reverse = pPrevGameObject;
                }
            }
            pRootNode.Reverse = pPrevGameObject;

         //   Console.WriteLine("Leaving Calculate inside TreeIterator.cs");
        }



        //public TreeIterator(GameObject root)
      //  {
      //      Debug.WriteLine("TreeIterator Constructor Method was called.");
     //       this.rootNode = root;
     //       this.currentNode = this.rootNode;
     //   }

        /**
         * TreeIterator getCurrent Method.
         * */
      //  public PCSNode getCurrent()
      //  {
     //       Debug.WriteLine("TreeIterator getCurrent Method was called.");
     //       return this.currentNode;
    //    }


        /**
         * Tree Iterator getRoot Method.
         * */
     //   public PCSNode getRoot()
    //    {
    //        Debug.WriteLine("TreeIterator getRoot Method was called.");
   //         return this.currentNode;
   //     }

        /**
         * Tree Iterator getNext Method.
         * */
        public static GameObject getNext()
        {
            
            TreeIterator.current = getNextPCSNode(TreeIterator.current);
            return (GameObject)TreeIterator.current;

           // Debug.WriteLine("TreeIterator getNext Method was called.");
            //PCSNode next = this.getNextPCSNode((GameObject)this.currentNode);
            //this.currentNode = next;
            //return this.currentNode;
        }

    //    public static void resetTree()
    //    {
     //       Debug.WriteLine("TreeIterator resetTree Method was called.");
      //      TreeIterator.current = TreeIterator.root;
       // }

        /**
         * Tree Iterator Private get next PCS Node Method
         * -- This method takes the current node, and checks to see if all the siblings have been run through. If no, then the next sibling is returned. 
         * -- If current.sibling == null, then we drob down a level on the tree and check the first child
         * -- Finally, if the parent of the current node is not equal to the root of the iterator, we go up a level in the tree and start the process over. 
         * */
        private static GameObject getNextPCSNode(GameObject node, Boolean visitChild = true)
        {
            //Debug.WriteLine("TreeIterator getNextPCSNode Method was called.");
            //Debug.Assert(current != null);
           
            GameObject tmp = null;
            
            if ((node.child != null) && visitChild)
            {
                tmp = (GameObject)node.child;
                
            }
            else if (node.sibling != null)
            {
                tmp = (GameObject)node.sibling;
                
            }
            
            else if(node.parent != TreeIterator.root && node.parent != TreeIterator.wrongParent)
            {
                tmp = TreeIterator.getNextPCSNode((GameObject)node.parent, false);
            }
            else
            {
                tmp = null; 
            }

            return tmp;

        }
    }
}
