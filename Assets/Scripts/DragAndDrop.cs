using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private float ZPos;
    Rigidbody rb;

    private void Start()
    {
        ZPos = transform.position.z;
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        if (f) return;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        rb.useGravity = false;
    }
    private void OnMouseUp()
    {
        if(f) return;
        rb.useGravity = true;
        rb.velocity= Vector3.zero;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (f) return;
        Vector3 newPosition = GetMouseAsWorldPoint() + mOffset;
        transform.position = newPosition;
        transform.position = new Vector3(transform.position.x, transform.position.y, ZPos);

        if (IsAtGoodSpot() && !f)
        {
            DoSomething();
        }
    }

    public Vector2 atThisPosThenGood;
    public float ArountThisMuch = 0.3f;
    
    private bool IsAtGoodSpot()
    {
        if (transform.position.x < atThisPosThenGood.x + ArountThisMuch && 
            transform.position.x > atThisPosThenGood.x - ArountThisMuch && 
            transform.position.y < atThisPosThenGood.y + ArountThisMuch && 
            transform.position.y > atThisPosThenGood.y - ArountThisMuch)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool f = false;
    public bool freezeIfGootTheLocation;
    private void DoSomething()
    {
        if (freezeIfGootTheLocation)
            f = true;
        rb.velocity = Vector3.zero;

        Debug.Log("Got the good location");
    }
}