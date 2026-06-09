using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MyNamespace
{
    public class InteractionManager : MonoBehaviour
    {   
        public bool InteractionUI = false;


        // Start is called before the first frame update
        void Start()
        {
            InteractionUI = false;
        }

        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Collision");
                InteractionUI = true;
            }
            else InteractionUI = false;
        }
        
    }
}

