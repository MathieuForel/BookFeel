using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : Singleton<DragAndDrop>
{
    Controls inputs;
    Camera _camera;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        inputs = new Controls();
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        inputs.Mouse.DragAndDrop.started += ctx => MouseDown(ctx);
        inputs.Mouse.DragAndDrop.canceled += ctx => OffMouseDown(ctx);

        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    public bool mouseDown;
    public Vector2 mousePos;
    public float movableOffset;
    private void MouseDown(InputAction.CallbackContext ctx)
    {
        mouseDown = true;
        mousePos = inputs.Mouse.Pos.ReadValue<Vector2>();
    }
    private void OffMouseDown(InputAction.CallbackContext ctx)
    {
        mouseDown = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_camera.transform.position, Input.mousePosition);
    }

    GameObject objToMove = null;
    private void Update()
    {
        Vector2 vector2 = inputs.Mouse.Pos.ReadValue<Vector2>();
        Vector2 vector2ParCam = _camera.ScreenToWorldPoint(vector2);
        if (mouseDown)
        {
            Debug.Log($" Mouse Down");
            if (Physics.Raycast(_camera.transform.position, Input.mousePosition, out RaycastHit hit, 100, layerMask))
            {
                objToMove = hit.collider.gameObject;
                Debug.Log($" hit : {hit.collider.gameObject}");
            }

            if (objToMove == null)
                return;

            if ((vector2.x > mousePos.x - movableOffset && vector2.x < mousePos.x + movableOffset) ||
                (vector2.y < mousePos.y + movableOffset && vector2.y > mousePos.y - movableOffset))
                return;

            if (objToMove.TryGetComponent(out Rigidbody rb))
            {
                rb.useGravity = false;
            }

            Debug.Log("Move an Object");

            Vector3 newpos = new Vector3(vector2ParCam.x, vector2ParCam.y, objToMove.transform.position.z);
            objToMove.transform.position = newpos;
        }
        else if (objToMove != null && !mouseDown)
        {
            if (objToMove.TryGetComponent(out Rigidbody rb))
            {
                rb.useGravity = true;
            }
            objToMove = null;
        }
    }
}