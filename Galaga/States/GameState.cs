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
        static Vector2 z4 = new Vector2(Globals.screenSize.X / (float)1.2, Globals.screenSize.Y / 8);

        static Vector2 w1 = new Vector2(Globals.screenSize.X / 2, 0);
        static Vector2 w2 = new Vector2(Globals.screenSize.X - Globals.screenSize.X * (float)1.5, Globals.screenSize.Y);
        static Vector2 w3 = new Vector2(Globals.screenSize.X, Globals.screenSize.Y / 5);
        static Vector2 w4 = new Vector2(Globals.screenSize.X / (float)1.2, Globals.screenSize.Y / 8);

        static Vector2 z5 = new Vector2(Globals.screenSize.X / (float)1.2 - 40, Globals.screenSize.Y / 8);
        static Vector2 z6 = new Vector2(Globals.screenSize.X / (float)1.2 - 80, Globals.screenSize.Y / 8);
        static Vector2 z7 = new Vector2(Globals.screenSize.X / (float)1.2 - 120, Globals.screenSize.Y / 8);
        static Vector2 z8 = new Vector2(Globals.screenSize.X / (float)1.2 - 160, Globals.screenSize.Y / 8);
        static Vector2 z9 = new Vector2(Globals.screenSize.X / (float)1.2 - 200, Globals.screenSize.Y / 8);
        static Vector2 z10 = new Vector2(Globals.screenSize.X / (float)1.2 - 240, Globals.screenSize.Y / 8);
        static Vector2 z11 = new Vector2(Globals.screenSize.X / (float)1.2 - 280, Globals.screenSize.Y / 8);
        static Vector2 z12 = new Vector2(Globals.screenSize.X / (float)1.2 - 320, Globals.screenSize.Y / 8);
        static Vector2 z13 = new Vector2(Globals.screenSize.X / (float)1.2 - 360, Globals.screenSize.Y / 8);
        static Vector2 z14 = new Vector2(Globals.screenSize.X / (float)1.2 - 400, Globals.screenSize.Y / 8);
        static Vector2 z15 = new Vector2(Globals.screenSize.X / (float)1.2 - 440, Globals.screenSize.Y / 8);
        static Vector2 z16 = new Vector2(Globals.screenSize.X / (float)1.2 - 480, Globals.screenSize.Y / 8);

        static List<Vector2> points_1 = DrawBezier((float)0.0011, z1, z2, z3, z4);
        static List<Vector2> points_2 = DrawBezier((float)0.0012, z1, z2, z3, z5);
        static List<Vector2> points_3 = DrawBezier((float)0.0013, z1, z2, z3, z6);
        static List<Vector2> points_4 = DrawBezier((float)0.0014, z1, z2, z3, z7);
        static List<Vector2> points_5 = DrawBezier((float)0.0015, z1, z2, z3, z8);
        static List<Vector2> points_6 = DrawBezier((float)0.0016, z1, z2, z3, z9);
        static List<Vector2> points_7 = DrawBezier((float)0.0017, z1, z2, z3, z10);
        static List<Vector2> points_8 = DrawBezier((float)0.0018, z1, z2, z3, z11);
        static List<Vector2> points_9 = DrawBezier((float)0.0019, z1, z2, z3, z12);
        static List<Vector2> points_10 = DrawBezier((float)0.00191, z1, z2, z3, z13);
        static List<Vector2> points_11 = DrawBezier((float)0.00192, z1, z2, z3, z14);
        static List<Vector2> points_12 = DrawBezier((float)0.00193, z1, z2, z3, z15);
        static List<Vector2> points_13 = DrawBezier((float)0.00194, z1, z2, z3, z16);

        List<List<Vector2>> points_list_for_flyin = new List<List<Vector2>> { points_1, points_2 , points_3, points_4, points_5, points_6, points_7, points_8, points_9, points_10, points_11, points_12, points_13};
        Spacekraft spacekraft;
        Enemyship_1 enemyship_1, enemyship_2, enemyship_3, enemyship_4, enemyship_5, enemyship_6, enemyship_7, enemyship_8, enemyship_9, enemyship_10, enemyship_11;
        ArrayList backgroundItems;
        public GameState()
        {
            Globals.points = new Points();
            backgroundItems = new ArrayList();
            spacekraft = new Spacekraft();

            for(int i=0;i<13;i++)
            {
                Globals.enemy.Add(new Enemyship_1());
            }
           
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            //czarne tło first
            Globals.spriteBatch.Draw(Globals.spacekraft, new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y), Color.Black);
            backgroundItems.Add(new BackgroundRectangle());

            spacekraft.Draw();
            for(int i=0;i<Globals.enemy.Count;i++)
            {
                Globals.enemy[i].Draw();
            }
            String score = "SCORE";
            Globals.spriteBatch.DrawString(Globals.defaultFont, score, new Vector2((Globals.screenSize.X - Globals.defaultFont.MeasureString(score).X) / 2, Globals.defaultFont.MeasureString(score).Y), Color.Red);
            int points = Globals.points.playerPoints;
            Globals.spriteBatch.DrawString(Globals.defaultFont, points.ToString(), new Vector2((Globals.screenSize.X - Globals.defaultFont.MeasureString(points.ToString()).X) / 4, Globals.defaultFont.MeasureString(score).Y) * 2, Color.White);

            Globals.spriteBatch.End();
        }

        public void Update()
        {
            Draw();
            if(Globals.enemy.Count==0)
            {
                for (int i = 0; i < 13; i++)
                {
                    Globals.enemy.Add(new Enemyship_1());
                }
                Globals.iteration_for_points = 0;
            }
            for (int i = 0; i < backgroundItems.Count; i++)
            {
                BackgroundRectangle currentBackgroundRect = (BackgroundRectangle)backgroundItems[i];
                currentBackgroundRect.Update();
                if (currentBackgroundRect._position.Y > Globals.screenSize.Y)
                    backgroundItems.Remove(currentBackgroundRect);
            }

            if(points_1.Count>Globals.iteration_for_points)
            {
                for(int i=0;i<Globals.enemy.Count;i++)
                {
                    var list = points_list_for_flyin[i];
                    if(list.Count>Globals.iteration_for_points)
                    {
                        Globals.enemy[i]._position = list[Globals.iteration_for_points];
                        Globals.enemy[i]._bounds = new Rectangle((int)Globals.enemy[i]._position.X, (int)Globals.enemy[i]._position.Y,
                            Globals.enemyship_1.Width, Globals.enemyship_1.Height);
                    }
                 
                }
                Globals.iteration_for_points++;
            }

     
            Console.WriteLine(Globals.enemy.Count);
            spacekraft.Update();
        }
    }
}
