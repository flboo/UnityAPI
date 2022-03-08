using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < 1000; i++)
        {
            Debug.Log(i);
        }
    }

}
