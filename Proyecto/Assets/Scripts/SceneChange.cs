using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public GameObject menuDePausa;
    public Animator playerAnimator;
    private bool menuOn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuOn = !menuOn;
        }

        if(menuOn == true)
        {
            menuActivado();
        }
        else
        {
            menuDesactivado();
        }
    }

    public void Play()
    {
        menuDesactivado();
        menuOn = false;
    }

    public void volverAlInicio()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Inicio");
    }

    private void menuActivado()
    {
        menuDePausa.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        playerAnimator.SetFloat("Horizontal", 0);
        playerAnimator.SetFloat("Vertical", 0);
        playerAnimator.SetFloat("Velocidad", 0);
        playerAnimator.SetInteger("Direccion", 0);
    }

    private void menuDesactivado()
    {
        menuDePausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
