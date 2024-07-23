using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameScene
{
    Launch,
    MainMenu,
    Level1
}

public class SceneManager
{
    public static void LoadScene(GameScene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }
}
