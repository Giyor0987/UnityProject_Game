using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    public class SceneController : MonoBehaviour
    {
        private float _delay = 1.5f; // 遅延時間（秒）
        [SerializeField] Animator transitionAime; 
        private void Start()
        {
            if (GameManager.Instance.sceneController == null)
            {
                GameManager.Instance.sceneController = this;
                DontDestroyOnLoad(gameObject);
            }
            
            GameManager.Instance.fadeEffectManager.FadeOutEffect(GameManager.Instance.imageManager.StartEffectImage.gameObject, 1f);
        }

        public void StartFinishSequence()
        {
            if (GameManager.Instance.imageManager.FinishEffectImage != null) GameManager.Instance.imageManager.FinishEffectImage = GameObject.Find("FinishFadeOut").GetComponent<Image>();
            GameManager.Instance.fadeEffectManager.FadeInEffect(GameManager.Instance.imageManager.FinishEffectImage.gameObject, 1f);
            Debug.Log("Player collided with the finish point.");
            // プレイヤーがゴールに到達したときの処理
                /*
                GameManager.Instance.fadeEffectManager.FadeOutEffect(finishEffectObject,1f);
                */
                StartCoroutine(LoadNextLevelAfterDelay());
                // 1秒後にLoadNextLevelメソッドを呼び出す
            Debug.Log("Player reached the finish point, loading next level...");
            //else GameManager.Instance.sceneController.LoadScene(levelName);
            
        }
        private void NextLevel()
        {
            StartCoroutine(LoadNextLevelAfterTransition());
        }

        IEnumerator LoadNextLevelAfterDelay()
        {
            yield return new WaitForSeconds(_delay);
            GameManager.Instance.sceneController.NextLevel();
        }
        IEnumerator LoadNextLevelAfterTransition()
        {
            transitionAime.SetTrigger("Start");
            yield return new WaitForSeconds(1f);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            transitionAime.SetTrigger("End");
        }
        
        /*
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
            if (sceneName == null) Debug.LogError("Scene is null");
        }
        */
    }

}

