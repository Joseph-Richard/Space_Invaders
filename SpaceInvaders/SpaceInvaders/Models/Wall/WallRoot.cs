using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class WallRoot:WallType
    {
        public WallRoot(float x, float y, int index)
            : base(WallType.Type.WallRoot, GameObject.Name.WallRoot, Sprite.Name.FakeObject, index)
        {
            this.x = x;
            this.y = y;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            //turnOFFCollisionBox();
        }

        public override void Update()
        {
            base.updateBoundingBox();
            base.Update();
        }
        public override void Accept(Visitor v)
        {
       //     Console.Write("MissileRoot hit->");
            v.visitWallRoot(this);
        }
        public override void visitGrid(Grid g)
        {
            Console.WriteLine("Hit Grid in Wallroot.");
            Console.WriteLine("MissileRoot.");
            CollisionPair.checkForCollision(g, (GameObject)this.child);
        }


        public override void visitMissile(Missile m)
        {
      //      Console.WriteLine("WallRoot.");
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }

        public override void visitMissileRoot(MissileRoot m)
        {
       //     Console.WriteLine("WallRoot.");
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }

        public override void visitBombRoot(BombRoot b)
        {
            CollisionPair.checkForCollision(b, (GameObject)this.child);
        }

        public override void visitBomb(Bomb b)
        {
            CollisionPair.checkForCollision(b, (GameObject)this.child);

        }


        public override void visitMothershipRoot(MothershipRoot m)
        {
            CollisionPair.checkForCollision(this, (GameObject)m.child);
        }

        public override void visitMothership(Mothership m)
        {
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }


        public override void visitShipRoot(ShipRoot sr)
        {
            CollisionPair.checkForCollision(sr, (GameObject)this.child);

        }

        public override void visitShip(Ship s)
        {
            CollisionPair.checkForCollision(s, (GameObject)this.child);

        }
    }
}
