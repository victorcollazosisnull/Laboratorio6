using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [Header("Interfaz Menú")]
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    void Start()
    {
        menuPausa.SetActive(false);
        botonPausa.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
