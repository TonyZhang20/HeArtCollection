using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ShowCircle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject redCircle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        redCircle.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        redCircle.transform.position = transform.position;
        redCircle.SetActive(true);
    }

}
