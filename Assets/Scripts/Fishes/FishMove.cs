using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    [SerializeField] FlagSO flagSO = default;
    [SerializeField] float defaultSpeed = default; // power
    [SerializeField] float speed = default;

    [SerializeField] float defaultPullSpeed = default; // power
    [SerializeField] float pullSpeed = default;
    [SerializeField] float escapeSpeed = default;
    [SerializeField] PlayerInput playerInput = default;
    [SerializeField] Transform upModePoint = default;
    [SerializeField] Transform liftPoint = default;
    [SerializeField] Transform escapePoint = default;
    [SerializeField] Transform floorPoint = default;

    [SerializeField] FishSO fishSO = default;
    [SerializeField] FishSO normalFishSO = default;
    [SerializeField] FishSO hardFishSO = default;
    [SerializeField] Animator animator = default;
    [SerializeField] GameObject model = default;

    [SerializeField] Sprite moveSprite = default;
    [SerializeField] Sprite rampageSprite = default;
    [SerializeField] GameObject fishingLine = default;
    [SerializeField] Sprite fishingLineSprite = default;
    [SerializeField] Animator fishingLineAnimator = default;
    AudioSource audioSource;
    [SerializeField] AudioClip audioClip = default;
    [SerializeField] AudioClip moveAudioClip = default;
    [SerializeField] GameObject moveFishingLine = default;

    int escapeRate;
    // 引っ張ら
    public enum Status
    {
        Move,
        Stop,
        Pulled,
        Escape,
    }

    // ある程度の高さになると背景移動がなくなる？

    public Status state = Status.Move;

    public const int ESCAPE_BORDER = 150;
    public int escapeValue = 0;

    public const int ESCAPE_DISTANCE = 100;
    float initPositionx = 0;
    // スタート位置から

    private void Awake()
    {
        spriteRenderer = model.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator PullSound()
    {
        yield return new WaitForSeconds(0.2f);
        while (true)
        {
            yield return null;
            while (state == Status.Move)
            {
                audioSource.PlayOneShot(audioClip);
                yield return new WaitForSeconds(0.2f);
            }
            while (state == Status.Stop)
            {
                audioSource.PlayOneShot(audioClip);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public float MovingDistance
    {
        get
        {
            if (initPositionx < transform.position.x)
            {
                return 0;
            }
            return -(transform.position.x - initPositionx);
        }
    }

    bool CanEscape
    {
        get => escapeValue >= ESCAPE_BORDER || MovingDistance >= ESCAPE_DISTANCE || escapePoint.position.x > transform.position.x;
    }

    bool wasLift;
    bool CanFift
    {
        get => transform.position.y >= liftPoint.position.y;
    }

    private void LoadData()
    {
        FishSO[] fishSOs = new FishSO[]
        {
            fishSO,
            fishSO,
            fishSO,
            fishSO,
            fishSO,
            normalFishSO,
            normalFishSO,
            hardFishSO,
        };
        FishSO tmp = null;
        if (flagSO.GetFlag("HardMode"))
        {
            tmp = hardFishSO;
        }
        else
        {
            tmp = fishSOs[Random.Range(0, fishSOs.Length)];
        }
        defaultSpeed = tmp.defaultSpeed;
        defaultPullSpeed = tmp.defaultPullSpeed;
        speed = defaultSpeed;
        pullSpeed = defaultPullSpeed;
        escapeRate = tmp.escapeRate;
    }

    private void Start()
    {
        initPositionx = transform.position.x;
        state = Status.Move;
        LoadData();
        StartCoroutine(ChangeStateCor());
        StartCoroutine(PullSound());
    }

    int duration = 3;

    IEnumerator ChangeStateCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            ChangeState();
        }
    }
    // 切り替わる瞬間にゆっくりになる

    void ChangeState()
    {
        if (state == Status.Stop)
        {
            // 魚が動く
            speed = defaultSpeed;
            state = Status.Move;

            int r = Random.Range(0, 100);
            if (r < 30)
            {
                duration = Random.Range(1, 2);
            }
            else
            {
                duration = Random.Range(3, 5);
            }
        }
        else if (state == Status.Move)
        {
            // 人が引く
            pullSpeed = defaultPullSpeed;
            state = Status.Stop;
            int r = Random.Range(0, 100);
            if (r < 10)
            {
                duration = Random.Range(1, 2);
            }
            else
            {
                duration = Random.Range(3, 7);
            }
        }
    }

    void DebugInput()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            state = Status.Move;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            state = Status.Stop;
        }
    }

    void Update()
    {
        DebugInput();

        if (CanFift)
        {
            Lift();
            return;
        }

        if (CanEscape)
        {
            state = Status.Escape;
        }

        switch (state)
        {
            case Status.Move:
                if (playerInput.OnSpace)
                {
                    fishingLine.SetActive(true);
                    moveFishingLine.SetActive(false);
                    Rampage();
                }
                else
                {
                    fishingLine.SetActive(false);
                    moveFishingLine.SetActive(true);
                    Move();
                }
                break;
            case Status.Stop:
                // 一定時間は動く
                if (playerInput.OnSpace)
                {
                    fishingLine.SetActive(true);
                    moveFishingLine.SetActive(false);
                    Pulled();
                }
                float moveSpeed = Mathf.Sqrt(Mathf.Max(0.5f, pullSpeed));
                SetAnim("PullAnim", moveSpeed);
                break;
            case Status.Escape:
                Escape();
                break;
        }
    }

    // 左下に移動する
    private void Move()
    {
        speed -= defaultSpeed / duration * Time.deltaTime;
        float moveSpeed = Mathf.Sqrt(Mathf.Max(0, speed));

        Vector2 direction = new Vector2(-1, -0.2f).normalized;
        if (floorPoint.position.y >= transform.position.y)
        {
            direction = new Vector2(-1, 0).normalized;
        }
        // model.transform.localPosition = new Vector3(-2, 0, 0);
        Vector2 diff = direction * moveSpeed * Time.deltaTime;
        transform.Translate(diff);
        model.transform.localScale = new Vector3(-1, 1, 1);        
        SetAnim("MoveAnim", moveSpeed);
    }
    SpriteRenderer spriteRenderer;

    bool isRampage;
    void Rampage()
    {
        escapeValue++;
        if (isRampage)
        {
            return;
        }
        isRampage = true;
        StartCoroutine(RampageEffect());
    }

    IEnumerator RampageEffect()
    {
        fishingLine.transform.localPosition = new Vector3(12, 4.64f, 0);
        model.transform.localScale = new Vector3(1, 1, 1);
        model.transform.localPosition = new Vector3(2, 0, 0);
        animator.enabled = false;
        spriteRenderer.sprite = rampageSprite;
        fishingLine.GetComponent<SpriteRenderer>().sprite = fishingLineSprite;
        for (int i=0; i< 3; i++)
        {
            audioSource.PlayOneShot(audioClip);
        }
        yield return new WaitForSeconds(0.1f);
        fishingLine.SetActive(false);
        moveFishingLine.SetActive(true);
        animator.enabled = true;
        // spriteRenderer.sprite = rampageSprite;
        fishingLine.transform.localPosition = new Vector3(10.84f, 4.64f, 0);
        model.transform.localPosition = new Vector3(0, 0, 0);
        model.transform.localScale = new Vector3(-1, 1, 1);
        isRampage = false;
        // 動く方になる?
        speed = defaultSpeed;
        state = Status.Move;
        if (Random.Range(0,100) < escapeRate)
        {
            state = Status.Escape;
            escapeValue = ESCAPE_BORDER;
        }
    }

    void SetAnim(string animName, float moveSpeed)
    {
        if (moveSpeed > 0.01f)
        {
            animator.enabled = true;
            animator.Play(animName);
            fishingLineAnimator.Play(animName);
        }
        else
        {
            animator.enabled = false;
            spriteRenderer.sprite = moveSprite;
        }
    }

    void Pulled()
    {
        pullSpeed -= defaultPullSpeed / duration * Time.deltaTime;
        float moveSpeed = Mathf.Sqrt(Mathf.Max(0.5f, pullSpeed));

        Vector2 direction = new Vector2(1, 0.25f).normalized;
        // 魚の位置が一定値
        if (upModePoint.position.x <= transform.position.x)
        {
            direction = new Vector2(0.1f, 1).normalized;
        }
        // model.transform.localPosition = new Vector3(2, 0, 0);
        Vector2 diff = direction * moveSpeed * Time.deltaTime;
        transform.Translate(diff);
        model.transform.localScale = new Vector3(1, 1, 1);

    }

    bool isEscape;
    private void Escape()
    {
        Vector2 direction = new Vector2(-1, -0.01f).normalized;
        Vector2 diff = direction * escapeSpeed * Time.deltaTime;
        transform.Translate(diff);
        StartCoroutine(EscapeCor());
    }
    IEnumerator EscapeCor()
    {
        if (!isEscape)
        {
            isEscape = true;
            fishingLine.SetActive(false);
            moveFishingLine.SetActive(true);
            moveFishingLine.AddComponent<Rigidbody2D>().gravityScale = 2;
            moveFishingLine.transform.parent = transform.parent;
            animator.enabled = true;
            animator.Play("MoveAnim");
            model.transform.localScale = new Vector3(-1, 1, 1);

            flagSO.SetFlag("GetFish", false);
            yield return new WaitForSeconds(1f);
            SceneLoader.instance.UnLoadScene("MainFishing");
        }
    }


    private void Lift()
    {
        if (wasLift)
        {
            return;
        }
        wasLift = true;
        StartCoroutine(LiftCor());
    }

    IEnumerator LiftCor()
    {
        state = Status.Stop;
        flagSO.SetFlag("GetFish", true);
        yield return new WaitForSeconds(1f);
        SceneLoader.instance.UnLoadScene("MainFishing");
    }
}
