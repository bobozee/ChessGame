using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegalMove : MonoBehaviour
{

    private TappableObj _tap;
    private ChessFigure _us;
    private ChessFigure _them;
    private Vector2Int _chessCoordinates;

    void Start()
    {
        _tap = GetComponent<TappableObj>();
    }

    void Update()
    {
        if (_tap.isTapped())
        {
            _us.moveTo(_chessCoordinates, _them);
            Destroy(gameObject);
        }
        if (_us && !_us.getLegalsSpawned())
        {
            Destroy(gameObject);
        }
    }

    public void setUs(ChessFigure us)
    {
        _us = us;
    }

    public void setThem(ChessFigure them)
    {
        _them = them;
    }

    public void setChessCoordinates(Vector2Int chessCoordinates)
    {
        _chessCoordinates = chessCoordinates;
    }
}
