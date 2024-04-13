using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public enum GameState
    {
        Start,
        Running,
        Focused,
        Paused,
        GameOver
    }

    GameState _currentState;
    public GameState CurrentState
    {
        get => _currentState;
        set
        {
            switch (value)
            {
                case GameState.Start:

                    if (_startMenu.activeSelf != true)
                        _startMenu.SetActive(true);

                    break;

                case GameState.Running:

                    if (!CutieBehavior.Instance.IsInstantiated)
                        CutieBehavior.Instance.InstantiateJurors();

                    if (_startMenu.activeSelf == true)
                        _startMenu.SetActive(false);

                    if (_pauseMenu.activeSelf == true)
                        _pauseMenu.SetActive(false);

                    if (_dialogueBox.activeSelf == true)
                        _dialogueBox.SetActive(false);

                    if(_as.clip != _gameLoop)
                    {
                        _as.Stop();
                        _as.clip = _gameLoop;
                        _as.Play();
                    }

                    break;

                case GameState.Focused:

                    _dialogueBox.SetActive(true);
                    break;

                case GameState.Paused:

                    _pauseMenu.SetActive(true);

                    break;

                case GameState.GameOver:
                    break;
            }
            _currentState = value;
        }
    }

    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _dialogueBox;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;

    public Vector3 MainCameraPosition;

    [SerializeField] AudioSource _as;
    [SerializeField] AudioClip _startLoop;
    [SerializeField] AudioClip _gameLoop;
    [SerializeField] AudioClip _transition;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        CurrentState = GameState.Start;
        MainCameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        switch (CurrentState)
        {
            case GameState.Start:

                if (Input.GetKeyDown(KeyCode.Return))
                    CurrentState = GameState.Running;

                break;

            case GameState.Running:

                if (Input.GetKeyDown(KeyCode.Escape))
                    CurrentState = GameState.Paused;

                break;

            case GameState.Paused:

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if(_dialogueBox.activeSelf)
                        CurrentState = GameState.Focused;
                    else
                        CurrentState = GameState.Running;
                }

                break;

            case GameState.GameOver:
                break;
        }
    }
}
