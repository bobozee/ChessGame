using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingChessMoveRule : MonoBehaviour, IChessMoveRule
{
    public bool isLegal(ChessMoveRuleContext context)
    {
        return  !context.hasFriend &&
                Math.Abs(context.delta.y) <= 1 &&
                Math.Abs(context.delta.x) <= 1;
    }
}
