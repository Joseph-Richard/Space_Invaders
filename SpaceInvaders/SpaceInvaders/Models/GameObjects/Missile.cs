using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Missile:MissileType
    {
       // private Boolean isHit;
        public float delta;
        private Boolean isAlive;
        public Missile(float x, float y, int index = 0)
            : base(MissileType.Type.Missile,GameObject.Name.Missile, Sprite.Name.Missile, index)
        {
        //    Debug.WriteLine("Missile Constructor Method was called.");
            this.x = x;
            this.y = y;
            this.index = index;
            this.delta = 30.0f;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }

        public void updateLocation(float x, float y)
        {
            this.x = x;
            this.y = y;
        //    this.Update();
        }

        public override void Remove()
        {
            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            base.Update();

            GameObject mRoot = (GameObject)this.parent;
            mRoot.Update();
            base.Remove();
        }

        public void setIsAlive(Boolean isAlive)
        {
            this.isAlive = isAlive;
        }
        public override void Accept(Visitor v)
        {
          //  Console.Write("Missile hit ->");
            v.visitMissile(this);
        }

        public override void Update()
        {
            base.Update();
            this.y += delta;
        }


        public override void visitGrid(Grid g)
        {
          //  Console.WriteLine("Missile.");
            
            CollisionPair.checkForCollision(this, (GameObject)g.child);
        }

        public override void visitWallRoot(WallRoot wr)
        {
         //   Console.WriteLine("Missile.");

            CollisionPair.checkForCollision(this, (GameObject)wr.child);
        }

        public override void visitTopWall(TopWall w)
        {
           // Console.WriteLine("Missile.");
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
          //  Sound explosion = SoundManager.Find(Sound.Name.MissileExplosion);
          //  explosion.activateSound();
        }

        //SHIELD----------------------------------------------------------------------------------
        public override void visitShieldRoot(ShieldRoot s)
        {
            CollisionPair.checkForCollision(this, (GameObject)s.child);

        }
        public override void visitShieldColumn(ShieldColumn s)
        {
            CollisionPair.checkForCollision(this, (GameObject)s.child);
        }
        public override void visitShieldBrick(ShieldBrick s)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(s, this);


            cp.NotifyListeners();

        }
        //END SHIELD-------------------------------------------------------------------------------

        //BOMB-------------------------------------------------------------------------------------
        public override void visitBomb(Bomb b)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(b, this);

            cp.NotifyListeners();

        }
        public override void visitBombRoot(BombRoot b)
        {
            CollisionPair.checkForCollision(this, (GameObject)b.child);
        }
        //END BOMB----------------------------------------------------------------------------------

        //MOTHERSHIP--------------------------------------------------------------------------------
        public override void visitMothershipRoot(MothershipRoot m)
        {
            CollisionPair.checkForCollision(this, (GameObject)m.child);

        }

        public override void visitMothership(Mothership m)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(m, this);
            cp.NotifyListeners();

        }
    }
}
