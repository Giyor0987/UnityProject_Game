using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    public class FinishPoint : MonoBehaviour
    {
        
        [SerializeField] string levelName;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.sceneController.StartFinishSequence();
            }
        }
    }
}


