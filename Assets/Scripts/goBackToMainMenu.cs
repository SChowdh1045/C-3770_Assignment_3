using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class goBackToMainMenu : MonoBehaviour
{
    public void goBackToMainMenuFunc()
    {
        SceneManager.LoadScene(0);
    }
}
