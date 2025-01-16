using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnChessMoveRule : MonoBehaviour, IChessMoveRule
{
    public bool isLegal(ChessMoveRuleContext context)
    {
        return  !context.hasFriend &&
                context.delta.y == (context.weAreBlack ? -1 : 1) &&
                (!context.hasEnemy && context.delta.x == 0 || context.hasEnemy && Math.Abs(context.delta.x) == 1);
    }
}
