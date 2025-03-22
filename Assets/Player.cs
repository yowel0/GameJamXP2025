using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Swiping")]
    public int accepts = 2;
    
    private int _accepts;

    public override void SaveValues()
    {
        base.SaveValues();
        _accepts = accepts;
    }

    public override void ResetValues(){
        base.ResetValues();
        accepts = _accepts;
    }
}
