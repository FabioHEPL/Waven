using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CommandManager : MonoBehaviour
{
    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        _combatManager = FindObjectOfType<CombatManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnEnable()
    {
        Debug.Log("je m'abonne à l'input manager");
        _inputManager.ActiveAbilitySelected += InputManager_ActiveAbilitySelected;      
        _combatManager.onSwitchTurn += CombatManager_onSwitchTurn;
    }

    private void OnDisable()
    {
        Debug.Log("je me desabonne");
        _inputManager.ActiveAbilitySelected -= InputManager_ActiveAbilitySelected;
        _combatManager.onSwitchTurn -= CombatManager_onSwitchTurn;
    }

    public void InputManager_ActiveAbilitySelected(object sender, InputManager.ActiveAbilitySelectedArgs args)
    {
        Debug.Log("déclencher l'abilité " + args.AbilityNumber);
        AttackModel attackModel = _character.attackLibrary[args.AbilityNumber];
        attackModel.AssignToCharacter(_character);
        attackModel.Execute();

        
        Debug.Log(String.Format("Active ability selected {0} and attackRange is : {1}", args.AbilityNumber, attackModel.range.magnitude));
    }


    //public void OnActiveAbilitySelected(int abilityNumber)
    //{
    //    Debug.Log("déclencher l'abilité " + args.AbilityNumber);
    //    AttackModel attackModel = _character.attackLibrary[args.AbilityNumber];
    //    attackModel.AssignToCharacter(_character);
    //    attackModel.Execute();
    //}


    private void AttackRadius_Clicked(object sender, UICircle.ClickedArgs e)
    {
        UICircle circle = (UICircle)sender;

    }

    private void CombatManager_onSwitchTurn(object sender, CombatManager.SwitchTurnEventArgs args)
    {
        _currentPlayerId = args.IdentityPlayer;
        GameObject characterGameObject = CharacterLibrary.characterLibrary[_currentPlayerId];
        _character = characterGameObject.GetComponent<Character>();
    }
    

    private int _currentPlayerId;
    private Character _character;
    private CombatManager _combatManager;
    private InputManager _inputManager;
    private UIManager _uiManager;
}

public class AbilityCheckArgs
{

}

