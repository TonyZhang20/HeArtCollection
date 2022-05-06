using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDWorld : MonoBehaviour
{
    public Vector3 position;
    public bool Check = true;
    public bool EndTravel = true;
    public ItemPickup itemPickup;
    private void Update()
    {
        if (Check)
        {
            CheckItem();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && InventoryManager.Instance.playerBag.hasItem(1015) && EndTravel)
        {
            EndTravel = false;
            Transfrom();
        }
    }
    

    public bool CheckItem()
    {
        var list = InventoryManager.Instance.playerBag;
        if (list.hasItem(1009) && list.hasItem(1010) && list.hasItem(1011) && list.hasItem(1012) && list.hasItem(1013) && list.hasItem(1014))
        {
            Check = false;
            itemPickup.hasEvent = false;
            itemPickup.gameObject.GetComponent<ShowPressE>().show = true;
            return true;
        }

        return false;
    }

    public void Transfrom()
    {
        EventHandler.CallTransitionEvent("d-home", position);
    }

}
