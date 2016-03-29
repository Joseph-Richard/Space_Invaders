using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("->Set Screen Title Name Here<-");
            this.SetWidthHeight(896, 1024);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
                TextureManager.Create(3, 2);
                  ImageManager.Create(3, 2);
                 SpriteManager.Create(3, 2);
            SpriteBatchManager.Create(3, 2);
                  TimerManager.Create(3, 2);
            ProxySpriteManager.Create(3, 2);
             GameObjectManager.Create(3, 2);
             SpriteBoxManager.Create(3, 2);
             CollisionPairManager.Create(3, 2);
            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------
                Azul.Texture pAliensTex = new Azul.Texture("Sprites.tga");
                Debug.Assert(pAliensTex != null);

                TextureManager.Add(Texture.Name.Aliens, "Sprites.tga");
                
            //--------------------------------------------------------------------------------------------------------
            //Create the SpriteBatch groups
            //--------------------------------------------------------------------------------------------------------

               SpriteBatch sBAliens = SpriteBatchManager.Add(SpriteBatch.Name.Aliens,3,2);
               SpriteBatch sBSpriteBoxes = SpriteBatchManager.Add(SpriteBatch.Name.SpriteBoxes, 3, 2);

            //---------------------------------------------------------------------------------------------------------
            // Create Images in Image Manager
            //---------------------------------------------------------------------------------------------------------
                ImageManager.Add(Image.Name.Squid1, Texture.Name.Aliens, 256.0f, 0.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Squid2, Texture.Name.Aliens, 384.0f, 0.0f, 128.0f, 85.0f);

                ImageManager.Add(Image.Name.Crab1, Texture.Name.Aliens, 0.0f, 0.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Crab2, Texture.Name.Aliens, 128.0f, 0.0f, 128.0f, 85.0f);

                ImageManager.Add(Image.Name.Octo1, Texture.Name.Aliens, 0.0f, 85.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Octo2, Texture.Name.Aliens, 128.0f, 85.0f, 128.0f, 85.0f);    

                ImageManager.Add(Image.Name.Mothership, Texture.Name.Aliens, 0.0f, 425.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Fryship, Texture.Name.Aliens, 128.0f, 425.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Missile, Texture.Name.Aliens, 128.0f ,510.0f, 128.0f, 85.0f);    
            


            //---------------------------------------------------------------------------------------------------------
            //Create Sprites in Sprite Manager
            //---------------------------------------------------------------------------------------------------------
                //Crab aliens are size 45x33
                SpriteManager.Add(Sprite.Name.Crab, Image.Name.Crab1, 200.0f, 200.0f, 45.0f, 33.0f);
                SpriteManager.Add(Sprite.Name.Fryship, Image.Name.Fryship, 100.0f, 100.0f, 128.0f, 85.0f);

                //Octo aliens are size 49x33
                SpriteManager.Add(Sprite.Name.Octo, Image.Name.Octo1, 300.0f, 300.0f, 49.0f, 33.0f);
                SpriteManager.Add(Sprite.Name.Mothership, Image.Name.Mothership, 100.0f, 800.0f, 128.0f, 85.0f);

                //Squid aliens are size 33x33
                SpriteManager.Add(Sprite.Name.Squid, Image.Name.Squid1, 500.0f, 500.0f, 33.0f, 33.0f);
                SpriteManager.Add(Sprite.Name.Missile, Image.Name.Missile, 100.0f, 100.0f, 33.0f, 33.0f);
                
            //---------------------------------------------------------------------------------------------------------
            //Attach Sprites to SpriteBatches
            //---------------------------------------------------------------------------------------------------------
                
                                //sBAliens.Attach(Sprite.Name.Octo);
                //sBAliens.Attach(Sprite.Name.Squid);
                PCSTree alienTree = new PCSTree();

                AlienFactory alienFactory = new AlienFactory(alienTree,SpriteBatch.Name.Aliens);

                //AlienFactory creating all the necessary rows of aliens
                alienFactory.setParentNode(null);
                Alien grid = alienFactory.Create(Alien.Type.Grid, 10.0f, 10.0f,0);
                //alienFactory.setParentNode(grid);
                
                for (int i = 0; i < 1; i++)
                {
                    alienFactory.setParentNode(grid);
                    Alien Column = alienFactory.Create(Alien.Type.Column, 0, 0, i);
                    alienFactory.setParentNode(Column);

                    //Create A column HERE and then add the Aliens below.
                    alienFactory.Create(Alien.Type.Squid, 100.0f + 66.0f * i, 733.0f,i);//Squid Top Row
                    alienFactory.Create(Alien.Type.Crab, 100.0f + 66.0f * i, 700.0f, i);//Crab Row Upper
                    alienFactory.Create(Alien.Type.Crab, 100.0f + 66.0f * i, 667.0f, i);//Crab Row Lower
                    alienFactory.Create(Alien.Type.Octo, 100.0f + 66.0f * i, 634.0f, i);//Octo Row Upper
                    alienFactory.Create(Alien.Type.Octo, 100.0f + 66.0f * i, 601.0f, i);//Octo Row Lower
                }

            /**
             * Missile Stuff
             * */

                PCSTree missileTree = new PCSTree();
                MissileRoot mRoot = new MissileRoot(0, 0, 1);
                Missile missile = new Missile(100, 300);

                missileTree.Insert(missile, mRoot);
                mRoot.attachCollisionBox(sBAliens);
                missile.attachCollisionBox(sBAliens);
                mRoot.attachSprite(sBAliens);
                missile.attachSprite(sBAliens);
                GameObjectManager.Attach(mRoot, missileTree);
                

                //FIX: Is there a better way to hide the animation sprite stuff?

                //IF YOU ATTACH 1 then 2, there is a delay in the animation.

                //Grid Movement
                AnimationGrid pAnimGrid = new AnimationGrid(GameObject.Name.Grid);

                //Squid
                AnimationSprite pAnimSquid = new AnimationSprite(Sprite.Name.Squid);
                pAnimSquid.Attach(Image.Name.Squid2);
                pAnimSquid.Attach(Image.Name.Squid1);

                //Crab
                AnimationSprite pAnimCrab = new AnimationSprite(Sprite.Name.Crab);
                pAnimCrab.Attach(Image.Name.Crab2);
                pAnimCrab.Attach(Image.Name.Crab1);

                //Octo
                AnimationSprite pAnimOcto = new AnimationSprite(Sprite.Name.Octo);
                pAnimOcto.Attach(Image.Name.Octo2);
                pAnimOcto.Attach(Image.Name.Octo1);
                
            //---------------------------------------------------------------------------------------------
            //Add timer events to timermanager
            //Squid(0.5)
            //Crab (0.75)
            //Octo (1.0)
            //---------------------------------------------------------------------------------------------
                
                TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.5f, pAnimSquid);
                TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.75f, pAnimCrab);
                TimerManager.Add(TimerEvent.Name.SpriteAnimation, 1.0f, pAnimOcto);
                TimerManager.Add(TimerEvent.Name.GridAnimation, 0.65f, pAnimGrid);
            //---
            //Collision Stuff
            //---
                GameObject go1 = (GameObject)grid;
                GameObject go2 = (GameObject)mRoot;
                CollisionPairManager.Add(CollisionPair.Name.AlienVsMissle, go1, go2);
        }
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {

            // Uncomment to see how they work
            //InputTest.KeyboardTest();
            //InputTest.MouseTest();
            Console.WriteLine("Game.Update() Called");
            Console.WriteLine("TimerManager.Update("+this.GetTime()+") was called");

            TimerManager.Update(this.GetTime());
            //Grid pGrid = (Grid)GameObjectManager.Find(GameObject.Name.Grid);
            //pGrid.Move();
            GameObjectManager.Update();
            CollisionPairManager.Process();
              
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SpriteBatchManager.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

