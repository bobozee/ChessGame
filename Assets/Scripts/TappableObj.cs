using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappableObj : MonoBehaviour
{
    private bool _tap;

    public void tap()
    {
        _tap = true;
    }

    public bool isTapped()
    {
        return _tap;
    }

    public void reset()
    {
        _tap = false;
    }

}
