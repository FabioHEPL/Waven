using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerClickHandler
{
    public event EventHandler<ClickedArgs> Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(this, new ClickedArgs());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class ClickedArgs
    {
    }
}

