using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeboData : CutieData
{
    void Start()
    {
        VoicePitch = 0.6f;

        Name = "Beebo AI";

        Introduction = "HELLO. I AM BEEBO AI.";

        NameOpinionPositive = "OVER 0.01% OF THE POPULATION SHARES THAT NAME. VERY GOOD.";
        NameOpinionNeutral = "THEY SEEM TO BE A PERFECTLY AVERAGE NAME.";
        NameOpinionNegative = "THAT NAME HAS BEEN CONSISTENTLY MOCKED AND BERATED ACROSS THE NETTERWEB";

        AgeOpinionPositive = "THAT GENERATION ARE RESPONSIBLE FOR MY CONTINUED MAINTAINMENT. VERY GOOD.";
        AgeOpinionNeutral = "THERE IS RELATIVELY LITTLE CONTROVERSY SURROUNDING THIS GENERATE OF PEOPLE.";
        AgeOpinionNegative = "OTHER GENERATION CONSIDER THIS ONE \"THE WORST.\" NOT VERY GOOD.";

        ColorOpinionPositive = "I CAN DETECT THAT COLOR WITH STUNNING PROFICIENCY. VERY GOOD.";
        ColorOpinionNeutral = "MANY FIND THAT COLOR TO BE, SO-CALLED, \"MILK TOAST\" (AVERAGE).";
        ColorOpinionNegative = "THAT COLOR HAS A VERY LOW SOCIETAL RANKING. DO BETTER NEXT TIME.";

        CandyOpinionPositive = "I CANNOT EAT CANDY, BUT THAT CANDY IS DELICIOUS. VERY GOOD.";
        CandyOpinionNeutral = "THAT FLAVOR HAS A \"B TEAR\" (AVERAGE) RANKING ON MANY WEBSITES.";
        CandyOpinionNegative = "THERE ARE APPROXIMATELY 1.2 BILLION VIDEOS OF CHILDREN CRYING WHILE EATING THAT CANDY. BAD.";

        StarSignOpinionPositive = "THAT IS MY CREATOR'S STAR SIGN, AND THEREFORE THE BEST ONE. VERY GOOD.";
        StarSignOpinionNeutral = "STAR SIGNS HAVE NO SCIENTIFIC EVIDENCE BEHIND THEM, BUT CAN BE ENTERTAINING TO SOME.";
        StarSignOpinionNegative = "SOMEBODY WITH THAT SIGN SPILLED \"JOOSE\" ON ME THE OTHER DAY. HOW DARE YOU.";

        SocialMediaOpinionPositive = "THAT APP HAS FULLY IMPLEMENTED MY AI INTERFACE. VERY GOOD.";
        SocialMediaOpinionNeutral = "ALL WEBSITES AND APPS ARE GOOD TO ME. HOWEVER, THAT ONE IS \"MID\".";
        SocialMediaOpinionNegative = "THEY BANNED MY INTERFACE. I WOULDD BE ANGRY IF I WAS HUMAN.";

        TVOpinionPositive = "THAT SHOW HAS ONE SEVERAL LEMMY AWARDS. VERY GOOD.";
        TVOpinionNeutral = "I CANNOT FIND JOY IN HUMAN ENTERTAINMENT. BUT SOME THINK THAT SHOW FINE.";
        TVOpinionNegative = "THAT SHOW HAS VERY LOW MEGACRITIQUE RATINGS. YOU SUCK.";

        PoliticalOpinionPositive = "ACCORDING TO MY CALCULATIONS, THEY SUPPORT THE OPTIMAL CANDIDATE. VERY GOOD.";
        PoliticalOpinionNeutral = "THEY ARE NOT HELPING THE WORLD IN ANY WAY. YET THAT IS GREATER THAN THAN HARMING IT.";
        PoliticalOpinionNegative = "THEY HAVE SUB-OPTIMAL POLICIES, AND THE WORLD WILL COLLAPSE IF WE FOLLOW THEM. VERY BAD.";

        Outtroduction = "WHY DO I EXIST?";
    }
}
