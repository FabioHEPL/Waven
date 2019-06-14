using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event EventHandler<AbilitySelectedArgs> AbilitySelected;
    private Vector2 Mouvement;

    private void OnEnable()
    {
        _uiManager.AbilitiesCreated += UIManager_AbilitiesCreated;
    }

    private void OnDisable()
    {
        _uiManager.AbilitiesCreated -= UIManager_AbilitiesCreated;
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

    [SerializeField]
    private UIManager _uiManager;
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