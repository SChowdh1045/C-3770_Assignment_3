using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public float mageHealth = 1000f;
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
        gm.boss2mage = damageFromBoss;

        if (!gm.paused)
        {
            if (mageHealth <= 0f)
            {
                Debug.Log("Mage");
                Time.timeScale = 0;
                gm.paused = true;
                Destroy(gameObject);
                gm.GoBackToMainMenuFunc();
            }
            else
            {
                mageHealth -= damageFromBoss;
            }

            totalDamageDone += gm.mage2boss;
            info.text = "Mage\r\nHealth: " + mageHealth + "\r\nDamage Done: " + (int)totalDamageDone + "";

        }
    }
}
