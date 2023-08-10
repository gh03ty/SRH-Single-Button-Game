using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var map = SceneManager.LoadSceneAsync("Scenes/Main/Main");
            if (map.isDone)
            {
                SceneManager.UnloadSceneAsync("Scenes/Main Menu/Main Menu");
                SceneManager.LoadScene("Scenes/Main/Main");
            }
        }
    }
}
