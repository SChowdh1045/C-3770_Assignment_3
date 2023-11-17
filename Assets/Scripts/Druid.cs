using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Druid : MonoBehaviour
{
    public float druidHealth = 1250f;
    private int damageFromBoss;

    // Reference to the GameManager script
    private GameManager gm;
    [SerializeField] private TextMeshProUGUI info;
    
    private float totalDamageDone;

    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        damageFromBoss = Random.Range(5, 20);
        gm.boss2druid = damageFromBoss;

        if (!gm.paused)
        {
            if (druidHealth <= 0f)
            {
                Debug.Log("Druid");
                Time.timeScale = 0;
                gm.paused = true;
                Destroy(gameObject);
                gm.GoBackToMainMenuFunc();
            }
            else
            {
                druidHealth -= damageFromBoss;
            }

            totalDamageDone += gm.druid2boss;
            info.text = "Druid\r\nHealth: " + druidHealth + "\r\nDamage Done: " + (int)totalDamageDone + "";

        }
    }
}
