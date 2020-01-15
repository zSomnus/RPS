using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        public Animator transition;

        public float transitionTime = 1;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame

        public void LoadNextLevel()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");
        
            yield return new WaitForSeconds(transitionTime);
        
            SceneManager.LoadScene(levelIndex);
        }
    
    }
}
