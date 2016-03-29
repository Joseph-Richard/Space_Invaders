using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class LeftWall:WallType
    {
        public LeftWall(float x, float y, float width, float height, int index)
        : base(WallType.Type.LeftWall, GameObject.Name.LeftWall, Sprite.Name.FakeObject, index)
        {
            this.collisionObj.collisionRect.Set(x,y,width,height);
            this.x = x;
            this.y = y;

            //turnOFFCollisionBox();
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }

        public override void Update()
        {
            //base.updateBoundingBox();
            base.Update();
        }
        public override void Accept(Visitor v)
        {
       //     Console.Write("MissileRoot hit->");
            v.visitLeftWall(this);
        }
        public override void visitGrid(Grid g)
        {
            if (g.rightWall == true)
            {
                g.rightWall = false;
                g.isDelayed = false;
            }
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(g, this);
            cp.NotifyListeners();
        }

        public override void visitMothershipRoot(MothershipRoot m)
        {
            CollisionPair.checkForCollision(this, (GameObject)m.child);
        }

        public override void visitMothership(Mothership m)
        {
            if (m.rightWall == true)
            {
                m.leftWall = false;
                m.isSwitchingDirection = false;
            }
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(m, this);
            cp.NotifyListeners();
        }


        public override void visitShipRoot(ShipRoot sr)
        {
            CollisionPair.checkForCollision(this, (GameObject)sr.child);
        }


        public override void visitShip(Ship s)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(s, this);
            cp.NotifyListeners();
        }
    }
}
