using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameObjectManager:Manager
    {
        //constructor, add, remove, create, compare, createnode, find, getInstance
        private static GameObjectManager pInstance;
        private GameObjectNode reference;
        private PCSTree treeRoot;
        /**
         * GameObjectManager Constructor
         * */
            private GameObjectManager(int reserveNum=3, int growthRate=2): base(reserveNum,growthRate)
        {
        //    Debug.WriteLine("GameObjectManager private Constructor was called.");
            this.reference = (GameObjectNode)this.CreateNode();
            this.reference.gameObject = new FakeGameObject();
            this.treeRoot = new PCSTree();
        }

        /**
         * GameObjectManager Create Method
         * */
        public static void Create(int reserveNum = 3, int growthRate = 2)
        {
        //    Debug.WriteLine("GameObjectManager Create(3,2) Method was called.");
            Debug.Assert(pInstance == null);
             if (pInstance == null)
            {
                pInstance = new GameObjectManager(reserveNum, growthRate);
            }
        }


        /**
         *GameObjectManager Attach Method
         * */
        public static GameObjectNode Attach(GameObject goNode, PCSTree tree)
        {
        //    Debug.WriteLine("GameObjectManager Attach Method was called.");
            Debug.Assert(tree != null);

            GameObjectManager gom = GameObjectManager.getInstance();
            GameObjectNode temp = (GameObjectNode)gom.baseAdd();

            Debug.Assert(temp != null);
            

            temp.Set(goNode, tree);
            return temp;
         
        }

        /**
         * GameObjectManager Compare Method
         * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
       //     Debug.WriteLine("GameObjectManager Compare Method was called.");
            Debug.Assert(pNodeA != null && pNodeB != null);
           // GameObjectNode gonA = (GameObjectNode)pNodeA;
          //  GameObjectNode gonB = (GameObjectNode)pNodeB;
           // Boolean status = false;
         //   if (gonA.gameObject.name == gonB.gameObject.name)
         //   {
        //        status = true;
           // }
            return false;
        }
        /**
         *GameObjectManager Remove Method
         * */
        public static void Remove(GameObject goNode)
        {
         //   Debug.WriteLine("GameObjectManager Remove Method was called.");
            Debug.Assert(goNode != null);
            GameObjectManager gom = GameObjectManager.getInstance();
            
            GameObject temp = (GameObject)goNode;

            GameObject node = goNode;
            GameObject root = null;
            while (node != null)
            {
                root = node;
                node = (GameObject)node.parent;
            }

            GameObjectNode totalTree = (GameObjectNode)gom.pActive;

            while (totalTree != null)
            {
                if (totalTree.gameObject == root)
                {
                    break;
                }
                totalTree = (GameObjectNode)totalTree.pNext;
            }
            if (totalTree != null)
            {
                gom.treeRoot.setRoot(totalTree.gameObject);
            }
            gom.treeRoot.Remove(goNode);


        }

        public static void Insert(GameObject gameObject, GameObject parent)
        {
            GameObjectManager gom = GameObjectManager.getInstance();

            if (parent == null)
            {
                GameObjectManager.Attach(gameObject, null);
            }
            else
            {
                gom.treeRoot.setRoot(parent);
                gom.treeRoot.Insert(gameObject, parent);
            }
        }

        /**
         * GameObjectManager Update Method
         * --Just a standard loop through the nodes and call update on their associated gameobjects.
         * */
        public static void Update()
        {
            GameObjectManager gom = GameObjectManager.getInstance();
            GameObjectNode rootNode = (GameObjectNode)gom.pActive;

            while (rootNode != null)
            {
            //    Console.WriteLine("Creating forward Iterator");
                BackwardIterator iterator = new BackwardIterator(rootNode.gameObject);
               // Console.WriteLine("Calling Iterator.First()");
                GameObject gameObj = (GameObject)iterator.First();

                while (!iterator.isDone())
                {
                //    Console.WriteLine("{0}({1}) is being called in GameObjectManager.Update()",gameObj.getName(), gameObj.getIndex());
                    gameObj.Update();

                    gameObj = (GameObject)iterator.Next();
                }
                rootNode = (GameObjectNode)rootNode.pNext;

            }
        }

        public static void RemoveAll()
        {
            GameObjectManager gom = GameObjectManager.getInstance();
            GameObjectNode rootNode = (GameObjectNode)gom.pActive;

            while (rootNode != null)
            {
                //    Console.WriteLine("Creating forward Iterator");
                BackwardIterator iterator = new BackwardIterator(rootNode.gameObject);
                // Console.WriteLine("Calling Iterator.First()");
                GameObject gameObj = (GameObject)iterator.First();

                while (!iterator.isDone())
                {
                    //    Console.WriteLine("{0}({1}) is being called in GameObjectManager.Update()",gameObj.getName(), gameObj.getIndex());
                    //GameObjectManager.Remove(gameObj);
                    gameObj.Remove();
                    gameObj = (GameObject)iterator.Next();
                }
                rootNode = (GameObjectNode)rootNode.pNext;

            }
        }

        /**
         *GameObjectManager CreateNode Method
         * */
        protected override DLink CreateNode()
        {
        //    Debug.WriteLine("GameObjectManager CreateNode Method was called.");
            DLink go = new GameObjectNode();
            Debug.Assert(go != null);
            return go;
        }
        /**
         *GameObjectManager Find Method
         * */
        public static GameObject Find(GameObject.Name name, int index = 0)
        {
         //   Debug.WriteLine("GameObjectManager Find Method was called.");
            GameObjectManager gom = GameObjectManager.getInstance();
            GameObject temp = gom.reference.gameObject;
            
            temp.name = name;
            temp.index = index;


            GameObjectNode rootNode = (GameObjectNode)gom.pActive;
            Boolean isFound = false;
            GameObject gameObject = null;


            while (rootNode != null && isFound == false)
            {
                ForwardIterator iterator = new ForwardIterator(rootNode.gameObject);
                gameObject = (GameObject)iterator.First();

                while (!iterator.isDone())
                {

                    if (gameObject.name == temp.name && gameObject.index == temp.index)
                    {
                        isFound = true;
                        break;
                    }
                    gameObject = (GameObject)iterator.Next();

                }
                rootNode = (GameObjectNode)rootNode.pNext;
            }
            return gameObject;

        }

        public static PCSTree getTree()
        {
            GameObjectManager gmo = GameObjectManager.getInstance();
            Debug.Assert(gmo != null);
            return gmo.treeRoot;
        }

        /**
         * GameObject Sort Method
         * */
        protected override bool Sort(DLink pLinkA, DLink pLinkB)
        {
        //    Debug.WriteLine("GameObjectManager Sort Method was called. Not Implemented");
            return false;
        }

        /**
         * GameObjectManager GetInstance Method
         * */
        public static GameObjectManager getInstance()
        {
         //   Debug.WriteLine("GameObjectManager get Instance Method was called.");
            Debug.Assert(pInstance != null);
            return pInstance;
        }
    }
}
