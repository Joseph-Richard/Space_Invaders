using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class BombRoot:BombType
    {
        private float dropDelta;
        public BombRoot(float x, float y, int index)
            : base(BombType.Type.BombRoot, GameObject.Name.BombRoot, Sprite.Name.FakeObject, index)
        {
            this.x = x;
            this.y = y;
            this.dropDelta = 1.0f;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            //turnOFFCollisionBox();
        }

        public void Pause()
        {
            if(this.child != null)
            {
                BombType node = (BombType)this.child;
                while (node != null)
                {
                    Bomb b = (Bomb)node;
                    b.dropDelta = 0.0f;
                    node = (BombType)this.sibling;
                }
            }
            
        }

        public void Play()
        {
            if (this.child != null)
            {
                BombType node = (BombType)this.child;
                while (node != null)
                {
                    Bomb b = (Bomb)node;
                    b.dropDelta = this.dropDelta;
                    node = (BombType)this.sibling;
                }
            }

        }

        public override void Update()
        {
            base.updateBoundingBox();
            base.Update();
        }
        public override void Accept(Visitor v)
        {

            v.visitBombRoot(this);
        }

        public override void visitWallRoot(WallRoot wr)
        {
            CollisionPair.checkForCollision(wr, (GameObject)this.child);
        }

        public override void visitBottomWall(BottomWall w)
        {
            CollisionPair.checkForCollision(w, (GameObject)this.child);
        }


        //SHIELD----------------------------------------------------------------
        public override void visitShieldRoot(ShieldRoot s)
        {
            Console.Write("--BombRootVSShieldRoot--");
            CollisionPair.checkForCollision(s, (GameObject)this.child);

        }

        public override void visitShieldColumn(ShieldColumn s)
        {
            Console.Write("--BombRootVSShieldColumn--");
            CollisionPair.checkForCollision(s, (GameObject)this.child);

        }

        public override void visitShieldBrick(ShieldBrick s)
        {
            Console.Write("--BombRootVSShieldBrick--");

            CollisionPair.checkForCollision(s, (GameObject)this.child);

        }
        //END SHIELD------------------------------------------------------------
        public override void visitMissileRoot(MissileRoot m)
        {
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }

        public override void visitMissile(Missile m)
        {
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }

        //SHIP-------------------------------------------------------------------
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
