using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPressE : MonoBehaviour
{
    private GameObject pickCanvas;
    private Transform image;
    [SerializeField] private Vector3 movePosition;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += GetPickupCanvas;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= GetPickupCanvas;
    }

    private void GetPickupCanvas()
    {
        pickCanvas = GameObject.FindGameObjectWithTag("PickupCanvas");
        image = pickCanvas.transform.Find("PressE");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            image.gameObject.SetActive(true);
            pickCanvas.GetComponent<RectTransform>().position = transform.position + movePosition;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            image.gameObject.SetActive(false);
        }
    }
}
