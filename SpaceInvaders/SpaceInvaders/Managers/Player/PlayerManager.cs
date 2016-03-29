using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class PlayerManager:Manager
    {
        private static PlayerManager instance;
        private Player refNode;
        private Player currentPlayer;
        private static int highscore;


        public PlayerManager(int reserveNum, int growthRate)
            : base(reserveNum, growthRate)
        {
            this.refNode = (Player)this.CreateNode();
            this.currentPlayer = (Player)this.CreateNode();
            highscore = 0000;


        }

        public static void Create(int reserveNum, int growthRate)
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new PlayerManager(reserveNum, growthRate);
            }
        }

        public static Player Add(Player.Name name, ScreenText.Name stName)
        {
            PlayerManager pm = PlayerManager.GetInstance();
            Player p = (Player)pm.baseAdd();
            Debug.Assert(p != null);

            p.Set(name, stName);
            return p; 
        }

        public static void Update()
        {
            PlayerManager pm = PlayerManager.GetInstance();
            ScreenText score = ScreenTextManager.Find(pm.currentPlayer.scoreText);
            ScreenText lives = ScreenTextManager.Find(ScreenText.Name.LivesLeft);
            score.UpdateScreenText(pm.currentPlayer.currentScore.ToString());
            lives.UpdateScreenText(pm.currentPlayer.playerLives.ToString());

        }

        public static Player getCurrentPlayer()
        {
            PlayerManager pm = PlayerManager.GetInstance();
            Debug.Assert(pm.currentPlayer != null);
            return pm.currentPlayer;
        }

        public static void SwitchToPlayer(Player.Name name)
        {
            PlayerManager pm = PlayerManager.GetInstance();
            Player link = PlayerManager.Find(name);
            Debug.Assert(link != null);
            pm.currentPlayer = link;

        }
        public static Player Find(Player.Name name)
        {
            PlayerManager pm = PlayerManager.GetInstance();
            pm.refNode.playerName = name;
            Player link = (Player)pm.baseFind(pm.refNode);
            return link;
        }

        public static void SelectToGame()
        {
            Player currentPlayer = PlayerManager.getCurrentPlayer();
            currentPlayer.gameState = Player.GameState.Game;
            currentPlayer.credits = 3;
            currentPlayer.currentScore = 0;
            SpriteBatchManager.MakeVisible(SpriteBatch.Name.PlayerShip);
            SpriteBatchManager.MakeVisible(SpriteBatch.Name.Aliens);
            SpriteBatchManager.MakeVisible(SpriteBatch.Name.Shields);
            SpriteBatchManager.MakeVisible(SpriteBatch.Name.GameScreenText);
            SpriteBatchManager.MakeVisible(SpriteBatch.Name.Bombs);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.SelectScreenText);
            Sprite s = SpriteManager.Find(Sprite.Name.Octo);
            s.SwapColor(new Azul.Color(1, 1, 1));
            TimerManager.Play();
        }
        public static void GameToEnd()
        {
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.SpriteBoxes);
          //  SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Aliens);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.PlayerShip);
          //  SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Shields);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.GameScreenText);
           // SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Bombs);

            SpriteBatchManager.MakeVisible(SpriteBatch.Name.GameOverScreenText);
            TimerManager.Pause();
            Ship ship = ShipManager.getShip();
            ship.setState(ShipManager.State.End);
            Player currentPlayer = PlayerManager.getCurrentPlayer();
            currentPlayer.gameState = Player.GameState.GameOver;

            if (currentPlayer.currentScore > PlayerManager.highscore)
            {
                PlayerManager.highscore = currentPlayer.currentScore;
                ScreenText HIGHSCORE = ScreenTextManager.Find(ScreenText.Name.HiScoreValue);
                HIGHSCORE.UpdateScreenText(PlayerManager.highscore.ToString());
            }
        }

        public static void EndToSelect()
        {
            ProxySprite pSprite = ProxySpriteManager.Add(Sprite.Name.Octo);
            pSprite.pSprite.SwapColor(new Azul.Color(0, 1, 0));
            TimerManager.Pause();
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.GameOverScreenText);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.SpriteBoxes);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Aliens);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.PlayerShip);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Shields);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.GameScreenText);
            SpriteBatchManager.RenderInvisible(SpriteBatch.Name.Bombs);
            SpriteBatchManager.MakeVisible(SpriteBatch.Name.SelectScreenText);
            
            Player CurrentPlayer = PlayerManager.getCurrentPlayer();
            CurrentPlayer.EnterPressed = false;
                      
            //CurrentPlayer.gameState = Player.GameState.Select;
            //^^When i add this, the game gets wonky. do everything before switching the states. 
            CurrentPlayer.closeOutGame();
            PlayerManager.setUpGame();
            
        }

        protected override bool Compare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Player pNodeA = (Player)pLinkA;
            Player pNodeB = (Player)pLinkB;

            Boolean status = false;

            if (pNodeA.playerName == pNodeB.playerName)
            {
                status = true;
            }
            return status; 

        }

        public static void setUpGame()
        {
            Player player1 = PlayerManager.getCurrentPlayer();

            player1.setUpAliens();


            player1.setUpUserShip();

            player1.setUpBombRoot();

            
            player1.setupMothership();

            player1.setUpMissileRoot();

            player1.setUpGameWalls();

            player1.setUpShields();

            player1.setUpCollisions();

            player1.setUpBombAnimations();
           // InputManager.ResetHandled();
            player1.gameState = Player.GameState.Select;
            
        }
        public static void resetGridAnimation()
        {
            Player player1 = PlayerManager.getCurrentPlayer();
            player1.resetGridAnimation();
        }
        public static Alien resetGame()
        {
            Player player1 = PlayerManager.getCurrentPlayer();
            player1.setupMothership();

            //player1.setUpUserShip();

            player1.setUpBombRoot();

            Alien grid = player1.resetAliens();
            

            player1.setUpMissileRoot();

            player1.setUpGameWalls();

            //player1.setUpShields();

            player1.setUpCollisions();

            player1.setUpBombAnimations();

            return grid;
        }

        protected override DLink CreateNode()
        {
            DLink link = new Player();
            return link;
        }

        public static PlayerManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance; 
        }
    }
}
