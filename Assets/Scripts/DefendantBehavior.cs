using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefendantBehavior : MonoBehaviour
{
    [HideInInspector] public static DefendantBehavior Instance;

    [HideInInspector] public string Crime;
    [HideInInspector] public string Article;

    [HideInInspector] public string Name;
    [HideInInspector] public string Age;
    [HideInInspector] public string Color;
    [HideInInspector] public string Candy;
    [HideInInspector] public string StarSign;
    [HideInInspector] public string SocialMedia;
    [HideInInspector] public string TVShow;
    [HideInInspector] public string Politics;

    [SerializeField] GameObject _questionMenu;
    [SerializeField] TMP_Dropdown _topDrop;
    [SerializeField] TMP_Dropdown _bottomDrop;

    [SerializeField] GameObject _dialogueBox;

    int _topDropValueHold = -1;

    [SerializeField] List<TMP_Dropdown.OptionData> _nameOptions;
    [SerializeField] List<TMP_Dropdown.OptionData> _ageOptions;
    [SerializeField] List<TMP_Dropdown.OptionData> _colorOptions;
    [SerializeField] List<TMP_Dropdown.OptionData> _candyOptions;
    [SerializeField] List<TMP_Dropdown.OptionData> _starSignOptions;
    [SerializeField] List<TMP_Dropdown.OptionData> _socialMediaOptions;
    [SerializeField] List<TMP_Dropdown.OptionData> _tvShowOptions;
    [SerializeField] List<TMP_Dropdown.OptionData> _politicalOptions;

    public List<Vector2> AskedQuestions = new List<Vector2>();

    public bool IsQuestioning = false;

    public int CrimeIndex;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        CrimeIndex = Random.Range(0, DefendantData.Instance.Crimes.Length);
        Crime = DefendantData.Instance.Crimes[CrimeIndex];
        Article = DefendantData.Instance.Articles[CrimeIndex];

        Name = DefendantData.Instance.FirstNames[Random.Range(0, DefendantData.Instance.FirstNames.Length)] + " " +
            DefendantData.Instance.LastNames[Random.Range(0, DefendantData.Instance.LastNames.Length)];

        Age = DefendantData.Instance.Ages[Random.Range(0, DefendantData.Instance.Ages.Length)];

        Color = DefendantData.Instance.FavoriteColors[Random.Range(0, DefendantData.Instance.FavoriteColors.Length)];

        Candy = DefendantData.Instance.FavoriteCandies[Random.Range(0, DefendantData.Instance.FavoriteCandies.Length)];

        StarSign = DefendantData.Instance.StarSigns[Random.Range(0, DefendantData.Instance.StarSigns.Length)];

        SocialMedia = DefendantData.Instance.SocialMedias[Random.Range(0, DefendantData.Instance.SocialMedias.Length)];

        TVShow = DefendantData.Instance.TVShows[Random.Range(0, DefendantData.Instance.TVShows.Length)];

        Politics = DefendantData.Instance.Politics[Random.Range(0, DefendantData.Instance.Politics.Length)];

        for (int i = 0; i < 9; i++)
        {
            _nameOptions.Add(new TMP_Dropdown.OptionData(
                DefendantData.Instance.FirstNames[Random.Range(0, DefendantData.Instance.FirstNames.Length)] + " " +
                DefendantData.Instance.LastNames[Random.Range(0, DefendantData.Instance.LastNames.Length)])
            );
        }

        _nameOptions.Insert(Random.Range(0, 10), new TMP_Dropdown.OptionData(Name));
    }

    void Update()
    {
        if (IsQuestioning && _topDrop.value != _topDropValueHold)
        {
            _topDropValueHold = _topDrop.value;
            switch (_topDrop.value)
            {
                case 0:
                    _bottomDrop.options = _nameOptions;
                    break;

                case 1:
                    _bottomDrop.options = _ageOptions;
                    break;

                case 2:
                    _bottomDrop.options = _colorOptions;
                    break;

                case 3:
                    _bottomDrop.options = _candyOptions;
                    break;

                case 4:
                    _bottomDrop.options = _starSignOptions;
                    break;

                case 5:
                    _bottomDrop.options = _socialMediaOptions;
                    break;

                case 6:
                    _bottomDrop.options = _tvShowOptions;
                    break;

                case 7:
                    _bottomDrop.options = _politicalOptions;
                    break;
            }
        }
    }

    public void StartQuestioning()
    {
        if (CutieBehavior.Instance.HighlightedJuror.RemainingQuestions > 0)
        {
            IsQuestioning = true;
            _dialogueBox.SetActive(false);
            _questionMenu.SetActive(true);
        }
        else
        {
            CutieBehavior.Instance.AS.pitch = 1;
            CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.JudgeHeyClip);

            GameBehavior.Instance.NameText.text = "Judge";
            GameBehavior.Instance.DialogueText.text = "You've asked them enough questions!";
        }
    }

    public void OnSubmitQuestion()
    {
        Vector2 question = new Vector2(_topDrop.value, _bottomDrop.value);

        int count = 0;
        foreach(Vector2 v in AskedQuestions)
        {
            if (v == question)
                count++;
        }

        if(count >= 2)
        {
            CutieBehavior.Instance.AS.pitch = 1;
            CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.JudgeHeyClip);

            GameBehavior.Instance.NameText.text = "Judge";
            GameBehavior.Instance.DialogueText.text = "You've asked that question enough!";
        }
        else
        {
            AskedQuestions.Add(question);

            bool correct = false;
            switch (_topDrop.value)
            {
                case 0:
                    correct = _nameOptions[_bottomDrop.value].text == Name;
                    break;

                case 1:
                    correct = _ageOptions[_bottomDrop.value].text == Age;
                    break;

                case 2:
                    correct = _colorOptions[_bottomDrop.value].text == Color;
                    break;

                case 3:
                    correct = _candyOptions[_bottomDrop.value].text == Candy;
                    break;

                case 4:
                    correct = _starSignOptions[_bottomDrop.value].text == StarSign;
                    break;

                case 5:
                    correct = _socialMediaOptions[_bottomDrop.value].text == SocialMedia;
                    break;

                case 6:
                    correct = _tvShowOptions[_bottomDrop.value].text == TVShow;
                    break;

                case 7:
                    correct = _politicalOptions[_bottomDrop.value].text == Politics;
                    break;
            }

            CutieBehavior.Instance.HighlightedJuror.AnswerQuestion(correct, _topDrop.value);

        }

        _questionMenu.SetActive(false);
        _dialogueBox.SetActive(true);

        IsQuestioning = false;
    }
}
