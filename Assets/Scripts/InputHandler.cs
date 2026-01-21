using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private Transform _prevHover, _nextHover;
    [SerializeField] private Tooltip tooltip;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnMouseEnter(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.paused) return;
        // Debug.Log("it's 4am");

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(context.ReadValue<Vector2>()));
        
        _prevHover = _nextHover;
        // Debug.LogFormat("previous: {0} / next: {1}", _prevHover, _nextHover);
        _nextHover = rayHit.collider ? rayHit.collider.transform : null;
        if (_nextHover)
        {
            if (_nextHover.parent.GetComponent<Card>() != null) {
                tooltip.ShowTooltip(_nextHover.parent.GetComponent<Card>().GetTooltip());
                // tooltip.ShowTooltip("cardardd\ncard");
                if (_nextHover.parent.GetComponent<Card>().selectable)
                {
                    _nextHover.GetComponent<SpriteRenderer>().color = new Color(0.95f, 0.95f, 0.6f);
                }
                if (_prevHover && _nextHover && _prevHover.GetInstanceID() != _nextHover.GetInstanceID())
                {
                    _prevHover.GetComponent<SpriteRenderer>().color = Color.white;
                    Debug.Log("out of a card!");
                    tooltip.HideTooltip();
                }
            }
            else if (_nextHover.GetComponent<Item>() != null) {
                tooltip.ShowTooltip(_nextHover.GetComponent<Item>().GetTooltip());
                // tooltip.ShowTooltip("item\nitemitem");
                if (_prevHover && _nextHover && _prevHover.GetInstanceID() != _nextHover.GetInstanceID())
                {
                    // _prevHover.GetComponent<SpriteRenderer>().color = Color.white;
                    tooltip.HideTooltip();
                }
            }
        }
        else if (_prevHover)
        {
            _prevHover.GetComponent<SpriteRenderer>().color = Color.white;
            tooltip.HideTooltip();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.paused) return;
        if (!context.started) return;
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(context.ReadValue<Vector2>()));
        if (!rayHit.collider) return;
        GameObject test = rayHit.collider.gameObject.transform.parent.gameObject;
        if (test.CompareTag("Card"))
        {
            Card c = test.GetComponent<Card>();
            if (c.selectable)
            {
                c.Select();
            }
        }
    }
}
