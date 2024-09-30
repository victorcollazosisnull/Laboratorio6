using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed;
    private Vector2 movementInput;
    private Rigidbody _rigidbody;
    [Header("Sonidos")]
    public AudioSource walkAudioSource;
    public AudioSource musicAudioSource;
    public AudioSource enterAudioSource;
    public AudioSource exitAudioSource;

    public VolumenSettings volumenSettings;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void ReadDirection(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, movementInput.y, 0) * speed;
        _rigidbody.velocity = movement;
        if (movementInput != Vector2.zero)
        {
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.Play();
            }
        }
        else
        {
            walkAudioSource.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rojo") || other.CompareTag("Azul") || other.CompareTag("Morado"))
        {
            enterAudioSource.Play();

            if (other.CompareTag("Rojo") && musicAudioSource.clip != volumenSettings.musicRojo)
            {
                musicAudioSource.clip = volumenSettings.musicRojo;
                musicAudioSource.Play();
                musicAudioSource.loop = true;
            }
            else if (other.CompareTag("Azul") && musicAudioSource.clip != volumenSettings.musicAzul)
            {
                musicAudioSource.clip = volumenSettings.musicAzul;
                musicAudioSource.Play();
                musicAudioSource.loop = true;
            }
            else if (other.CompareTag("Morado") && musicAudioSource.clip != volumenSettings.musicMorado)
            {
                musicAudioSource.clip = volumenSettings.musicMorado;
                musicAudioSource.Play();
                musicAudioSource.loop = true;
            }

            if (!musicAudioSource.isPlaying)
            {
                musicAudioSource.Play();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        musicAudioSource.Stop();
        if (other.CompareTag("Rojo") || other.CompareTag("Azul") || other.CompareTag("Morado"))
        {
            musicAudioSource.Stop();
            exitAudioSource.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cuarto"))
        {
            SceneManager.LoadScene("nivel2");
        }
    }
}
