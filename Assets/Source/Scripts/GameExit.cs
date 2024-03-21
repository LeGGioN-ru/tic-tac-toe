using UnityEngine;

public class GameExit : IExitStrategy
{
    public void Exit()
    {
        Application.Quit();
    }
}
