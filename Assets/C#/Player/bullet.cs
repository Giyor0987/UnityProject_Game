using MyNamespace;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    void Update()
    {
        float current_positon = GameManager.Instance.playerController.transform.position.magnitude;

        if (transform.position.magnitude > current_positon + Mathf.Abs(30f)) Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")) return; 
        else if (collision.gameObject.CompareTag("Ground")) Destroy(this.gameObject);

    }
    
}
