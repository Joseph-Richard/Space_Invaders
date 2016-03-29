using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class MothershipRoot:MothershipType
    {
         /**
         * ShipRoot Constructor 
         * */
        private float delta;
        public MothershipRoot(float x, float y, int index)
            : base(MothershipType.Type.MothershipRoot, GameObject.Name.MothershipRoot, Sprite.Name.FakeObject, index)
        {
            this.x = x;
            this.y = y;
            //turnOFFCollisionBox();
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            this.delta = 1.0f;
        }


        public void Pause()
        {
            if (this.child != null)
            {
                SoundManager sm = SoundManager.getInstance();
                sm.getSoundEngine().StopAllSounds();
                //SoundManager sm = SoundManager.getInstance();
                Sound mothershipSound = SoundManager.Find(Sound.Name.UFO_HighPitch);
                //sm.getSoundEngine().Play2D(mothershipSound.soundSource, true, false, false);
                sm.getSoundEngine().RemoveSoundSource(mothershipSound.soundSource.Name);

                
                MothershipType node = (MothershipType)this.child;
                while (node != null)
                {
                    Mothership b = (Mothership)node;
                    b.delta = 0.0f;
                    node = (MothershipType)this.sibling;
                }
            }

        }

        public void Play()
        {
            if (this.child != null)
            {

                MothershipType node = (MothershipType)this.child;
                while (node != null)
                {
                    Mothership b = (Mothership)node;
                    b.delta = this.delta;
                    node = (MothershipType)this.sibling;
                    
                }
            }

        }

        /**
         * MothershipRoot Accept Method
         * */
        public override void Accept(Visitor v)
        {

            v.visitMothershipRoot(this);
        }

        /**
         * MothershipRoot Update Method
         * */
        public override void Update()
        {
            base.updateBoundingBox();
            base.Update();
        }



        public override void visitMissileRoot(MissileRoot m)
        {
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }


        public override void visitMissile(Missile m)
        {
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }



        public override void visitWallRoot(WallRoot wr)
        {
            CollisionPair.checkForCollision(wr, (GameObject)this.child);
        }

        public override void visitRightWall(RightWall w)
        {
            CollisionPair.checkForCollision(w, (GameObject)this.child);
        }

        public override void visitLeftWall(LeftWall w)
        {
            CollisionPair.checkForCollision(w, (GameObject)this.child);
        }
    }
}
