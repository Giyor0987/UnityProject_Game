using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    public class ImageManager : MonoBehaviour
    {

        [NonSerialized] public Image FinishEffectImage;
        [NonSerialized] public Image StartEffectImage;
        [SerializeField] Sprite _Chara1;
        [SerializeField] Sprite _Chara2;
        [SerializeField] GameObject _leftChara;
        [SerializeField] GameObject _rightChara;
        [SerializeField] GameObject _imagePrefab;
        [SerializeField] Canvas canvas;
        [SerializeField] Image textWindow;
        [SerializeField] RectTransform _textWindowParentObject;
        Dictionary<string, Sprite> _CharactersSprites;
        Dictionary<string, GameObject> _CharacterParentObject;
        Dictionary<string, GameObject> _CharactersSpriteObject;

        private GameObject item;
        [NonSerialized] GameObject _CharachterObject;
        void Awake()
        {
            FinishEffectImage = GameObject.Find("FinishFadeOut").GetComponent<Image>();
            StartEffectImage = GameObject.Find("StartFadeIn").GetComponent<Image>();
            _CharactersSprites = new Dictionary<string, Sprite>();
            _CharactersSprites.Add("Chara1", _Chara1);
            _CharactersSprites.Add("Chara2", _Chara2);

            _CharacterParentObject = new Dictionary<string, GameObject>();
            _CharacterParentObject.Add("MainChara", _leftChara);
            _CharacterParentObject.Add("SubChara", _rightChara);
            

            _CharactersSpriteObject = new Dictionary<string, GameObject>();
            _CharactersSpriteObject.Add("Charachter", _CharachterObject);

        }
        private void Start()
        {
            //GameManager.Instance.fadeEffectManager.FadeInEffect(StartEffectImage.gameObject, 1f);
        }
        public void PutImage(string imageName, string parentObjectName)
        {
            Debug.Log("PutImage");

            // get Sprite and ParentObject from Dictionary
            Sprite image = _CharactersSprites[imageName];
            GameObject parentObject = _CharacterParentObject[parentObjectName];

            // get  location of parentObject, and instantiate imagePrefab
            Transform parent = parentObject.transform;
            RectTransform parentRect = _textWindowParentObject.GetComponent<RectTransform>();

            Instantiate(textWindow,parentRect);
            item = Instantiate(_imagePrefab, parent);
            
            
            GameManager.Instance.imageDisplayManager.SetAspect(item, image);


            GameManager.Instance.fadeEffectManager.FadeOutEffect(GameManager.Instance.helthController.playerUI, 1f);
            GameManager.Instance.fadeEffectManager.FadeInEffect(item,1f);
            

            // ä«óùópÇ…ìoò^
            _CharactersSpriteObject.Add(imageName, item);

        }

        public void RemoveImage(string imageName)
        {
            if(!_CharactersSpriteObject.ContainsKey(imageName))
            {
                Debug.LogError("Image not found: " + imageName);
                return;
            }

            GameManager.Instance.fadeEffectManager.FadeOutEffect(_CharactersSpriteObject[imageName], 1f);
            GameManager.Instance.fadeEffectManager.FadeInEffect(GameManager.Instance.helthController.playerUI, 1f);
            _CharactersSpriteObject.Remove(imageName);//list in Dictionary, stuck imageName and item
        }
    }
}

