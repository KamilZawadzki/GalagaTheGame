using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Galaga
{

class Globals
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static Texture2D spacekraft;
        public static Texture2D enemyship_1;

        public static SpriteFont defaultFont;

        public static Vector2 screenSize;

        public static enGameStates activeState = enGameStates.GAME;
        public static Texture2D bullet;

        public static SoundEffect bulletShotSoundEffect;
        public static float volume = 0.1f;

        public static int iteration_enemyship_1=0;
        public List<Vector2> brezierpoints = new List<Vector2>();

    public enum enGameStates
        {
            SPLASH,
            MENU,
            GAME,
            PAUSE,
            TEST,
            EXIT,
            WINSTATE,
            INFO
        }




}
}
