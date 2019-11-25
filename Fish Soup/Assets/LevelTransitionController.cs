using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionController : MonoBehaviour
{
    [SerializeField] private string LevelToPlay = string.Empty;
    [SerializeField] private GameObject LoadingCanvas = null;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered == false)
        {
            if (other.CompareTag("Player"))
            {
                if (Application.CanStreamedLevelBeLoaded(LevelToPlay) == true)
                {
                    StartCoroutine(LoadSceneCo(LevelToPlay));
                    Instantiate(LoadingCanvas);
                    triggered = true;
                }
                else
                {
                    throw new System.Exception(string.Format(
                        "A scene in the name of {0} can't be loaded. Make sure it exist and that it is included in the build settinsg!",
                        LevelToPlay
                        ));
                }
            }
        }
    }

    private IEnumerator LoadSceneCo(string sceneName)
    {
        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(LevelToPlay);

        yield return new WaitForEndOfFrame();
    }
}
