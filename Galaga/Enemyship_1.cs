using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{
    class Enemyship_1
    {

        public Vector2 _position;
        public Rectangle _bounds { get; set; }
        public Enemyship_1()
        {

            _position = new Vector2((Globals.screenSize.X - Globals.enemyship_1.Width) / 2, Globals.screenSize.Y);
            _bounds = new Rectangle((int)_position.X, (int)_position.Y, Globals.enemyship_1.Width, Globals.enemyship_1.Height);

        }

        public void Draw()
        {
            //Globals.spriteBatch.Begin();
            //Can replace _position with to get larger spacekraft
            //new Rectangle((int)_position.X,(int)_position.Y,40,40)
            Globals.spriteBatch.Draw(Globals.enemyship_1, _position, Color.White);
           //  Globals.spriteBatch.End();
        }

        public void Update()
        {    
                _bounds = new Rectangle((int)_position.X, (int)_position.Y, Globals.spacekraft.Width, Globals.spacekraft.Height);
                
        }

    }
}
