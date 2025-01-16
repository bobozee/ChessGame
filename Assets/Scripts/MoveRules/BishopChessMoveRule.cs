using System;
using UnityEngine;

public class BishopChessMoveRule : MonoBehaviour, IChessMoveRule
{
    public bool isLegal(ChessMoveRuleContext context)
    {
        bool alreadyHasEnemy = false;
        bool isLegal = tileRule(context, ref alreadyHasEnemy);
        alreadyHasEnemy = false;

        if (isLegal)
        {
            //For each tile on the path to this tile, check the same rule too. Only return true if it returns true for the entire path.
            for (int i = 1; i <= Math.Abs(context.delta.x); i++)
            {
                int signX = context.delta.x >= 0 ? 1 : -1;
                int signY = context.delta.y >= 0 ? 1 : -1;
                Vector2Int scanTile = new Vector2Int(context.currentPosition.x + signX * i, context.currentPosition.y + signY * i);
                isLegal &= tileRule(new ChessMoveRuleContext(
                    scanTile,
                    context.currentPosition,
                    context.figureMap,
                    context.weAreBlack
                ), ref alreadyHasEnemy);
            }
        }

        return isLegal;
    }

    private bool tileRule(ChessMoveRuleContext context, ref bool alreadyHasEnemy)
    {
        bool legal = 
            !context.hasFriend &&
            !alreadyHasEnemy &&
            (Math.Abs(context.delta.x) == Math.Abs(context.delta.y));
        if (legal && context.hasEnemy) { alreadyHasEnemy = true; }
        return legal;
            
    }
}
