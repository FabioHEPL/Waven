using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ability : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public event EventHandler<ClickArgs> Click;
    public event EventHandler<HoverArgs> Hover;

    // Start is called before the first frame update

    public int id;
    public GameObject icon;
    public string name;
    public string description;
    public string type;
    // enum AbilityType  {
    // Zone,
    // Target,
    // }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Je clique sur l'abilité");
        Click?.Invoke(this, new ClickArgs());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Je survole avec la souris sur l'abilité");
        Hover?.Invoke(this, new HoverArgs());
    }
}

public class ClickArgs
{

}

public class HoverArgs
{

}
