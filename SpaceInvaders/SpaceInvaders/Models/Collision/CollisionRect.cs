using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class CollisionRect: Azul.Rect
    {
        //private float minX;
        //private float maxX;
       // private float minY;
       // private float maxY;
      //  private SpriteBatchNode sbNode;
        /**
         * Collision Rectangle Constructor method 1
         * */
        public CollisionRect()
            : base()
        {
          //  Debug.WriteLine("CollisionRect Constructor Method was called.");
        }
        /**
         * Collision Rect Constructor Method 2
         * */
        public CollisionRect(Azul.Rect rect)
            : base(rect)
        {
         //   Debug.WriteLine("CollisionRect Constructor Method2 was called.");

        }
        /**
         * Collision Rectangle Constructor method 3
         * */
        public CollisionRect(float sx, float sy, float width, float height)
            : base(sx, sy, width, height)
        {
         //   Debug.WriteLine("CollisionRect Constructor Method3 was called.");
        }

        public CollisionRect(CollisionRect rect)
            : base(rect)
        {

        }
        /**
         * Collision Rectangle isIntersection Method
         * */
        public static Boolean isIntersection(CollisionRect crA, CollisionRect crB)
        {
         //   Debug.WriteLine("CollisionRect isIntersection Method was called.");
            Debug.Assert(crA != null);
            Debug.Assert(crB != null);

            Boolean status = false;
            //Min X
            float craMinX = crA.x - crA.width / 2;
            float crbMinX = crB.x - crB.width / 2;

            //Min Y
            float craMinY = crA.y - crA.height / 2;
            float crbMinY = crB.y - crB.height / 2;

            //Max X
            float craMaxX = crA.x + crA.width / 2;
            float crbMaxX = crB.x + crB.width / 2;

            //Max Y
            float craMaxY = crA.y + crA.height / 2;
            float crbMaxY = crB.y + crB.height / 2;


            //CHECK TO SEE IF any of the four possible intersections has occured
            //Each corner is checked. if the two rects are lined up just right and hit with equal X or Y min and max, it will still be caught. 
            //bottom right corner
            if (crbMaxX < craMinX || crbMinY > craMaxY || crbMaxY < craMinY || crbMinX > craMaxX)
            {
                status = false;
            }
            else
            {
                status = true;
            }

            return status;
        }


        /**
         * Collision Rectangle Combine Rect method
         * --This method takes another Azul.rect and updates this collision rectangle to include that rectangle within it. 
         * */
        public void createUnion(CollisionRect other)
        {
         //   Debug.WriteLine("CollisionRect CreateUnion Method was called.");
            Debug.Assert(other != null);
            float minX;
            float minY;
            float maxX;
            float maxY;

            //Debug.Assert(this.x > 0);
           // Debug.Assert(this.y > 0);
          //  Debug.Assert(other.x > 0);
          //  Debug.Assert(other.y > 0);
            //MinX
            if ((this.x - this.width / 2) < (other.x - other.width / 2))
            {
                minX = (this.x - this.width / 2);
            }
            else
            {
                
                minX = (other.x - other.width / 2);
            }

            //MinY
            if ((this.y - this.height / 2) < (other.y - other.height / 2))
            {
                minY = (this.y - this.height / 2);
               
            }
            else
            {
                minY = (other.y - other.height / 2);
            }

            //MaxX
            if ((this.x + this.width / 2) > (other.x + other.width / 2))
            {
                maxX = (this.x + this.width / 2);
            }
            else
            {
                maxX = (other.x + other.width / 2);
            }

            //MaxY
            if ((this.y + this.height / 2) > (other.y + other.height / 2))
            {
                maxY = this.y + this.height / 2;
            }
            else
            {
                maxY = other.y + other.height / 2;
            }

           // Debug.Assert(minX > 0);
          //  Debug.Assert(minY > 0);
         //   Debug.Assert(maxX > 0);
        //    Debug.Assert(maxY > 0);
        //    Debug.Assert(minX != 0);
       //     Debug.Assert(minY != 0);
       //     Debug.Assert(maxX != 0);
       //     Debug.Assert(maxY != 0);
            this.width = (maxX - minX);
            this.height = (maxY - minY);
            this.x = minX + this.width / 2;
            this.y = minY + this.height / 2;
        }

   /*     public void setSpriteBatchNode(SpriteBatchNode sbn)
        {
            Debug.Assert(sbn != null);

            this.sbNode = sbn;
        }

        public SpriteBatchNode getSpriteBatchNode()
        {
            return this.sbNode;
        }*/
    }
}
