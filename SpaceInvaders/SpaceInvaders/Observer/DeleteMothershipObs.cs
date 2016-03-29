using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteMothershipObs:Observer
    {
        private GameObject mothership;

        public DeleteMothershipObs()
        {
            this.mothership = null;
        }

        public DeleteMothershipObs(DeleteMothershipObs dmo)
        {
            this.mothership = dmo.mothership;
        }
        public override void Notify()
        {
            CollisionGroup g = this.getGroup();
            this.mothership = MothershipType.selectMothership(g.getObjA(), g.getObjB());

            Debug.Assert(this.mothership != null);
            if (this.mothership.isDead == false)
            {
                this.mothership.isDead = true;
                DeleteMothershipObs dmo = new DeleteMothershipObs(this);
                DestructionManager.attachObserver(dmo);
            }
        }

        public override void Execute()
        {
            Mothership m = (Mothership)mothership;

            this.mothership.Remove();


            SoundManager sm = SoundManager.getInstance();
            


            Sound msExplosion = SoundManager.Find(Sound.Name.UFO_LowPitch);
            msExplosion.activateSound();

            Azul.Rect rect = new Azul.Rect(this.mothership.proxySprite.pSprite.pAzulSprite.sx, this.mothership.proxySprite.pSprite.pAzulSprite.sy, 450.0f,60.0f);
            ScreenText points = ScreenTextManager.Find(ScreenText.Name.MothershipPointsAwarded);
            points.UpdateScreenText(m.pointsAwarded.ToString());
            TimerManager.Add(TimerEvent.Name.DeleteMothershipScore, 0.6f, new DeleteMothershipScore(points));


            points.spriteFont.x = m.x;
            points.spriteFont.y = m.y;
            points.spriteFont.UpdateColor(1.0f, 0, 0);
            //Player p = PlayerManager.getCurrentPlayer();
            //p.UpdateScore(m.pointsAwarded);
            ProxySprite explosion = ProxySpriteManager.Add(Sprite.Name.AlienExplosion);
            explosion.pSprite.SetColor(1, 0, 0);
            explosion.x = points.spriteFont.x+50.0f;
            explosion.y = points.spriteFont.y;
            //explosion.pSprite.pAzulSprite.SwapScreenRect(rect);
            SpriteBatch ex = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            ex.Attach(explosion);
            Command deleteEx = new DeleteAlienExplosion(explosion);
            TimerManager.Add(TimerEvent.Name.DeleteAlienExplosion, 0.15f, deleteEx);
        }
    }
}
