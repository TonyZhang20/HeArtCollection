using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPressE : MonoBehaviour
{
    public bool show = true;
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

    public void StopShow()
    {
        show = false;
        image.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            image.gameObject.SetActive(show);
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
