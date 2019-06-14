using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInfoPanel : MonoBehaviour
{
    [SerializeField]
    private Text _nameText;
    [SerializeField]
    private Text _paCostText;
    [SerializeField]
    private Text _descriptionText;


    public string Name
    {
        get
        {
            return _nameText.text;
        }
        set
        {
            _nameText.text = "Nom : " + value;
        }
    }



    public string PACost
    {
        get
        {
            // TODO:
            return _paCostText.text;
        }
        set
        {
            _paCostText.text = "Cout PA : " + value;
        }
    }

    public string Description
    {
        get
        {
            return _descriptionText.text;
        }
        set
        {
            _descriptionText.text = "Description : " + value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayRepresentation(ActiveAbility ability)
    {
        representation.Display(ability);
    }

    private AbilityRepresentation representation;

    public  void SetRepresentation(AbilityRepresentation abilityRepresentation)
    {
        representation = abilityRepresentation;
    }

}


public interface AbilityRepresentation
{
    void Display(ActiveAbility ability);
    //void Hide();
}

public class PassiveAbilityRepresentation :  AbilityRepresentation
{
    public PassiveAbilityRepresentation(Text nameText, Text paCostText, Text descriptionText)
    {
        _nameText = nameText;
        _paCostText = paCostText;
        _descriptionText = descriptionText;
    }

    private Text _nameText;
    private Text _paCostText;
    private Text _descriptionText;

    public void Display(ActiveAbility ability)
    {        
        _nameText.text = "Name : " + ability.Name;
        _descriptionText.text = "Description : " + ability.Description;
        _paCostText.gameObject.SetActive(false);
    }

    public void Hide()
    {
        
    }
}

public class ActiveAbilityRepresentation : AbilityRepresentation
{
     public ActiveAbilityRepresentation(Text nameText, Text paCostText, Text descriptionText)
    {
        _nameText = nameText;
        _paCostText = paCostText;
        _descriptionText = descriptionText;
    }

    private Text _nameText;
    private Text _paCostText;
    private Text _descriptionText;


    public void Display(ActiveAbility ability)
    {
        _nameText.text = "Name : " + ability.Name;
        _descriptionText.text = "Description : " + ability.Description;
        _paCostText.gameObject.SetActive(true);
        _paCostText.text = "PA Cost : " + ability.PACost;
    }

    //public void Hide()
    //{
    //    throw new NotImplementedException();
    //}
}
