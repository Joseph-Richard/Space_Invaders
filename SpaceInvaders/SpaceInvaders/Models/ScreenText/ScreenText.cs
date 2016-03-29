using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ScreenText:DLink
    {
        public Name name;
        public SpriteFont spriteFont;

        public enum Name
        {
            P1ScoreLabel,
            P1ScoreValue,
            P2ScoreLabel,
            P2ScoreValue, 
            HiScoreLable,
            HiScoreValue,
            Player1, 
            Player2, 
            GameOver, 
            LivesLeft, 
            TotalCredits, 
            MothershipPointsAwarded, 
            FakeObject, 


            VideoGamesUKLTD,
            Presents,
            SpaceAttack2, 

            ScoreAdvanceTable,
            MothershipPoints,
            SquidPoints,
            CrabPoints,
            OctoPoints, 

            ZenitoneMicrosecLTD,




            Uninitialized
        }

        public ScreenText()
            : base()
        {
            this.name = Name.Uninitialized;
            this.spriteFont = new SpriteFont();

        }

        public void UpdateScreenText(String newText)
        {
            Debug.Assert(newText != null);
            Debug.Assert(newText.Length > 0);

            this.spriteFont.UpdateText(newText);
        }

        public void Set(ScreenText.Name name, String newText, Glyph.FontStyle fstyle, float x, float y)
        {
            Debug.Assert(newText != null);
            Debug.Assert(newText.Length > 0);

            this.name = name;
            this.spriteFont.Set(newText, name, fstyle, x, y);
            if (name == Name.ZenitoneMicrosecLTD || name == Name.OctoPoints)
            {
                this.spriteFont.UpdateColor(0, 1, 0);
            }
            else if (name == Name.VideoGamesUKLTD)
            {
                this.spriteFont.UpdateColor(1, 0, 0);
            }
        }

    }
}
