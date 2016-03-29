using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeleteMothershipScore:Command
    {
        private ScreenText scoreText;

        public DeleteMothershipScore(ScreenText st)
            : base()
        {
            Debug.Assert(st != null);
            this.scoreText = st; 
        }

        public override void Execute(float executeTime)
        {
            this.scoreText.spriteFont.UpdateColor(0, 0, 0);
            this.scoreText.spriteFont.x = 10000;
            this.scoreText.spriteFont.y = 10000;
        }
    }
}
