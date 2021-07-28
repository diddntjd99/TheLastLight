using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireGaugeControl : MonoBehaviour
{
    [SerializeField] public Slider fireGauge; //불 게이지
    public static bool CLR_Gauge;//게이지 on/off

    void Start()
    {
        fireGauge.value = 100; //초기 불 게이지 값 100
        CLR_Gauge = true;
    }

    void Update()
    {
        if (CLR_Gauge)
        {
            fireGauge.value -= Time.deltaTime; //시간 당 불 게이지 감소
        }
    }
}