using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurorBehavior : MonoBehaviour
{
    bool _highlighted = false;

    Vector3 _highlightedCameraPosition;

    public Material JurorMaterial;

    public CutieData JurorData;

    [SerializeField] Animator _anim;

    public int NameOpinion = 0;
    public int AgeOpinion = 0;
    public int ColorOpinion = 0;
    public int CandyOpinion = 0;
    public int StarSignOpinion = 0;
    public int SocialMediaOpinion = 0;
    public int TVOpinion = 0;
    public int PoliticsOpinion = 0;

    IEnumerator _disappearCoroutine;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.Play("Base Layer.MakeVisible", 0, 0);

        _highlightedCameraPosition =
            new Vector3(
                    transform.position.x,
                    transform.position.y - 0.5f,
                    transform.position.z - 5
            )
        ;

        _disappearCoroutine = Disappear();
    }

    void Update()
    {
        if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused)
        {
            if (_highlighted && Camera.main.transform.position != _highlightedCameraPosition)
            {
                CutieBehavior.Instance.HighlightedJuror = null;
                _highlighted = false;
            }
        }
    }

    public void MakeDisappear()
    {
        StartCoroutine(_disappearCoroutine);
    }

    private void OnMouseDown()
    {
        if ((GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running ||
            GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused) &&
            CutieBehavior.Instance.HighlightedJuror == null)
        {
            if (!_highlighted)
            {
                Camera.main.transform.position = _highlightedCameraPosition;

                _highlighted = true;

                GameBehavior.Instance.NameText.text = JurorData.Name;
                GameBehavior.Instance.DialogueText.text = JurorData.Introduction;

                CutieBehavior.Instance.HighlightedJuror = this;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Focused;
            }
            else
            {
                Camera.main.transform.position = GameBehavior.Instance.MainCameraPosition;

                _highlighted = false;

                CutieBehavior.Instance.HighlightedJuror = null;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;
            }
        }
    }

    IEnumerator Disappear()
    {
        _anim = GetComponent<Animator>();
        _anim.Play("Base Layer.MakeDisappear", 0, 0);

        yield return new WaitForSeconds(0.66f);

        Destroy(this);
    }
}
