using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutieBehavior : MonoBehaviour
{
    public static CutieBehavior Instance;

    public bool IsInstantiated = false;

    public bool IsRoundOne = true;

    public List<GameObject> Cuties;
    List<JurorBehavior> _currentCuties;

    MeshRenderer[] _cutieMeshes;

    public Transform[] JurorSeats;

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
        _cutieMeshes = new MeshRenderer[8];

        InstantCuties = InstantiateCuties();
    }

    //void Update()
    //{
    //    if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running)
    //    {

    //    }
    //}

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

        for (int i = 8; i > 0; i--)
        {
            int rng = Random.Range(0, i);
            _currentCuties[i - 1].NameOpinion = _nameOpinions[rng];
            _nameOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].AgeOpinion = _ageOpinions[rng];
            _ageOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].ColorOpinion = _colorOpinions[rng];
            _colorOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].CandyOpinion = _candyOpinions[rng];
            _candyOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].StarSignOpinion = _signOpinions[rng];
            _signOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].SocialMediaOpinion = _socialMediaOpinions[rng];
            _socialMediaOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].TVOpinion = _tvOpinions[rng];
            _tvOpinions.RemoveAt(rng);

            rng = Random.Range(0, i);
            _currentCuties[i - 1].PoliticsOpinion = _politicalOpinions[rng];
            _politicalOpinions.RemoveAt(rng);
        }
    }

    public void InstantiateJurors()
    {
        IsInstantiated = true;

        StartCoroutine(InstantCuties);
    }

    IEnumerator InstantiateCuties()
    {
        for (int i = 0; i < 8; i++)
        {
            int rng = Random.Range(0, Cuties.Count);

            _currentCuties.Add(Instantiate(
                Cuties[rng],
                JurorSeats[i]
            ).GetComponent<JurorBehavior>());

            _cutieMeshes[i] = _currentCuties[i].GetComponent<MeshRenderer>();
            _cutieMeshes[i].material.color = new Color(0, 0, 0, 0);

            Cuties.RemoveAt(rng);

            yield return new WaitForSeconds(0.66f);
        }

        GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;
    }
}
