using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShieldRoot:ShieldType
    {
         public ShieldRoot(float x, float y, int index)
            : base(ShieldType.Type.ShieldRoot, GameObject.Name.ShieldRoot, Sprite.Name.FakeObject, index)
        {
            this.x = x;
            this.y = y;
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            //turnOFFCollisionBox();
        }

         public override void Update()
         {
             base.updateBoundingBox();
             base.Update();
         }


         public override void Accept(Visitor v)
         {
             v.visitShieldRoot(this);
         }

         public override void visitMissileRoot(MissileRoot m)
         {
             CollisionPair.checkForCollision(m, (GameObject)this.child);
         }

         public override void visitMissile(Missile m)
         {
             CollisionPair.checkForCollision(m, (GameObject)this.child);

         }


         public override void visitGrid(Grid g)
         {
             CollisionPair.checkForCollision(g, (GameObject)this.child);
         }

        //BOMB-----------------------------------------------------------------------
         public override void visitBombRoot(BombRoot b)
         {
             Console.Write("--ShieldRootVSBombRoot--");
             CollisionPair.checkForCollision(this, (GameObject)b.child);

         }
         public override void visitBomb(Bomb b)
         {
             Console.Write("--ShieldRootVSBomb--");
             CollisionPair.checkForCollision(b, (GameObject)this.child);

         }
        //END BOMB--------------------------------------------------------------------
    }
}
