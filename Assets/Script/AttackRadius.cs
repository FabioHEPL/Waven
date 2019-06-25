using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackRadius : MonoBehaviour
{
    private UICircle _circle;
    [SerializeField]
    private List<GameObject> collided;

    public event EventHandler<SelectedArgs> Selected;

    private void Awake()
    {
        _circle = GetComponent<UICircle>();
    }

    private void Update()
    {
        Vector3 circlePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(
            circlePos.x,
            circlePos.y,
            this.transform.position.z);
    }

    private void OnMouseDown()
    {
        OnSelected();
    }

    private void OnSelected()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _circle.Radius, Vector2.zero);

        // convert to game object list
        List<GameObject> collided = SelectGameObjects(hits);

        Selected?.Invoke(this, new SelectedArgs(collided));
    }

    private List<GameObject> SelectGameObjects(RaycastHit2D[] hits)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        for (int i = 0; i < hits.Length; i++)
        {
            gameObjects.Add(hits[i].collider.gameObject);
        }

        return gameObjects;
    }

    private List<GameObject> SelectGameObjects(RaycastHit2D[] hits, string tag)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.CompareTag(tag))
            {
                gameObjects.Add(hits[i].collider.gameObject);
            }
        }

        return gameObjects;
    }

    public class SelectedArgs
    {
        private List<GameObject> _collided;

        public List<GameObject> Collided
        {
            get { return _collided; }
            set { _collided = value; }
        }

        public SelectedArgs(List<GameObject> collided)
        {
            this._collided = collided;
        }
    }
}

