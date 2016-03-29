using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class CollisionPair:DLink
    {
        private GameObject treeA;
        private GameObject treeB;
        private CollisionPair.Name name;
        private CollisionGroup collisionGroup;
        //private TreeIterator treeIteratorA;
        //private TreeIterator treeIteratorB;
        //TODO Index: DO I NEED IT?

        public enum Name {AlienVsMissle, AlienVsWall, AlienVsShield,
                          FryshipVsWall,
                          MissleVsUFO, MissleVsShield, MissileVsWall,
                          BombVsMissle, BombVsShield, BombVsFryship, BombVsWall,
                          UFOVsWall,
                          Uninitialized,
                            }

        /**
         * CollisionPair Constructor
         * */
        public CollisionPair()
            : base()
        {
        //    Debug.WriteLine("CollisionPair Constructor Method was called.");
            this.treeA = null;
            this.treeB = null;
            this.name = Name.Uninitialized;
            this.collisionGroup = new CollisionGroup();

        }

        public void set(Name name, GameObject treeRootA, GameObject treeRootB)
        {
        //    Debug.WriteLine("CollisionPair set Method was called.");
            Debug.Assert(name != Name.Uninitialized);
            Debug.Assert(treeRootA != null);
            Debug.Assert(treeRootB != null);
            this.name = name;
            this.treeA = treeRootA;
            this.treeB = treeRootB;

        }

        public void updateCollisionGroup(GameObject a, GameObject b)
        {
            Debug.Assert(a != null);
            Debug.Assert(b != null);
            this.collisionGroup.setObjA(a);
            this.collisionGroup.setObjB(b);
        }

        public void process()
        {
            checkForCollision(this.treeA, this.treeB);
        }

        public void AddListenter(Observer o)
        {
            Debug.Assert(o != null);
            this.collisionGroup.AttachObserver(o);
        }

        public void NotifyListeners()
        {
            this.collisionGroup.NotifyAll();
        }
        /**
         * 
         * */
        public static void checkForCollision(GameObject trA, GameObject trB)
        {
          //  Debug.WriteLine("CollisionPair checkForCollision Method was called.");
            //Idea 1: double four loop style? 
            //Idea 2: Recursion?



            GameObject NodeA = trA;
            GameObject NodeB = trB;

           
            while (NodeA != null)
            {
                NodeB = trB;
                while (NodeB != null)
                {
                    CollisionRect rectA = NodeA.collisionObj.collisionRect;
                    CollisionRect rectB = NodeB.collisionObj.collisionRect;

                    if (CollisionRect.isIntersection(rectA, rectB))
                    {
                        NodeA.Accept(NodeB);
                        break;
                    }
                    NodeB = (GameObject)NodeB.sibling;
                }
                NodeA = (GameObject)NodeA.sibling;
            }

        }


        public Enum getName()
        {
         //   Debug.WriteLine("CollisionPair getName Method was called.");
            return this.name;
        }


    }
}
