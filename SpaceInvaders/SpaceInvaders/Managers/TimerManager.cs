using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class TimerManager:Manager
    {
        //=============================================================================
        //Fields
        //=============================================================================
        private static TimerManager pInstance = null;
        private float currentTime;
        private TimerEvent refNode;
        private Boolean pause;
        //=============================================================================
        //Methods
        //=============================================================================

        //-----------------------------------------------------------------------------
        //TODO: TimerManager Constructor
        //-----------------------------------------------------------------------------
        private TimerManager(int reservedSize=3, int growthRate=2):base(reservedSize,growthRate)
        {
        //    Debug.WriteLine("TimerManager Private Constructor was called.");
            this.refNode = null;
            this.currentTime = 0.0f;
            this.pause = false;
        }

        //-----------------------------------------------------------------------------
        //TimerManager Create Method
        //-----------------------------------------------------------------------------
        public static void Create(int reservedSize=3, int growthRate=2)
        {
        //    Debug.WriteLine("TimerManager Create Method was called.");
            Debug.Assert(pInstance == null);
            if (pInstance == null)
            {
                pInstance = new TimerManager(reservedSize, growthRate);
            }
        }

        //----------------------------------------------------------
        //TODO: TimeManager Compare Method
        //----------------------------------------------------------
        protected override bool Compare(DLink pLinkA, DLink pLinkB)
        {
         //   Debug.WriteLine("TimerManager Compare Method was called.");
            Debug.Assert(pLinkA != null && pLinkB != null);
            TimerEvent teA = (TimerEvent)pLinkA;
            TimerEvent teB = (TimerEvent)pLinkB;
            Boolean status = false;
            if (teA.name == teB.name)
            {
                status = true;
            }
            return status;
        }

        //----------------------------------------------------------
        //TODO: TimeManager CreateNode Method
        //----------------------------------------------------------
        protected override DLink CreateNode()
        {
        //    Debug.WriteLine("TimerManager CreateNode Method was called.");
            DLink node = new TimerEvent();
            return node;
        }

        //----------------------------------------------------------
        //TimerManager Add Function
        //----------------------------------------------------------
        public static TimerEvent Add(TimerEvent.Name teName, float executeTime, Command command){
           // Console.WriteLine(command.spriteTest.name +"was added with an execute time of: "+executeTime);
            TimerManager tm = TimerManager.getInstance();
            Debug.Assert(tm != null);
            Debug.Assert(command != null);
            Debug.Assert(executeTime > 0);
            //Add to the TimerManager Active list and set the values
            tm.refNode = (TimerEvent)tm.baseCreateNoAdd();
            Debug.Assert(tm.refNode != null);
            tm.refNode.Set(teName, executeTime, command);
            //Now sort that list
            tm.baseAddSorted(tm.refNode);
            return tm.refNode;
            //tm.refNode = null;
        }
        
        //----------------------------------------------------------
        //TimerManager getTime Function
        //----------------------------------------------------------
        public static float getTime()
        {
         //   Debug.WriteLine("TimerManager getTime Method was called.");
            TimerManager tm = TimerManager.getInstance();
            Debug.Assert(tm != null);
            return tm.currentTime;
        }

        public static void Pause()
        {
            TimerManager tm = TimerManager.getInstance();
            tm.pause = true;
        }

        public static void Play()
        {
            TimerManager tm = TimerManager.getInstance();
            tm.pause = false;
        }
        /**
         * TimerManager Update Function
         * */
        public static void Update(float tTime)
        {
            
            TimerManager tm = TimerManager.getInstance();
            tm.currentTime = tTime;
            
            TimerEvent teHead = (TimerEvent)tm.pActive;
            if (tm.pause == false)
            {
                while (teHead != null)
                {


                    teHead = (TimerEvent)teHead.pNext;
                }

                teHead = (TimerEvent)tm.pActive;
                TimerEvent nextEvent = null;
                while (teHead != null && (tm.currentTime >= teHead.triggerTime))
                {
                    nextEvent = (TimerEvent)teHead.pNext;

                    Debug.Assert(teHead.name != TimerEvent.Name.Uninitialized);


                    if (tm.currentTime >= teHead.triggerTime)
                    {

                        teHead.process();

                        tm.baseRemove(teHead);
                    }
                    teHead = nextEvent;
                }

            }
        }


        public static void RemoveAll()
        {
            TimerManager tm = TimerManager.getInstance();
            TimerEvent teHead = (TimerEvent)tm.pActive;
            Debug.Assert(teHead != null);
            
            while (teHead != null)
            {
                TimerManager.Remove(teHead);

                teHead = (TimerEvent)tm.pActive.pNext;
            }
            TimerManager.Remove((TimerEvent)tm.pActive);
        
        }

        //
        //TimerManager Find Function
        //
        public static TimerEvent Find(TimerEvent.Name name)
        {
          //  Debug.WriteLine("TimerManager Find Method was called.");
            TimerManager tm = TimerManager.getInstance();
            Debug.Assert(tm != null);
            tm.refNode.name = name;
            TimerEvent teLink =(TimerEvent)tm.baseFind(tm.refNode);
            return teLink;
        }

        /**
         * TimerManager Sort Function
         * */
        protected override Boolean Sort(DLink dlListNode, DLink dlNodeToAdd)
        {
         //   Debug.WriteLine("TimerManager Sort Method was called.");
            Debug.Assert(dlListNode != null);
            Debug.Assert(dlNodeToAdd != null);

            TimerEvent teListNode = (TimerEvent)dlListNode;
            TimerEvent teNodeToAdd = (TimerEvent)dlNodeToAdd;
            Debug.Assert(teListNode.deltaTime > 0);
            Debug.Assert(teNodeToAdd.deltaTime > 0);

            Boolean status = false;
            if (teListNode.deltaTime > teNodeToAdd.deltaTime)
            {
                status = true;
            }
            return status;
        }

        public static void Remove(TimerEvent t)
        {
            Debug.Assert(t != null);
            TimerManager tm = TimerManager.getInstance();
            tm.baseRemove(t);
        }
        
        //----------------------------------------------------------
        //TimerManager getInstance Method
        //----------------------------------------------------------
        public static TimerManager getInstance()
        {
         //   Debug.WriteLine("TimerManager getInstance Method was called.");
            Debug.Assert(pInstance != null);
            return pInstance; 
        }

        private class TimerIterator
        {
            private TimerEvent current;
            private TimerEvent root;


            private TimerIterator(TimerEvent first)
            {
                this.root = first;
                this.current = root;

            }

            public TimerEvent Next()
            {
                this.current = (TimerEvent)this.current.pNext;
                return this.current;
            }

            private TimerEvent First()
            {
                this.current = this.root;
                return this.current;
            }
            private TimerEvent Current()
            {
                return this.current;
            }

            private Boolean isDone()
            {
                return this.current == null;
            }
        }


    }
}
