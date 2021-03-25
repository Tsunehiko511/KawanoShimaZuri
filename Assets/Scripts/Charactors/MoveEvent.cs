using System.Collections.Generic;
using System.Collections;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class MoveEvent : LuaInterpreterHandlerBase
{
    [SerializeField] GameObject model = default;
    [SerializeField] Sprite spriteFront = default;
    [SerializeField] Sprite spriteRight = default;
    [SerializeField] Sprite spriteLeft = default;
    [SerializeField] Sprite spriteBack = default;
    [SerializeField]
    private Texture2D texture = null;

    const float speed = 3.5f;
    Dictionary<string, Vector3> getDirection = new Dictionary<string, Vector3>()
    {
        {"left", Vector3.left },
        {"right", Vector3.right },
        {"up", Vector3.up },
        {"down", Vector3.down },
    };

    Animator animator;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();

    }

    public void MoveTo(string direction, int count, bool look = true)
    {
        if (look)
        {
            Look(direction);
        }
        StartCoroutine(MoveCorou(getDirection[direction], count));
    }

    IEnumerator MoveCorou(Vector3 direction, int count)
    {
        flag = false;

        Vector3 target = transform.position + direction * count;
        while (Vector2.Distance(transform.position, target) > float.Epsilon)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(ParamSO.Instance.RuntimeWaitTime);
        StopAnim();
        flag = true;
    }
    public void JumpTo(string direction, int count)
    {
        Vector3 position = getDirection[direction] * count;
        transform.Translate(position);
    }
    public int JumpToPosition(int x, int y, bool isFloat = false)
    {
        if (isFloat)
        {
            float newX = x / 10.0f;
            float newY = y / 10.0f;
            transform.position = new Vector3(newX, newY);
            return 10;
        }
        transform.position = new Vector3(x, y);
        return 11;
    }
    public void Show(bool isActive)
    {
        model.SetActive(isActive);
    }

    public void StopAnim()
    {
        animator.enabled = false;
    }

    public void Look(string direction)
    {

        if (spriteRight == null)
        {
            return;
        }
        SpriteRenderer renderer = model.GetComponent<SpriteRenderer>();

        switch (direction)
        {
            case "right":
                renderer.sprite = spriteRight;
                break;
            case "left":
                renderer.sprite = spriteLeft;
                break;
            case "down":
                renderer.sprite = spriteFront;
                break;
            case "up":
                renderer.sprite = spriteBack;
                break;
        }
        LookAnim(direction);
    }
    void LookAnim(string direction)
    {
        if (animator == null)
        {
            return;
        }
        animator.enabled = true;
        switch (direction)
        {
            case "right":
                animator.Play("PlayerRight");
                break;
            case "left":
                animator.Play("PlayerLeft");
                break;
            case "down":
                animator.Play("PlayerDown");
                break;
            case "up":
                animator.Play("PlayerUp");
                break;
        }
    }

}
