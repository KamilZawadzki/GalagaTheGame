using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.States
{
    class GameState : StateTemplate
    {
        Spacekraft spacekraft;
        public GameState()
        {
            spacekraft = new Spacekraft();
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            //czarne tło first
            Globals.spriteBatch.Draw(Globals.spacekraft, new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y), Color.Black);

            spacekraft.Draw();

            String highScore = "HIGH SCORE";
            Globals.spriteBatch.DrawString(Globals.defaultFont, highScore, new Vector2((Globals.screenSize.X - Globals.defaultFont.MeasureString(highScore).X)/2, Globals.defaultFont.MeasureString(highScore).Y), Color.Red);
            //TODO: store and download high score
            int points = 100000;
            Globals.spriteBatch.DrawString(Globals.defaultFont, points.ToString(), new Vector2((Globals.screenSize.X - Globals.defaultFont.MeasureString(points.ToString()).X)/4, Globals.defaultFont.MeasureString(highScore).Y)*2, Color.White);
                        
            Globals.spriteBatch.End();
        }

        public void Update()
        {            
            Draw();
            spacekraft.Update();
        }
    }
}
