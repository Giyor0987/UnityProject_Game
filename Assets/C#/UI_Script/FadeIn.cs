using System;
using System.Collections;
using UnityEngine;

namespace MyNamespace
{
    public class FadeEffectManager : MonoBehaviour
    {
        private float elapesd = 0f;//経過時間

        public void FadeInEffect(GameObject item, float fadeduration)
        {
            // CanvasGroup is provide fadein effecte
            CanvasGroup canvasGroup = item.GetComponent<CanvasGroup>();
            StartCoroutine(GameManager.Instance.fadeEffectManager.FadeIn(canvasGroup, fadeduration));//コルーチンFadeInメソッドの参照
            Debug.Log(item.name);
        }
        public void FadeOutEffect(GameObject item, float fadeduration)
        {
            
            // CanvasGroup is provide fadein effecte
            CanvasGroup canvasGroup = item.GetComponent<CanvasGroup>();
            StartCoroutine(GameManager.Instance.fadeEffectManager.FadeOut(canvasGroup, fadeduration));//コルーチンFadeInメソッドの参照
            Debug.Log(item.name);
        }


        // Corutine
        private IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
        {
            canvasGroup.alpha = 0f;//最初は透明
            elapesd = 0f;
            while (elapesd < duration)
            {
                elapesd += Time.deltaTime;
                canvasGroup.alpha = Mathf.Clamp01(elapesd / duration);//Ration
                yield return null;
            }
            canvasGroup.alpha = 1f;
        }

        private IEnumerator FadeOut(CanvasGroup canvasGroup, float duration)
        {
            Debug.Log("FadeOutImage");
            elapesd = 0f;//経過時間だからalphaではない。
            while (elapesd < duration)
            {
                elapesd += Time.deltaTime;
                canvasGroup.alpha = 1f - Mathf.Clamp01(elapesd / duration);//guradualy decrease
                yield return null;
            }
            canvasGroup.alpha = 0f;
        }
    }

}
