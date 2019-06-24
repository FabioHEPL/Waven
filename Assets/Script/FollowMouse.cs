using UnityEngine;
using UnityEngine.EventSystems;


public class FollowMouse : MonoBehaviour
{

    private UICircle _circle;

    private void Awake()
    {
        _circle = GetComponent<UICircle>();
    }

    private void Update()
    {
        this.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}

