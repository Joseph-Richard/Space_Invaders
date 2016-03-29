using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Bomb:BombType
    {
        private GameObject c;
        public float dropDelta;
        public Bomb(BombType.Type type, GameObject.Name name, Sprite.Name sName,GameObject c, float x, float y, int index)
            : base(type,name, sName, index)
        {
            this.x = x;
            this.y = y;
            this.c = c;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            //turnOFFCollisionBox();
            this.dropDelta = 1.0f;
        }

        public override void Update()
        {
            this.y -= dropDelta;
            base.Update();
        }


        public override void Remove()
        {
            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            base.Update();

            GameObject mRoot = (GameObject)this.parent;

            if (c is Column)
            {
                Column cl = (Column)c;
                cl.bombDropped = false;
            }
            else if (c is Mothership)
            {
                Mothership m = (Mothership)c;
                m.bombDropped = false;
            }
            mRoot.Update();
            base.Remove();
        }

        public override void Accept(Visitor v)
        {
            v.visitBomb(this);
        }


        public override void visitWallRoot(WallRoot wr)
        {
            CollisionPair.checkForCollision(this, (GameObject)wr.child);
        }

        public override void visitBottomWall(BottomWall w)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }
        //SHIELD-------------------------------------------------------------
        public override void visitShieldRoot(ShieldRoot s)
        {
            Console.Write("--BombVSShieldRoot--");
            CollisionPair.checkForCollision(this, (GameObject)s.child);
        }

        public override void visitShieldColumn(ShieldColumn s)
        {
            Console.Write("--BombVSShieldColumn--");
            CollisionPair.checkForCollision(this, (GameObject)s.child);
        }

        public override void visitShieldBrick(ShieldBrick s)
        {
            Console.Write("--BombVSShieldBrick("+this.name+")");
            Console.WriteLine("END");
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(s, this);
            cp.NotifyListeners();
        }
        //END SHIELD---------------------------------------------------------------


        public override void visitMissileRoot(MissileRoot m)
        {
            CollisionPair.checkForCollision(this, (GameObject)m.child);
        }

        public override void visitMissile(Missile m)
        {
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
