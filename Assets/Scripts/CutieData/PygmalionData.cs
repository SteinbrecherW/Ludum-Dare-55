using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PygmalionData : CutieData
{
    void Start()
    {
        Name = "Pygmalion";

        Introduction = "I'm Pygmalion. Do you have any drugs?";

        NameOpinionPositive = "Name's good. I can give you good money.";
        NameOpinionNeutral = "Name's okay. I'm serious about the drugs.";
        NameOpinionNegative = "Name sucks. I'm jonesing for a hit, man.";

        AgeOpinionPositive = "They're good people, they let me cop teenths.";
        AgeOpinionNeutral = "They're okay, sometimes they have the goods.";
        AgeOpinionNegative = "I hate them, they never have anything for me.";

        ColorOpinionPositive = "Good color. Reminds me of drugs.";
        ColorOpinionNeutral = "That's an alright color. I'm dying to get high bro.";
        ColorOpinionNegative = "I've hated that color ever since my bad trip...";

        CandyOpinionPositive = "That candy tastes amazing when I'm high.";
        CandyOpinionNeutral = "That candy's okay. Way better when I'm high.";
        CandyOpinionNegative = "That candy sucks, even when I'm high.";

        StarSignOpinionPositive = "People with that sign always give me the best gas.";
        StarSignOpinionNeutral = "People with that sign usually have okay drugs.";
        StarSignOpinionNegative = "I get skunk crunk from people with that sign, not good at all.";

        TVOpinionPositive = "Good show. Are you sure you don't have any drugs?";
        TVOpinionNeutral = "Ok show. I would literally do anything for some blow.";
        TVOpinionNegative = "Terrible show. Please give me drugs, I'm begging here.";

        PoliticalOpinionPositive = "Heck yeah man, legalize it!";
        PoliticalOpinionNeutral = "They're okay, but they don't talk about drugs enough.";
        PoliticalOpinionNegative = "I hate them more than anything. You can't take them from me!";

        Outtroduction = "Please find some drugs for me.";
    }
}
