using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private List<Ability> abilities;

    public event EventHandler<AbilitiesCreatedArgs> AbilitiesCreated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAbilitiesCreated()
    {
        AbilitiesCreated?.Invoke(this, new AbilitiesCreatedArgs(abilities));
    }
}

public class AbilitiesCreatedArgs
{
    public AbilitiesCreatedArgs(List<Ability> abilities)
    {
        this._abilities = abilities;
    }

    public List<Ability> Abilities { get => _abilities; }


    private List<Ability> _abilities;
}