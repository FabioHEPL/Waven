using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Partie chargée des abilités
public partial class InputManager : MonoBehaviour
{
    //private Character _character;
    private CombatManger _combatManager;
    private int _currentPlayerId = 1;

    private void Awake()
    {
        //_character = FindObjectOfType<Character>();
        _combatManager = FindObjectOfType<CombatManger>();        
    }


    private void OnEnable()
    {
        //_uiManager.AbilitiesCreated += UIManager_AbilitiesCreated;
        //_movementButton.Clicked += MovementButton_Clicked;
        //_switchTurnButton.Clicked += SwitchTurnButton_Clicked;
        _uiManager = FindObjectOfType<UIManager>();

        _uiManager.Clicked += UIManager_Clicked;
        _combatManager.onSwitchTurn += CombatManager_onSwitchTurn;
    } 

    private void OnDisable()
    {
        //_uiManager.AbilitiesCreated -= UIManager_AbilitiesCreated;
        //_movementButton.Clicked -= MovementButton_Clicked;
        //_switchTurnButton.Clicked -= SwitchTurnButton_Clicked;
        _combatManager.onSwitchTurn -= CombatManager_onSwitchTurn;
    }

    private void CombatManager_onSwitchTurn(object sender, CombatManger.SwitchTurnEventArgs e)
    {
        _currentPlayerId = e.IdentityPlayer;
    }

    private UIManager _uiManager;
}

