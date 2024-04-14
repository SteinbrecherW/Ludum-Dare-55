using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CutieData : MonoBehaviour
{
    [HideInInspector] public string Name;

    [HideInInspector] public string Introduction;

    [HideInInspector] public string NameOpinionPositive;
    [HideInInspector] public string NameOpinionNeutral;
    [HideInInspector] public string NameOpinionNegative;

    [HideInInspector] public string AgeOpinionPositive;
    [HideInInspector] public string AgeOpinionNeutral;
    [HideInInspector] public string AgeOpinionNegative;

    [HideInInspector] public string ColorOpinionPositive;
    [HideInInspector] public string ColorOpinionNeutral;
    [HideInInspector] public string ColorOpinionNegative;

    [HideInInspector] public string CandyOpinionPositive;
    [HideInInspector] public string CandyOpinionNeutral;
    [HideInInspector] public string CandyOpinionNegative;

    [HideInInspector] public string StarSignOpinionPositive;
    [HideInInspector] public string StarSignOpinionNeutral;
    [HideInInspector] public string StarSignOpinionNegative;

    [HideInInspector] public string SocialMediaOpinionPositive;
    [HideInInspector] public string SocialMediaOpinionNeutral;
    [HideInInspector] public string SocialMediaOpinionNegative;

    [HideInInspector] public string TVOpinionPositive;
    [HideInInspector] public string TVOpinionNeutral;
    [HideInInspector] public string TVOpinionNegative;

    [HideInInspector] public string PoliticalOpinionPositive;
    [HideInInspector] public string PoliticalOpinionNeutral;
    [HideInInspector] public string PoliticalOpinionNegative;

    [HideInInspector] public string Outtroduction;

    [HideInInspector] public float VoicePitch;
}
