using System;
using Manager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.MusicSlider
{
    public class MusicSwitchButtonScript : MonoBehaviour
    { 
        [SerializeField] private Slider musicSlider;

        // When user click on Music slider UI component
        public void OnMusicSliderButtonClicked()
        {
            if (musicSlider.value != 0f)
            {
                musicSlider.value = 1f;
            }
            else
            {
                if (Mathf.Approximately(musicSlider.value, 1f))
                {
                    musicSlider.value = 0f;
                }
            }
            
            MusicManager.ChangeMusicMode(musicSlider.value != 0f);
        }
    }
}