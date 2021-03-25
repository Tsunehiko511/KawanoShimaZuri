using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject gameObjects = default;
    public string currentScene;
    string mainScene;
    public static SceneLoader instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        mainScene = SceneManager.GetActiveScene().name;
        currentScene = mainScene;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadScene("MainFishing");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            UnLoadScene("MainFishing");
        }
    }

    public void LoadScene(string sceneName)
    {
        if (currentScene != mainScene)
        {
            return;
        }
        currentScene = sceneName;
        StartCoroutine(LoadSceneCor(sceneName));

    }
    public void UnLoadScene(string sceneName)
    {
        if (currentScene == mainScene)
        {
            return;
        }
        StartCoroutine(UnLoadSceneCor(sceneName));
    }

    IEnumerator LoadSceneCor(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        gameObjects.SetActive(false);
    }

    IEnumerator UnLoadSceneCor(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(sceneName);
        gameObjects.SetActive(true);
        currentScene = SceneManager.GetActiveScene().name;
    }
}
