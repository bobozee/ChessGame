using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public string sceneName;

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
