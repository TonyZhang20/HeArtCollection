using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveSlot_BookUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Correct;
    public GameObject MakeSure;
    public int index;
    private DataSlot currentData;
    private void OnEnable() 
    {
        GetComponent<Button>().onClick.AddListener(EmptySaveSlot);
        MakeSure.gameObject.SetActive(false);
        Correct.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Correct.gameObject.SetActive(true);
        Correct.transform.position = transform.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Correct.gameObject.SetActive(false);
    }

    private void EmptySaveSlot()
    {
        currentData = SaveloadManager.Instance.dataSlots[index];
        if(currentData == null)
        {
            SaveloadManager.Instance.Save(index);
        }
        else
        {
            MakeSure.SetActive(true);
            MakeSure.GetComponent<MainCanvasSaveConfrim>().index = index;
        }
    }
}
