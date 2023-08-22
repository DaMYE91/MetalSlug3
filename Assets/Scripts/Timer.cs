using UnityEngine;

public class Timer : MonoBehaviour
{
    //�߰��� �� ���� ���������� �Ѿ�� ���ڰ� 60���� �ʱ�ȭ

    public Sprite[] digitSprites; // 0���� 9������ ���� ��������Ʈ �迭
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
        int tensDigit = currentSecond / 10; // ���� �ڸ� ����
        int unitsDigit = currentSecond % 10; // ���� �ڸ� ����

        // ���� ��������Ʈ �̹��� ����
        spriteRenderer.sprite = digitSprites[tensDigit];

        // ���� �ڸ� ���ڸ� ���������� ��ġ
        GameObject unitSpriteObject = new GameObject("UnitDigitSprite");
        SpriteRenderer unitSpriteRenderer = unitSpriteObject.AddComponent<SpriteRenderer>();
        unitSpriteRenderer.sprite = digitSprites[unitsDigit];
        unitSpriteObject.transform.parent = transform;
        unitSpriteObject.transform.localPosition = new Vector3(0.5f, 0f, 0f);
    }
}
