using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyNamespace
{
    
    public class BulletControler : MonoBehaviour
    {
        private RectTransform _targetposition;
        [SerializeField]GameObject _bullet;


        // Start is called before the first frame update
        void Start()
        {
            _targetposition = GameManager.Instance.mousePoint._mousePoint;
        }

        // Update is called once per frame
        void FixedUpdate()
        {/*
            while ()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
                }
            }
         */   
        }
    }

}