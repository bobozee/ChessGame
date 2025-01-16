using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ChessFigure : MonoBehaviour
{
    [SerializeField] public bool isBlack;
    [SerializeField] public GameObject possibleMovePrefab;
    [SerializeField] public Turn turn;
    [SerializeField] public Score score;


    private ChessCoordinates _coords;
    private TappableObj _tap;
    private IChessMoveRule[] _rules;
    private RectTransform _canvasRect;
    private bool _legalsSpawned;

    void Start()
    {
        _coords = GetComponent<ChessCoordinates>();
        _rules = GetComponents<IChessMoveRule>();
        _tap = GetComponent<TappableObj>();
        _canvasRect = transform.parent.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    void Update()
    {
        if (_tap.isTapped() && !_legalsSpawned && turn.isBlackTurn() == getIsBlack())
        {
            generateLegalCoordinates(true);
        }
        else if (!_tap.isTapped())
        {
            _legalsSpawned = false;
        }
    }

    public List<Vector2Int> generateLegalCoordinates(bool visualize)
    {
        List<Vector2Int> legalMoves = new List<Vector2Int>();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                Vector2Int move = new Vector2Int(x, y);
                if (move == _coords.getChessCoordinates()) {continue;}

                Vector2 movePosition = _coords.convertChessCoordinatesToPosition(move);
                ChessFigure[][] map = getFigureMap();
                ChessFigure otherFigure = map[x][y];

                ChessMoveRuleContext context = new ChessMoveRuleContext(move, _coords.getChessCoordinates(), map, getIsBlack());

                bool isLegal = false;
                foreach (IChessMoveRule rule in _rules)
                {
                    isLegal |= rule.isLegal(context);
                }

                if (isLegal)
                {
                    legalMoves.Add(move);
                    if (visualize)
                    {
                        GameObject obj = Instantiate(possibleMovePrefab, transform.parent);
                        obj.GetComponent<RectTransform>().anchoredPosition = movePosition;
                        LegalMove legal = obj.AddComponent<LegalMove>();
                        legal.setUs(this);
                        legal.setThem(otherFigure);
                        legal.setChessCoordinates(move);
                        _legalsSpawned = true;
                    }
                }
            }
        }
        return legalMoves;
    }

    public void moveTo(Vector2Int targetCoords, ChessFigure target, bool changeTurn = true)
    {
        if (target)
        {
            Destroy(target.gameObject);
            score.addScore(1);
        }
        _coords.moveToChessCoordinates(targetCoords);
        if (changeTurn) { turn.switchTurn(); }
    }

    public bool getIsBlack()
    {
        return isBlack;
    }

    public bool getLegalsSpawned()
    {
        return _legalsSpawned;
    }

    private ChessFigure[][] getFigureMap()
    {
        ChessFigure[][] map = new ChessFigure[8][];
        for (int row = 0; row < 8; row++)
        {
            map[row] = new ChessFigure[8];
        }

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                Vector2Int move = new Vector2Int(x, y);
                Vector2 movePosition = _coords.convertChessCoordinatesToPosition(move);
                Vector3 worldPosition = _canvasRect.TransformPoint(movePosition);
                Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

                PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
                {
                    position = screenPosition
                };
                List<RaycastResult> raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);
                foreach (var result in raycastResults)
                {
                    ChessFigure possibleOtherFigure = result.gameObject.GetComponentInParent<ChessFigure>();
                    if (possibleOtherFigure)
                    {
                        map[x][y] = possibleOtherFigure;
                    }
                }
                
            }
        }
        return map;
    }
}
