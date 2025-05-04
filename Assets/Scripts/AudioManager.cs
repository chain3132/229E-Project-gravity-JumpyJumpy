using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("Audio Source")]
   [SerializeField] AudioSource musicsource;
   [SerializeField] AudioSource sfxsource;
   
   [Header("Audio Clips")]
   public AudioClip backgroundMusic;
   public AudioClip jump;
   public AudioClip chargejump;
   public AudioClip hit;
   public AudioClip pickup;
   public AudioClip unlock;

   private void Awake()
   {
      DontDestroyOnLoad(gameObject);
   }
}
