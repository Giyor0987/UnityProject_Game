using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyNamespace
{

    public class ReticleController : MonoBehaviour
    {
        public RectTransform[] mouseUI;
        public Rigidbody2D[] mouseUIrb;
        public float _impact;
        public float spring;
        private float maxdist = 30f;

        Vector2[] directions = new Vector2[]
        {
        new Vector2(-1,-1),
        new Vector2(+1,-1),
        new Vector2(+1,+1),
        new Vector2(-1,+1)
        };

        void FixedUpdate()
        {
            Vector2 center = GameManager.Instance.mousePoint._mousePoint.position;

            for (int i = 0; i < mouseUI.Length; i++)
            {

                // rerative position
                Vector2 diff = (Vector2)mouseUI[i].position - center;

                float dist = diff.magnitude;

                if (dist < maxdist)
                {
                    mouseUIrb[i].velocity = Vector2.zero;
                }
                else
                {
                    // バネ
                    Vector2 force = -diff.normalized * spring * (dist - maxdist);
                    mouseUIrb[i].AddForce(force);
                }

                // 反動
                if (Input.GetMouseButtonDown(0))
                {
                    mouseUIrb[i].AddForce(directions[i] * _impact, ForceMode2D.Impulse);
                }
            }
        }
    }

}
