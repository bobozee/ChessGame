using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Turn : MonoBehaviour, IDisplayImage
{
    [SerializeField] Sprite blackTurnImage;
    [SerializeField] Sprite whiteTurnImage;
    private bool _isBlackTurn;
        
    public bool isBlackTurn()
    {
        return _isBlackTurn;
    }
    
    public void switchTurn()
    {
        _isBlackTurn = !_isBlackTurn;
    }

    public Sprite display()
    {
        return _isBlackTurn ? blackTurnImage : whiteTurnImage;
    }

}
