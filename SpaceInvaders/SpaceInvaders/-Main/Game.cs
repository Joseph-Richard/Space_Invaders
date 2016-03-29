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
        //Sprite explosion;
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
             GlyphManager.Create(3, 2);
             ScreenTextManager.Create(3, 2);
             SoundManager.Create(3, 2);
             InputManager.Create();
             PlayerManager.Create(3, 2);

             
            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------
                Azul.Texture pAliensTex = new Azul.Texture("Sprites.tga");
                
                Debug.Assert(pAliensTex != null);

                TextureManager.Add(Texture.Name.Aliens, "Sprites.tga");
                TextureManager.Add(Texture.Name.Shield, "birds_N_shield.tga");
                TextureManager.Add(Texture.Name.Bullets, "aliensv4.tga");
                TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
                
            
            //--------------------------------------------------------------------------------------------------------
            //Set up Sounds
            //--------------------------------------------------------------------------------------------------------
                SoundManager.Add(Sound.Name.Theme, "theme.wav");
                SoundManager.Add(Sound.Name.MissileFire, "shoot.wav");
                SoundManager.Add(Sound.Name.AlienKilled, "invaderkilled.wav");
                SoundManager.Add(Sound.Name.UFO_HighPitch, "ufo_highpitch.wav");
                SoundManager.Add(Sound.Name.UFO_LowPitch, "ufo_lowpitch.wav");
                SoundManager.Add(Sound.Name.ShipExplosion, "explosion.wav");
                SoundManager.Add(Sound.Name.GridMovement1, "fastinvader1.wav");
                SoundManager.Add(Sound.Name.GridMovement2, "fastinvader2.wav");
                SoundManager.Add(Sound.Name.GridMovement3, "fastinvader3.wav");
                SoundManager.Add(Sound.Name.GridMovement4, "fastinvader4.wav");
            
            
            //--------------------------------------------------------------------------------------------------------
            //Create the SpriteBatch groups
            //--------------------------------------------------------------------------------------------------------
                
                
               SpriteBatch sBAliens = SpriteBatchManager.Add(SpriteBatch.Name.Aliens,3,2);
               SpriteBatch sBSpriteBoxes = SpriteBatchManager.Add(SpriteBatch.Name.SpriteBoxes, 3, 2);
               SpriteBatch sBShields = SpriteBatchManager.Add(SpriteBatch.Name.Shields, 3, 2);
               SpriteBatch sBBombs = SpriteBatchManager.Add(SpriteBatch.Name.Bombs, 3, 2);
               SpriteBatch sBScreenTexts = SpriteBatchManager.Add(SpriteBatch.Name.ScreenText, 3, 2);
               SpriteBatch sBExplosions = SpriteBatchManager.Add(SpriteBatch.Name.Explosions, 3, 2);
               SpriteBatchManager.Add(SpriteBatch.Name.PlayerShip, 1, 1);
               SpriteBatchManager.Add(SpriteBatch.Name.SelectScreenText, 9, 1);
               SpriteBatchManager.Add(SpriteBatch.Name.GameScreenText, 2, 2);
               SpriteBatchManager.Add(SpriteBatch.Name.GameOverScreenText, 1, 2);
               SpriteBatchManager.Add(SpriteBatch.Name.Walls, 4, 2);
               SpriteBatchManager.Add(SpriteBatch.Name.StupidColumns, 12, 5);
            //---------------------------------------------------------------------------------------------------------
            // Create Images in Image Manager
            //---------------------------------------------------------------------------------------------------------
                ImageManager.Add(Image.Name.Squid1, Texture.Name.Aliens, 256.0f, 0.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Squid2, Texture.Name.Aliens, 384.0f, 0.0f, 128.0f, 85.0f);

                ImageManager.Add(Image.Name.Crab1, Texture.Name.Aliens, 0.0f, 0.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Crab2, Texture.Name.Aliens, 128.0f, 0.0f, 128.0f, 85.0f);

                ImageManager.Add(Image.Name.Octo1, Texture.Name.Aliens, 0.0f, 85.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Octo2, Texture.Name.Aliens, 128.0f, 85.0f, 128.0f, 85.0f);

                ImageManager.Add(Image.Name.AlienExplosion, Texture.Name.Aliens, 384.0f, 425.0f, 128.0f, 85.0f);

                ImageManager.Add(Image.Name.Mothership, Texture.Name.Aliens, 0.0f, 425.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.MothershipBomb, Texture.Name.Bullets, 80.0f, 1952.0f, 90.0f, 170.0f);
                ImageManager.Add(Image.Name.Fryship, Texture.Name.Aliens, 128.0f, 425.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.FryshipExplosion, Texture.Name.Aliens, 256.0f, 425.0f, 128.0f, 85.0f);
                ImageManager.Add(Image.Name.Missile, Texture.Name.Aliens, 236.0f ,527.0f, 7.0f, 43.0f);


                ImageManager.Add(Image.Name.ZigZag1, Texture.Name.Aliens, 170.0f, 527.0f, 20.0f, 50.0f);
                ImageManager.Add(Image.Name.ZigZag2, Texture.Name.Aliens, 186.0f, 527.0f, 20.0f, 50.0f);

                ImageManager.Add(Image.Name.Dagger1, Texture.Name.Aliens, 137.0f, 530.0f, 20.0f, 40.0f);
                ImageManager.Add(Image.Name.Dagger2, Texture.Name.Aliens, 154.0f, 530.0f, 20.0f, 40.0f);

                ImageManager.Add(Image.Name.LineBomb1, Texture.Name.Aliens, 202.0f, 531.0f, 20.0f, 40.0f);
                ImageManager.Add(Image.Name.LineBomb2, Texture.Name.Aliens, 218.0f, 531.0f, 20.0f, 40.0f);

                //Shields
                ImageManager.Add(Image.Name.ShieldBrick, Texture.Name.Shield, 20, 210, 10, 5);
                ImageManager.Add(Image.Name.ShieldBottomRightEmpty, Texture.Name.Shield, 35, 215, 10, 5);
                ImageManager.Add(Image.Name.ShieldBottomLeftEmpty, Texture.Name.Shield, 55, 215, 10, 5);
                ImageManager.Add(Image.Name.ShieldTopLeftEmptyLarge, Texture.Name.Shield, 15, 180, 10, 5);
                ImageManager.Add(Image.Name.ShieldTopLeftEmptySmall, Texture.Name.Shield, 15, 185, 10, 5);
                ImageManager.Add(Image.Name.ShieldTopRightEmptyLarge, Texture.Name.Shield, 75, 180, 10, 5);
                ImageManager.Add(Image.Name.ShieldTopRightEmptySmall, Texture.Name.Shield, 75, 185, 10, 5);
            //---------------------------------------------------------------------------------------------------------
            //Create Sprites in Sprite Manager
            //---------------------------------------------------------------------------------------------------------
                //Crab aliens are size 45x33
                SpriteManager.Add(Sprite.Name.Crab, Image.Name.Crab1, 200.0f, 200.0f, 45.0f, 33.0f);
                

                //Octo aliens are size 49x33
                SpriteManager.Add(Sprite.Name.Octo, Image.Name.Octo1, 300.0f, 300.0f, 49.0f, 33.0f);
                

                //Squid aliens are size 33x33
                SpriteManager.Add(Sprite.Name.Squid, Image.Name.Squid1, 500.0f, 500.0f, 33.0f, 33.0f);

                //AlienExplosion
                SpriteManager.Add(Sprite.Name.AlienExplosion, Image.Name.AlienExplosion, 200.0f, 200.0f, 45.0f, 33.0f);

                //FryShip
                SpriteManager.Add(Sprite.Name.Fryship, Image.Name.Fryship, 100.0f, 100.0f, 128.0f, 85.0f);
                SpriteManager.Add(Sprite.Name.FryshipExplosion, Image.Name.FryshipExplosion, 100.0f, 100.0f, 128.0f, 85.0f);

                //Missile
                SpriteManager.Add(Sprite.Name.Missile, Image.Name.Missile, 100.0f, 100.0f, 5.0f, 50.0f);

                //Bombs
                SpriteManager.Add(Sprite.Name.Dagger, Image.Name.Dagger1, 300.0f, 300.0f, 15, 45);
                SpriteManager.Add(Sprite.Name.ZigZag, Image.Name.ZigZag1, 300.0f, 300.0f, 15, 45);
                SpriteManager.Add(Sprite.Name.LineBomb, Image.Name.LineBomb1, 300.0f, 300.0f, 15, 45);

                //Mothership
                SpriteManager.Add(Sprite.Name.Mothership, Image.Name.Mothership, 100.0f, 800.0f, 65.0f, 45.0f);
                SpriteManager.Add(Sprite.Name.MothershipBomb, Image.Name.MothershipBomb, 300.0f, 300.0f, 25.0f, 46.0f);

                //Shield
                float shieldX = 20;
                float shieldY = 10;
                SpriteManager.Add(Sprite.Name.ShieldBrick, Image.Name.ShieldBrick, 50, 25, shieldX, shieldY);
                SpriteManager.Add(Sprite.Name.ShieldBottomLeftEmpty, Image.Name.ShieldBottomLeftEmpty, 50, 25, shieldX, shieldY);
                SpriteManager.Add(Sprite.Name.ShieldBottomRightEmpty, Image.Name.ShieldBottomRightEmpty, 50, 25, shieldX, shieldY);
                SpriteManager.Add(Sprite.Name.ShieldTopLeftEmptyLarge, Image.Name.ShieldTopLeftEmptyLarge, 50, 25, shieldX, shieldY);
                SpriteManager.Add(Sprite.Name.ShieldTopLeftEmptySmall, Image.Name.ShieldTopLeftEmptySmall, 50, 25, shieldX, shieldY);
                SpriteManager.Add(Sprite.Name.ShieldTopRightEmptyLarge, Image.Name.ShieldTopRightEmptyLarge, 50, 25, shieldX, shieldY);
                SpriteManager.Add(Sprite.Name.ShieldTopRightEmptySmall, Image.Name.ShieldTopRightEmptySmall, 50, 25, shieldX, shieldY);


            //----------------------------------------------------------------------------------------------
            //Static ScreenText
            //----------------------------------------------------------------------------------------------
                ScreenTextManager.createGlyphsFromXml(Glyph.FontStyle.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);
                ScreenTextManager.Add(ScreenText.Name.P1ScoreLabel, SpriteBatch.Name.ScreenText, "SCORE<1>", Glyph.FontStyle.Consolas36pt, 50, 1000);
                ScreenTextManager.Add(ScreenText.Name.P1ScoreValue, SpriteBatch.Name.ScreenText, "0000", Glyph.FontStyle.Consolas36pt, 75, 950);

                ScreenTextManager.Add(ScreenText.Name.HiScoreLable, SpriteBatch.Name.ScreenText, "HI-SCORE", Glyph.FontStyle.Consolas36pt, 350, 1000);
                ScreenTextManager.Add(ScreenText.Name.HiScoreValue, SpriteBatch.Name.ScreenText, "0000", Glyph.FontStyle.Consolas36pt, 375, 950);


                ScreenTextManager.Add(ScreenText.Name.P2ScoreLabel, SpriteBatch.Name.ScreenText, "SCORE<2>", Glyph.FontStyle.Consolas36pt, 650, 1000);
                ScreenTextManager.Add(ScreenText.Name.P2ScoreValue, SpriteBatch.Name.ScreenText, "0000", Glyph.FontStyle.Consolas36pt, 675, 950);


                ScreenTextManager.AddToGameScreen(ScreenText.Name.LivesLeft, "3", Glyph.FontStyle.Consolas36pt, 50, 20);
                ScreenTextManager.Add(ScreenText.Name.TotalCredits, SpriteBatch.Name.ScreenText, "CREDIT 00", Glyph.FontStyle.Consolas36pt, 650, 20);

                ScreenTextManager.Add(ScreenText.Name.MothershipPointsAwarded, SpriteBatch.Name.ScreenText, "0", Glyph.FontStyle.Consolas36pt, 1000, 1000);
            //-----------------------------------------------------------------------------------------------------
            //Select ScreenText 
            //-----------------------------------------------------------------------------------------------------
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.VideoGamesUKLTD, "VIDEO   GAMES   <UK>  LTD", Glyph.FontStyle.Consolas36pt, 200, 750);
                
                
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.Presents, "PRESENTS", Glyph.FontStyle.Consolas36pt, 355, 700);
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.SpaceAttack2, "SPACE  ATTACK  II", Glyph.FontStyle.Consolas36pt, 285, 650);
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.ScoreAdvanceTable, "*SCORE   ADVANCE   TABLE*", Glyph.FontStyle.Consolas36pt, 200, 550);
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.MothershipPoints, "= ?   MYSTERY",Glyph.FontStyle.Consolas36pt, 315, 500);
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.SquidPoints, "= 30   POINTS", Glyph.FontStyle.Consolas36pt, 315, 450);
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.CrabPoints,  "= 20   POINTS", Glyph.FontStyle.Consolas36pt, 315, 400);
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.OctoPoints,  "= 10   POINTS", Glyph.FontStyle.Consolas36pt, 315, 350);
                
                ScreenTextManager.AddToSelectScreen(ScreenText.Name.ZenitoneMicrosecLTD, "ZENITONE - MICROSEC   LTD", Glyph.FontStyle.Consolas36pt, 200, 250);
                SpriteBatch sb = SpriteBatchManager.Find(SpriteBatch.Name.SelectScreenText);
                ProxySprite pSprite = ProxySpriteManager.Add(Sprite.Name.Mothership);
                pSprite.UpdateLocation(275, 500);
                sb.Attach(pSprite);

                pSprite = ProxySpriteManager.Add(Sprite.Name.Squid);
                pSprite.UpdateLocation(275, 450);
                sb.Attach(pSprite);

                pSprite = ProxySpriteManager.Add(Sprite.Name.Crab);
                pSprite.UpdateLocation(275, 400);
                sb.Attach(pSprite);

                pSprite = ProxySpriteManager.Add(Sprite.Name.Octo);
                pSprite.pSprite.SwapColor(new Azul.Color(0, 1, 0));
                pSprite.UpdateLocation(275, 350);
                sb.Attach(pSprite);

            //------------------------------------------------------------------------------------------------------------------------------------------------------
            //GameOver Screen
            //------------------------------------------------------------------------------------------------------------------------------------------------------


                ScreenText st = ScreenTextManager.AddToGameOverScreen(ScreenText.Name.GameOver, "GAME OVER", Glyph.FontStyle.Consolas36pt, 340, 800);
                st.spriteFont.UpdateColor(1, 0, 0);
                SpriteBatchManager.RenderInvisible(SpriteBatch.Name.GameOverScreenText);
            //---------------------
            //Input Stuff
            //---------------------
                InKey key;
                key = InputManager.getLeftA();
                key.attachObserver(new LeftObserver());

                key = InputManager.getRightA();
                key.attachObserver(new RightObserver());

                key = InputManager.getSpace();
                key.attachObserver(new SpaceObserver());

                key = InputManager.getEnterKey();
                key.attachObserver(new EnterObserver());

                key = InputManager.getToggleKey();
                key.attachObserver(new ToggleObserver());
            //-------------------------------------------------------------------------------------------
            //Animation Stuff
            //-------------------------------------------------------------------------------------------
                ////Dagger
                //AnimationSprite animDagger = new AnimationSprite(Sprite.Name.Dagger, null);
                //animDagger.Attach(Image.Name.Dagger2);
                //animDagger.Attach(Image.Name.Dagger1);

                ////Dagger
                //AnimationSprite animZigZag = new AnimationSprite(Sprite.Name.ZigZag, null);
                //animZigZag.Attach(Image.Name.ZigZag2);
                //animZigZag.Attach(Image.Name.ZigZag1);

                ////Dagger
                //AnimationSprite animBomb = new AnimationSprite(Sprite.Name.LineBomb, null);
                //animBomb.Attach(Image.Name.LineBomb2);
                //animBomb.Attach(Image.Name.LineBomb1);

                //AnimationBomb animBomb1 = new AnimationBomb(null);
                //TimerManager.Add(TimerEvent.Name.BombDrop, 1.7f, animBomb1);
                //TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.362f, animDagger);
                //TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.361f, animZigZag);
                //TimerManager.Add(TimerEvent.Name.SpriteAnimation, 0.36f, animBomb);
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------
            //Player Creation
            //-------------------------------------------------------------------------------------------------------
                Player player1 = PlayerManager.Add(Player.Name.Player1, ScreenText.Name.P1ScoreValue);
                PlayerManager.SwitchToPlayer(Player.Name.Player1);

                PlayerManager.setUpGame();

                SpriteBatchManager.RenderInvisible(SpriteBatch.Name.SpriteBoxes);
                SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Aliens);
                SpriteBatchManager.RenderInvisible(SpriteBatch.Name.PlayerShip);
                SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Shields);
                SpriteBatchManager.RenderInvisible(SpriteBatch.Name.GameScreenText);

                TimerManager.Pause();
              
        }
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {

            Player currentPlayer = PlayerManager.getCurrentPlayer();
            //if (currentPlayer.gameState == Player.GameState.Select && InputManager.isHandled() == true)
            //{
            //    InputManager.ResetHandled();
            //}

            if (currentPlayer.gameState == Player.GameState.Game && currentPlayer.playerLives <= 0)
            {
                PlayerManager.GameToEnd();
            }

            GameObject grid = GameObjectManager.Find(GameObject.Name.Grid);
            if (grid.child == null)
            {

                
                currentPlayer.LevelUp();
                grid = currentPlayer.resetAliens();
                currentPlayer.setUpCollisions();
                

            }

            InputManager.Update();
            SoundManager.Update();
            TimerManager.Update(this.GetTime());
            GameObjectManager.Update();
            PlayerManager.Update();
            CollisionPairManager.Process();
            DelayedManager.Process();
            DestructionManager.Process();


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
            //explosion.pAzulSprite.Render();
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

