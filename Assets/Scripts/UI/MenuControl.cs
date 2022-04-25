using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(menu.activeInHierarchy)
                menu.SetActive(false);
            else
                menu.SetActive(true);
            Debug.Log("Run");
        }    
    }
}
