using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void EnterGame()
    {
        SceneManager.LoadScene(2);
    }
}
