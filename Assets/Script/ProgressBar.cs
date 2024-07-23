using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Scrollbar scrollbar;
    private readonly float maxValue = 5.25f;
    private float targetTime = 0.0f;

    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    void Update()
    {
        StartCoroutine(UpdateProgressBar());
    }

    private IEnumerator UpdateProgressBar()
    {

        if (targetTime <= maxValue)
        {
            scrollbar.value = targetTime;
            targetTime += Time.deltaTime;
            yield return null;
        }
        else if (targetTime >= maxValue)
        {
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(GameScene.MainMenu);
        Destroy(scrollbar);
    }
}
