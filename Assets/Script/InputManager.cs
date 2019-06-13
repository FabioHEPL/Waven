using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event EventHandler<AbilitySelectedArgs> AbilitySelected;

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
        foreach (Ability ability in e.Abilities)
        {
            ability.Click += Ability_Click;
        }
    }

    private void Ability_Click(object sender, ClickArgs e)
    {
        // L'abilité sur laquelle on a cliqué
        Ability ability = (Ability)sender;

        OnAbilitySelected(ability);
    }

    private void OnAbilitySelected(Ability ability)
    {
        AbilitySelected?.Invoke(this, new AbilitySelectedArgs(ability));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    private UIManager _uiManager;
}

public class AbilitySelectedArgs
{
    public AbilitySelectedArgs(Ability ability)
    {
        this._ability = ability;
    }

    private Ability _ability;

    public Ability Ability
    {
        get { return _ability; }
    }
}