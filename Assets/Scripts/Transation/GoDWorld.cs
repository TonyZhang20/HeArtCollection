using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDWorld : MonoBehaviour
{
    public Vector3 position;
    public bool Check = true;

    private void Update()
    {
        if(Check)
        {
            CheckItem();
        }
    }

    public bool CheckItem()
    {
        var list = InventoryManager.Instance.playerBag;
        if (list.hasItem(1009) && list.hasItem(1010) && list.hasItem(1011) && list.hasItem(1012) && list.hasItem(1013) && list.hasItem(1014))
        {
            Check = false;
            GetComponent<ItemPickup>().hasEvent = false;
            GetComponent<ShowPressE>().show = true;
            return true;
        }

        return false;
    }

    public void Transfrom()
    {
        EventHandler.CallTransitionEvent("d-town", position);
        Debug.Log("Run");
    }

}
