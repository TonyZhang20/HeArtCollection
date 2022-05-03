using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    public AudioSource BGM;
    // Start is called before the first frame update
    private void Update()
    {
        ms.instance.SetValue(BGM.volume / (float)1);
    }

 
}
