using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound;
   
   public void PlaySounds (bool correct)
   {
    if(correct)
    {
        correctSound.Play();
    }
    else
    {
        wrongSound.Play();
    }
   }
}
