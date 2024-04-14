using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        int crimeIndex = Random.Range(0, DefendantData.Instance.Crimes.Length);
        Crime = DefendantData.Instance.Crimes[crimeIndex];
        Article = DefendantData.Instance.Articles[crimeIndex];

        Name = DefendantData.Instance.FirstNames[Random.Range(0, DefendantData.Instance.FirstNames.Length)] + " " +
            DefendantData.Instance.LastNames[Random.Range(0, DefendantData.Instance.LastNames.Length)];

        Age = DefendantData.Instance.Ages[Random.Range(0, DefendantData.Instance.Ages.Length)];

        Color = DefendantData.Instance.FavoriteColors[Random.Range(0, DefendantData.Instance.FavoriteColors.Length)];

        Candy = DefendantData.Instance.FavoriteCandies[Random.Range(0, DefendantData.Instance.FavoriteCandies.Length)];

        StarSign = DefendantData.Instance.StarSigns[Random.Range(0, DefendantData.Instance.StarSigns.Length)];

        SocialMedia = DefendantData.Instance.SocialMedias[Random.Range(0, DefendantData.Instance.SocialMedias.Length)];

        TVShow = DefendantData.Instance.TVShows[Random.Range(0, DefendantData.Instance.TVShows.Length)];

        Politics = DefendantData.Instance.Politics[Random.Range(0, DefendantData.Instance.Politics.Length)];
    }
}
