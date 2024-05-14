using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilitesController : MonoBehaviour
{
    public Text timeText;

    private void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm");
    }
}
