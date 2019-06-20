using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InputManager : MonoBehaviour
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
                int abilityNumber = clicked.transform.GetSiblingIndex()+1;
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

    public event EventHandler<AbilitySelectedArgs> AbilitySelected;
    public event EventHandler<MouvementRequestArgs> MovementRequest;
    public event EventHandler<SwitchTurnRequestArgs> SwitchTurnRequest;

    public bool _movementMode = false;

    private Vector2 Mouvement;





    //private void SwitchTurnButton_Clicked(object sender, SwitchTurnButton.ClickedArgs e)
    //{
    //    SwitchTurnRequest?.Invoke(this, new SwitchTurnRequestArgs());
    //    Debug.Log("Switch turn !");
    //}

    //private void MovementButton_Clicked(object sender, MovementButton.ClickedArgs e)
    //{
    //    _movementMode = true;
    //}


    private void Update()
    {
        // si on est en mode mouvement
        if (_movementMode)
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        // appuyer sur bouton
        if (Input.GetMouseButton(0))
        {
            Vector3 movement = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            MovementRequest?.Invoke(this, new MouvementRequestArgs((Vector2)movement));
            _movementMode = false;

        }
    }

    private void UIManager_AbilitiesCreated(object sender, AbilitiesCreatedArgs e)
    {
        foreach (ActiveAbility ability in e.Abilities)
        {
            ability.Click += Ability_Click;
        }
    }

    private void Ability_Click(object sender, ClickArgs e)
    {
        // L'abilité sur laquelle on a cliqué
        ActiveAbility ability = (ActiveAbility)sender;

        OnAbilitySelected(ability);
    }

    private void OnAbilitySelected(ActiveAbility ability)
    {
        AbilitySelected?.Invoke(this, new AbilitySelectedArgs(ability));
    }

    //[SerializeField]
    //private MovementButton _movementButton;

    //[SerializeField]
    //private SwitchTurnButton _switchTurnButton;


    [SerializeField]
    private UIManager _uiManager;


}

public class SwitchTurnRequestArgs
{
}

public class MouvementRequestArgs
{
    public MouvementRequestArgs(Vector2 movement)
    {
        this._movement = movement;
    }

    private Vector2 _movement;
    public Vector2 Movement
    {
        get { return _movement; }
        set { _movement = value; }
    }

}

public class AbilitySelectedArgs
{
    public AbilitySelectedArgs(ActiveAbility ability)
    {
        this._ability = ability;
    }

    private ActiveAbility _ability;

    public ActiveAbility Ability
    {
        get { return _ability; }
    }
}