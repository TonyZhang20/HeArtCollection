using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleAnimation : MonoBehaviour
{
    private Image image;
    private float fill = 0;
    private bool isEnable = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update() 
    {
        
        if(!isEnable) return;

        image.fillAmount = fill;
        fill += Time.deltaTime * speed;
    }
    private void OnEnable() 
    {
        image = GetComponent<Image>();
        fill = 0;
        image.fillAmount = 0;
        isEnable = true;
    }

    private void OnDisable() 
    {
        fill = 0;
        image.fillAmount = 0;
        isEnable = false;
    }


}
