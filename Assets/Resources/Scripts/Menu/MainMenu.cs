using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitMainMenu()
    {
        Application.Quit();
    }

    public void EnterCharacterSelect()
    {
        SceneManager.LoadScene(2);
    }
}

[RequireComponent(typeof(Health))]
public abstract class Death : MonoBehaviour
{
    protected Health health;
    public bool isDead = false;

    void Start()
    {
        health = gameObject.GetComponent<Health>();
        health.OnHealthZero += DeathAction;
    }

    public abstract void DeathAction();
}
