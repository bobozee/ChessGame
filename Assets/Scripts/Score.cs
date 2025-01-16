using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour, IDisplayString
{
    [SerializeField] string identifier;
    private int _score;

    void Start()
    {
        _score = PlayerPrefs.GetInt(identifier);
    }

    public void addScore(int amount)
    {
        _score += amount;
        PlayerPrefs.SetInt(identifier, _score);
    }

    public int getScore()
    {
        return _score;
    }

    public string display()
    {
        return _score+"";
    }
    
}
