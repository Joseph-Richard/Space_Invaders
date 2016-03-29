using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class MissileRoot:MissileType
    {
        public MissileRoot(float x, float y, int index)
            : base(MissileType.Type.MissileRoot, GameObject.Name.MissileRoot, Sprite.Name.FakeObject, index)
        {
            this.x = x;
            this.y = y;

            this.collisionObj.proxyBox.swapColors(0, 1, 0);
        }

        public override void Update()
        {
            base.updateBoundingBox();
            base.Update();
        }
        public override void Accept(Visitor v)
        {
      //      Console.Write("MissileRoot hit->");
            v.visitMissileRoot(this);
        }
        public override void visitGrid(Grid g)
        {
      //      Console.WriteLine("MissileRoot.");
            CollisionPair.checkForCollision(g, (GameObject)this.child);
        }

        public override void visitWallRoot(WallRoot wr)
        {
            CollisionPair.checkForCollision(wr, (GameObject)this.child);
        }

        public override void visitTopWall(TopWall w)
        {
            CollisionPair.checkForCollision(w, (GameObject)this.child);
        }

        public override void visitShieldRoot(ShieldRoot s)
        {
            CollisionPair.checkForCollision(s, (GameObject)this.child);

        }

        public override void visitShieldColumn(ShieldColumn s)
        {
            CollisionPair.checkForCollision(s, (GameObject)this.child);

        }

        public override void visitShieldBrick(ShieldBrick s)
        {
            CollisionPair.checkForCollision(s, (GameObject)this.child);

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
            CollisionPair.checkForCollision(m, (GameObject)this.child);

        }


        public override void visitMothership(Mothership m)
        {
            CollisionPair.checkForCollision(m, (GameObject)this.child);

        }
    }
}
