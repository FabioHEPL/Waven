using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveAbility : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool IsPassive;
    public GameObject AbilityPanel;
    public event EventHandler<ClickArgs> Click;
    public event EventHandler<HoverEnterArgs> OnHoverEnter;
    public event EventHandler<HoverExitArgs> OnHoverExit;
    public int CharacterPlaying;

    public void Awake()
    {       
        _image = GetComponent<Image>();

        if (_icon != null)
        {
            _image.sprite = _icon;
        }

        CombatManager tmp = FindObjectOfType<CombatManager>();

        FindObjectOfType<CombatManager>().onUIUpdatePlayer += OnUIUpdatePlayerListener;
    }

    private void OnUIUpdatePlayerListener(object sender, CombatManager.UIUpdateEventArgs e)
    {
        CharacterPlaying = e.PlayerID;
    }

    private void Start()
    {
        AbilityPanel.SetActive(false);
        if(CharacterPlaying == 0)
        {
            CharacterPlaying = 1;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Je clique sur l'abilité");
        Click?.Invoke(this, new ClickArgs());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Je survole avec la souris sur l'abilité");
        OnHoverEnter?.Invoke(this, new HoverEnterArgs());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Je survole avec la souris sur l'abilité");
        OnHoverExit?.Invoke(this, new HoverExitArgs());
    }
    public void OnEnterPassif(bool passive)
    {
        IsPassive = passive;
        OnHoverEnter?.Invoke(this, new HoverEnterArgs { IsPassive = IsPassive , Character = 1});
    }
    public void OnEnter(int ButtonNr)
    {
        OnHoverEnter?.Invoke(this, new HoverEnterArgs { Character = CharacterPlaying ,ButtonNR = ButtonNr});
    }
    public void OnExit()
    {
        OnHoverExit?.Invoke(this, new HoverExitArgs());
    }
    public Sprite Icon
    {
        get
        {
            return _icon;
        }
        set
        {
            setIcon(value);     
        }
    }

    private void setIcon(Sprite value)
    {
        _icon = value;
        // update UI Image's Sprite with new icon
        _image.sprite = _icon;
    }


    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int PACost
    {
        get { return _paCost; }
        set { _paCost = value; }
    }

    private Image _image;

    [SerializeField]
    private int id;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private string _name;
    [SerializeField]
    private string description;
    [SerializeField]
    private int _paCost;

}

public class ClickArgs
{

}

public class HoverEnterArgs
{
    public int ButtonNR;
    public bool IsPassive;
    public int Character;
}

public class HoverExitArgs
{

}
