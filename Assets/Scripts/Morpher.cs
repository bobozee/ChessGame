using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morpher : MonoBehaviour
{
    [SerializeField] GameObject morphInto;

    private ChessCoordinates _coords;
    private ChessFigure _figure;

    // Start is called before the first frame update
    void Start()
    {
        _coords = GetComponent<ChessCoordinates>();
        _figure = GetComponent<ChessFigure>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_coords.getChessCoordinates().y == 6 && !_figure.getIsBlack() ||
            _coords.getChessCoordinates().y == 0 && _figure.getIsBlack())
        {
            GameObject morph = Instantiate(morphInto, transform.parent);
            morph.GetComponent<RectTransform>().anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
            morph.GetComponent<ChessFigure>().moveTo(_coords.getChessCoordinates(), null, false);
            Destroy(gameObject);
        }
    }
}
