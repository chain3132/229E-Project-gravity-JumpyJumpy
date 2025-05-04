using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
   [Header("Audio Source")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource sfxSource;
   
   [Header("Audio Clips")]
   public AudioClip backGroundMusic;
   public AudioClip jump;
   public AudioClip hit;
   public AudioClip pickup;
   public AudioClip unlock;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
         return;
      }
      DontDestroyOnLoad(gameObject);
      PlayMusic(backGroundMusic);
   }

   private void Start()
   {
      PlayMusic(backGroundMusic);
   }

   public void PlaySFX(AudioClip clip)
   {
      sfxSource.clip = clip;
      sfxSource.Play();
   }
   public void PlayMusic(AudioClip clip)
   {
      musicSource.clip = clip;
      musicSource.Play();
   }
   
}
