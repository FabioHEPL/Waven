using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCombatManager : CombatManager
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Je suis le Combat Manager. C'est le tour au player 1");
        OnSwitchTurn(new SwitchTurnEventArgs() { IdentityPlayer = 1 });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
