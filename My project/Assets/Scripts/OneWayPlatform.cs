using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWay;

    [SerializeField] private BoxCollider2D playerCollider;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(currentOneWay != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWay = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWay = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        EdgeCollider2D platformcollider = currentOneWay.GetComponent<EdgeCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformcollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformcollider, false);
    }
}
