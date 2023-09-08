using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introManager : MonoBehaviour
{
    public RawImage comic1;
    public RawImage comic2;
    private RectTransform rectTransform1;

    void Start()
    {
        rectTransform1 = comic1.GetComponent<RectTransform>();

    }

    void Update()
    {
        if (rectTransform1.anchoredPosition.y < 792 && Input.anyKey)
        {
            rectTransform1.anchoredPosition += new Vector2(0, 1);
        }
        if (rectTransform1.anchoredPosition.y == 792 && Input.anyKeyDown)
        {
            comic1.gameObject.SetActive(false);
            comic2.gameObject.SetActive(true);
        }
    }
}