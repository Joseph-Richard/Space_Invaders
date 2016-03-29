using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class GameObject:Visitor
    {
        /**
         * Fields
         * */

        //TODO: need to implement Collision Rect
        public float x, y;
        public GameObject.Name name;
        public ProxySprite proxySprite;
        public int index;
        public CollisionObject collisionObj;
        public Boolean isDead;
        public enum Name {Uninitialized, 
                            Octo,
                            Crab,
                            Squid,
                            Mothership,
                            MothershipRoot,
                            Fryship,
                            FryshipExplosion,
                            FryshipRoot,
                            shieldBox,
                            FakeObject,
                            Column,
                            Shield,
                            ShieldRoot,
                            ShieldColumn,
                            ShieldBrick,
                            
                            AlienExplosion, 
                            Missile,
                            MissileRoot,
                            BottomWall,
                            LeftWall, 
                            RightWall,
                            TopWall,
                            WallRoot,
                            
                            BombRoot,
                            Bomb, 
                            ZigZag,
                            Dagger, 
                            LineBomb, 
                            MothershipBomb, 
                            Grid}


        /**
         * GameObject Constructor Method ()
         * */
        public GameObject(GameObject.Name name, Sprite.Name sName, int index=0)
        {
          //  Debug.WriteLine("GameObject Constructor Method was called.");

            this.name = name;

            this.x = 0.0f;
            this.y = 0.0f;
            this.index = index;
            this.isDead = false;

            this.proxySprite = ProxySpriteManager.Add(sName);
            Debug.Assert(this.proxySprite != null);
            this.collisionObj = new CollisionObject(this.proxySprite);
            Debug.Assert(this.collisionObj != null);
        }


        /**
         * GameObject Constructor (GameObject.Name, Sprite.Name)
         * */
        public GameObject(GameObject.Name name, int index = 0)
        {
         //   Debug.WriteLine("GameObject Constructor Method2 was called.");
            this.name = name;
            this.proxySprite = null;
            this.x = 0.0f;
            this.y = 0.0f;
            this.index = index;
            this.collisionObj = null;
            this.isDead = false;
        }
        
        /**
         * GameObject Set Method (Not Implemented)
         * */
        public void Set(Sprite.Name gsName, Image.Name iName, float x, float y, float width, float height)
        {
         //   Debug.WriteLine("GameObject Set Method was called. Should NOt Be Called");
            return;

        }


        /**
         * GameObject Update Method
         * */
        public virtual void Update()
        {
         //   Debug.WriteLine("GameObject Update Method was called.");
            Debug.Assert(this.proxySprite != null);
            this.proxySprite.x = this.x;
            this.proxySprite.y = this.y;
            Debug.Assert(this.collisionObj != null);
            this.collisionObj.UpdateLocation(this.x, this.y);
        }


        /**
         * GameObject Render Method (Not implemented)
         * */
        public virtual void Render()
        {
         //   Debug.WriteLine("GameObject Render Method was called.");
            return;
        }

        public virtual void Remove()
        {
            SpriteBatchNode sbn = this.proxySprite.getSpriteBatchNode();
       //     if (sbn != null)
         //   {
                 SpriteBatchManager.Remove(sbn);
         //   }
            sbn = this.collisionObj.proxyBox.getSpriteBatchNode();
           // if (sbn != null)
        //    {
                SpriteBatchManager.Remove(sbn);
        //    }
            GameObjectManager.Remove(this);
            
        }
        /**
         * GameObject updateBoundingBox Method
         * */
        public void updateBoundingBox()
        {
         //   Debug.WriteLine("GameObject UpdateBoundingBox Method was called.");
            
            PCSNode node = (PCSNode)this;
            node = node.child;
            if (node == null)
            {
                this.Remove();
                return;
            }
            CollisionRect colTotal = this.collisionObj.collisionRect;

            GameObject gameObject = (GameObject)node;
           // Console.WriteLine("{0} is the First child of {1}({2})", node.getName(), node.parent.getName(),this.getIndex());

            colTotal.Set(gameObject.collisionObj.collisionRect);

            while (node != null)
            {
                gameObject = (GameObject)node;
          //      Console.WriteLine("colTotal is being unioned with {0}", node.getName());
                colTotal.createUnion(gameObject.collisionObj.collisionRect);
                node = node.sibling;
            }
            this.x = this.collisionObj.collisionRect.x;
            this.y = this.collisionObj.collisionRect.y;
        //    Console.WriteLine("Unioning complete: x = {0}, y = {1}", this.x, this.y);
        }


        public void attachSprite(SpriteBatch psb)
        {
         //   Debug.WriteLine("GameObject attachSprite Method was called.");
            Debug.Assert(psb != null);
            Debug.Assert(this.proxySprite != null);
            
            
            psb.Attach(this.proxySprite);
        }

        public void attachCollisionBox(SpriteBatch psb)
        {
        //    Debug.WriteLine("GameObject attachCollisionBox Method was called.");
            Debug.Assert(psb != null);
            Debug.Assert(this.collisionObj != null);
            psb.Attach(this.collisionObj.proxyBox);
        }

        /**
         * GameObject getName Method
         * */
        override public Enum getName()
        {
           // Debug.WriteLine("GameObject getName Method was called.");
            return this.name;
        }

        public int getIndex()
        {
        //    Debug.WriteLine("GameObject getIndex Method was called.");
            return this.index;
        }


        public void turnOFFCollisionBox()
        {
            this.collisionObj.proxyBox.swapColors(0, 0, 0);
        }

        public void turnONCollisionBox()
        {
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }
    }
}
