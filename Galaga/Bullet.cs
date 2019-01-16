using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{

    public class Bullet
    {
        private int velocity = 16;
        public Vector2 _position { get; set; }
        private Rectangle bounds { get; set; }
        Vector2 _spacekraftPosition;
        public bool killed { get; set; } = false;
        public Bullet(Vector2 spacekraftPosition)
        {

            _spacekraftPosition = spacekraftPosition;
            _position = new Vector2(_spacekraftPosition.X + ((Globals.spacekraft.Width - Globals.bullet.Width) / 2), _spacekraftPosition.Y);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            //Can replace _position with to get larger spacekraft
            //new Rectangle((int)_position.X,(int)_position.Y,40,40)
            Globals.spriteBatch.Draw(Globals.bullet, _position, Color.White);
           // Globals.spriteBatch.Draw(Globals.bullet, bounds, Color.Yellow);

            Globals.spriteBatch.End();
        }

        public void Update()
        {
            Console.WriteLine(Globals.enemy.Count);
            

            for (int i = 0; i < Globals.enemy.Count; i++)
            {
                var enemy = Globals.enemy[i]._bounds;
                //if (this.bounds.Left > enemy.Left && this.bounds.Right < enemy.Right && this.bounds.Top > enemy.Bottom)
                if (this.bounds.Intersects(enemy))
                {
                    if (Globals.enemy.Count != 0)
                    {
                        Globals.points.playerPoints += Globals.enemy[i].pointsForKill;
                        Globals.enemy.Remove(Globals.enemy[i]);
                        killed = true;
                    }
                }
            }
            _position = new Vector2(_position.X, _position.Y - velocity);
            bounds = new Rectangle((int)_position.X, (int)_position.Y, Globals.spacekraft.Width, Globals.spacekraft.Height);
            Draw();
        }
    }
}
