using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
    public Color col1;
    public Color col2;

    public float speed = 3.0f;

    private Image image;

    public bool isTimerOn = false;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        while(isTimerOn)
        {
            float t = (Mathf.Sin(Time.time * speed) + 1) / 2.0f;
            image.color = Color.Lerp(col1, col2, t);
        }
    }


}
