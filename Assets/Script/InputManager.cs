using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  
    public event EventHandler<PassiveAbilitySelectedArgs> PassiveAbilitySelected;
    public event EventHandler<MouvementModeArgs> MouvementMode;
    public event EventHandler<SwitchTurnArgs> SwitchTurn;

    public class MouvementModeArgs
    {
    }

    public class PassiveAbilitySelectedArgs
    {

    }


    public class SwitchTurnArgs
    {

    }


    private void UIManager_Clicked(object sender, UIManager.ClickedArgs e)
    {
        HandleClick(e.Clicked);
    }

    private void HandleClick(GameObject clicked)
    {
        switch (clicked.tag)
        {
            case "active-ability":
                int abilityNumber = clicked.transform.GetSiblingIndex() + 1;
                OnActiveAbilitySelected(abilityNumber);

                Debug.Log(String.Format("Active ability selected {0}", abilityNumber));
                break;
            case "passive-ability":
                // event
                PassiveAbilitySelected?.Invoke(this, new PassiveAbilitySelectedArgs());
                break;
            case "mouvement-button":
                MouvementMode?.Invoke(this, new MouvementModeArgs());
                break;
            case "switch-turn-button":
                SwitchTurn?.Invoke(this, new SwitchTurnArgs());
                break;
            default:
                throw new Exception("Le bouton de l'UI sur lequel on a cliqué n'a pas de tag valide.");
                //break;
        }
    }

    private CombatManager _combatManager;
    private int _currentPlayerId = 1;

    private void Awake()
    {
        _combatManager = FindObjectOfType<CombatManager>();
    }

    private void Start()
    {

        //OnActiveAbilitySelected(1);
    }


    private void OnEnable()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _uiManager.Clicked += UIManager_Clicked;
        _combatManager.onSwitchTurn += CombatManager_onSwitchTurn;
    }

    private void OnDisable()
    {
        _combatManager.onSwitchTurn -= CombatManager_onSwitchTurn;
    }

    private void CombatManager_onSwitchTurn(object sender, CombatManager.SwitchTurnEventArgs e)    {
        _currentPlayerId = e.IdentityPlayer;
    }

    
    public class ActiveAbilitySelectedArgs : EventArgs
    {
        private int _abilityNumber;

        public int AbilityNumber
        {
            get { return _abilityNumber; }
            set { _abilityNumber = value; }
        }

        public ActiveAbilitySelectedArgs(int abilityNumber)
        {
            this._abilityNumber = abilityNumber;
        }
    }


    public event EventHandler<ActiveAbilitySelectedArgs> ActiveAbilitySelected;

    public void OnActiveAbilitySelected(int abilityNumber)
    {
        Debug.Log(abilityNumber);
        ActiveAbilitySelected?.Invoke(this, new ActiveAbilitySelectedArgs(abilityNumber));


        // Debug.Log("je déclenche l'event active ability");
    }

    private UIManager _uiManager;
}


