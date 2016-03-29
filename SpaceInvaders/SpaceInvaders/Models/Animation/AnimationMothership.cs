using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AnimationMothership:Command
    {
        private MothershipRoot mothershipRoot;
        
        public AnimationMothership(MothershipRoot m)
        {
            this.mothershipRoot = m;
        }


        public override void Execute(float executeTime)
        {
            Random randET = new Random();
            MothershipRoot mothershipRoot2 = (MothershipRoot)GameObjectManager.Find(GameObject.Name.MothershipRoot);
            if (mothershipRoot2.child==null)
            {
                Random rnd = new Random();
                int points = 0; 
                int p = rnd.Next(4);
                switch(p){
                    case 0:
                        points = 50;
                        break;
                    case 1:
                        points = 100;
                        break;
                    case 2:
                        points = 150;
                        break;
                    case 3:
                        points = 300;
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
                Random rndcoordinate = new Random();
                int xVal = 0;
                if (rndcoordinate.Next(1, 10)%2 == 0)
                {
                    xVal = 50;
                }
                else
                {
                    xVal = 850;
                }
               
                PCSTree tree = GameObjectManager.getTree();
                Mothership mShip = new Mothership(MothershipType.Type.Mothership, GameObject.Name.Mothership, Sprite.Name.Mothership, (float)xVal, 900, 0, points);
                SpriteBatch sb = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
                SpriteBatch boxes = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);
                mShip.attachSprite(sb);
                mShip.attachCollisionBox(boxes);
                tree.Insert(mShip, mothershipRoot2);
                SoundManager sm = SoundManager.getInstance();
                Sound mothershipSound = SoundManager.Find(Sound.Name.UFO_HighPitch);
                sm.getSoundEngine().Play2D(mothershipSound.soundSource, true, false, false);

            }
            float ex = (float)randET.Next(7, 15);
            TimerManager.Add(TimerEvent.Name.CreateMothership, ex, this);
        }
    }
}
