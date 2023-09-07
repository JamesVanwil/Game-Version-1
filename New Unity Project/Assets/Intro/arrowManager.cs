using UnityEngine;
using UnityEngine.UI;

public class arrowManager : MonoBehaviour
{
    public RawImage arrow;
    public RawImage comic1;
    public float speed = 5f;
    public float minX = 380f;
    public float maxX = 400f;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving && comic1.rectTransform.localPosition.y >= 792f)
        {
            isMoving = true;
            arrow.gameObject.SetActive(true);
        }

        if (isMoving)
        {
            Vector3 pos = arrow.rectTransform.localPosition;
            pos.x += speed * Time.deltaTime;
            if (pos.x > maxX)
            {
                pos.x = minX;
            }
            arrow.rectTransform.localPosition = pos;
        }

        if (comic1.gameObject.activeSelf == false)
        {
            isMoving = false;
            arrow.gameObject.SetActive(false);
        }
    }
}
/* Another variation
 * {
    public RawImage arrow;
    public RawImage comic1;
    public RawImage comic2;
    public float speed = 5f;
    public float minX = 380f;
    public float maxX = 400f;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving && comic1.rectTransform.localPosition.y >= 792f || comic2.rectTransform.localPosition.y >= 792f)
        {
            isMoving = true;
            arrow.gameObject.SetActive(true);
        }

        if (isMoving)
        {
            Vector3 pos = arrow.rectTransform.localPosition;
            pos.x += speed * Time.deltaTime;
            if (pos.x > maxX)
            {
                pos.x = minX;
            }
            arrow.rectTransform.localPosition = pos;
        }

        if (isMoving && Input.anyKeyDown)
        {
            isMoving = false;
            arrow.gameObject.SetActive(false);
        }
    }
}

/* previous variation
{
    public RawImage arrow;
    public RawImage comic1;
    public RawImage comic2;
    public float speed = 5f;
    public float minX = 380f;
    public float maxX = 400f;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving && (comic1.rectTransform.localPosition.y >= 792f || comic2.rectTransform.localPosition.y >= 792f))
        {
            isMoving = true;
            arrow.gameObject.SetActive(true);
        }

        if (isMoving)
        {
            Vector3 pos = arrow.rectTransform.localPosition;
            pos.x += speed * Time.deltaTime;
            if (pos.x > maxX)
            {
                pos.x = minX;
            }
            arrow.rectTransform.localPosition = pos;
        }

        if (isMoving && Input.anyKeyDown)
        {
            isMoving = false;
            arrow.gameObject.SetActive(false);
        }
    }
}*/