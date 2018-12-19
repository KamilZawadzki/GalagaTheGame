using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{
    class Spacekraft
    {
        ArrayList bullets;       
        int Velocity = 10;
        int counterTimer;
        int delayBetweenShots = 3;
        int maxBulletCountInTheSameTime = 2;
        private Vector2 _position;
        public Rectangle _bounds { get; set; }
        public Spacekraft()
        {            
            bullets = new ArrayList();
            _position = new Vector2((Globals.screenSize.X - Globals.spacekraft.Width) / 2, Globals.screenSize.Y - (Globals.spacekraft.Height * 2));
            _bounds = new Rectangle((int)_position.X, (int)_position.Y, Globals.spacekraft.Width, Globals.spacekraft.Height);
            counterTimer = 0;
        }

        public void Draw()
        {
            //Globals.spriteBatch.Begin();
            //Can replace _position with to get larger spacekraft
            //new Rectangle((int)_position.X,(int)_position.Y,40,40)
            Globals.spriteBatch.Draw(Globals.spacekraft, _position, Color.White);
           // Globals.spriteBatch.End();
        }

        public void Update()
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && (_position.X - Velocity > 0))
                _position.X -= Velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && (_position.X + Velocity + Globals.spacekraft.Width < Globals.screenSize.X))
                _position.X += Velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && counterTimer++ > delayBetweenShots && bullets.Count<maxBulletCountInTheSameTime)
            {
                bullets.Add(new Bullet(_position));
                //MediaPlayer.Volume = Globals.volume;
                //MediaPlayer.Play(Globals.bulletShotSoundEffect);
                var instance = Globals.bulletShotSoundEffect;              
                instance.Play();
                counterTimer = 0;
            }
            if (bullets.Count != 0)
            {
                for (int i = 0; i < bullets.Count; i++)
                {
                    Bullet currentBullet = (Bullet)bullets[i];
                    currentBullet.Update();
                    if ((int)currentBullet._position.Y < 0)
                    {
                        bullets.Remove(currentBullet);
                    }
                }

            }
            _bounds = new Rectangle((int)_position.X, (int)_position.Y, Globals.spacekraft.Width, Globals.spacekraft.Height);

        }
    }
}
