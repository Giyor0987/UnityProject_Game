using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace MyNamespace
{
    public class AspectMangaer : MonoBehaviour
    {
        public void SetAspect(GameObject item , Sprite image)
        {
            RectTransform rectTransform = item.GetComponent<RectTransform>();

            // set image to Image component
            Image imageCompornent = item.GetComponent<Image>();
            imageCompornent.sprite = image;
            imageCompornent.preserveAspect = true;


            // calculate aspect ratio(Width/Hight)
            float spriteWidth = image.rect.width;
            float spriteHeight = image.rect.height;
            float aspectRatio = spriteWidth / spriteHeight;


            float desiredHeight = 300f;
            float desiredWidth = desiredHeight * aspectRatio;
            rectTransform.sizeDelta = new Vector2(desiredWidth, desiredHeight);
            rectTransform.anchoredPosition = Vector2.zero;
        }


    }
}

