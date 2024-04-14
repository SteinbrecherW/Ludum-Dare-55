using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public enum GameState
    {
        Start,
        Rules,
        PreGame,
        PreTransition,
        Running,
        Focused,
        PostTransition,
        FinalTransition,
        Paused,
        GameOver,
        Finale
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

                    _splashMenu.SetActive(true);

                    break;

                case GameState.Rules:

                    _splashMenu.SetActive(false);

                    if (_startMenu.activeSelf != true)
                        _startMenu.SetActive(true);

                    RulesTitleText.text = "Rules (1/8)";

                    RulesText.text = _rulesPages[0];
                    RulesImage.sprite = _rulesImages[0];

                    break;

                case GameState.PreGame:

                    _startMenu.SetActive(false);

                    _clipboard.SetActive(true);

                    ClipboardNameText.text = DefendantBehavior.Instance.Name;
                    AgeText.text = "Age Range: " + DefendantBehavior.Instance.Age;
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

                    if (_dialogueBox.activeSelf == false)
                        _dialogueBox.SetActive(true);

                    if (_clipboard.activeSelf == true)
                        _clipboard.SetActive(false);

                    if (_newspaper.activeSelf == true)
                        _newspaper.SetActive(false);

                    if (_questionUI.activeSelf == true)
                        _questionUI.SetActive(false);

                    NameText.text = "";
                    DialogueText.text = "Click on a juror to speak with them";

                    if (!CutieBehavior.Instance.OpinionsPopulated)
                        CutieBehavior.Instance.PopulateJurorOpinions();

                    if (_as.clip != _gameLoop)
                    {
                        _as.clip = _gameLoop;
                        _as.Play();
                        _as.loop = true;
                    }

                    break;

                case GameState.Focused:

                    if (_dialogueBox.activeSelf == false)
                        _dialogueBox.SetActive(true);

                    if (_questionUI.activeSelf == false)
                        _questionUI.SetActive(true);

                    QuestionText.text = "Question (" + CutieBehavior.Instance.HighlightedJuror.RemainingQuestions + "/3)";

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

                case GameState.FinalTransition:
                    
                    Camera.main.transform.SetPositionAndRotation(
                        EndCameraPosition,
                        Quaternion.Euler(15, -16, 0)
                    );

                    _as.Stop();
                    _as.pitch = 1;
                    _as.time = 0;
                    _as.loop = false;
                    _as.PlayOneShot(_transition);
                    CutieBehavior.Instance.StartFinalJudgement();

                    NameText.text = "Judge";
                    DialogueText.text = "The jury is done deliberating...";
                    _dialogueBox.SetActive(true);

                    if (_questionUI.activeSelf == true)
                        _questionUI.SetActive(false);

                    break;

                case GameState.GameOver:

                    DialogueText.text = "What's your decision?";

                    CutieBehavior.Instance.AS.pitch = 1;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.JudgeOrderClip);

                    StartCoroutine(_finalCoroutine);

                    break;

                case GameState.Finale:

                    _as.loop = true;
                    _as.clip = _endLoop;
                    _as.Play();

                    NameText.text = "";

                    _gameOverMenu.SetActive(true);

                    break;
            }
            _currentState = value;
        }
    }

    [SerializeField] GameObject _splashMenu;
    [SerializeField] GameObject _startMenu;
    [SerializeField] string[] _rulesPages;
    [SerializeField] Sprite[] _rulesImages;

    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _dialogueBox;
    [SerializeField] GameObject _newspaper;
    [SerializeField] GameObject _clipboard;
    [SerializeField] GameObject _questionUI;
    [SerializeField] GameObject _gameOverMenu;

    int _rulePageIndex = 0;
    public TextMeshProUGUI RulesTitleText;
    public TextMeshProUGUI RulesText;
    public Image RulesImage;

    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI QuestionText;

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

    public TextMeshProUGUI GameOverText;

    public Vector3 MainCameraPosition;
    public Vector3 EndCameraPosition;

    //15, -16, 0

    IEnumerator _finalCoroutine;
    public int FinalSum;

    [SerializeField] AudioSource _as;
    [SerializeField] AudioClip _startLoop;
    [SerializeField] AudioClip _gameLoop;
    [SerializeField] AudioClip _endLoop;
    [SerializeField] AudioClip _transition;
    [SerializeField] AudioClip _swell;
    [SerializeField] AudioClip _win;
    [SerializeField] AudioClip _lose;

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
        _finalCoroutine = EndGame();
    }

    void Update()
    {
        switch (CurrentState)
        {
            case GameState.Start:

                if (Input.GetKeyDown(KeyCode.Return))
                    CurrentState = GameState.Rules;

                break;

            case GameState.Rules:

                if (Input.GetKeyDown(KeyCode.RightArrow) && _rulePageIndex < _rulesPages.Length - 1)
                {
                    _rulePageIndex++;
                    RulesTitleText.text = "Rules (" + (_rulePageIndex + 1) + "/8)";
                    RulesText.text = _rulesPages[_rulePageIndex];
                    RulesImage.sprite = _rulesImages[_rulePageIndex];
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow) && _rulePageIndex > 0)
                {
                    _rulePageIndex--;
                    RulesTitleText.text = "Rules (" + (_rulePageIndex + 1) + "/8)";
                    RulesText.text = _rulesPages[_rulePageIndex];
                    RulesImage.sprite = _rulesImages[_rulePageIndex];
                }

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

            case GameState.Finale:
                if (Input.GetKeyDown(KeyCode.R))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }

    IEnumerator EndGame()
    {
        _as.PlayOneShot(_swell);

        yield return new WaitForSeconds(4f);

        NameText.text = "Foreman";

        if (FinalSum > 0)
        {
            _as.PlayOneShot(_win);
            DialogueText.text = "Innocent!";
            GameOverText.text = "You Won!";
        }
        else if(FinalSum == 0)
        {
            _as.PlayOneShot(_lose);
            DialogueText.text = "Mistrial.";
            GameOverText.text = "It's a draw.";
        }
        else
        {
            _as.PlayOneShot(_lose);
            DialogueText.text = "Guilty!";
            GameOverText.text = "You Lost.";
        }

        yield return new WaitForSeconds(3f);
        CurrentState = GameState.Finale;
    }
}
