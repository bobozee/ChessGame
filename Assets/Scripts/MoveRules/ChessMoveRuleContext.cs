using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct ChessMoveRuleContext
{
    public Vector2Int targetPosition;
    public Vector2Int currentPosition;
    public Vector2Int delta;
    public ChessFigure[][] figureMap;
    public ChessFigure targetFigure;
    public ChessFigure ourFigure;
    public bool weAreBlack;
    public bool hasEnemy;
    public bool hasFriend;


    public ChessMoveRuleContext(
        Vector2Int targetPosition,
        Vector2Int currentPosition,
        ChessFigure[][] figureMap,
        bool weAreBlack
    )
    {
        this.targetPosition = targetPosition;
        this.currentPosition = currentPosition;
        this.figureMap = figureMap;
        this.weAreBlack = weAreBlack;

        this.delta = targetPosition - currentPosition;
        this.targetFigure = figureMap[targetPosition.x][targetPosition.y];
        this.ourFigure = figureMap[currentPosition.x][currentPosition.y];
        this.hasFriend = targetFigure && weAreBlack == targetFigure.getIsBlack();
        this.hasEnemy = targetFigure && weAreBlack != targetFigure.getIsBlack();
    }
}
