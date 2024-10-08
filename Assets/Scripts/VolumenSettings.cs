using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio", menuName = "Audio/volumenSettings")]
public class VolumenSettings : ScriptableObject
{
    [Header("Musica")]
    public AudioClip musicRojo;
    public AudioClip musicAzul;
    public AudioClip musicMorado;
    [Header("Sonidos")]
    public AudioClip walk;
    public AudioClip enter;
    public AudioClip goOut;
    [Header("Configuracion de audios")]
    public float masterVolumen;
    public float musicVolumen;
    public float sfxVolumen;
}
