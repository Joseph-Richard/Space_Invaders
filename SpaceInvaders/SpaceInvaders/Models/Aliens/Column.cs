using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Column:Alien
    {
        private float total;
        private float delta;
        public Boolean bombDropped;
        private Random rnd;
        public Column(float x, float y, int index)
            : base(Alien.Type.Column, GameObject.Name.Column, Sprite.Name.FakeObject, index)
        {
          //  Debug.WriteLine("Column Constructor Method was called.");
            this.x = x;
            this.y = y;
            this.total = 0.0f;
            this.delta = 2.0f;
            this.index = index;
            turnOFFCollisionBox();
            this.bombDropped = false;
            this.rnd = new Random();
        //    AnimationBomb animBomb = new AnimationBomb(this);
         //   float tim = (float)((5 - this.index) * rnd.NextDouble() + this.index);
           // TimerManager.Add(TimerEvent.Name.BombDrop, 1.5f, animBomb);
        }

        /**
         * Column Accept Method
         * */
        public override void Accept(Visitor other)
        {
        //    Console.Write("Missile hit-> ");
            other.visitColumn(this);
        }


        public override void Update()
        {
         //   Debug.WriteLine("Column Update Method was called.");
            
            base.updateBoundingBox();

            //this.dropBomb();
            
            
            base.Update();
        }



        public override void Remove()
        {
            Console.WriteLine("Column.Remove() was called.");
            this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            //this.Update();

             GameObject parent = (GameObject)this.parent;
            //parent.Update();


            
            if (parent != null && parent.child == null)
            {
                parent.Remove();
            }
            base.Remove();
        }
        //What Can collide with a collumn
        //--Missle
        //--Wall
        //--Shield

        /**
         * Collumn visit Missile Method
         * */
        public override void visitMissile(Missile m)
        {
         //   Console.WriteLine("Column.");
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }



        /**
         * Column visit Wall Method
         * */
        public override void visitRightWall(RightWall w)
        {
         //   Console.WriteLine("Column.");
            //Do Something
        }


        public void dropBomb()
        {
            if(this.bombDropped==false)
            {
                PCSTree bombTree = GameObjectManager.getTree();
                this.bombDropped = true;

                
                int bombStyle = rnd.Next(3);
                Bomb bomb = null;
                switch(bombStyle){
                    case 0:
                        //bomb = new Bomb(BombType.Type.MothershipBomb, Name.MothershipBomb, Sprite.Name.MothershipBomb, this, this.x, this.y - 110, 0);
                        bomb = new Bomb(BombType.Type.Dagger, Name.Dagger, Sprite.Name.Dagger,this, this.x, this.y - 110, 0);
                        break;
                    case 1:
                        //bomb = new Bomb(BombType.Type.MothershipBomb, Name.MothershipBomb, Sprite.Name.MothershipBomb,this, this.x, this.y - 110, 0);    
                        bomb = new Bomb(BombType.Type.ZigZag, Name.ZigZag, Sprite.Name.ZigZag,this, this.x, this.y - 110, 0);
                        break;
                    case 2:
                        //bomb = new Bomb(BombType.Type.MothershipBomb, Name.MothershipBomb, Sprite.Name.MothershipBomb, this, this.x, this.y - 110, 0);
                        bomb = new Bomb(BombType.Type.LineBomb, Name.LineBomb, Sprite.Name.LineBomb,this, this.x, this.y - 110, 0);
                        break;
                    default:
                        Debug.Assert(false);
                        break;

                }
                BombType bombRoot = (BombType)GameObjectManager.Find(GameObject.Name.BombRoot);
                SpriteBatch sb = SpriteBatchManager.Find(SpriteBatch.Name.Bombs);
                SpriteBatch boxes = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);
                bomb.attachSprite(sb);
                bomb.attachCollisionBox(boxes);
                bombTree.Insert(bomb, bombRoot);
            }
 
        }

        public void moveGrid()
        {
            ForwardIterator iterator = new ForwardIterator(this);

            PCSNode node = iterator.First();

            while (node != null)
            {
                GameObject gameObject = (GameObject)node;
                gameObject.x += this.delta;
                node = iterator.Next();

            }
            this.total += this.delta;
            if (this.total > 400.0f || this.total < 0.0f)
            {
                this.delta *= -1.0f;
            }
        }
    }
}
