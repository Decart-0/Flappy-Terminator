using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private InputService _inputService;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private BulletPoolEnemy _bulletPoolEnemy;
    [SerializeField] private BulletPoolPlayer _bulletPoolPlayer;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private SpawnerEnemy _spawnerEnemy;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _inputService.enabled = false;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
        _spawnerEnemy.StartGenerator();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _inputService.enabled = true;
        _bird.Reset();
        _bulletPoolEnemy.Reset();
        _enemyPool.Reset();
        _bulletPoolPlayer.Reset();
    }
}