﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICircle : MonoBehaviour
{
    public event EventHandler<ClickedArgs> Clicked;

    [SerializeField]
    private float _radius;
    public float Radius
    {
        get { return _radius; }
        set { SetRadius(value); }
    }

    public Color Color
    {
        get { return _renderer.color; }
        set { _renderer.color = value; }
    }

    private SpriteRenderer _renderer;
    private UICircle _bounds;
    private Vector3 _previousFramePosition = Vector3.zero;

    public void SetBounds(UICircle circle)
    {
        _bounds = circle;
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void SetRadius(float value)
    {
        transform.localScale = new Vector3(value * 2, value * 2, transform.localScale.z);
        _radius = value;
    }

    private void Update()
    {
        _previousFramePosition = transform.position;
    }

    private void LateUpdate()
    {
        if (_bounds != null)
        {
            bool inside = Mathf.Pow(transform.position.x - _bounds.transform.position.x, 2) +
                Mathf.Pow(transform.position.y - _bounds.transform.position.y, 2)
                < Mathf.Pow(_bounds.Radius, 2);


            if (!inside)
            {
                transform.position = _previousFramePosition;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked !");
        Clicked?.Invoke(this, new ClickedArgs());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            public List<GameObject> TargetList;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            // supprimer sprite ou bouton selon type d'attaque
            // et retirer de la liste 
            // savoir dans quelle équipe est le joueur et 
            // comparer l'équipe du joueur qui lance le sort
        }
    }    

    public class ClickedArgs
    {
    }
}
