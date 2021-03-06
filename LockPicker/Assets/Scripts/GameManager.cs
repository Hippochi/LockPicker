using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject lockpick;
    [SerializeField] private GameObject introTxt;
    [SerializeField] private GameObject resetTxt;

    private bool hasOpened = false;
    void Update()
    {
        if (Input.GetKeyDown("f") && hasOpened == false)
        {
            lockpick.SetActive(true);
            introTxt.SetActive(false);
            hasOpened = true;
        }

        if (Input.GetKeyDown("x") && hasOpened == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
