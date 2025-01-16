using System;
using UnityEngine;

public class RookChessMoveRule : MonoBehaviour, IChessMoveRule
{
    public bool isLegal(ChessMoveRuleContext context)
    {

        bool isLegal = tileRule(context);

        if (isLegal)
        {
            //For each tile on the path to this tile, check the same rule too. Only return true if it returns true for the entire path.
            if (context.delta.x != 0)
            {
                for (int i = 1; i <= Math.Abs(context.delta.x); i++)
                {
                    int sign = context.delta.x >= 0 ? 1 : -1;
                    Vector2Int scanTile = new Vector2Int(context.currentPosition.x + sign * i, context.currentPosition.y);
                    isLegal &= tileRule(new ChessMoveRuleContext(
                        scanTile,
                        context.currentPosition,
                        context.figureMap,
                        context.weAreBlack
                    ));
                }
            }
            else // march vertically
            {
                for (int i = 1; i <= Math.Abs(context.delta.y); i++)
                {
                    int sign = context.delta.y >= 0 ? 1 : -1;
                    Vector2Int scanTile = new Vector2Int(context.currentPosition.x, context.currentPosition.y + sign * i);
                    isLegal &= tileRule(new ChessMoveRuleContext(
                        scanTile,
                        context.currentPosition,
                        context.figureMap,
                        context.weAreBlack
                    ));
                }
            }
        }

        return isLegal;
    }

    private bool tileRule(ChessMoveRuleContext context)
    {
        return
            !context.hasFriend &&
            (context.delta.x == 0 && context.delta.y != 0 || context.delta.x != 0 && context.delta.y == 0);
    }

}
