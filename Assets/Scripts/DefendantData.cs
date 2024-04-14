using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendantData : MonoBehaviour
{
    [HideInInspector] public static DefendantData Instance;

    /*
     * Candy
     * Social Media
     * Age
     * Name
     * TV
     * Star Sign
     * Color
     * Politics
     */
    [HideInInspector] public string[] Crimes =
    {
        "Thief Steals Candy From Baby",
        "Person Spreads Misinformation Online",
        "Public Indecency at Retirement Home",
        "Illegal Name Change Has Dire Results",
        "They Won't Stop Talking About Their Favorite TV Show",
        "They Lied About Themself On Dating Apps",
        "The Elementary School Art Thief",
        "Government Coup Attempted Single-Handedly"
    };

    [HideInInspector] public string[] Articles =
    {
        "Will their candy of choice sway jurors?",
        "Will their social media posts convince anybody?",
        "Will the jury's presumptions on age come into play?",
        "Will the jurors find his new name ridiculous?",
        "Will the court find his hot TV takes acceptable?",
        "Will the jury think that star sign really matters?",
        "Will the defendant's favorite color be persuasive?",
        "Will the defense's political beliefs rile up a jury?"
    };

    [HideInInspector] public string[] FirstNames =
    {
        "Barton",
        "Scamp",
        "McHael",
        "Peeps",
        "Bivvy",
        "Dand",
        "Loffo",
        "Kilp",
        "Ghen",
        "Flis"
    };

    [HideInInspector] public string[] LastNames =
    {
        "McGee",
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

    [HideInInspector] public string[] Ages =
    {
        "Generation Omicron",
        "Centennials",
        "Generation Bronze",
        "Scooners",
        "The Okayest Generation",
    };

    [HideInInspector] public string[] FavoriteColors =
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

    [HideInInspector] public string[] FavoriteCandies =
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

    [HideInInspector] public string[] StarSigns =
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

    [HideInInspector] public string[] SocialMedias =
    {
        "Scooper",
        "InstantGram",
        "Y",
        "HeadCanon",
        "BrownIt",
    };

    [HideInInspector] public string[] TVShows =
    {
        "The Tenors",
        "Hurting Bad",
        "Better Ring Ming",
        "The Cable",
        "Family Dad",
        "Rock and Moriarty",
        "Old Feldman"
    };

    [HideInInspector] public string[] Politics =
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
