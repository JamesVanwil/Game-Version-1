using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class introManager2 : MonoBehaviour
{
    public RawImage comic2;
    private RectTransform rectTransform2;

    void Start()
    {
        rectTransform2 = comic2.GetComponent<RectTransform>();

    }

    void Update()
    {
        if (rectTransform2.anchoredPosition.y < 792 && Input.anyKey && comic2.isActiveAndEnabled)
        {
            rectTransform2.anchoredPosition += new Vector2(0, 1);
        }
        if (rectTransform2.anchoredPosition.y == 792 && Input.anyKeyDown)
        {
            comic2.gameObject.SetActive(false);
        }
    }
}