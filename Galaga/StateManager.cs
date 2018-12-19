using Galaga.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{
    class StateManager
    {
        StateTemplate splashState = new SplashState();
        StateTemplate gameState = new GameState();
        public void Update()
        {
            //TU SIE DZIEJE INTERPRETACJA STANÓW
            switch (Globals.activeState)
            {
                case Globals.enGameStates.SPLASH:
                    splashState.Update();
                    break;
                case Globals.enGameStates.MENU:
                    //menuComponent.Update();
                    break;
                case Globals.enGameStates.GAME:
                    gameState.Update();
                    break;
                case Globals.enGameStates.PAUSE:
                    // componentPause.Update();
                    break;
                case Globals.enGameStates.EXIT:
                    // Globals.exit = true;
                    break;
                case Globals.enGameStates.TEST:
                    // testComponent.Update();
                    break;
                case Globals.enGameStates.WINSTATE:
                    // winStateComponent.Update();
                    break;
                case Globals.enGameStates.INFO:
                    //componentInfo.Update();
                    break;
            }
        }
    }
}