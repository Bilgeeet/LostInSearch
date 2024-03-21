using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
        
        public enum BasicSoundTypes {General , Memory , Negative , Positive};
        public enum MainSoundTypes {MainBgMusic , Walking , Trigger};
        public enum UISoundTypes {Click};
        
        [Header("Basic Sounds")]
        public AudioSource generalSound;
        public AudioSource memorySound;
        public AudioSource crashNegativeWordSound;
        public AudioSource crashPositiveWordSound;
        
        [Header("Main Sounds")]
        public AudioSource bgSound;
        public AudioSource walkingSound;
        public AudioSource triggerSound;
        
        [Header("UI")]
        public AudioSource clickSound;

        [Header("Scene Check")]
        public string sceneCheck = "normal";
    
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        // Start is called before the first frame update
        void Start()
        {
           OnSceneChanged();
        }

        public void OnSceneChanged()
        {
            if (sceneCheck == "memory")
            {
                memorySound.Play();
                memorySound.volume = 0.02f;
                bgSound.Stop();
            }
            else if (sceneCheck == "ui")
            {
                
            }
            else
            {
                memorySound.Stop();
                bgSound.Play();
                bgSound.volume = 0.02f;
            }
        }

        public void PlayMainMusic(MainSoundTypes currentMusic)
        {
            switch (currentMusic)
            {
                case MainSoundTypes.MainBgMusic:
                    bgSound.Play();
                    bgSound.volume = 0.1f;
                    break;
                case MainSoundTypes.Walking:
                    walkingSound.Play();
                    break;
                case MainSoundTypes.Trigger:
                    triggerSound.Play();
                    break;
            }
        }
    
        public void PlayBasicSound(BasicSoundTypes currentBasicSound)
        {
            switch (currentBasicSound)
            {
                case BasicSoundTypes.General:
                    generalSound.Play();
                    break;
                case BasicSoundTypes.Memory:
                    memorySound.Play();
                    break;
                case BasicSoundTypes.Negative:
                    crashNegativeWordSound.Play();
                    break;
                case BasicSoundTypes.Positive:
                    crashPositiveWordSound.Play();
                    break;
            }
        }
        
        public void PlayMainSound(UISoundTypes currentUISound)
        {
            switch (currentUISound)
            {
                case UISoundTypes.Click:
                    clickSound.Play();
                    break;
            }
        }
        
        public void StopMainSound(UISoundTypes currentUISound)
        {
            switch (currentUISound)
            {
                case UISoundTypes.Click:
                    clickSound.Stop();
                    break;
                
            }
        }
        
}
