using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) return; 
        else if (collision.gameObject.CompareTag("Ground")) Destroy(this.gameObject);

    }
    void Update()
    {
        //if (transform.position.magnitude > Mathf.Abs(30f)) Destroy(this.gameObject);
    }
}
