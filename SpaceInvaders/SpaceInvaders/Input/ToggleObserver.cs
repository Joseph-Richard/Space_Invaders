using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ToggleObserver:InputObserver
    {
        public ToggleObserver()
        {

        }

        public override void Notify()
        {
            Player player = PlayerManager.getCurrentPlayer();
            if (player.gameState == Player.GameState.Game)
            {
                SpriteBatch boxes = SpriteBatchManager.Find(SpriteBatch.Name.SpriteBoxes);
                if (boxes.isInvisible)
                {
                    SpriteBatchManager.MakeVisible(SpriteBatch.Name.SpriteBoxes);
                }
                else
                {
                    SpriteBatchManager.RenderInvisible(SpriteBatch.Name.SpriteBoxes);
                }
            }
        }
    }
}
