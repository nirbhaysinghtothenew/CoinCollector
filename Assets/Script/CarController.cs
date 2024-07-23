using System.Collections;
using System.Collections.Generic;
using Manager;
using Script;
using UnityEngine;
using TMPro;


class CarControllerConstant
{
    public static readonly string Horizontal = "Horizontal";
    public static readonly string Vertical = "Vertical";
    public static readonly string Score = "Score: ";
    public static readonly string Life = "Life: ";
}

public class CarController : MonoBehaviour
{

    // Components
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    private AudioSource audioSource;
    [SerializeField]
    private CameraController cameraController = null;
    
    private float xInput;
    private float zInput;
    private float movingSpeed = 30f;
    private int collectedCoinsCount = 0;
    private int currentLive;
    
    void Awake()
    {
        currentLive = LifeManager.CurrentLive;
        lifeText.text = $"{CarControllerConstant.Life + currentLive}";

        audioSource = GetComponent<AudioSource>();
        if (cameraController == null)
        {
            this.cameraController = this.gameObject.GetComponent<CameraController>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movingSpeed = movingSpeed + 15f;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movingSpeed = movingSpeed - 15f;
        }

        xInput = Input.GetAxis(CarControllerConstant.Horizontal) * Time.deltaTime * movingSpeed;
        zInput = Input.GetAxis(CarControllerConstant.Vertical) * Time.deltaTime * movingSpeed;

    }

    void FixedUpdate()
    {
        MoveCar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Boundary.ToString()))
        {
            UpdateLife();
            RestartTheLevel();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(Tags.Coin.ToString())) return;
        PlayMusic();
        UpdateScore();
        Destroy(other.gameObject);
        cameraController.GoTo(transform.position);
    }

    private void UpdateScore()
    {
        collectedCoinsCount++;
        scoreText.text = $"{CarControllerConstant.Score + collectedCoinsCount}";
    }

    private void UpdateLife()
    {
        LifeManager.DecrementLife();
        lifeText.text = $"{CarControllerConstant.Life + currentLive}";
    }

    private void MoveCar()
    {
        transform.Translate(xInput, 0f, zInput);
    }

    private void RestartTheLevel()
    {
        SceneManager.LoadScene(LifeManager.CurrentLive > 0 ? GameScene.Level1 : GameScene.MainMenu);
    }

    private void PlayMusic()
    {
        if (MusicManager.ShouldPlayMusic())
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
