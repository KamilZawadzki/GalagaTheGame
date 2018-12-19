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
        public Bullet(Vector2 spacekraftPosition)
        {
            
            _spacekraftPosition = spacekraftPosition;
            _position = new Vector2(_spacekraftPosition.X + ((Globals.spacekraft.Width-Globals.bullet.Width) / 2), _spacekraftPosition.Y);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            //Can replace _position with to get larger spacekraft
            //new Rectangle((int)_position.X,(int)_position.Y,40,40)
            Globals.spriteBatch.Draw(Globals.bullet, _position, Color.White);
            Globals.spriteBatch.End();
        }

        public void Update()
        {
            _position = new Vector2(_position.X, _position.Y- velocity);
            Draw();
        }
    }
}
