using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public int fruitsCollected = 0;
    public int requiredFruits = 3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CollectFruit()
    {
        fruitsCollected++;
        Debug.Log("Fruits: " + fruitsCollected);

        if (fruitsCollected >= requiredFruits)
        {
            OnWinConditionReady?.Invoke();
        }
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Se acabó");
        }
    }

    public delegate void WinConditionDelegate();
    public event WinConditionDelegate OnWinConditionReady;
}