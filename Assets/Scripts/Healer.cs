using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healer : MonoBehaviour
{
    public float healerHealth = 900f;
    public int mana = 1000;
    private int damageFromBoss;

    // Reference to the GameManager script
    private GameManager gm;
    [SerializeField] private TextMeshProUGUI info;

    [SerializeField] private Rogue r;
    [SerializeField] private Mage m;
    [SerializeField] private Druid d;
    [SerializeField] private Tank t;

    void Start()
    {
        gm = GameManager.Instance;

        r = GetComponent<Rogue>();
        m = GetComponent<Mage>();
        d = GetComponent<Druid>();
        t = GetComponent<Tank>();

    }

    // Update is called once per frame
    void Update()
    {
        damageFromBoss = Random.Range(5, 20);
        gm.boss2healer = damageFromBoss;

        float activateHeal = Random.Range(0f, 4f);

        if (!gm.paused)
        {
            if (healerHealth <= 0f)
            {
                Debug.Log("Healer");
                Time.timeScale = 0;
                gm.paused = true;
                Destroy(gameObject);
                gm.GoBackToMainMenuFunc();
            }
            else
            {
                healerHealth -= damageFromBoss;
            }


            if(activateHeal < 2f)
            {
                healerHealth += 15;
            }
            else
            {
                float pickA_DD = Random.Range(1f, 3f);
                
                if(pickA_DD <= 1f && r != null)
                {
                    r.rogueHealth += 15;
                }
                else if(pickA_DD > 1 && pickA_DD <= 2f && m != null)
                {
                    m.mageHealth += 15;
                }
                else {
                    if(d != null)
                    {
                        d.druidHealth += 15;
                    }
                }
            }

            mana -= 5; // for DD 'small heal'

            if(t != null)
            {
                t.tankHealth += 25;
                mana -= 10; // for tank 'big heal'

                if (SceneManager.GetActiveScene().name == "Level 2" && t.tankHealth <= 1500)
                {
                    Debug.Log("im in L2 saving the tank");
                    float smallOrBigHeal = Random.Range(0f, 1f) <= 0.5f ? 15 : 25;
                    t.tankHealth += smallOrBigHeal;
                }
            }

            mana += 3; //regen mana

            info.text = "Healer\r\nHealth: " + healerHealth + "\r\nMana: " + mana + "";

        }
    }
}
