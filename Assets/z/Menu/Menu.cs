using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Level1GameScene;
    public string Level2GameScene;
    public void PlayGame1()
    {
        SceneManager.LoadScene(Level1GameScene, LoadSceneMode.Single);
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene(Level2GameScene, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
