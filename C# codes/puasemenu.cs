using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puasemenu : MonoBehaviour {

    public GameObject Puasemenu;
    public bool puase = false;
    public player playe;
    void Start()
    {
        Puasemenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Puase"))
        {
            puase = !puase;
        }
        if (puase)
        {
            Puasemenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (!puase)
        {
            Puasemenu.SetActive(false);
            Time.timeScale = 1;
        }

    }
    public void Resume()
    {
        puase = false;
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Mainmenu()
    {
        Application.LoadLevel(0);
    }
}
