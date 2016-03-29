using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShieldBrick:ShieldType
    {
         public ShieldBrick(ShieldType.Type type, GameObject.Name name, Sprite.Name sName,  float x, float y, int index)
            : base(type, name, sName, index)
        {
            this.x = x;
            this.y = y;

            //turnOFFCollisionBox();
            this.proxySprite.pSprite.SetColor(0.0f, 1.0f, 0.0f);

        }

         public override void Update()
         {
             base.Update();
         }

         public override void Accept(Visitor v)
         {
             v.visitShieldBrick(this);
         }

         public override void visitMissileRoot(MissileRoot m)
         {
             CollisionPair.checkForCollision((GameObject)m.child,this);
         }

         public override void visitMissile(Missile m)
         {
             CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
             cp.updateCollisionGroup(m, this);
             cp.NotifyListeners();
         }

         public override void visitGrid(Grid g)
         {
             CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
             cp.updateCollisionGroup(g,this);
             cp.NotifyListeners();
         }
        //BOMB---------------------------------------------------------------------------
         public override void visitBombRoot(BombRoot b)
         {
             Console.Write("--ShieldBrickVSBombRoot--");
             CollisionPair.checkForCollision((GameObject)b.child, this);

         }

         public override void visitBomb(Bomb b)
         {
             CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
             cp.updateCollisionGroup(b, this);
             cp.NotifyListeners();
         }
        //END BOMB-----------------------------------------------------------------------
    }
}
