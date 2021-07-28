using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] public Slider fireGauge;
    public Text FWcounter;  //각 텍스트 이름들
    public Text Ccounter;
    public Text RanCounter;
    public static int Fire = 0;  //변수 설정
    public static int C = 0;
    public static int Ran = 0;

    void Start()
    {
        Fire = 0;
        C = 0;
        Ran = 0;
    }

    public void UseFirewood()
    {
        if (Fire > 0)
        {
            fireGauge.value += 10;
            Fire -= 1;
        }
    }
    public void UseCoal()
    {
        if (C > 0)
        {
            fireGauge.value += 20;
            C -= 1;
        }
    }
    public void UseRandomStone()
    {
        if (Ran > 0)
        {
            fireGauge.value += (int)(Random.Range(-2, 3)) * 5;
            Ran -= 1;
        }
    }
    void Update()
    {
        FWcounter.text = Fire.ToString();
        Ccounter.text = C.ToString();
        RanCounter.text = Ran.ToString();
        if (Input.GetKeyDown(KeyCode.D))
        {
            UseRandomStone();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            UseFirewood();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UseCoal();
        }
    }
}