using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        private Animator transition;

        public int maingameSceneIndex = 1;

        public float transitionTime = 1;
        // Start is called before the first frame update
        void Start()
        {
            transition = transform.Find("CrossFade").GetComponent<Animator>();
        }

        // Update is called once per frame

        public void LoadNextLevel()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        public void LoadMinigame(int miniGameSceneIndex)
        {
            StartCoroutine(LoadLevel(miniGameSceneIndex));
        }

        public void LoadMainGame()
        {
            StartCoroutine(LoadLevel(maingameSceneIndex));
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");
        
            yield return new WaitForSeconds(transitionTime);
        
            SceneManager.LoadScene(levelIndex);
        }
    
    }
}
