using UnityEngine;

public class Timer : MonoBehaviour
{
    //추가할 것 작은 스테이지가 넘어가면 숫자가 60으로 초기화

    public Sprite[] digitSprites; // 0부터 9까지의 숫자 스프라이트 배열
    public float startingTime = 60f;
    public float timeDecreaseInterval = 7f;
    public int decreaseAmount = 1;

    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentSecond;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = startingTime;
        currentSecond = Mathf.CeilToInt(timer);
        UpdateTimeSprite();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = startingTime;
            currentSecond = Mathf.CeilToInt(timer);
        }

        int newSecond = Mathf.CeilToInt(timer);
        if (newSecond != currentSecond)
        {
            currentSecond = newSecond;
            UpdateTimeSprite();
        }
    }

    void UpdateTimeSprite()
    {
        int tensDigit = currentSecond / 10; // 십의 자리 숫자
        int unitsDigit = currentSecond % 10; // 일의 자리 숫자

        // 숫자 스프라이트 이미지 설정
        spriteRenderer.sprite = digitSprites[tensDigit];

        // 일의 자리 숫자를 오른쪽으로 위치
        GameObject unitSpriteObject = new GameObject("UnitDigitSprite");
        SpriteRenderer unitSpriteRenderer = unitSpriteObject.AddComponent<SpriteRenderer>();
        unitSpriteRenderer.sprite = digitSprites[unitsDigit];
        unitSpriteObject.transform.parent = transform;
        unitSpriteObject.transform.localPosition = new Vector3(0.5f, 0f, 0f);
    }
}
