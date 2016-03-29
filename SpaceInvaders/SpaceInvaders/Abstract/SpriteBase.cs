using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class SpriteBase:DLink
    {

        /**
         * Fields
         * */
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;
        private SpriteBatchNode sbNode;

        /**
         * Abstract Methods that must be implemented in the inherited classes. 
         * */
        public abstract void Render();
        public abstract void Update();
        abstract public Enum getName();
        public SpriteBatchNode getSpriteBatchNode()
        {
            return this.sbNode;
        }

        public void setSpriteBatchNode(SpriteBatchNode sbn)
        {
            Debug.Assert(sbn != null);

            this.sbNode = sbn;
        }
    }
}
