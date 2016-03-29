using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Ship:ShipType
    {
        public ShipState currentState;
        public ShipReadyState shipRS;
        public ShipShootingState shipSS;
        public ShipEndState shipES;
        public Boolean isShooting;
        public float speed;
        public Boolean leftWallFlag;
        public Boolean rightWallFlag;

        //Create Just like an alien 
        public Ship(float x, float y, int index):base(ShipType.Type.Ship, GameObject.Name.Fryship, Sprite.Name.Fryship, index)
        {
            this.x = x;
            this.y = y;
            this.speed = 5.0f;
            this.shipRS = new ShipReadyState();
            this.currentState = null;
            this.shipSS = new ShipShootingState();
            this.shipES = new ShipEndState();
            this.leftWallFlag = false;
            this.rightWallFlag = false;
            this.isShooting = false;
            this.proxySprite.pSprite.SetColor(0.0f, 1.0f, 0.0f);
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }

        public void setState(ShipManager.State state)
        {
            this.currentState = ShipManager.getState(state);
        }


        public void MoveLeft()
        {
            if (this.leftWallFlag == false)
            {
                this.currentState.MoveLeft(this);
            }
            this.leftWallFlag = false;
        }

        public void MoveRight()
        {
            if (this.rightWallFlag == false)
            {
                this.currentState.MoveRight(this);
            }
            this.rightWallFlag = false;
        }

        public void Shoot()
        {
            this.currentState.Shoot(this);
        }



        public override void Accept(Visitor v)
        {
            v.visitShip(this);
        }


        public override void visitBombRoot(BombRoot b)
        {
            CollisionPair.checkForCollision(this, (GameObject)b.child);
        }

        public override void visitBomb(Bomb b)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(b, this);
            cp.NotifyListeners();
        }


        public override void visitWallRoot(WallRoot wr)
        {
            CollisionPair.checkForCollision(this, (GameObject)wr.child);

        }

        public override void visitLeftWall(LeftWall w)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }

        public override void visitRightWall(RightWall w)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }
    }
}
