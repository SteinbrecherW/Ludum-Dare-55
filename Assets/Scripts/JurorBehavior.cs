using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurorBehavior : MonoBehaviour
{
    Vector3 _highlightedCameraPosition;

    public Material JurorMaterial;

    public CutieData JurorData;

    [SerializeField] Animator _anim;

    public int RemainingQuestions = 3;

    public int OverallScore = 0;

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
        MakeAppear();

        _highlightedCameraPosition =
            new Vector3(
                    transform.position.x,
                    transform.position.y - 0.5f,
                    transform.position.z - 5
            )
        ;

        _disappearCoroutine = Disappear();
    }

    public void MakeAppear()
    {
        _anim.Play("Base Layer.MakeVisible", 0, 0);
    }

    public void MakeDisappear()
    {
        CutieBehavior.Instance.HighlightedJuror = null;

        StartCoroutine(_disappearCoroutine);
    }

    private void OnMouseDown()
    {
        if (!DefendantBehavior.Instance.IsQuestioning)
        {
            if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Running &&
                CutieBehavior.Instance.HighlightedJuror == null)
            {
                Camera.main.transform.position = _highlightedCameraPosition;

                GameBehavior.Instance.NameText.text = JurorData.Name;
                GameBehavior.Instance.DialogueText.text = JurorData.Introduction;

                CutieBehavior.Instance.HighlightedJuror = this;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Focused;
            }
            else if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused &&
                    CutieBehavior.Instance.HighlightedJuror == this)
            {
                Camera.main.transform.position = GameBehavior.Instance.MainCameraPosition;

                CutieBehavior.Instance.HighlightedJuror = null;

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;
            }
        }
    }

    public void AnswerQuestion(bool correct, int categoryIndex)
    {
        switch (categoryIndex)
        {
            case 0:
                if (correct)
                {
                    if(NameOpinion < 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionNegative;

                    else if (NameOpinion == 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionNeutral;

                    else
                        GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionPositive;
                }
                else
                    GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionNeutral;

                break;

            case 1:
                if (correct)
                {
                    if (AgeOpinion < 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionNegative;

                    else if (AgeOpinion == 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionNeutral;

                    else
                        GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionPositive;
                }
                else
                    GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionNeutral;

                break;

            case 2:
                if (correct)
                {
                    if (ColorOpinion < 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionNegative;

                    else if (ColorOpinion == 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionNeutral;

                    else
                        GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionPositive;
                }
                else
                    GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionNeutral;

                break;

            case 3:
                if (correct)
                {
                    if (CandyOpinion < 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionNegative;

                    else if (CandyOpinion == 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionNeutral;

                    else
                        GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionPositive;
                }
                else
                    GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionNeutral;

                break;

            case 4:
                if (correct)
                {
                    if (StarSignOpinion < 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionNegative;

                    else if (StarSignOpinion == 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionNeutral;

                    else
                        GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionPositive;
                }
                else
                    GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionNeutral;

                break;

            case 6:
                if (correct)
                {
                    if (TVOpinion < 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionNegative;

                    else if (TVOpinion == 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionNeutral;

                    else
                        GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionPositive;
                }
                else
                    GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionNeutral;

                break;

            case 7:
                if (correct)
                {
                    if (PoliticsOpinion < 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionNegative;

                    else if (PoliticsOpinion == 0)
                        GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionNeutral;

                    else
                        GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionPositive;
                }
                else
                    GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionNeutral;

                break;
        }

        RemainingQuestions--;
    }

    IEnumerator Disappear()
    {
        _anim = GetComponent<Animator>();
        _anim.Play("Base Layer.MakeDisappear", 0, 0);
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(0.66f);
    }
}
