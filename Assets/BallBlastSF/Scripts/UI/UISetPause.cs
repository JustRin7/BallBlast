using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//работа со сценой

public class UISetPause : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private CartInputControl cartInputControl;
    private bool isPaused = false;

    private void Start()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Update()
    {    
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        cartInputControl.enabled = true;
        Panel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        cartInputControl.enabled = false;
        Panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadLevel(int buildIndex)//включает лвл на старте
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void PauseButtom()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }
}






