using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFight : MonoBehaviour
{
    public void Translate()
    {
        SceneManager.LoadScene("battle");
    }
}
