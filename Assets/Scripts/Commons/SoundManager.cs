using System.Collections;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class SoundManager : LuaInterpreterHandlerBase
{

    //public static SoundManager instance;
    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}

    [SerializeField] AudioSource audioSourceBGM = default;
    [SerializeField] AudioSource audioSourceSE = default;
    [SerializeField] AudioClip[] clipsBGM = default;
    [SerializeField] AudioClip[] clipsSE = default;
    public enum BGM
    {
        Title,
        Main,
    }

    public enum SE
    {
        Message,
        Sleep,
        Ending
    }

    public void PlayBGM(BGM bgm)
    {
        audioSourceBGM.volume = 1;
        int index = (int)bgm;
        audioSourceBGM.clip = clipsBGM[index];
        audioSourceBGM.Play();
    }
    public void PlayBGM(string clipName)
    {
        audioSourceBGM.volume = 1;
        int index = 0;
        switch (clipName)
        {
            case "title":
                index = 0;
                break;
        }
        audioSourceBGM.clip = clipsBGM[index];
        audioSourceBGM.Play();
        flag = true;
    }


    public void StopBGM()
    {
        StartCoroutine(FadeBGM());
    }
    IEnumerator FadeBGM()
    {
        while (audioSourceBGM.volume > 0)
        {
            audioSourceBGM.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        audioSourceBGM.Stop();
    }

    public void PlaySE(SE se)
    {
        int index = (int)se;
        audioSourceSE.PlayOneShot(clipsSE[index]);
    }
}
