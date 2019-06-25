using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCombatManager : CombatManger
{
    public override event EventHandler<SwitchTurnEventArgs> onSwitchTurn;

    public class TestSwitchTurnEventArgs : SwitchTurnEventArgs
    {
        public TestSwitchTurnEventArgs(int identityPlayer)
        {
            this.IdentityPlayer = identityPlayer;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Je suis le Combat Manager. C'est le tour au player 1");
        onSwitchTurn(this, new TestSwitchTurnEventArgs(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
