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
    }

    void Update()
    {
        if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused)
        {
            if (_highlighted && Camera.main.transform.position != _highlightedCameraPosition)
                _highlighted = false;
        }
    }

    private void OnMouseDown()
    {
        if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running ||
            GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused)
        {
            if (!_highlighted)
            {
                Camera.main.transform.position = _highlightedCameraPosition;

                _highlighted = true;

                GameBehavior.Instance.NameText.text = JurorData.Name;
                GameBehavior.Instance.DialogueText.text = JurorData.Introduction;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Focused;
            }
            else
            {
                Camera.main.transform.position = GameBehavior.Instance.MainCameraPosition;

                _highlighted = false;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;
            }
        }
    }
}
