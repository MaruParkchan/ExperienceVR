using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isMoveFreeze = false;

    public void IsMoveFreeze(bool isMoveFix)
    {
        isMoveFreeze = isMoveFix;
    }

    public bool GetIsMoveFreeze()
    {
        return isMoveFreeze;
    }
}
