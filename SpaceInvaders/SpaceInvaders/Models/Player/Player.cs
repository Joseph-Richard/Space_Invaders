using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Player:DLink
    {
        public enum Name{
            Player1,
            Player2, 
            FakeObject, 
            Uninitialized
        }
        public Name playerName;
        public ScreenText.Name scoreText; 
        public int currentScore;
        private int currentLevel; 
        public int playerLives;
        public Boolean isPlaying;
        public int credits;
        private PCSTree gameRoot;
        private MissileRoot missileRoot;
        private Alien AlienGrid;
        private float AlienGridDropDelta;
        private GameObjectManager gameObjectManager;
        private SpriteBatch spriteBatchBoxes;
        private WallRoot wallRoot;
        private ShieldType shieldRoot;
        private MothershipRoot mothershipRoot;
        private ShipRoot shipRoot;
        private BombRoot bombRoot;
        private AlienFactory alienFactory;
        private AnimationGrid animGrid;
        

        //private ShipManager shipManager;
        private TimerEvent animSquid;
        private TimerEvent animCrab;
        private TimerEvent animOcto;
        private TimerEvent GridMovement;
        private TimerEvent MothershipMovement;
        private AnimationSprite pAnimSquid;
        private AnimationSprite pAnimCrab;
        private AnimationSprite pAnimOcto;

        public Boolean EnterPressed;
        public Boolean GameStarted;
        public GameState gameState;
        public enum GameState
        {
            Select,
            Game, 
            GameOver, 
            Uninitialized
        }
        
        public Player()
            : base()
        {
            this.playerLives = 1;
            this.currentScore = 0000;
            this.isPlaying = false;
            this.gameObjectManager = GameObjectManager.getInstance();
            this.gameRoot = GameObjectManager.getTree();
            this.spriteBatchBoxes = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);
            
            this.currentLevel = 3;
            this.AlienGridDropDelta = this.currentLevel;
            this.EnterPressed = false;
            this.GameStarted = false;
            this.gameState = GameState.Select;
            this.credits = 00;
            
        }

        public void Set(Player.Name name, ScreenText.Name stName)
        {
            this.playerName = name;
            this.scoreText = stName;

            this.playerLives = 3;
            this.credits = 00;
            this.currentScore = 0000;
            this.isPlaying = false;
            this.gameObjectManager = GameObjectManager.getInstance();
            this.gameRoot = GameObjectManager.getTree();
            this.spriteBatchBoxes = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);
            this.currentLevel = 1;
            this.AlienGridDropDelta = this.currentLevel;
            this.EnterPressed = false;
            this.GameStarted = false;
            this.gameState = GameState.Select;
            
        }

        public void UpdateScore(int newPoints)
        {
            Debug.Assert(newPoints >= 0);

            this.currentScore += newPoints; 
        }

        public void loseLife()
        {
            this.playerLives -= 1; 
        }


        public void restPlayerValues()
        {
            this.playerLives = 3;
            this.currentScore = 0000;
            this.isPlaying = false;
        }


        public void playerStart()
        {
            this.isPlaying = true; 
        }

        public void playerEnd()
        {
            this.isPlaying = false;
        }

        public void resetGridAnimation()
        {
            TimerManager.Remove(this.GridMovement);
            //animGrid = new AnimationGrid(GameObject.Name.Grid);
            this.GridMovement = TimerManager.Add(TimerEvent.Name.GridAnimation, 0.65f, animGrid);
        }




        public Alien resetAliens()
        {
            this.AlienGridDropDelta = this.currentLevel * 10;

            this.AlienGrid = (Alien)GameObjectManager.Find(GameObject.Name.Grid);
             Grid grid = (Grid)AlienGrid;
             grid.currentLevel += 1;
            for (int i = 0; i < 11; i++)
            {
                this.alienFactory.setParentNode(this.AlienGrid);
                Alien Column = alienFactory.Create(Alien.Type.Column, 100.0f, 100.0f, i);
                this.alienFactory.setParentNode(Column);

                //Create A column HERE and then add the Aliens below.
                this.alienFactory.Create(Alien.Type.Squid, 100.0f + (66.0f * i), 733.0f - this.AlienGridDropDelta, i);//Squid Top Row
                this.alienFactory.Create(Alien.Type.Crab, 100.0f + (66.0f * i), 700.0f - this.AlienGridDropDelta, i);//Crab Row Upper
                this.alienFactory.Create(Alien.Type.Crab, 100.0f + (66.0f * i), 667.0f - this.AlienGridDropDelta, i);//Crab Row Lower
                this.alienFactory.Create(Alien.Type.Octo, 100.0f + (66.0f * i), 634.0f - this.AlienGridDropDelta, i);//Octo Row Upper
                this.alienFactory.Create(Alien.Type.Octo, 100.0f + (66.0f * i), 601.0f - this.AlienGridDropDelta, i);//Octo Row Lower
                grid.totalAliens += 5;
            }
            this.AlienGrid.Update();
            
            return AlienGrid;
        }
        public Alien setUpAliens()
        {
            this.AlienGridDropDelta = this.currentLevel * 10;
            PCSTree alienTree = new PCSTree();

            this.alienFactory = new AlienFactory(alienTree, SpriteBatch.Name.Aliens);

            //AlienFactory creating all the necessary rows of aliens
            alienFactory.setParentNode(null);
            this.AlienGrid = alienFactory.Create(Alien.Type.Grid);

            Grid grid = (Grid)AlienGrid;
            grid.currentLevel = 1;
            for (int i = 0; i < 11; i++)
            {
                alienFactory.setParentNode(AlienGrid);
                Alien Column = alienFactory.Create(Alien.Type.Column, 100.0f, 100.0f, i);
                alienFactory.setParentNode(Column);

                //Create A column HERE and then add the Aliens below.
                alienFactory.Create(Alien.Type.Squid, 100.0f + (66.0f * i), 733.0f-this.AlienGridDropDelta, i);//Squid Top Row
                alienFactory.Create(Alien.Type.Crab, 100.0f + (66.0f * i), 700.0f-this.AlienGridDropDelta, i);//Crab Row Upper
                alienFactory.Create(Alien.Type.Crab, 100.0f + (66.0f * i), 667.0f-this.AlienGridDropDelta, i);//Crab Row Lower
                alienFactory.Create(Alien.Type.Octo, 100.0f + (66.0f * i), 634.0f-this.AlienGridDropDelta, i);//Octo Row Upper
                alienFactory.Create(Alien.Type.Octo, 100.0f + (66.0f * i), 601.0f-this.AlienGridDropDelta, i);//Octo Row Lower
                grid.totalAliens += 5;
            }

            this.AlienGrid.Update();
           this.pAnimSquid = new AnimationSprite(Sprite.Name.Squid, this.AlienGrid);
            pAnimSquid.Attach(Image.Name.Squid2);
            pAnimSquid.Attach(Image.Name.Squid1);

            //Crab
            this.pAnimCrab = new AnimationSprite(Sprite.Name.Crab, this.AlienGrid);
            pAnimCrab.Attach(Image.Name.Crab2);
            pAnimCrab.Attach(Image.Name.Crab1);

            //Octo
            this.pAnimOcto = new AnimationSprite(Sprite.Name.Octo, this.AlienGrid);
            pAnimOcto.Attach(Image.Name.Octo2);
            pAnimOcto.Attach(Image.Name.Octo1);

            //Console.WriteLine((float)(this.gridClass.totalAliens / 100.0f)+0.20f);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.5f, this.pAnimSquid);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.75f, this.pAnimCrab);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, 1.0f, this.pAnimOcto);

            this.animGrid = new AnimationGrid(GameObject.Name.Grid);
            this.GridMovement = TimerManager.Add(TimerEvent.Name.GridAnimation, 0.65f, animGrid);
            return AlienGrid;
        }


        public GameObjectManager getGameObjectManager()
        {
            return this.gameObjectManager;
        }

        public MissileRoot setUpMissileRoot()
        {
            SpriteBatch bombs = SpriteBatchManager.Find(SpriteBatch.Name.Bombs);
            this.missileRoot = new MissileRoot(200, 100, 0);
            this.gameRoot.Insert(missileRoot, null);
            missileRoot.attachSprite(bombs);
            missileRoot.attachCollisionBox(this.spriteBatchBoxes);
            GameObjectManager.Attach(missileRoot, this.gameRoot);
            return this.missileRoot;
        }

        public WallRoot setUpGameWalls()
        {
            SpriteBatch walls = SpriteBatchManager.Find(SpriteBatch.Name.Walls);
            wallRoot = new WallRoot(0, 0, 0);
            this.gameRoot.Insert(wallRoot, null);
            wallRoot.attachSprite(walls);
            wallRoot.attachCollisionBox(this.spriteBatchBoxes);


            TopWall topWall = new TopWall(448, 1000, 870, 30, 0);
            this.gameRoot.Insert(topWall, wallRoot);
            topWall.attachSprite(walls);
            topWall.attachCollisionBox(this.spriteBatchBoxes);

            LeftWall leftWall = new LeftWall(10, 500, 10, 870, 0);
            this.gameRoot.Insert(leftWall, wallRoot);
            leftWall.attachSprite(walls);
            leftWall.attachCollisionBox(this.spriteBatchBoxes);


            RightWall rightWall = new RightWall(885, 500, 10, 870, 0);
            this.gameRoot.Insert(rightWall, wallRoot);
            rightWall.attachSprite(walls);
            rightWall.attachCollisionBox(this.spriteBatchBoxes);

            BottomWall bottomWall = new BottomWall(448, 40, 870, 1, 0);
            this.gameRoot.Insert(bottomWall, wallRoot);
            bottomWall.attachSprite(walls);
            bottomWall.attachCollisionBox(this.spriteBatchBoxes);

            GameObjectManager.Attach(wallRoot, this.gameRoot);

            return this.wallRoot;
        }


        public ShieldType setUpShields()
        {
            float shieldX = 20;
            float shieldY = 10;
            PCSTree shieldTree = new PCSTree();
            ShieldFactory shieldFactory = new ShieldFactory(shieldTree, SpriteBatch.Name.Shields);
            shieldFactory.setParent(null);

            this.shieldRoot = shieldFactory.Create(ShieldType.Type.ShieldRoot, GameObject.Name.ShieldRoot, 0.0f, 0.0f, 0);
            shieldFactory.setParent(shieldRoot);
            float x = 70.0f;
            float y = 140.0f;
            for (float i = 1f; i < 5; i++)
            {
                int k = 0;
                float xInterval = shieldX;
                float yInterval = shieldY;

                shieldFactory.setParent(shieldRoot);
                ShieldType column = shieldFactory.Create(ShieldType.Type.ShieldColumn, GameObject.Name.ShieldColumn, 0, 0, k);
                shieldFactory.setParent(column);

                //Column 1
                for (int j = 0; j < 8; j++)
                {
                    shieldFactory.Create(ShieldType.Type.ShieldBrick, GameObject.Name.ShieldBrick, x + xInterval, y + yInterval * j, j);
                }
                shieldFactory.Create(ShieldType.Type.ShieldTopLeftEmptySmall, GameObject.Name.ShieldBrick, x + xInterval, y + yInterval * 8, 0);
                shieldFactory.Create(ShieldType.Type.ShieldTopLeftEmptyLarge, GameObject.Name.ShieldBrick, x + xInterval, y + yInterval * 9, 0);


                //Column 2
                shieldFactory.setParent(shieldRoot);
                column = shieldFactory.Create(ShieldType.Type.ShieldColumn, GameObject.Name.ShieldColumn, 0, 0, k += 1);
                shieldFactory.setParent(column);
                for (int j = 0; j < 10; j++)
                {
                    shieldFactory.Create(ShieldType.Type.ShieldBrick, GameObject.Name.ShieldBrick, x + xInterval * 2, y + yInterval * j, j);
                }

                //Column 3
                shieldFactory.setParent(shieldRoot);
                column = shieldFactory.Create(ShieldType.Type.ShieldColumn, GameObject.Name.ShieldColumn, 0, 0, k += 1);
                shieldFactory.setParent(column);

                shieldFactory.Create(ShieldType.Type.ShieldBottomRightEmpty, GameObject.Name.ShieldBrick, x + xInterval * 3, y + yInterval * 2, 0);
                for (int j = 0; j < 7; j++)
                {
                    shieldFactory.Create(ShieldType.Type.ShieldBrick, GameObject.Name.ShieldBrick, x + xInterval * 3, y + yInterval * (j + 3), j);
                }


                //Column 4
                shieldFactory.setParent(shieldRoot);
                column = shieldFactory.Create(ShieldType.Type.ShieldColumn, GameObject.Name.ShieldColumn, 0, 0, k += 1);
                shieldFactory.setParent(column);
                for (int j = 0; j < 7; j++)
                {
                    shieldFactory.Create(ShieldType.Type.ShieldBrick, GameObject.Name.ShieldBrick, x + xInterval * 4, y + yInterval * (j + 3), j);
                }


                //Column 5
                shieldFactory.setParent(shieldRoot);
                ShieldType column5 = shieldFactory.Create(ShieldType.Type.ShieldColumn, GameObject.Name.ShieldColumn, 0, 0, k += 1);
                shieldFactory.setParent(column5);
                shieldFactory.Create(ShieldType.Type.ShieldBottomLeftEmpty, GameObject.Name.ShieldBrick, x + xInterval * 5, y + yInterval * 2, 0);
                for (int j = 0; j < 7; j++)
                {
                    shieldFactory.Create(ShieldType.Type.ShieldBrick, GameObject.Name.ShieldBrick, x + xInterval * 5, y + yInterval * (j + 3), j);
                }

                //Column 6
                shieldFactory.setParent(shieldRoot);
                column = shieldFactory.Create(ShieldType.Type.ShieldColumn, GameObject.Name.ShieldColumn, 0, 0, k += 1);
                shieldFactory.setParent(column);
                for (int j = 0; j < 10; j++)
                {
                    shieldFactory.Create(ShieldType.Type.ShieldBrick, GameObject.Name.ShieldBrick, x + xInterval * 6, y + yInterval * j, j);
                }


                //Column 7
                shieldFactory.setParent(shieldRoot);
                column = shieldFactory.Create(ShieldType.Type.ShieldColumn, GameObject.Name.ShieldColumn, 0, 0, k += 1);
                shieldFactory.setParent(column);
                for (int j = 0; j < 8; j++)
                {
                    shieldFactory.Create(ShieldType.Type.ShieldBrick, GameObject.Name.ShieldBrick, x + xInterval * 7, y + yInterval * j, j);
                }

                shieldFactory.Create(ShieldType.Type.ShieldTopRightEmptySmall, GameObject.Name.ShieldBrick, x + xInterval * 7, y + yInterval * 8, 0);
                shieldFactory.Create(ShieldType.Type.ShieldTopRightEmptyLarge, GameObject.Name.ShieldBrick, x + xInterval * 7, y + yInterval * 9, 0);
                x = x + xInterval * 9.5f;

            }


            GameObjectManager.Attach(shieldRoot, this.gameRoot);

            return this.shieldRoot;

        }


        public MothershipRoot setupMothership()
        {
            SpriteBatch mothership = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            this.mothershipRoot = new MothershipRoot(0, 0, 0);
            this.gameRoot.Insert(mothershipRoot, null);
            this.mothershipRoot.attachCollisionBox(this.spriteBatchBoxes);
            this.mothershipRoot.attachSprite(mothership);

            GameObjectManager.Attach(mothershipRoot, this.gameRoot);

            AnimationMothership animMothership = new AnimationMothership(this.mothershipRoot);
            this.MothershipMovement = TimerManager.Add(TimerEvent.Name.CreateMothership, 15.0f, animMothership);

            return this.mothershipRoot;
        }

        public ShipRoot setUpUserShip()
        {
            SpriteBatch ships = SpriteBatchManager.Find(SpriteBatch.Name.PlayerShip);
            this.shipRoot = new ShipRoot(0, 0, 0);
            this.shipRoot.attachCollisionBox(this.spriteBatchBoxes);
            this.shipRoot.attachSprite(ships);
            this.gameRoot.Insert(this.shipRoot, null);
            GameObjectManager.Attach(this.shipRoot, this.gameRoot);
            ShipManager.Create();
            return this.shipRoot;
        }

        public BombRoot setUpBombRoot()
        {
            SpriteBatch bombs = SpriteBatchManager.Find(SpriteBatch.Name.Bombs);
            this.bombRoot = new BombRoot(0, 0, 0);
            this.bombRoot.attachCollisionBox(this.spriteBatchBoxes);
            this.bombRoot.attachSprite(bombs);
            this.gameRoot.Insert(bombRoot, null);

            GameObjectManager.Attach(bombRoot, this.gameRoot);



            return this.bombRoot;
        }


        public void setUpCollisions()
        {
            //Missile Vs Aliens----------------------------------------------------------------------
            GameObject go1 = (GameObject)this.AlienGrid;
            GameObject go2 = (GameObject)this.missileRoot;
            CollisionPair cp = CollisionPairManager.Add(CollisionPair.Name.AlienVsMissle, go1, go2);
            cp.AddListenter(new ShipReadyObs());
            cp.AddListenter(new DeleteMissileObs());
            cp.AddListenter(new DeleteAlienObs());
            cp.AddListenter(new UpdateScoreObserver());

            //Missile vs Walls----------------------------------------------------------------------
            go1 = (GameObject)this.wallRoot;
            go2 = (GameObject)this.missileRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.MissileVsWall, go1, go2);
            cp.AddListenter(new DeleteMissileObs());
            cp.AddListenter(new ShipReadyObs());

            //Aliens Vs Walls------------------------------------------------------------------------
            go1 = (GameObject)this.wallRoot;
            go2 = (GameObject)this.AlienGrid;
            cp = CollisionPairManager.Add(CollisionPair.Name.AlienVsWall, go1, go2);
            cp.AddListenter(new GridHorizontalSwitchObs());
            cp.AddListenter(new BottomWallEndGameObs());


            //Missile vs Shields---------------------------------------------------------------------
            go1 = (GameObject)this.shieldRoot;
            go2 = (GameObject)this.missileRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.MissleVsShield, go1, go2);
            cp.AddListenter(new DeleteShieldBrickObs());
            cp.AddListenter(new DeleteMissileObs());
            cp.AddListenter(new ShipReadyObs());

            //Missile vs Bomb------------------------------------------------------------------------
            go1 = (GameObject)this.bombRoot;
            go2 = (GameObject)this.missileRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.BombVsMissle, go1, go2);
            cp.AddListenter(new DeleteMissileObs());
            cp.AddListenter(new DeleteBombObs());
            cp.AddListenter(new ShipReadyObs());

            //Missile vs Mothership------------------------------------------------------------------
            go1 = (GameObject)this.missileRoot;
            go2 = (GameObject)this.mothershipRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.MissleVsUFO, go1, go2);
            cp.AddListenter(new DeleteMissileObs());
            cp.AddListenter(new ShipReadyObs());
            cp.AddListenter(new DeleteMothershipObs());
            cp.AddListenter(new UpdateMothershipScore());


            //Bomb vs Shield-------------------------------------------------------------------------

            go1 = (GameObject)this.bombRoot;
            go2 = (GameObject)this.shieldRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.BombVsShield, go1, go2);
            cp.AddListenter(new DeleteShieldBrickObs());
            cp.AddListenter(new DeleteBombObs());

            //Alien Grid vs Shield-------------------------------------------------------------------
            go1 = (GameObject)this.shieldRoot;
            go2 = (GameObject)this.AlienGrid;
            cp = CollisionPairManager.Add(CollisionPair.Name.AlienVsShield, go1, go2);
            cp.AddListenter(new DeleteShieldBrickObs());

            //Bomb vs Wall---------------------------------------------------------------------------
            go1 = (GameObject)this.bombRoot;
            go2 = (GameObject)this.wallRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.BombVsWall, go1, go2);
            cp.AddListenter(new DeleteBombObs());

            //Mothership Vs Wall---------------------------------------------------------------------
            go1 = (GameObject)this.wallRoot;
            go2 = (GameObject)this.mothershipRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.UFOVsWall, go1, go2);
            cp.AddListenter(new MothershipCollisionObs());


            //Usership Vs Bomb-----------------------------------------------------------------------
            go1 = (GameObject)this.shipRoot;
            go2 = (GameObject)this.bombRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.BombVsFryship, go1, go2);
            cp.AddListenter(new DeleteBombObs());
            cp.AddListenter(new UserDeathObs());

            //Usership Vs Walls----------------------------------------------------------------------
            go1 = (GameObject)this.shipRoot;
            go2 = (GameObject)this.wallRoot;
            cp = CollisionPairManager.Add(CollisionPair.Name.FryshipVsWall, go1, go2);
            cp.AddListenter(new PlayerBoundaryObs());

        }


        public void resetAlienAnimations()
        {
            TimerManager.Remove(this.animCrab);
            TimerManager.Remove(this.animSquid);
            
            TimerManager.Remove(this.animOcto);



            this.animCrab = TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.75f, this.pAnimCrab);
            this.animSquid = TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.5f, this.pAnimSquid);
            
            this.animOcto = TimerManager.Add(TimerEvent.Name.SpriteAnimation, 1.0f, this.pAnimOcto);
        }
        public void setUpBombAnimations()
        {
            //Dagger
            AnimationSprite animDagger = new AnimationSprite(Sprite.Name.Dagger, this.AlienGrid);
            animDagger.Attach(Image.Name.Dagger2);
            animDagger.Attach(Image.Name.Dagger1);

            //Dagger
            AnimationSprite animZigZag = new AnimationSprite(Sprite.Name.ZigZag, this.AlienGrid);
            animZigZag.Attach(Image.Name.ZigZag2);
            animZigZag.Attach(Image.Name.ZigZag1);

            //Dagger
            AnimationSprite animBomb = new AnimationSprite(Sprite.Name.LineBomb, this.AlienGrid);
            animBomb.Attach(Image.Name.LineBomb2);
            animBomb.Attach(Image.Name.LineBomb1);

            AnimationBomb animBomb1 = new AnimationBomb(null);
            TimerManager.Add(TimerEvent.Name.BombDrop, 1.7f, animBomb1);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.362f, animDagger);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.361f, animZigZag);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.36f, animBomb);
        }

        public void closeOutGame()
        {
          
            ShipManager.Nullify();
            this.bombRoot = null;
            this.AlienGrid = null;
            this.shieldRoot = null;
            this.mothershipRoot = null;
            this.missileRoot = null;

            this.playerLives = 3;
            
            
            GameObjectManager.RemoveAll();
            TimerManager.RemoveAll();
        }




        //-------------------------------------------------------------------------------------------------
        //Helpers
        //-------------------------------------------------------------------------------------------------
        public void LevelUp()
        {
            this.currentLevel += 1; 
        }

        public void SelectToGame()
        {
            this.EnterPressed = true;
        }



    }
}
