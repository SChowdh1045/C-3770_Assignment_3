using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    public float rogueHealth = 1500f;
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
        gm.boss2rogue = damageFromBoss;

        if (!gm.paused)
        {
            if (rogueHealth <= 0f)
            {
                Debug.Log("Rogue");
                Time.timeScale = 0;
                gm.paused = true;
                Destroy(gameObject);
                gm.GoBackToMainMenuFunc();
            }
            else
            {
                rogueHealth -= damageFromBoss;
            }

            totalDamageDone += gm.rogue2boss;
            info.text = "Rogue\r\nHealth: " + rogueHealth + "\r\nDamage Done: " + (int)totalDamageDone + "";

        }
    }
}
