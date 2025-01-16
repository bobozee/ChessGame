using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnDeath : MonoBehaviour
{

    private SceneLoader _sl;

    void Start()
    {
        _sl = GetComponent<SceneLoader>();
    }

    void OnDestroy()
    {
        _sl.loadScene();
    }

}
