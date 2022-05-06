using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool showingEffect = true;
    private bool canPickup = false;
    public bool hasEvent = false;
    public GameObject EffectPrefabs;
    [SerializeField] private Vector3 position;
    private void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            Item item = GetComponent<Item>();
            InventoryManager.Instance.AddItem(item);
            GameObject.FindGameObjectWithTag("DialoageCanvas").GetComponent<DialogueUI>().ShowPanel("你获得了" + item.itemDetails.itemName);
        }
        //Debug.Log(InventoryManager.Instance.GetItemDetails(1004).canPickup);
        if(showingEffect && !hasEvent)
        {
            StartCoroutine(ShowEffect());
        }
        
    }
    IEnumerator ShowEffect()
    {
        showingEffect = false;
        EffectPrefabs.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        
        var MineEffect = Instantiate(EffectPrefabs);
        MineEffect.transform.position = transform.position + position;
        showingEffect = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果这是一个可以被捡起来的物体
        if (other.CompareTag("Player") && hasEvent == false)
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
        }
    }

}
