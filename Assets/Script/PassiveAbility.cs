using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PassiveAbility : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event EventHandler<ClickArgs> Click;
    public event EventHandler<HoverEnterArgs> HoverEnter;
    public event EventHandler<HoverExitArgs> HoverExit;

    // Start is called before the first frame update

    //public int id;
    //public Sprite icon;
    //public string name;
    //public string description;
    //public int apCost;
    // public string type;
    // enum AbilityType  {
    // Zone,
    // Target,
    // }

    public void Awake()
    {
        _image = GetComponent<Image>();

        if (_icon != null)
        {
            _image.sprite = _icon;
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
        HoverEnter?.Invoke(this, new HoverEnterArgs());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Je survole avec la souris sur l'abilité");
        HoverExit?.Invoke(this, new HoverExitArgs());
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
