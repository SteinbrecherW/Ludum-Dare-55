using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuibbyData : CutieData
{
    void Start()
    {
        VoicePitch = 1.75f;

        Name = "Quibby";

        Introduction = "Heeey guurrll! I'm Quibby.";

        NameOpinionPositive = "That name is SO YOU! I can't get enough!";
        NameOpinionNeutral = "That's a perfectly fine name! You do you, honey.";
        NameOpinionNegative = "I'll keep it real, that name's BAD. Change it.";

        AgeOpinionPositive = "Y'all's is chill, I'm down with you!";
        AgeOpinionNeutral = "Sometimes y'all say some crazy stuff, but you ain't that bad!";
        AgeOpinionNegative = "They're so out of it. Not a fan.";

        ColorOpinionPositive = "That works so well on you bestie! Keep it up!";
        ColorOpinionNeutral = "It's a good color, but maybe you could go with something else?";
        ColorOpinionNegative = "Oh sweetie, that color does NOT work on you.";

        CandyOpinionPositive = "Love it, that candy is SWE-EE-ET! Just like me, HAH!";
        CandyOpinionNeutral = "It's aight, who doesn't like candy?";
        CandyOpinionNegative = "Ugh, that stuff's been out for MONTHS now. Get it together!";

        StarSignOpinionPositive = "OMG, we're super compatible from that sign! Why didn't you tell me?";
        StarSignOpinionNeutral = "That makes so much sense for you. Could be worse, though.";
        StarSignOpinionNegative = "Honestly, I don't know if I can talk to you anymore if that's your sign.";

        SocialMediaOpinionPositive = "SLAAAY! You should totally add me, let's collab!";
        SocialMediaOpinionNeutral = "I only use that for my business promo, kinda boring.";
        SocialMediaOpinionNegative = "Eww. I don't even use that site for SEI.";

        TVOpinionPositive = "That show is EVERYTHING! SO GOOD!!!";
        TVOpinionNeutral = "My friend likes that show. I don't like them very much, though.";
        TVOpinionNegative = "THAT SHOW IS SO CAMP! Oh, you mean unironically? That's embarrassing.";

        PoliticalOpinionPositive = "SLAY, that party is BASED! They're what we need right now!";
        PoliticalOpinionNeutral = "I don't really agree with them, but be your best self queen!";
        PoliticalOpinionNegative = "Why would you bring the vibes down like that? Creep.";

        Outtroduction = "Bye bestie!!!";
    }
}
