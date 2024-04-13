using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamanthaData : CutieData
{
    void Start()
    {
        Name = "Samantha";

        Introduction = "Oh, hello.";

        NameOpinionPositive = "That's a nice name.";
        NameOpinionNeutral = "That name's okay.";
        NameOpinionNegative = "I don't care for that name.";

        AgeOpinionPositive = "I like them, they're polite.";
        AgeOpinionNeutral = "They're alright, a little rowdy sometimes.";
        AgeOpinionNegative = "I don't care for them. Disrespectful.";

        ColorOpinionPositive = "That color can be quite dashing.";
        ColorOpinionNeutral = "That's a fine color.";
        ColorOpinionNegative = "That color doesn't work well with me.";

        CandyOpinionPositive = "It's quite nice, that candy.";
        CandyOpinionNeutral = "It's good, but a tad much at times.";
        CandyOpinionNegative = "I don't care for it at all.";

        StarSignOpinionPositive = "Why, that's my sign! Marvelous.";
        StarSignOpinionNeutral = "I've know some nice people with that sign.";
        StarSignOpinionNegative = "Oh, I don't think so. No.";

        TVOpinionPositive = "What a lovely program.";
        TVOpinionNeutral = "I don't get the appeal, but it's caused quite a stir.";
        TVOpinionNegative = "That show represents everything wrong with society today.";

        PoliticalOpinionPositive = "I support their campaign, yes.";
        PoliticalOpinionNeutral = "People are free to make their own choices, I suppose.";
        PoliticalOpinionNegative = "I think they're full of themselves and weak.";

        Outtroduction = "Thank you, dear.";
    }
}
