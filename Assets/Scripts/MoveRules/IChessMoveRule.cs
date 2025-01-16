using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IChessMoveRule
{
    public bool isLegal(ChessMoveRuleContext context);

}
