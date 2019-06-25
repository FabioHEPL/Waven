using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerClickHandler
{
    private InputManager _inputManager;
    private CombatManager _combatManager;
    private int _currentPlayerId = 1;
    private Character _character;

    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        _combatManager = FindObjectOfType<CombatManager>();
        _character = FindObjectOfType<Character>();
    }

    private void CombatManager_onSwitchTurn(object sender, CombatManager.SwitchTurnEventArgs e)
    {
        _currentPlayerId = e.IdentityPlayer;
        GameObject characterGameObject = CharacterLibrary.characterLibrary[_currentPlayerId];
        _character = characterGameObject.GetComponent<Character>();
    }


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

    private void OnEnable()
    {        
        _combatManager.onSwitchTurn += CombatManager_onSwitchTurn;
    }

    private void OnDisable()
    {        
        _combatManager.onSwitchTurn -= CombatManager_onSwitchTurn;
    }

    public UICircle CreateCircle(float radius, Vector2 position)
    {
        GameObject circleGO = Instantiate(_circlePrefab, position, Quaternion.identity);

        UICircle circle = circleGO.GetComponent<UICircle>();
        circle.Radius = radius;


        circle.GetComponent<SpriteRenderer>().sortingOrder = _circleCount;


        // increase depth
        circle.transform.position = new Vector3(
            circle.transform.position.x,
            circle.transform.position.y,
            -(float)_circleCount / 100);

        Debug.Log(circle.transform.position);
        Debug.Log(_circleCount);
        _circleCount++;

        return circle;
    }

    private int _circleCount = 0;

    [SerializeField]
    private GameObject _circlePrefab;
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
