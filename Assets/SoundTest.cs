using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    
    [Button]
    public void PlayOneShot()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
