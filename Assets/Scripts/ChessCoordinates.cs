using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessCoordinates : MonoBehaviour
{
    [SerializeField] private Vector2Int initialChessCoordinates;
    
    private Vector2Int _chessCoords;
    private Vector2 _initialPos;

    private RectTransform _rect;
    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _initialPos = _rect.anchoredPosition;
        _chessCoords = initialChessCoordinates;
    }

    public Vector2Int getChessCoordinates()
    {
        return _chessCoords;
    }

    public Vector2 convertChessCoordinatesToPosition(Vector2Int chessCoordinates)
    {
        Vector2Int offset = chessCoordinates - initialChessCoordinates;
        return _initialPos + new Vector2(offset.x * _rect.rect.width, offset.y * _rect.rect.height);
    }

    public void moveToChessCoordinates(Vector2Int chessCoords)
    {
        Vector2Int delta = chessCoords - initialChessCoordinates;
        _rect.anchoredPosition = _initialPos + new Vector2(delta.x * _rect.rect.width, delta.y * _rect.rect.height);
        _chessCoords = chessCoords;
    }
}
