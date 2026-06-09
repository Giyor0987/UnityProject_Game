using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class ChangeChara : MonoBehaviour
    {
        Dictionary<string, GameObject> charaDic;
        [SerializeField] List<GameObject> charaList;
        private int nowChara;

        void Awake()
        {
            charaDic = new Dictionary<string, GameObject>();
            charaDic.Add("Chara1", charaList[0]);
            charaDic.Add("Chara2", charaList[1]);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                nowChara++;
                //List‚ÌCout‚Å—v‘f”‚ðŽæ“¾‚µ‚ÄA¡‚ÌƒLƒƒƒ‰‚ª—v‘f”ˆÈã‚É‚È‚Á‚½‚çÅ‰‚É–ß‚·
                if (nowChara >= charaList.Count) nowChara = 0;
            }

            switch (nowChara)
            {
                case 0:
                    charaDic["Chara1"].SetActive(true);
                    charaDic["Chara2"].SetActive(false);
                    break;
                case 1:
                    charaDic["Chara1"].SetActive(false);
                    charaDic["Chara2"].SetActive(true);
                    break;
            }
            
        }
    }

}