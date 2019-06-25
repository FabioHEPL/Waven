using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CommandManager : MonoBehaviour
{
    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        _combatManager = FindObjectOfType<CombatManger>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnEnable()
    {
        _inputManager.ActiveAbilitySelected += InputManager_ActiveAbilitySelected;
        _combatManager.onSwitchTurn += CombatManager_onSwitchTurn;
    }

    private void OnDisable()
    {
        _inputManager.ActiveAbilitySelected -= InputManager_ActiveAbilitySelected;
        _combatManager.onSwitchTurn -= CombatManager_onSwitchTurn;
    }

    private void InputManager_ActiveAbilitySelected(object sender, InputManager.ActiveAbilitySelectedArgs args)
    {
        AttackModel attackModel = _character.attackLibrary[args.AbilityNumber];
        attackModel.AssignToCharacter(_character);
        attackModel.Execute();
        //ComputeAbilityGraphics(attackModel);
        
        Debug.Log(String.Format("Active ability selected {0} and attackRange is : {1}", args.AbilityNumber, attackModel.range.magnitude));
    }

    private void ComputeAbilityGraphics(AttackModel attackModel)
    {
        //if (attackModel.Matrix[AttackModel.AttackType.Zone])
        //{
        //    _attackRange = _uiManager.CreateCircle(attackModel.range.magnitude, _character.transform.position);
        //    _attackRange.Color = Color.red;

        //    _attackRadius = _uiManager.CreateCircle(attackModel.radius, _character.transform.position);
        //    _attackRadius.Color = Color.green;

        //    _attackRadius.SetBounds(_attackRange);
        //    _attackRadius.gameObject.AddComponent<FollowMouse>();

        //    _attackRadius.Clicked += AttackRadius_Clicked;
        //}      
    }

    private void AttackRadius_Clicked(object sender, UICircle.ClickedArgs e)
    {
        UICircle circle = (UICircle)sender;

    }

    private void CombatManager_onSwitchTurn(object sender, CombatManger.SwitchTurnEventArgs args)
    {
        _currentPlayerId = args.IdentityPlayer;
        GameObject characterGameObject = CharacterLibrary.characterLibrary[_currentPlayerId];
        _character = characterGameObject.GetComponent<Character>();
    }

    //public event EventHandler<AbilityCheckArgs> AbilityCheck; 

    //[SerializeField]
    //private InputManager _inputManager;
    ////[SerializeField]
    ////private CycleManager _cycleManager;

    //private void OnEnable()
    //{
    //    _inputManager.AbilitySelected += InputManager_AbilitySelected;
    //    // _combatManager.

    //}
    //private void OnDisable()
    //{
    //    _inputManager.AbilitySelected -= InputManager_AbilitySelected;
    //}

    //private void InputManager_AbilitySelected(object sender, AbilitySelectedArgs e)
    //{
    //    // LOGIQUE : étons-bien dans le cycle du jeu dans lequel a-t-on la possibilité 
    //    // de séléctionner une abilité ?
    //    // EXEMPLE : if (_cycleManager.GameMode.AbilitySelection)
    //    // [...]
    //    AbilityCheckArgs args = new AbilityCheckArgs();       

    //}

    private int _currentPlayerId;
    private Character _character;
    private CombatManger _combatManager;
    private InputManager _inputManager;
    private UIManager _uiManager;
}

public class AbilityCheckArgs
{

}

