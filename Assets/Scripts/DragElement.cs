using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragElement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;

    public bool gravity;
    [SerializeField]
    private float timeToWait = 0.5f;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (gravity)
        {
            rigidbody.gravityScale = 1;
        }
        else
        {
            rigidbody.gravityScale = 0;
        }
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Handheld.Vibrate();
        StartCoroutine(WaitToEnd());
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(timeToWait);
        GameManager.MiniGameSolved();
    }
}
