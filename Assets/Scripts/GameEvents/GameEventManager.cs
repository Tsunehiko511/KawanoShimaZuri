using System.Collections;
using MoonSharp.Interpreter;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    [SerializeField] Player player = default;
    [SerializeField] MoveEvent npcGirl = default;
    [SerializeField] MoveEvent npcBoy = default;
    [SerializeField] MessageManager messagePanel = default;
    [SerializeField] MoveEvent chocolate = default;
    [SerializeField] FadePanel fadePanel = default;
    [SerializeField] Player oldPlayer = default;
    [SerializeField] new MoveEvent camera = default;
    [SerializeField] SoundManager sound = default;
    [SerializeField] SelectionEvent select = default;
    [SerializeField] FlagManager flag = default;

    [SerializeField] TextAsset textAsset = default;
    [SerializeField] GameObject titlePanel = default;
    [SerializeField] GameObject[] lines = default;
    bool pushStart;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        // Luaで使うクラスは登録する必要がある
        UserData.RegisterAssembly(typeof(Player).Assembly);
        UserData.RegisterAssembly(typeof(MoveEvent).Assembly);
        UserData.RegisterAssembly(typeof(FadePanel).Assembly);
        UserData.RegisterAssembly(typeof(MessageManager).Assembly);
        UserData.RegisterAssembly(typeof(SoundManager).Assembly);
        UserData.RegisterAssembly(typeof(SelectionEvent).Assembly);
        UserData.RegisterAssembly(typeof(FlagManager).Assembly);
        UserData.RegisterAssembly(typeof(SceneLoader).Assembly);


        pushStart = false;
        titlePanel.SetActive(true);
        sound.PlayBGM(SoundManager.BGM.Title);
        lines[0].SetActive(true);
        lines[1].SetActive(true);
    }

    private void Update()
    {
        if (SceneLoader.instance.currentScene != "MainStory")
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && pushStart == false)
        {
            flag.SetFlag("HardMode", false);
            pushStart = true;
            titlePanel.GetComponent<Animator>().Play("FadeTitleAnimation");
            // titlePanel.SetActive(false);
            sound.StopBGM();
            // StartCoroutine(GameEvent());
            StartCoroutine(ExecuteEvent(textAsset.text));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            flag.SetFlag("HardMode", false);
            SceneLoader.instance.LoadScene("MainFishing");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            flag.SetFlag("HardMode", true);
            SceneLoader.instance.LoadScene("MainFishing");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            flag.SetFlag("HardMode", false);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainStory");
        }
    }

    IEnumerator ExecuteEvent(string script)
    {
        var interpreter = new LuaInterpreter(script); // スクリプトを渡して初期化
        interpreter.AddHandler("player", player);
        interpreter.AddHandler("npcGirl", npcGirl);
        interpreter.AddHandler("npcBoy", npcBoy);
        interpreter.AddHandler("message", messagePanel);
        interpreter.AddHandler("camera", camera);
        interpreter.AddHandler("fadePanel", fadePanel);
        interpreter.AddHandler("oldPlayer", oldPlayer);
        interpreter.AddHandler("sound", sound);
        interpreter.AddHandler("chocolate", chocolate);
        interpreter.AddHandler("select", select);
        interpreter.AddHandler("flag", flag);
        interpreter.AddHandler("sceneLoader", SceneLoader.instance);
        yield return new WaitForSeconds(2);
        
        int? result = null;
        while (interpreter.HasNextScript())
        {
            if (SceneLoader.instance.currentScene != "MainStory")
            {
                yield return null;
            }
            interpreter.Resume(result);
            yield return interpreter.WaitCoroutine();
            if (interpreter.resultValue != null)
            {
                result = interpreter.resultValue.Value;
            }
            else
            {
                result = null;
            }
        }
        yield return null;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        PlayerPrefs.SetInt("CLEAR", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainStory");
    }
}