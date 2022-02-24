using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockPick : MonoBehaviour
{
    // Start is called before the first frame update
    public float skill, difficulty, time, chance;
    public int key, rounds;
    public string keyV;
    private bool keyWindow = false;

    [SerializeField] private GameObject skillTxt;
    [SerializeField] private GameObject introTxt;
    [SerializeField] private GameObject successTxt;
    [SerializeField] private GameObject difficultyTxt;
    [SerializeField] private GameObject keyBox;

    void Start()
    {
        
        skill = Random.value;
        difficulty = Random.value;
        time = 0.5f + (difficulty * 0.7f);
        rounds = Random.Range(2, 5);
        chance = 0.1f + (difficulty * 0.3f);
        Prep();        
        StartCoroutine(Qte());
    }

    private void Update()
    {
        if (keyWindow)
            KeyCheck();

        successTxt.GetComponent<TextMeshProUGUI>().text =  (Mathf.Clamp(Mathf.RoundToInt(chance *100), 0, 100)) + "% Chance";
        skillTxt.GetComponent<TextMeshProUGUI>().text = "Skill: " + (Mathf.RoundToInt(skill *100));
        difficultyTxt.GetComponent<TextMeshProUGUI>().text = "Difficulty: " + (100 - Mathf.RoundToInt(difficulty * 100)); ;
    }


    IEnumerator Qte()
    {
        
        if (rounds > 0)
        {
            
            rounds--;
            yield return new WaitForSecondsRealtime(2.0f + (Random.value * 2.0f));
            keyWindow = true;
            keyBox.SetActive(true);
            keyBox.GetComponent<TextMeshProUGUI>().text = "[" + keyV + "]";
            yield return new WaitForSecondsRealtime(time);
            keyWindow = false;
            keyBox.SetActive(false);
            Prep();
            StartCoroutine(Qte());
        }
        else GameOver();
    }

   
    void GameOver()
    {
        introTxt.SetActive(true);
        if (Random.value < chance)
        {
            introTxt.GetComponent<TextMeshProUGUI>().text = "You Unlocked The Chest!";
        }
        else
        introTxt.GetComponent<TextMeshProUGUI>().text = "You Failed To Unlock The Chest";
    }

    void Prep()
    {
        
        key = Random.Range(0, 7);
        Key(key);
    }

    void Key(int key)
    {

        switch (key)
        {
            case 7:
                keyV = "F";
                break;
            case 6:
                keyV = "D";
                break;
            case 5:
                keyV = "S";
                break;
            case 4:
                keyV = "A";
                break;
            case 3:
                keyV = "R";
                break;
            case 2:
                keyV = "E";
                break;
            case 1:
                keyV = "W";
                break;
            case 0:
                keyV = "Q";
                break;
        }
    }

    bool isMatching(int i)
    {
        if (i == key) 
        {
            return true;
        }
        else return false;
    }

    void KeyCheck()
    {
        if (Input.GetKeyDown("q"))
        {
            KeyBehaviour(0);
        }
        if (Input.GetKeyDown("w"))
        {
            KeyBehaviour(1);
        }
        if (Input.GetKeyDown("e"))
        {
            KeyBehaviour(2);
        }
        if (Input.GetKeyDown("r"))
        {
            KeyBehaviour(3);
        }
        if (Input.GetKeyDown("a"))
        {
            KeyBehaviour(4);
        }
        if (Input.GetKeyDown("s"))
        {
            KeyBehaviour(5);
        }
        if (Input.GetKeyDown("d"))
        {
            KeyBehaviour(6);
        }
        if (Input.GetKeyDown("f"))
        {
            KeyBehaviour(7);
        }
    }

    void KeyBehaviour(int i)
    {
        keyBox.SetActive(false);
        keyWindow = false;
        if (isMatching(i))
        {
            chance += (.15f * (1 + (1 * skill)));
        }
        else
        {
            chance -= (.1f - (.1f * skill));
        }
    }
}
