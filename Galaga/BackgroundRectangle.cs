using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{
    class BackgroundRectangle
    {
        Random random = new Random();
        public Vector2 _position;
       public BackgroundRectangle()
        {
            _position = new Vector2(random.Next(0, (int)Globals.screenSize.X - 1), 0);
            //rect = new Rectangle(random.Next(0, (int)Globals.screenSize.X - 1), 0, 1, 1);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(Globals.spacekraft, new Rectangle((int)_position.X, (int)_position.Y,1,1), Color.AliceBlue);
            Globals.spriteBatch.End();

        }
        public void Update()
        {
            _position.Y += 3;
            Draw();
        }
    }
}
