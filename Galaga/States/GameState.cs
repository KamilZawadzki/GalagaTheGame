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


        private static float X(float t,
          float x0, float x1, float x2, float x3)
        {
            return (float)(
                x0 * Math.Pow((1 - t), 3) +
                x1 * 3 * t * Math.Pow((1 - t), 2) +
                x2 * 3 * Math.Pow(t, 2) * (1 - t) +
                x3 * Math.Pow(t, 3)
            );
        }
        private static float Y(float t, float y0, float y1, float y2, float y3)
        {
            return (float)(
                y0 * Math.Pow((1 - t), 3) +
                y1 * 3 * t * Math.Pow((1 - t), 2) +
                y2 * 3 * Math.Pow(t, 2) * (1 - t) +
                y3 * Math.Pow(t, 3)
            );
        }

        // Draw the Bezier curve.
        public static List<Vector2> DrawBezier(float dt, Vector2 pt0, Vector2 pt1, Vector2 pt2, Vector2 pt3)
        {
            // Draw the curve.
            List<Vector2> points = new List<Vector2>();
            for (float t = 0.0f; t < 1.0; t += dt)
            {
                points.Add(new Vector2(
                    Y(t, pt0.X, pt1.X, pt2.X, pt3.X),
                    X(t, pt0.Y, pt1.Y, pt2.Y, pt3.Y)));
            }

            // Connect to the final point.
            points.Add(new Vector2(
                X(1.0f, pt0.X, pt1.X, pt2.X, pt3.X),
                Y(1.0f, pt0.Y, pt1.Y, pt2.Y, pt3.Y)));

            return points;
        }





        static Vector2 z1 = new Vector2(Globals.screenSize.X / 2, 0);
        static Vector2 z2 = new Vector2(Globals.screenSize.X - Globals.screenSize.X * (float)1.5, Globals.screenSize.Y);
        static Vector2 z3 = new Vector2(Globals.screenSize.X, Globals.screenSize.Y / 5);
        static Vector2 z4 = new Vector2(Globals.screenSize.X / 2, Globals.screenSize.Y / 8);



        List<Vector2> points_1 = DrawBezier((float)0.001, z1, z2, z3, z4);
        Spacekraft spacekraft;
        Enemyship_1 enemyship_1;
        ArrayList backgroundItems;
        public GameState()
        {
            backgroundItems = new ArrayList();
            spacekraft = new Spacekraft();
            enemyship_1 = new Enemyship_1();
            Globals.enemy.Add(enemyship_1);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            //czarne tło first
            Globals.spriteBatch.Draw(Globals.spacekraft, new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y), Color.Black);
            Globals.spriteBatch.Draw(Globals.enemyship_1, new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y), Color.Black);

            backgroundItems.Add(new BackgroundRectangle());

            spacekraft.Draw();
            String highScore = "HIGH SCORE";
            Globals.spriteBatch.DrawString(Globals.defaultFont, highScore, new Vector2((Globals.screenSize.X - Globals.defaultFont.MeasureString(highScore).X) / 2, Globals.defaultFont.MeasureString(highScore).Y), Color.Red);
            //TODO: store and load high score
            int points = 100000;
            Globals.spriteBatch.DrawString(Globals.defaultFont, points.ToString(), new Vector2((Globals.screenSize.X - Globals.defaultFont.MeasureString(points.ToString()).X) / 4, Globals.defaultFont.MeasureString(highScore).Y) * 2, Color.White);

            Globals.spriteBatch.End();
        }

        public void Update()
        {
            Draw();
            for (int i = 0; i < backgroundItems.Count; i++)
            {
                BackgroundRectangle currentBackgroundRect = (BackgroundRectangle)backgroundItems[i];
                currentBackgroundRect.Update();
                if (currentBackgroundRect._position.Y > Globals.screenSize.Y)
                    backgroundItems.Remove(currentBackgroundRect);
            }
            if (Globals.iteration_enemyship_1 < points_1.Count)
            {
                enemyship_1._position = points_1[Globals.iteration_enemyship_1];
                enemyship_1._bounds = new Rectangle((int)enemyship_1._position.X, (int)enemyship_1._position.Y, Globals.spacekraft.Width, Globals.spacekraft.Height);
                Globals.iteration_enemyship_1++;
            }
            else
            {
                // Globals.iteration_enemyship_1 = 0;

            }
            foreach (Enemyship_1 enemyship in Globals.enemy)
            {
                enemyship.Update();
            }
            Console.WriteLine(Globals.enemy.Count);
            spacekraft.Update();
        }
    }
}
