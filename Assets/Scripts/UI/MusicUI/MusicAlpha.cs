using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAlpha : MonoBehaviour
{
    public int index;
    public float value;
    public Image image;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(CallParent);
        image = GetComponent<Image>();
        ChangeAlphaToOne();
    }

    private void CallParent()
    {
        transform.GetComponentInParent<MusicHolder>().ChangeChildAlpha(index);
    }

    public void ChangeAlphaToZero()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.a, 0);
    }

    public void ChangeAlphaToOne()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.a, 1);
    }

}
