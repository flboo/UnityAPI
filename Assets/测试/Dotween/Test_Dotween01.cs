using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core;

public class Test_Dotween01 : MonoBehaviour
{

    [SerializeField]
    private Text m_TxtTest;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_TxtTest.text = "";
            int number = 0;
            // m_TxtTest.DOText("12345678765433456765434565", 2.0f);
            Tween t = DOTween.To(() => number, x =>
            {
                number = x;
                m_TxtTest.text = number.ToString();
            }, 100, 5);
        }
    }

}