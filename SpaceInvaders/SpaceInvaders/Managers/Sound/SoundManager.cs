using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SoundManager:Manager
    {
        private static SoundManager instance;
        private IrrKlang.ISoundEngine soundEngine;
        private Sound refNode; 
        private SoundManager(int reserveNum, int growthRate):base(reserveNum, growthRate)
        {
            this.soundEngine = new IrrKlang.ISoundEngine();
            this.refNode = (Sound)this.CreateNode();
        }

        public static void Create(int reserveNum, int growthRate)
        {
            Debug.Assert(instance == null);

            if (instance == null)
            {
                instance = new SoundManager(reserveNum, growthRate);
            }
        }



        public static Sound Add(Sound.Name name, String fileName)
        {
            SoundManager sm = SoundManager.getInstance();

            Sound sound = (Sound)sm.baseAdd();
            Debug.Assert(sound != null);

            sound.Set(name, sm.soundEngine.AddSoundSourceFromFile(fileName));
            return sound;
        }


        public IrrKlang.ISoundEngine getSoundEngine()
        {
            return this.soundEngine;
        }
        public static SoundManager getInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static Sound Find(Sound.Name name)
        {
            SoundManager sm = SoundManager.getInstance();

            sm.refNode.name = name;
            Sound pLink = (Sound)sm.baseFind(sm.refNode);
            return pLink;
        }



        /**
            * SpriteManager Compare Function
        * */
        override protected Boolean Compare(DLink pNodeA, DLink pNodeB)
        {
            //  Debug.WriteLine("SpriteManager Compare Method was called.");
            Debug.Assert(pNodeA != null && pNodeB != null);
            Sound pSpriteA = (Sound)pNodeA;
            Sound pSpriteB = (Sound)pNodeB;
            Boolean status = false;
            if (pSpriteA.name == pSpriteB.name)
            {
                status = true;
            }
            return status;
        }





        public static void Update()
        {
            SoundManager sm = SoundManager.getInstance();
            sm.soundEngine.Update();
        }




        override protected DLink CreateNode()
        {
            //   Debug.WriteLine("SpriteManager CreateNode Method was called.");
            DLink pLink = new Sound();
            return pLink;
        }
    }
}
