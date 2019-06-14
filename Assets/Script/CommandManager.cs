using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public event EventHandler<AbilityCheckArgs> AbilityCheck; 

    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private CycleManager _cycleManager;

    private void OnEnable()
    {
        _inputManager.AbilitySelected += InputManager_AbilitySelected;
        // _combatManager.

    }
    private void OnDisable()
    {
        _inputManager.AbilitySelected -= InputManager_AbilitySelected;

    }

    private void InputManager_AbilitySelected(object sender, AbilitySelectedArgs e)
    {
        // LOGIQUE : étons-bien dans le cycle du jeu dans lequel a-t-on la possibilité 
        // de séléctionner une abilité ?
        // EXEMPLE : if (_cycleManager.GameMode.AbilitySelection)
        // [...]
        AbilityCheckArgs args = new AbilityCheckArgs();       

    }

}

public class AbilityCheckArgs
{    

}

