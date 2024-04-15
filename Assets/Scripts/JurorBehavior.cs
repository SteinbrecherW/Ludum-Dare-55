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
        _highlightedCameraPosition =
        new Vector3(
            transform.position.x,
            transform.position.y - 0.5f,
            transform.position.z - 5
        );

        _anim = GetComponent<Animator>();
        MakeAppear();
    }

    public void MakeAppear()
    {
        _anim.Play("Base Layer.MakeVisible", 0, 0);
    }

    public void MakeDisappear()
    {
        CutieBehavior.Instance.HighlightedJuror = null;

        _disappearCoroutine = Disappear();
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

                CutieBehavior.Instance.AS.pitch = JurorData.VoicePitch;
                CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.HelloClip);

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Focused;
            }
            else if (GameBehavior.Instance.CurrentState == GameBehavior.GameState.Focused &&
                    CutieBehavior.Instance.HighlightedJuror == this)
            {
                Camera.main.transform.position = GameBehavior.Instance.MainCameraPosition;

                CutieBehavior.Instance.HighlightedJuror = null;

                CutieBehavior.Instance.AS.pitch = JurorData.VoicePitch;
                CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.GoodbyeClip);

                GameBehavior.Instance.CurrentState = GameBehavior.GameState.Running;
            }
        }
    }

    public void AnswerQuestion(bool correct, int categoryIndex)
    {
        CutieBehavior.Instance.AS.pitch = JurorData.VoicePitch;
        switch (categoryIndex)
        {
            case 0:
                if (correct)
                {
                    if(NameOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }
                    else if (NameOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }

                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.NameOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;

            case 1:
                if (correct)
                {
                    if (AgeOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }
                    else if (AgeOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }
                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.AgeOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;

            case 2:
                if (correct)
                {
                    if (ColorOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }
                    else if (ColorOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }
                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.ColorOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;

            case 3:
                if (correct)
                {
                    if (CandyOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }
                    else if (CandyOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }

                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.CandyOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;

            case 4:
                if (correct)
                {
                    if (StarSignOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }

                    else if (StarSignOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }

                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.StarSignOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;

            case 5:
                if (correct)
                {
                    if (SocialMediaOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.SocialMediaOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }

                    else if (SocialMediaOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.SocialMediaOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }

                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.SocialMediaOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.SocialMediaOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;

            case 6:
                if (correct)
                {
                    if (TVOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }

                    else if (TVOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }

                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.TVOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;

            case 7:
                if (correct)
                {
                    if (PoliticsOpinion < 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionNegative;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.NoClip);
                    }

                    else if (PoliticsOpinion == 0)
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionNeutral;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                    }

                    else
                    {
                        GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionPositive;
                        CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.YesClip);
                    }
                }
                else
                {
                    GameBehavior.Instance.DialogueText.text = JurorData.PoliticalOpinionNeutral;
                    CutieBehavior.Instance.AS.PlayOneShot(CutieBehavior.Instance.MehClip);
                }

                break;
        }

        RemainingQuestions--;
        GameBehavior.Instance.QuestionText.text = "Question (" + CutieBehavior.Instance.HighlightedJuror.RemainingQuestions + "/3)";
    }

    IEnumerator Disappear()
    {
        _anim = GetComponent<Animator>();
        _anim.Play("Base Layer.MakeDisappear", 0, 0);
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(0.66f);
    }
}
