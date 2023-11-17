using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    public float tankHealth = 3000f;
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
        damageFromBoss = Random.Range(40, 50);
        
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            gm.boss2tank = damageFromBoss + (int)(gm.TotalDamageDoneByBoss() / 100);
        }
        else
        {
            gm.boss2tank = damageFromBoss;

        }

        if (!gm.paused)
        {
            if (tankHealth <= 0f)
            {
                Debug.Log("Tank");
                Time.timeScale = 0;
                gm.paused = true;
                Destroy(gameObject);
                gm.GoBackToMainMenuFunc();
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Level 3")
                {
                    tankHealth -= (damageFromBoss + (int)(gm.TotalDamageDoneByBoss() / 100)); // EXTRA DAMAGE
                }
                else
                {
                    tankHealth -= damageFromBoss;
                }
            }

            totalDamageDone += gm.tank2boss;
            info.text = "Tank\r\nHealth: " + tankHealth + "\r\nDamage Done: " + (int)totalDamageDone + "";

        }
    }
}
