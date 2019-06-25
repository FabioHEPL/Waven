using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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


    private void Awake()
    {
        FindObjectOfType<ActiveAbility>().OnHoverEnter += OnEnterListener;
        FindObjectOfType<ActiveAbility>().OnHoverExit += OnHoverExitListener;
    }

    private void OnHoverExitListener(object sender, HoverExitArgs e)
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnterListener(object sender, HoverEnterArgs e)
    {
        var character = CharacterInfoUtilities.CharacterInfoUtility.GetCharacterInfo(e.Character);

        this.gameObject.SetActive(true);
        if (e.IsPassive)
        {
            _nameText.text = "Name: " + character.PassifName;
            _paCostText.text = "";
            _descriptionText.text = "Description: " + character.Passif;
        }
        else
        {
            _paCostText.text = "Cout PA: ";
            _nameText.text = "Name: " + character.Spells[e.ButtonNR].Name;
            _descriptionText.text ="Description: " + character.Spells[e.ButtonNR].Description;
        }
    }

    


    //    public void DisplayRepresentation(ActiveAbility ability)
    //    {
    //        representation.Display(ability);
    //    }

    //    private AbilityRepresentation representation;

    //    public  void SetRepresentation(AbilityRepresentation abilityRepresentation)
    //    {
    //        representation = abilityRepresentation;
    //    }

    //}


    //public interface AbilityRepresentation
    //{
    //    void Display(ActiveAbility ability);
    //    //void Hide();
    //}

    //public class PassiveAbilityRepresentation :  AbilityRepresentation
    //{
    //    public PassiveAbilityRepresentation(Text nameText, Text paCostText, Text descriptionText)
    //    {
    //        _nameText = nameText;
    //        _paCostText = paCostText;
    //        _descriptionText = descriptionText;
    //    }

    //    private Text _nameText;
    //    private Text _paCostText;
    //    private Text _descriptionText;

    //    public void Display(ActiveAbility ability)
    //    {        
    //        _nameText.text = "Name : " + ability.Name;
    //        _descriptionText.text = "Description : " + ability.Description;
    //        _paCostText.gameObject.SetActive(false);
    //    }

    //    public void Hide()
    //    {

    //    }
    //}

    //public class ActiveAbilityRepresentation : AbilityRepresentation
    //{
    //     public ActiveAbilityRepresentation(Text nameText, Text paCostText, Text descriptionText)
    //    {
    //        _nameText = nameText;
    //        _paCostText = paCostText;
    //        _descriptionText = descriptionText;
    //    }

    //    private Text _nameText;
    //    private Text _paCostText;
    //    private Text _descriptionText;


    //    public void Display(ActiveAbility ability)
    //    {
    //        _nameText.text = "Name : " + ability.Name;
    //        _descriptionText.text = "Description : " + ability.Description;
    //        _paCostText.gameObject.SetActive(true);
    //        _paCostText.text = "PA Cost : " + ability.PACost;
    //    }

    //public void Hide()
    //{
    //    throw new NotImplementedException();
    //}
}
