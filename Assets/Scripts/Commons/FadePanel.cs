using System.Collections;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class FadePanel : LuaInterpreterHandlerBase
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void PlayFadeOut()
    {
        StartCoroutine(PlayAnim("FadeOutAnimation"));        
    }
    public void PlayFadeIn()
    {
        StartCoroutine(PlayAnim("FadeInAnimation"));
    }

    IEnumerator PlayAnim(string animName)
    {
        flag = false;
        anim.Play(animName);
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
        flag = true;
    }

}
