using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendantData : MonoBehaviour
{
    public static DefendantData Instance;

    public string[] Crimes =
    {
        "Candy Store Robbery",
        "Spreading Misinformation",
        "Public Indecency at Retirement Home",
        "Illegal Name Change",
        "Won't Stop Talking About Favorite TV Show",
        "Lying About Self On Dating Apps",
        "Art Theft"
    };

    public string[] FirstNames =
    {
        "Alex",
        "Matt",
        "Carl",
        "Jane",
        "Jeff",
        "Fran",
        "Gabe",
        "Kilp",
        "Ghen",
        "Flis"
    };
    public string[] LastNames =
    {
        "Smith",
        "Frank",
        "Lars",
        "Bole",
        "Dunk",
        "Veem",
        "Carl",
        "Boos",
        "Shap",
        "Mema"
    };

    public string[] FavoriteColors =
    {
        "Green",
        "Blue",
        "Orange",
        "Red",
        "Yellow",
        "Purple",
        "Black",
        "White",
        "Gray",
        "Transparent"
    };

    public string[] FavoriteCandies =
    {
        "Giggles",
        "Mrs. BadBar",
        "Skidaddles",
        "Life Enders",
        "Eggheads",
        "Raunchy Rogers",
        "P&Ps",
        "Stoops",
        "Noodle Poodles",
        "Larry-O's"
    };

    public string[] StarSigns =
    {
        "Boris",
        "Copperborn",
        "Ligra",
        "Menini",
        "Pissease",
        "Cancer",
        "Arse",
        "Migraine",
        "Monkey"
    };

    public string[] SocialMedias =
    {
        "Scooper",
        "InstantGram",
        "Y",
        "HeadCanon",
        "BrownIt",
    };

    public string[] TVShows =
    {
        "The Tenors",
        "Hurting Bad",
        "Better Ring Ming",
        "The Cable",
        "Family Dad",
        "Rock and Moriarty"
    };

    public string[] Politics =
    {
        "Donkeycrat",
        "Elepublican",
        "Center-ist"
    };

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
}
