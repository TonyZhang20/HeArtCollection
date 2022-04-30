using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class HealthBar : SingleTon<HealthBar>, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject player;
    public Sprite heartIcon;
    public TextMeshProUGUI moneyText;
    public Image[] heart;
    private PlayerStats playerStats;
    private Animator anim;
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoad;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoad;
    }

    private void OnAfterSceneLoad()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();

        RefershHealthBar();
        RefershCoin();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("Down");
        //Debug.Log("Run");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("Up");
    }

    public void RefershHealthBar()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i < playerStats.currentHealth)
            {
                heart[i].gameObject.SetActive(true);
                heart[i].sprite = heartIcon;
            }
            else
            {
                heart[i].gameObject.SetActive(false);
            }
        }
    }

    public void RefershCoin()
    {
        moneyText.text = playerStats?.Money.ToString("00");
    }

}
