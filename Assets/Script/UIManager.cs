using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerClickHandler
{
    // CLICK HANDLER

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked(eventData.pointerEnter.gameObject);
    }

    private void OnClicked(GameObject clicked)
    {
        Clicked?.Invoke(this, new ClickedArgs(clicked));
    }

    public event EventHandler<ClickedArgs> Clicked;

    public class ClickedArgs
    {
        private GameObject _clicked;

        public GameObject Clicked
        {
            get { return _clicked; }
            set { _clicked = value; }
        }


        public ClickedArgs(GameObject clicked)
        {
            _clicked = clicked;
        }

    }




    public event EventHandler<AbilitiesCreatedArgs> AbilitiesCreated;
    public event EventHandler<PlayerTurnStartedArgs> PlayerTurnStarted;
    

    private void Awake()
    {
        activeAbilities = GetComponentsInChildren<ActiveAbility>();
        passiveAbilities = GetComponentsInChildren<PassiveAbility>();
        infoPanel = GetComponentInChildren<AbilityInfoPanel>(true);
    }

    private void OnEnable()
    {
        // S'abonner à l'évenement "hover" pour chaque abilité
        foreach (ActiveAbility activeAbility in activeAbilities)
        {
            activeAbility.HoverEnter += ActiveAbility_HoverEnter;
            activeAbility.HoverExit += ActiveAbility_HoverExit;
        }

        foreach (PassiveAbility passiveAbility in passiveAbilities)
        {
            passiveAbility.HoverEnter += PassiveAbility_HoverEnter;
            passiveAbility.HoverExit += PassiveAbility_HoverExit;
        }

        PlayerTurnStarted += Manager_PlayerTurnStarted;
        // _combatManager.
    }

    private void ActiveAbility_HoverEnter(object sender, HoverEnterArgs e)
    {
        ActiveAbility ability = (ActiveAbility)sender;
        infoPanel.gameObject.SetActive(true);
        infoPanel.Name = ability.Name;
        infoPanel.Description = ability.Description;
        infoPanel.PACost = String.Format("{0}", ability.PACost);
    }

    private void ActiveAbility_HoverExit(object sender, HoverExitArgs e)
    {
        infoPanel.gameObject.SetActive(false);
    }


    private void PassiveAbility_HoverEnter(object sender, HoverEnterArgs e)
    {
        PassiveAbility ability = (PassiveAbility)sender;
        infoPanel.gameObject.SetActive(true);
        infoPanel.Name = ability.Name;
        infoPanel.Description = ability.Description;
        infoPanel.PACost = String.Format("None");
    }

    private void PassiveAbility_HoverExit(object sender, HoverExitArgs e)
    {
        infoPanel.gameObject.SetActive(false);
    }


    private void OnDisable()
    {
        PlayerTurnStarted -= Manager_PlayerTurnStarted;

    }

    private void Manager_PlayerTurnStarted(object sender, PlayerTurnStartedArgs args)
    {
        SetPlayer(args.PlayerId);
    }

    public void OnAbilitiesCreated()
    {
        AbilitiesCreated?.Invoke(this, new AbilitiesCreatedArgs(activeAbilities));
    }

    private void SetPlayer(int playerId)
    {
        //// get player abilities info
        //AbilityInfo abilityInfo = new AbilityInfo(playerId);

        //GetCharacterInfo(playerId);

    }


    private PassiveAbility[] passiveAbilities;
    private ActiveAbility[] activeAbilities;
    private AbilityInfoPanel infoPanel;


}

public class PlayerTurnStartedArgs
{
    public PlayerTurnStartedArgs(int playerId)
    {
        this._playerId = playerId;
    }

    public int PlayerId { get => _playerId; }


    private int _playerId;
}

public class AbilitiesCreatedArgs
{
    public AbilitiesCreatedArgs(ActiveAbility[] abilities)
    {
        this._abilities = abilities;
    }

    public ActiveAbility[] Abilities { get => _abilities; }


    private ActiveAbility[] _abilities;
}


class AbilityInfo
{
    //public AbilityInfo(playerId)
    //{

    //}

    public string name;
    public string description;
    public int apCost;
    public string type;
}