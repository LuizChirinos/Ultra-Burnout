using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public void LoadScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
