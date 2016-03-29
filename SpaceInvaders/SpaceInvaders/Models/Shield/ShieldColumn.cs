using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShieldColumn:ShieldType
    {

        //private float total;
        //private float delta;

        public ShieldColumn(ShieldType.Type type, GameObject.Name name, float x, float y, int index)
            : base(type, name, Sprite.Name.FakeObject, index)
        {
          //  Debug.WriteLine("Column Constructor Method was called.");
            this.x = x;
            this.y = y;
          //  this.total = 0.0f;
            //this.delta = 2.0f;
            this.index = index;
           // turnOFFCollisionBox();
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
        }

        /**
         * Column Accept Method
         * */
        public override void Accept(Visitor other)
        {
            other.visitShieldColumn(this);
        //    other.visitShieldColumn(this);
        }






        public override void Update()
        {
         //   Debug.WriteLine("Column Update Method was called.");
            
            base.updateBoundingBox();
            base.Update();
        }



        public override void Remove()
        {
            Console.WriteLine("Column.Remove() was called.");
            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            //this.Update();

            GameObject parent = (GameObject)this.parent;
            parent.Update();


            base.Remove();
        }
        //What Can collide with a collumn
        //--Missle
        //--Wall
        //--Shield



        public override void visitMissileRoot(MissileRoot m)
        {
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }
        /**
         * Collumn visit Missile Method
         * */
        public override void visitMissile(Missile m)
        {
         //   Console.WriteLine("Column.");
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }

        public override void visitGrid(Grid g)
        {
            CollisionPair.checkForCollision(g, (GameObject)this.child);
        }

        //BOMB------------------------------------------------------------------------
        public override void visitBombRoot(BombRoot b)
        {
            Console.Write("--SHieldColumnVSBombRoot--");
            CollisionPair.checkForCollision(b, (GameObject)this.child);
        }

        public override void visitBomb(Bomb b)
        {
            Console.Write("--SHieldColumnVSBomb--");
            CollisionPair.checkForCollision(b, (GameObject)this.child);
        }
        //END BOMB--------------------------------------------------------------------
    }
}
