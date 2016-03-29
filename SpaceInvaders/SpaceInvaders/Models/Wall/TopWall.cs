using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class TopWall:WallType
    {
            public TopWall(float x, float y, float width, float height, int index)
            : base(WallType.Type.TopWall, GameObject.Name.TopWall, Sprite.Name.FakeObject, index)
        {
            this.collisionObj.collisionRect.Set(x,y,width,height);
            this.x = x;
            this.y = y;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            //turnOFFCollisionBox();

        }

        public override void Update()
        {
            //base.updateBoundingBox();
            base.Update();
        }
        public override void Accept(Visitor v)
        {
        //    Console.Write("TopWall hit->");
            v.visitTopWall(this);
        }
        public override void visitGrid(Grid g)
        {
         //   Console.WriteLine("TopWall.");
            //CollisionPair.checkForCollision(g, (GameObject)this.child);
        }

        public override void visitMissile(Missile m)
        {
          //  Console.WriteLine("TopWall.");
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(m, this);
            // m.shootOutOfSky();
            cp.NotifyListeners();
            // GameObjectManager.Remove(m);
        }

        public override void visitMissileRoot(MissileRoot m)
        {
          //  Console.WriteLine("TopWall.");
            CollisionPair.checkForCollision((GameObject)m.child, this);
        }
    }
}
