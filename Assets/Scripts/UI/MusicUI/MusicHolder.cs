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

    public void ChangeChildAlpha(int index = 12)
    {
        float count = 0;
        for (int i = 0; i < musicAlphas.Length; i++)
        {
            if (i <= index)
            {
                musicAlphas[i].ChangeAlphaToOne();
                count++;
            }
            else
            {
                musicAlphas[i].ChangeAlphaToZero();
            }
        }

        AudioManager.Instance.audioMixer.SetFloat("MusicVolume", AudioManager.Instance.ConvertSoundVolume((float)count / 12f));
    }
}
