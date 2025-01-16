using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnDeath : MonoBehaviour
{
    [SerializeField] string message;

    void OnDestroy()
    {
        Debug.Log(message); //TODO
    }

}
