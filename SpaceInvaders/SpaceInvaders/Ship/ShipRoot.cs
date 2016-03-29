using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShipRoot : ShipType
    {
        /**
         * ShipRoot Constructor 
         * */
        public ShipRoot(float x, float y, int index)
            : base(ShipType.Type.ShipRoot, GameObject.Name.FryshipRoot, Sprite.Name.FakeObject, index)
        {
            this.x = x;
            this.y = y;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }

        /**
         * ShipRoot Accept Method
         * */
        public override void Accept(Visitor v)
        {
            v.visitShipRoot(this);
        }

        /**
         * ShipRoot Update Method
         * */
        public override void Update()
        {
            base.updateBoundingBox();
            base.Update();
        }


        public override void visitBombRoot(BombRoot b)
        {
            CollisionPair.checkForCollision(b, (GameObject)this.child);
        }

        public override void visitBomb(Bomb b)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(b, this);
            cp.NotifyListeners();
        }


        public override void visitWallRoot(WallRoot wr)
        {
            CollisionPair.checkForCollision(wr, (GameObject)this.child);
        }

        public override void visitLeftWall(LeftWall w)
        {
            CollisionPair.checkForCollision(w, (GameObject)this.child);

        }

        public override void visitRightWall(RightWall w)
        {
            CollisionPair.checkForCollision(w, (GameObject)this.child);

        }
    }
}
