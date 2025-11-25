using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnMouseEnter(InputAction.CallbackContext context)
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(context.ReadValue<Vector2>()));
        if (!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);
    }
}
