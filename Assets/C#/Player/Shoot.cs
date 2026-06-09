using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    
    public class Shoot : MonoBehaviour
    {
        [SerializeField]  float _speed = 3.0f;
        [SerializeField]  GameObject _bullet;
        [SerializeField]  float _bulletDelay;
        public PlayerController player;
        private float _bulletTime;
        private GameObject bulletIns;
        private Vector2 mousePos;
        private IState ShootState;

        
        
        void Update()
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = Mathf.Abs(Camera.main.transform.position.z);
            mousePos = Camera.main.ScreenToWorldPoint(mouse);
            
            if (Input.GetKey(KeyCode.Mouse0))
            {
                
                _bulletTime += Time.deltaTime;
                
                if (_bulletTime > _bulletDelay)
                {
                    Vector2 dir = (mousePos - (Vector2)transform.position).normalized;
                    Vector2 spawnPos = (Vector2)transform.position + dir * 2.0f;
                    bulletIns = Instantiate(_bullet, spawnPos, Quaternion.identity);
                    bulletIns.GetComponent<Rigidbody2D>().velocity = dir * _speed;
                    _bulletTime -= _bulletTime;
                }
                
            }
            else _bulletTime = 0f;
        }
    }

}