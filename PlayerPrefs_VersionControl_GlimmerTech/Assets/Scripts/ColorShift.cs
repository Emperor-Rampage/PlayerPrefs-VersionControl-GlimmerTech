using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
    public Color col1;
    public Color col2;
    public Color IdleColor;

    public float speed = 3.0f;

    private Image image;

    public bool isTimerOn = false;

    public bool IsTimerOn
    {
        get { return isTimerOn; }
        set
        {
            isTimerOn = value;
        }
    }

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1) / 2.0f;
        if(isTimerOn)
        {
            image.color = Color.Lerp(col1, col2, t);
        }
        else
        {
            image.color = IdleColor;
        }
    }


}
