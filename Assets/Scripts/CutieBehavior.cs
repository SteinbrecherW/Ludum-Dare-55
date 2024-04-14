using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutieBehavior : MonoBehaviour
{
    public static CutieBehavior Instance;

    public JurorBehavior HighlightedJuror;

    public bool IsInstantiated = false;
    public bool OpinionsPopulated = false;
    public bool IsRoundOne = true;

    int _disappearCount = 0;

    public List<GameObject> Cuties;
    List<JurorBehavior> _currentCuties;
    JurorBehavior[] _finalJurors = new JurorBehavior[12];

    public Transform[] JurorSeats;
    public Transform[] FinalSeats;

    [SerializeField] List<int> _opinionWeights;

    List<int> _nameOpinions = new List<int>();
    List<int> _ageOpinions = new List<int>();
    List<int> _colorOpinions = new List<int>();
    List<int> _candyOpinions = new List<int>();
    List<int> _signOpinions = new List<int>();
    List<int> _socialMediaOpinions = new List<int>();
    List<int> _tvOpinions = new List<int>();
    List<int> _politicalOpinions = new List<int>();

    IEnumerator InstantCuties;
    IEnumerator RemoveHighlighted;
    IEnumerator RemoveCuties;
    IEnumerator FinalJudge;

    public AudioSource AS;
    public AudioClip HelloClip;
    public AudioClip YesClip;
    public AudioClip MehClip;
    public AudioClip NoClip;
    public AudioClip GoodbyeClip;
    public AudioClip DisappearClip;
    public AudioClip JudgeHeyClip;
    public AudioClip JudgeOrderClip;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        _currentCuties = new List<JurorBehavior>();
        FinalJudge = FinalJudgement();
        RemoveHighlighted = RemoveHighlightedCutie();
        AS = GetComponent<AudioSource>();
    }

    public void PopulateJurorOpinions()
    {
        _nameOpinions.AddRange(_opinionWeights);
        _ageOpinions.AddRange(_opinionWeights);
        _colorOpinions.AddRange(_opinionWeights);
        _candyOpinions.AddRange(_opinionWeights);
        _signOpinions.AddRange(_opinionWeights);
        _socialMediaOpinions.AddRange(_opinionWeights);
        _tvOpinions.AddRange(_opinionWeights);
        _politicalOpinions.AddRange(_opinionWeights);

        int crimeIndex = DefendantBehavior.Instance.CrimeIndex;

        for (int i = 8; i > 0; i--)
        {
            int rng = Random.Range(0, i);
            _currentCuties[i - 1].NameOpinion = crimeIndex == 3 ? _nameOpinions[rng] * 3 : _nameOpinions[rng];
            _nameOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].AgeOpinion = crimeIndex == 2 ? _ageOpinions[rng] * 3 : _ageOpinions[rng];
            _ageOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].ColorOpinion = crimeIndex == 6 ? _colorOpinions[rng] * 3 : _colorOpinions[rng];
            _colorOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].CandyOpinion = crimeIndex == 0 ? _candyOpinions[rng] * 3 : _candyOpinions[rng];
            _candyOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].StarSignOpinion = crimeIndex == 5 ? _signOpinions[rng] * 3 : _signOpinions[rng];
            _signOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].SocialMediaOpinion = crimeIndex == 1 ? _socialMediaOpinions[rng] * 3 : _socialMediaOpinions[rng];
            _socialMediaOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].TVOpinion = crimeIndex == 4 ? _tvOpinions[rng] * 3 : _tvOpinions[rng];
            _tvOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].PoliticsOpinion = crimeIndex == 7 ? _politicalOpinions[rng] * 3 : _politicalOpinions[rng];
            _politicalOpinions.RemoveAt(rng);

            _currentCuties[i - 1].OverallScore =
                _currentCuties[i - 1].NameOpinion +
                _currentCuties[i - 1].AgeOpinion +
                _currentCuties[i - 1].ColorOpinion +
                _currentCuties[i - 1].CandyOpinion +
                _currentCuties[i - 1].StarSignOpinion +
                _currentCuties[i - 1].SocialMediaOpinion +
                _currentCuties[i - 1].TVOpinion +
                _currentCuties[i - 1].PoliticsOpinion;
        }

        OpinionsPopulated = true;
    }

    public void InstantiateJurors()
    {
        IsInstantiated = true;

        InstantCuties = InstantiateCuties();
        StartCoroutine(InstantCuties);
    }

    public void RemoveJurors()
    {
        IsInstantiated = false;

        RemoveCuties = RetireCuties();
        StartCoroutine(RemoveCuties);
    }

    public void MakeHighlightedJurorDisappear()
    {
        StartCoroutine(RemoveHighlighted);
    }

    public void StartFinalJudgement()
    {
        StartCoroutine(FinalJudge);
    }

    IEnumerator InstantiateCuties()
    {
        _disappearCount = 0;
        for (int i = 0; i < 8; i++)
        {
            int rng = Random.Range(0, Cuties.Count);

            _currentCuties.Add(Instantiate(
                Cuties[rng],
                JurorSeats[i]
            ).GetComponent<JurorBehavior>());

            AS.pitch = _currentCuties[i].JurorData.VoicePitch;
            AS.PlayOneShot(HelloClip);

            Cuties.RemoveAt(rng);

            yield return new WaitForSeconds(0.66f);
        }

        GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;
    }

    IEnumerator RemoveHighlightedCutie()
    {
        _currentCuties.Remove(HighlightedJuror);

        HighlightedJuror.MakeDisappear();

        yield return new WaitForSeconds(0.66f);

        Camera.main.transform.position = GameBehavior.Instance.MainCameraPosition;
        GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;

        _disappearCount++;
        if (_disappearCount >= 2)
            GameBehavior.Instance.CurrentState = GameBehavior.GameState.PostTransition;
    }

    IEnumerator RetireCuties()
    {
        if (IsRoundOne)
        {
            for (int i = 6; i > 0; i--)
            {
                _finalJurors[i - 1] = _currentCuties[i - 1];

                _currentCuties[i - 1].MakeDisappear();

                _currentCuties.RemoveAt(i - 1);

                yield return new WaitForSeconds(0.66f);
            }

            IsRoundOne = false;
            OpinionsPopulated = false;
            DefendantBehavior.Instance.AskedQuestions = new List<Vector2>();
            GameBehavior.Instance.CurrentState = GameBehavior.GameState.PreTransition;
        }
        else
        {
            for (int i = 12; i > 6; i--)
            {
                _finalJurors[i - 1] = _currentCuties[i - 7];

                _currentCuties[i - 7].MakeDisappear();

                _currentCuties.RemoveAt(i - 7);

                yield return new WaitForSeconds(0.66f);
            }

            GameBehavior.Instance.CurrentState = GameBehavior.GameState.FinalTransition;
        }
    }

    IEnumerator FinalJudgement()
    {
        for (int i = 0; i < 12; i++)
        {
            GameBehavior.Instance.FinalSum += _finalJurors[i].OverallScore;

            _finalJurors[i].transform.position = FinalSeats[i].position;
            _finalJurors[i].MakeAppear();

            yield return new WaitForSeconds(0.33f);
        }

        GameBehavior.Instance.CurrentState = GameBehavior.GameState.GameOver;
    }
}
