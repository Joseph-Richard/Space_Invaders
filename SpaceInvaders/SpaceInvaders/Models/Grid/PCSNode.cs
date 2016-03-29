using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class PCSNode
    {

        // Constructors: --------------------------------
        public PCSNode()
        {
        //    Debug.WriteLine("PCSNode Constructor Method was called.");
            this.parent = null;
            this.child = null;
            this.sibling = null;
            this.Forward = null;
            this.Reverse = null;
        }

        public PCSNode(PCSNode pNode)
        {
        //    Debug.WriteLine("PCSNode Constructor Method2 was called.");
            this.parent = pNode.parent;
            this.child = pNode.child;
            this.sibling = pNode.sibling;
            this.Forward = pNode.Forward;
            this.Reverse = pNode.Reverse;
        }

        public PCSNode(PCSNode pParent, PCSNode pChild, PCSNode pSibling, PCSNode forward, PCSNode Reverse)
        {
         //   Debug.WriteLine("PCSNode Constructor Method3 was called.");
            this.parent = pParent;
            this.child = pChild;
            this.sibling = pSibling;
            this.Forward = forward;
            this.Reverse = Reverse;
        }

        // Methods: set/get -------------------------------

        abstract public Enum getName();

        // Methods: Dump ------------------

        public void dumpNode()
        {
            Debug.WriteLine("PCSNode dumpNode Method was called.");
            Debug.WriteLine("");
            Debug.WriteLine("    name: {0} {1}", this.getName(), this.GetHashCode());
            if (this.parent != null)
            {
                Debug.WriteLine("  parent: {0} {1}", this.parent.getName(), this.parent.GetHashCode());
            }
            else
            {
                Debug.WriteLine("  parent: ------");
            }
            if (this.child != null)
            {
                Debug.WriteLine("   child: {0} {1}", this.child.getName(), this.child.GetHashCode());
            }
            else
            {
                Debug.WriteLine("   child: ------");
            }
            if (this.sibling != null)
            {
                Debug.WriteLine(" sibling: {0} {1}", this.sibling.getName(), this.sibling.GetHashCode());
            }
            else
            {
                Debug.WriteLine(" sibling: ------");
            }

        }

        // data ----------------------
        public PCSNode parent;
        public PCSNode child;
        public PCSNode sibling;
        public PCSNode Forward;
        public PCSNode Reverse;
    }
}
