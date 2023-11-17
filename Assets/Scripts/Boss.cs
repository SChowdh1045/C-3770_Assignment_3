using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float bossHealth = 5000f;

    private int damageFromTank;
    private int damageFromRogue;
    private int damageFromMage;
    private int damageFromDruid;

    private int totalDamageFromAdventurers;

    // Reference to the GameManager script
    private GameManager gm;

    private float totalDamageDone;

    [SerializeField] private TextMeshProUGUI info;
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        damageFromTank = Random.Range(5, 10);
        gm.tank2boss = damageFromTank;

        damageFromRogue = Random.Range(15, 25);
        gm.rogue2boss = damageFromRogue;

        damageFromMage = Random.Range(5, 30);
        gm.mage2boss = damageFromMage;

        damageFromDruid = Random.Range(5, 15);
        gm.druid2boss = damageFromDruid;

        totalDamageFromAdventurers = damageFromTank + damageFromRogue + damageFromMage + damageFromDruid;

        if(!gm.paused)
        {
            if (bossHealth <= 0f)
            {
                Debug.Log("Boss");
                Time.timeScale = 0;
                gm.paused = true;
                Destroy(gameObject);
                gm.GoBackToMainMenuFunc();
            }
            else
            {
                bossHealth -= totalDamageFromAdventurers;
            }
            
            totalDamageDone += gm.TotalDamageDoneByBoss();
            info.text = "Boss\r\nHealth: " + bossHealth + "\r\nDamage Done: " + (int)totalDamageDone + "";
        }
    }
}
