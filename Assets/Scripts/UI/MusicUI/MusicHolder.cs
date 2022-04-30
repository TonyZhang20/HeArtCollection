using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicHolder : MonoBehaviour
{
    public MusicAlpha[] musicAlphas;
    private float totalVelum = 0f;
    private void Awake()
    {
        totalVelum = 100f / 12f;
        for (int i = 0; i < musicAlphas.Length; i++)
        {
            musicAlphas[i].index = i;
            musicAlphas[i].value += totalVelum * (i + 1);
        }
    }

    private void Start()
    {

    }

    public void ChangeChildAlpha(int index)
    {
        for (int i = 0; i < musicAlphas.Length; i++)
        {
            if (i <= index)
            {
                musicAlphas[i].ChangeAlphaToOne();
            }
            else
            {
                musicAlphas[i].ChangeAlphaToZero();
            }
        }
    }
}
