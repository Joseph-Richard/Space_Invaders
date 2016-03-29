using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameObjectNode:DLink
    {
        /**
         * Fields
         * */
        public GameObject.Name name;
        public GameObject gameObject;
        public PCSTree tree;

        /**
         * GameObjectNode Constructor (Zero Args)
         * */
        public GameObjectNode()
            : base()
        {
        //    Debug.WriteLine("GameObjectNode Constructor Method was called.");
            this.name = GameObject.Name.Uninitialized;
            this.gameObject =  null;
        }

        /**
         * GameObjectNode Set Method
         * */
        public void Set(GameObject go, PCSTree tree)
        {
        //    Debug.WriteLine("GameObjectNode Set Method was called.");
            Debug.Assert(go != null);
            Debug.Assert(tree != null);
            this.gameObject = go;
            this.name = this.gameObject.name;
            this.tree = tree;
        }
        public void ResetNode()
        {
            this.gameObject = null;
        }
        /**
         * GameObject getName Method
         * */
        public Enum getName()
        {
        //    Debug.WriteLine("GameObjectNode Set Method was called.");
            return this.name;
        }
    }
}
