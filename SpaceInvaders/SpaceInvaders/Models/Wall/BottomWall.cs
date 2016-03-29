using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class BottomWall:WallType
    {
        public BottomWall(float x, float y, float width, float height, int index)
        : base(WallType.Type.BottomWall, GameObject.Name.BottomWall, Sprite.Name.FakeObject, index)
        {
            this.collisionObj.collisionRect.Set(x,y,width,height);
            this.x = x;
            this.y = y;
            
            this.collisionObj.proxyBox.swapColors(0, 1, 0);
            //this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }

        public override void Update()
        {
            //base.updateBoundingBox();
            base.Update();
        }
        public override void Accept(Visitor v)
        {
      //      Console.Write("MissileRoot hit->");
            v.visitBottomWall(this);
        }
        public override void visitGrid(Grid g)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(g, this);
            cp.NotifyListeners();
        }

        public override void visitBombRoot(BombRoot b)
        {
            CollisionPair.checkForCollision(this,(GameObject)b.child);
        }

        public override void visitBomb(Bomb b)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(b, this);
            cp.NotifyListeners();
        }
    }
}
