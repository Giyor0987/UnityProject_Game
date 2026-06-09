using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace MyNamespace
{
    //controlling main text display for Usercontrol
    public class MainTextController : MonoBehaviour
    {
        //TextMeshGUIProがあるGameObjectを入れる箱
        [SerializeField] TextMeshProUGUI _mainTextObject;
        int _displayedSentenceLength;
        int _sentenceLenght;
        private float _time;
        private float _Feedtime;

        
        // Start is called before the first frame update
        void Start()
        {
            
            _time = 0f;
            _Feedtime = 0.05f;

        }

        // Update is called once per frame
        void Update()
        {
            
            _time += Time.deltaTime;

            if (_time >= _Feedtime)
            {
                /*
                 I just realized, when I was coding,
                this is sounds like a philosophy of computher in Permutation city.
                Slowing down the flow of time in virtual reality,thats guy be able to live semi- permanently.
                but i cant call that is "living",
                well, whatever its very interesting
                */
                _time -= _Feedtime;//なぜ「=0」ではなく「-= Feedtime」にする理由は、ゲーム内の時間と実時間の誤差をなくすため

                if (!CanGoToTheNextLine())
                {
                    _displayedSentenceLength++;

                    _mainTextObject.maxVisibleCharacters = _displayedSentenceLength;//画面に表示するもじ
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.interactionManger.InteractionUI)
            {

                string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();

                if (sentence.StartsWith("&"))
                {
                    
                    GameManager.Instance.userScriptManager.ExecuteStatement(sentence);
                }

                if (CanGoToTheNextLine())
                {
                    //push buttone ,increase line number of_sentence[] 
                    GoToTheNextLine();

                    //UserScriptManagerのGetCurrentSentenceメソッドで読み込んだTextをマウスボタンを押すごとに表示
                    DisplayText();
                }
                else
                {
                    _displayedSentenceLength = _sentenceLenght;
                }
            }
        }

        //その行の、すべての文字が表示されていなければ、まだ次の行へ進むことができない
        public bool CanGoToTheNextLine()
        {
            //読み込んだテキストライン
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _sentenceLenght = sentence.Length;
            //読み込んだラインの文字数が写す文字数より少ないならfalse
            return (_displayedSentenceLength > sentence.Length);
        }

        
        public void GoToTheNextLine()
        {

            _displayedSentenceLength = 0;
            _time = 0f;//_timeを初期化
            _mainTextObject.maxVisibleCharacters = 0;
            GameManager.Instance.lineNumber++;

            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();

            if (GameManager.Instance.userScriptManager.IsStatement(sentence))
            {
                GameManager.Instance.userScriptManager.ExecuteStatement(sentence);
                GoToTheNextLine();
            }
        }

        /*このメソッドでテキスト表示。_mainTextObjectというTextUI(これが画面のTextライン)に
        UserScriptManagerで読み込んだsentenceを代入(Important)*/
        public void DisplayText()
        {
            //_sentence[lineNumber]がreturnされる
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            //ここでTextGUIに文章が表示される。あとはDisplayメソッドが呼び出されると繰り返す
            _mainTextObject.text = sentence;
        }
    }
}
