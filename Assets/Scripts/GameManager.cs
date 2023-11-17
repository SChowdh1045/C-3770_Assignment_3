using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public bool paused = false;

    //Damage done from...
    public float tank2boss;
    public float rogue2boss;
    public float mage2boss;
    public float druid2boss;

    public float boss2tank;
    public float boss2rogue;
    public float boss2mage;
    public float boss2druid;
    public float boss2healer;


    [SerializeField] private Canvas goBackToMainMenu;
    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        goBackToMainMenu.GetComponent<Canvas>().enabled = false;
    }

    public float TotalDamageDoneByBoss()
    {
        return boss2tank + boss2rogue + boss2mage + boss2druid + boss2healer;
    }

    public void GoBackToMainMenuFunc()
    {
        goBackToMainMenu.GetComponent<Canvas>().enabled = true;
    }


}
