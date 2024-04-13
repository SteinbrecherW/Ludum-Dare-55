using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaksleyData : CutieData
{
    void Start()
    {
        Introduction = "Good morrow!";

        NameOpinionPositive = "I think that's a stupendous name, quite frankly.";
        NameOpinionNeutral = "It's quite alright. Nothing to write home about.";
        NameOpinionNegative = "...By Jove, that's an unfortunate name.";

        AgeOpinionPositive = "Everybody I've known from that generation is lovely as can be!";
        AgeOpinionNeutral = "I think they've some problems, but don't we all?";
        AgeOpinionNegative = "People from that generation are all rotten eggs.";

        ColorOpinionPositive = "Why, that hue would go tremendously with my feathers!";
        ColorOpinionNeutral = "Oh, I suppose it can work when used, er, sparingly...";
        ColorOpinionNegative = "That color should be left in the pits of Hell from whence it came.";

        CandyOpinionPositive = "Ooh, that sounds marvelous! Maybe I'll have some with tea later...";
        CandyOpinionNeutral = "There have been far worse flavors to cross my palette.";
        CandyOpinionNegative = "Those sweets are disgusting! I'll wretch up a pellet just thinking of it.";

        StarSignOpinionPositive = "I believe that's the Queen's sign! It's probably my favorite.";
        StarSignOpinionNeutral = "I find star signs to be a silly exercise, but to each their own.";
        StarSignOpinionNegative = "H**T! Oh, pardon me, but that was my ex-wife's sign. Ugh...";

        TVOpinionPositive = "Ahh yes, a true masterpiece of fiction! Have you seen the finale?";
        TVOpinionNeutral = "Not my cup of tea, but I'll admit I've seen far worse.";
        TVOpinionNegative = "Utter nonsense! Pure dreck! Only the lowest of the low watch that h**t.";

        PoliticalOpinionPositive = "I like the way their candidate talks. I'll probably vote for him, he's very handsome!";
        PoliticalOpinionNeutral = "Oh, those idiots? Well, at least they aren't hurting anybody.";
        PoliticalOpinionNegative = "I'd rather watch Princess Rhiana die a second time than be in the same room as one of them.";

        Outtroduction = "Good day!";
    }
}
