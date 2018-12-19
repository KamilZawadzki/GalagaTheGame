using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.States
{
    class GameState : StateTemplate
    {
        Spacekraft spacekraft;
        ArrayList backgroundItems;
        public GameState()
        {
            backgroundItems = new ArrayList();
            spacekraft = new Spacekraft();
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            //czarne tło first
            Globals.spriteBatch.Draw(Globals.spacekraft, new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y), Color.Black);
            
                       
                backgroundItems.Add(new BackgroundRectangle());
            
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
            for(int i = 0; i < backgroundItems.Count; i++)
            {
                BackgroundRectangle currentBackgroundRect = (BackgroundRectangle) backgroundItems[i];
                currentBackgroundRect.Update();
                if (currentBackgroundRect._position.Y > Globals.screenSize.Y)
                    backgroundItems.Remove(currentBackgroundRect);
            }
            
            spacekraft.Update();
        }
    }
}
