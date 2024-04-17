using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        double d = 1.1;
        for (int i = 0; i < 30; i++)
        {
            d *= 10;
            Debug.Log(CurrencyFormatDisplay.Display(d));
        }
    }
}
