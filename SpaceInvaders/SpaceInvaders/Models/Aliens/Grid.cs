using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Grid:Alien
    {
        /**
         * Fields
         * */
        private float deltaX;
        private float deltaY;
        private float total;
        public float totalAliens;
        public Boolean rightWall;
        public Boolean leftWall;
        public Boolean BottomWall;
        public Boolean isDelayed;
        public int callCount;
        public int callCountPrev;
        private int soundStep;
        public float currentLevel; 
        /**
         * Grid Constructor
         * */
        public Grid(float x, float y, float total=0.0f, int index=0)
            : base(Alien.Type.Grid,GameObject.Name.Grid, Sprite.Name.FakeObject, index)
        {
          //  Debug.WriteLine("Grid Constructor Method was called.");
            this.x = x;
            this.y = y;
            this.deltaX = 20.0f;
            this.deltaY = 20.0f;
            this.total = total;
            //turnOFFCollisionBox();
            this.collisionObj.proxyBox.swapColors(1, 1, 1);
            this.rightWall = false;
            this.leftWall = false;
            this.callCount = 0;
            this.callCountPrev = this.callCount;
            this.totalAliens = 0;
            this.soundStep = 1;
            this.currentLevel = 1;
        }

        public override void Update()
        {
         //   Debug.WriteLine("Grid Update Method was called.");

            base.updateBoundingBox();
            //this.MoveGrid();
            base.Update();
            
        }

        public override void Remove()
        {
            //this.collisionObj.collisionRect.Set(0, 0, 0, 0);
            //base.Remove();
            GameObject mothership = GameObjectManager.Find(GameObject.Name.Mothership);
            if (mothership != null)
            {
                Mothership m = (Mothership)mothership;
                if (m.isOnScreen == true)
                {
                    m.Remove();
                }
            }
            base.Remove();
            //Player currentPlayer = PlayerManager.getCurrentPlayer();
     //       currentPlayer.LevelUp();
     //       currentPlayer.setUpAliens();
        }

        /**
         * Grid Accept Method
         * */
        public override void Accept(Visitor v)
        {
         //   Console.Write("Grid hit -> ");
            v.visitGrid(this);
        }

        public override void visitMissileRoot(MissileRoot m)
        {
         //   Console.WriteLine("Grid.");
            CollisionPair.checkForCollision(m, (GameObject)this.child);
        }

        public override void visitMissile(Missile m)
        {
         //   Console.WriteLine("Grid.");
            CollisionPair.checkForCollision(m, (GameObject)this.child);
            //GameObjectManager.Remove(m);
        }

        public override void visitWallRoot(WallRoot wr)
        {
            
            CollisionPair.checkForCollision(this, (GameObject)wr.child);
        }
        public override void visitLeftWall(LeftWall w)
        {
            if (this.rightWall == true)
            {
                this.rightWall = false;
                this.isDelayed = false;
            }
            Console.WriteLine("HIT LEFT WALL");
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }

        public override void visitRightWall(RightWall w)
        {
            if (this.leftWall == true)
            {
                this.leftWall = false;
                this.isDelayed = false;
            }
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }

        public override void visitBottomWall(BottomWall w)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(w, this);
            cp.NotifyListeners();
        }

        public override void visitShieldRoot(ShieldRoot s)
        {
            CollisionPair.checkForCollision(this, (GameObject)s.child);
        }

        public override void visitShieldColumn(ShieldColumn s)
        {
            CollisionPair.checkForCollision(this, (GameObject)s.child);
        }

        public override void visitShieldBrick(ShieldBrick s)
        {
            CollisionPair cp = CollisionPairManager.getCurrentCollisionPair();
            cp.updateCollisionGroup(s, this);
            cp.NotifyListeners();
        }













        public static Grid selectGrid(GameObject a, GameObject b)
        {
            GameObject result = null;
            if (a is Grid)
            {
                result = a;
            }
            else
            {
                result = b;
            }
            return (Grid)result;
        }


        /**
         * Grid Move Function
         * --FIX: Add it to the TimerManager to be called every once and a while
         * */
        public void MoveGrid()
        {

            ForwardIterator iterator = new ForwardIterator(this);

            PCSNode node = iterator.First();

            while (!iterator.isDone())
            {
                GameObject gameObject = (GameObject)node;
                if (gameObject is Alien)
                {
                    //this.totalAliens += 1;
                }
                node = iterator.Next();
            }

            node = iterator.First();
            while (!iterator.isDone())
            {
                GameObject gameObject = (GameObject)node;
                gameObject.x += this.deltaX;
                node = iterator.Next();
            }
            Sound alienStep = null;
            switch(this.soundStep){
                case 1:
                    alienStep = SoundManager.Find(Sound.Name.GridMovement1);
                    this.soundStep = 2;
                    break;
                case 2:
                    alienStep = SoundManager.Find(Sound.Name.GridMovement2);
                    this.soundStep = 3;
                    break;
                case 3:
                    alienStep = SoundManager.Find(Sound.Name.GridMovement3);
                    this.soundStep = 4;
                    break;
                case 4:
                    alienStep = SoundManager.Find(Sound.Name.GridMovement4);
                    this.soundStep = 1;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            alienStep.activateSound();
            
        }

        public void ChangeDirection()
        {
            this.deltaX *= -1;
            this.traverseTreeY(this);
        }

        /**
         * Grid UpdateTree Method
         * --Recursively traverse through a PCSTREE
         * --Call update() on each child so that the grid goes down before it begins crossing the screen again
         * --traverse each child recursively 
         * */
        private void updateTree(GameObject node)
        {
            PCSNode child = null;

            this.Update();

            if (node.child != null)
            {
                child = node.child;

                while (child != null)
                {
                    this.updateTree((GameObject)child);
                    child = child.sibling;
                }
            }
            else
            {
                return;
            }
        }

        /**
         *Grid traverseTreeY Method
         * --Recursively traverse through a PCSTREE
         * --update the Y value of every GameObject in the tree
         * --traverse each child recursively 
         * */
        private void traverseTreeY(GameObject node)
        {
            PCSNode child = null;

            node.y -= this.deltaY;

            if (node.child != null)
            {
                child = node.child;

                while (child != null)
                {
                    this.traverseTreeY((GameObject)child);
                    child = child.sibling;
                }
            }
            else
            {

                return;
            }
        }


        /**
         * Grid traverseTreeY Method
         * --Recursively traverse through a PCSTREE
         * --update the X value of every GameObject in the tree
         * --traverse each child recursively 
         * */
        private void traverseTreeX(GameObject node)
        {
            PCSNode child = null;

            node.x += this.deltaX;

            if (node.child != null)
            {
                child = node.child;

                while (child != null)
                {
                    this.traverseTreeX((GameObject)child);
                    child = child.sibling;
                }
            }
            else
            {
                return;
            }
        }
    }
}
