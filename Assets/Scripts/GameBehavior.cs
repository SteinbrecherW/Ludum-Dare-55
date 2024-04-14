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
        PreGame,
        PreTransition,
        Running,
        Focused,
        PostTransition,
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

                case GameState.PreGame:

                    _startMenu.SetActive(false);

                    _clipboard.SetActive(true);

                    ClipboardNameText.text = DefendantBehavior.Instance.Name;
                    AgeText.text = "Age: " + DefendantBehavior.Instance.Age;
                    ColorText.text = "Fav. Color: " + DefendantBehavior.Instance.Color;
                    CandyText.text = "Fav. Candy: " + DefendantBehavior.Instance.Candy;
                    StarSignText.text = "Star Sign: " + DefendantBehavior.Instance.StarSign;
                    SocialMediaText.text = "Fav. Social Media: " + DefendantBehavior.Instance.SocialMedia;
                    TVText.text = "Fav. TV Show: " + DefendantBehavior.Instance.TVShow;
                    PoliticsText.text = "Politics: " + DefendantBehavior.Instance.Politics;

                    break;

                case GameState.PreTransition:

                    _as.Stop();
                    _as.pitch = 1;
                    _as.time = 0;
                    _as.PlayOneShot(_transition);
                    CutieBehavior.Instance.InstantiateJurors();

                    NameText.text = "Judge";
                    DialogueText.text = "SUMMON THE JURY!";
                    _dialogueBox.SetActive(true);

                    if (_questionUI.activeSelf == true)
                        _questionUI.SetActive(false);

                    break;

                case GameState.Running:

                    if (_startMenu.activeSelf == true)
                        _startMenu.SetActive(false);

                    if (_pauseMenu.activeSelf == true)
                        _pauseMenu.SetActive(false);

                    if (_dialogueBox.activeSelf == true)
                        _dialogueBox.SetActive(false);

                    if (_clipboard.activeSelf == true)
                        _clipboard.SetActive(false);

                    if (_newspaper.activeSelf == true)
                        _newspaper.SetActive(false);

                    if(!CutieBehavior.Instance.OpinionsPopulated)
                        CutieBehavior.Instance.PopulateJurorOpinions();

                    if (_as.clip != _gameLoop)
                    {
                        _as.Stop();
                        _as.clip = _gameLoop;
                        _as.Play();
                        _as.loop = true;
                    }

                    break;

                case GameState.Focused:

                    _dialogueBox.SetActive(true);

                    if (_questionUI.activeSelf == false)
                        _questionUI.SetActive(true);

                    break;

                case GameState.PostTransition:

                    _as.Stop();
                    _as.loop = true;
                    _as.pitch = -1f;
                    _as.time = 4f;
                    _as.clip = _transition;
                    _as.Play();
                    CutieBehavior.Instance.RemoveJurors();

                    NameText.text = "Judge";
                    DialogueText.text = "JURY DISMISSED!";
                    _dialogueBox.SetActive(true);

                    if (_questionUI.activeSelf == true)
                        _questionUI.SetActive(false);

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
    [SerializeField] GameObject _newspaper;
    [SerializeField] GameObject _clipboard;
    [SerializeField] GameObject _questionUI;

    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;

    public TextMeshProUGUI HeadlineText;
    public TextMeshProUGUI ArticleText;

    public TextMeshProUGUI ClipboardNameText;
    public TextMeshProUGUI AgeText;
    public TextMeshProUGUI ColorText;
    public TextMeshProUGUI CandyText;
    public TextMeshProUGUI StarSignText;
    public TextMeshProUGUI SocialMediaText;
    public TextMeshProUGUI TVText;
    public TextMeshProUGUI PoliticsText;

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
                    CurrentState = GameState.PreGame;

                break;

            case GameState.PreGame:

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_clipboard.activeSelf == true)
                    {
                        _clipboard.SetActive(false);
                        _newspaper.SetActive(true);

                        HeadlineText.text = DefendantBehavior.Instance.Crime;
                        ArticleText.text = DefendantBehavior.Instance.Article;
                    }
                    else
                    {
                        _newspaper.SetActive(false);
                        CurrentState = GameState.PreTransition;
                    }
                }
                break;

            case GameState.PreTransition:
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
