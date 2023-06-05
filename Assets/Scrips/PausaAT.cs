using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaAT : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject Menupausa;
    public void Pausa(){
        Time.timeScale =0f;
        botonPausa.SetActive(false);
        Menupausa.SetActive(true);
    }
    public void Reanudar(){
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        Menupausa.SetActive(false);
    }

    public void Reiniciar(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir(){
        Debug.Log("Cerrando");
        Application.Quit();
    }
}
