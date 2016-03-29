using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Sound:DLink
    {

        public IrrKlang.ISoundSource soundSource;
        public Name name;
        public enum Name
        {
            Uninitialized,
            MissileExplosion,
            ShipExplosion, 
            Theme, 
            AlienKilled,
            GridMovement1,
            GridMovement2,
            GridMovement3,
            GridMovement4, 
            MissileFire, 
            UFO_LowPitch,
            UFO_HighPitch, 
            Other
        }

        public Sound()
        {
            this.soundSource = null;
            this.name = Name.Uninitialized;
        }

        public void Set(Sound.Name name, IrrKlang.ISoundSource ss)
        {
            this.name = name;
            Debug.Assert(ss != null);

            this.soundSource = ss;
        }


        public void activateSound()
        {
            SoundManager sm = SoundManager.getInstance();
            Debug.Assert(this.soundSource != null);
            IrrKlang.ISoundEngine engine = sm.getSoundEngine();
            engine.Play2D(this.soundSource, false, false, false);
        }
    }
}
