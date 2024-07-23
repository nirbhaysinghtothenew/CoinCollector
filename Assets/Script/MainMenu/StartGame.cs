using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StartGame : MonoBehaviour
{
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(GameScene.Level1);
        audioData.Pause();
    }
}
