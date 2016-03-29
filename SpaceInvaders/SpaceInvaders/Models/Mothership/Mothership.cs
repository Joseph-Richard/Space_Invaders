using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Mothership:MothershipType
    {
        public float delta;
        public Boolean leftWall;
        public Boolean rightWall;
        public Boolean isSwitchingDirection;
        public Boolean bombDropped;
        public int count;
        public int pointsAwarded;
        public Boolean isOnScreen;
        public Mothership(Mothership.Type type, GameObject.Name name, Sprite.Name sName, float x, float y, int index, int pointsAwarded)
            : base(type, name, sName, index)
        {
            this.x = x;
            this.y = y;
            this.delta = 1.0f;
            this.proxySprite.pSprite.SetColor(1.0f, 0.0f, 0.0f);
            this.leftWall = false;
            this.rightWall = false;
            this.isSwitchingDirection = false;
            this.bombDropped = false;
            this.count = 0;
            //turnOFFCollisionBox();
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            this.pointsAwarded = pointsAwarded;
            this.isOnScreen = true;
        }

        public override void Accept(Visitor v)
        {
            v.visitMothership(this);
        }


        public override void Remove()
        {

            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            this.Update();

            GameObject parent = (GameObject)this.parent;
            parent.Update();

            SoundManager sm = SoundManager.getInstance();
            sm.getSoundEngine().StopAllSounds();
            //SoundManager sm = SoundManager.getInstance();
            Sound mothershipSound = SoundManager.Find(Sound.Name.UFO_HighPitch);
            //sm.getSoundEngine().Play2D(mothershipSound.soundSource, true, false, false);
            sm.getSoundEngine().RemoveSoundSource(mothershipSound.soundSource.Name);
            base.Remove();
            this.isOnScreen = false;




        }

        public override void Update()
        {
            this.x += this.delta;
            if (this.delta != 0.0)
            {
                dropBomb();
            }

            base.Update();
        }

        public void updateLocation()
        {
          //  if (this.leftWall == true && this.rightWall == true)
            //{
              //  this.Remove();
           // }
            //else
           // {
                this.delta *= -1;
          //  }
        }


        public void dropBomb()
        {
            if (this.bombDropped == false)
            {
                PCSTree bombTree = GameObjectManager.getTree();
                this.bombDropped = true;
                Bomb bomb = new Bomb(BombType.Type.MothershipBomb, Name.MothershipBomb, Sprite.Name.MothershipBomb, this, this.x, this.y - 110, 0);

                BombType bombRoot = (BombType)GameObjectManager.Find(GameObject.Name.BombRoot);
                SpriteBatch bombs = SpriteBatchManager.Find(SpriteBatch.Name.Bombs);
                SpriteBatch boxes = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);
                bomb.attachSprite(bombs);
                bomb.attachCollisionBox(boxes);
                bombTree.Insert(bomb, bombRoot);
            }

        }

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

        public override void visitRightWall(RightWall w)
        {
            if (this.leftWall == true)
            {
                this.rightWall = false;
                this.isSwitchingDirection = false;
            }
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }

        public override void visitLeftWall(LeftWall w)
        {
            if (this.rightWall == true)
            {
                this.leftWall = false;
                this.isSwitchingDirection = false;
            }
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }

        public override void visitWallRoot(WallRoot wr)
        {
            CollisionPair.checkForCollision(this, (GameObject)wr.child);
        }
    }
}
