using Manager;
using TMPro;
using UnityEngine;

namespace Script
{
    abstract class CarControllerConstant
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Score = "Score: ";
        public const string Life = "Life: ";
    }

    public class CarController : MonoBehaviour
    {

        // Components
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI lifeText;
        private AudioSource _audioSource;
        [SerializeField]
        private CameraController cameraController = null;
        [SerializeField] private GameObject popover;
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private GameObject panel;

        private float _xInput;
        private float _zInput;
        private float _movingSpeed = 35f;
        private int _collectedCoinsCount = 0;
        private int _currentLive;
        private bool _isLevelFinished = false;

        void Awake()
        {
            _currentLive = LifeManager.CurrentLive;
            lifeText.text = $"{CarControllerConstant.Life + _currentLive}";

            _audioSource = GetComponent<AudioSource>();
            if (cameraController == null)
            {
                this.cameraController = this.gameObject.GetComponent<CameraController>();
            }
            particle.Pause();
        }

        void Update()
        {
            if (_isLevelFinished) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movingSpeed = _movingSpeed + 15f;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _movingSpeed = _movingSpeed - 15f;
            }

            _xInput = Input.GetAxis(CarControllerConstant.Horizontal) * Time.deltaTime * _movingSpeed;
            _zInput = Input.GetAxis(CarControllerConstant.Vertical) * Time.deltaTime * _movingSpeed;

        }

        void FixedUpdate()
        {
            if (_isLevelFinished) return;
            MoveCar();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Boundary.ToString()))
            {
                UpdateLife();
                RestartTheLevel();
            }

            if (other.CompareTag(Tags.Finish.ToString()))
            {
                _isLevelFinished = true;
                panel.SetActive(true);
            }

            if (other.gameObject.CompareTag(Tags.Enemy.ToString()))
            {
                DecreaseScore();
                ParticleSystem newParticle = Instantiate(particle, other.gameObject.transform.position, other.gameObject.transform.rotation);
                particle.Play();
                Destroy(other.gameObject);
                Destroy(newParticle, 2f);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(Tags.Coin.ToString()))
            {
                PlayMusic();
                IncreaseScore();
                Destroy(other.gameObject);
                cameraController.GoTo(transform.position);
            }
        }

        private void IncreaseScore()
        {
            _collectedCoinsCount++;
            scoreText.text = $"{CarControllerConstant.Score + _collectedCoinsCount}";
        }

        private void DecreaseScore()
        {
            _collectedCoinsCount--;
            scoreText.text = $"{CarControllerConstant.Score + _collectedCoinsCount}";
        }

        private void UpdateLife()
        {
            LifeManager.DecrementLife();
            lifeText.text = $"{CarControllerConstant.Life + _currentLive}";
        }

        private void MoveCar()
        {
            transform.Translate(_xInput, 0f, _zInput);
        }

        public void RestartTheLevel()
        {
            SceneManager.LoadScene(GameScene.Level1);
        }

        public void LoadLevel2()
        {
            SceneManager.LoadScene(GameScene.Level2);
        }

        private void PlayMusic()
        {
            if (MusicManager.ShouldPlayMusic())
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Pause();
            }
        }
    }
}