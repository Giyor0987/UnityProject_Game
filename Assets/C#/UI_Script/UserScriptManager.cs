using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MyNamespace
{
    //read text file and execute the command in the text
    public class UserScriptManager : MonoBehaviour
    {
        [SerializeField] TextAsset _textFile;
        List<string> _sentence = new List<string>();

        void Awake()
        {
            if (_textFile == null)
            {
                Debug.LogWarning("LoadScript: textFile is null!");
            }
            Debug.Log("LoadScript");
            _sentence.Clear();
            StringReader reader = new StringReader(_textFile.text);
            while (reader.Peek() != -1)//Peek()は読み込んだreaderのTextが空白なら-1を返す
            {
                string line = reader.ReadLine();//ここで_textFileを読み込んでline箱に入れる [役目：右辺でテキストファイルを読む。]

                _sentence.Add(line);
                //そしてその中身を_sentenceというListという配列型の箱に入れる
            }
        }
        public void LoadScript(TextAsset textFile)
        {
            
        }

        //List型の_sentenceという変数に上で読み込んだtextをMainTextControllerで表示する
        //このメソッドがほかのメソッドから呼び出されると、読み込んだTextLine[]をかえす
        public string GetCurrentSentence()
        {
            
            var index = GameManager.Instance.lineNumber;

            if (_sentence == null || _sentence.Count == 0)
            {
                Debug.LogWarning("Sentence list is empty!");
                return "";
            }

            if (index < 0 || index >= _sentence.Count)
            {
                Debug.LogWarning($"lineNumber {index} is out of range (0 to {_sentence.Count - 1})");
                return "";
            }
            //Current Test Line
            return _sentence[GameManager.Instance.lineNumber];
            
            

        }
        
        public bool IsStatement(string sentence)
        {
            if (sentence[0] == '&')
            {
                return true;
            }
            return false;
        }

        public void ExecuteStatement(string sentence)
        {
            
            if (string.IsNullOrEmpty(sentence)) return;
            
            string[] words = sentence.Split(' ');//SpilitはC#のメソッドで文字列を区切ってわける。今回は空白で分ける

            if (words.Length < 2)
            {
                /*words is List that nessesary for 
                 */
                
                Debug.LogWarning("ExcuteStatement: args shortage。Input: " + sentence);
                return;
            }
            
            switch (words[0])
            {
                //"&img"was called ,PutImage method is executed, and "&img" this wouds contains text.txt file.
                case "&img":
                    GameManager.Instance.imageManager.PutImage(words[1], words[2]);
                    Debug.Log("DisplayImgae");
                    break;
                case "&rmimg"://"rmimg"destroy image
                    GameManager.Instance.imageManager.RemoveImage(words[1]);
                    Debug.Log("RemoveImage");
                    break;
                default:
                    Debug.LogWarning("ExcuteStatement: UnknownCommand → " + words[0]);
                    break;
            }
        }
    }
}
