using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

namespace MyNamespace
{
    public class MousePoint : MonoBehaviour
    {
        

        public RectTransform _mousePoint;
        void Start()
        {
            _mousePoint = GetComponent<RectTransform>();
            Cursor.visible = false;
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0)) Cursor.visible = false;

            Vector2 mousePosition = Input.mousePosition;
            _mousePoint.position = mousePosition;

        }

    }
}
