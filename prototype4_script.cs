using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prototype4_script : MonoBehaviour
{
    //public objects
    public Text currencyText;
    public Text currencyPerSecText;
    public Text currencyPerClickValueText;    
    public double currency;
    public double currencyPerSec;
    public double currencyPerClickValue;

    public Text bookText;
    public Text bookToolTip;
    public double bookCost;
    public double bookProduction;
    public double bookAmount;
    public Text upgradeBookText;
    public Text upgradeBookToolTip;
    public double upgradeBookCost;
    public double upgradeBookProduction;
    public double upgradeBookAmount;

    public Text posterText;
    public Text posterToolTip;
    public double posterCost;
    public double posterProduction;
    public double posterAmount;
    public Text upgradePosterText;
    public Text upgradePosterToolTip;
    public double upgradePosterCost;
    public double upgradePosterProduction;
    public double upgradePosterAmount;

    public Text videoText;
    public Text videoToolTip;
    public double videoCost;
    public double videoProduction;
    public double videoAmount;
    public Text upgradeVideoText;
    public Text upgradeVideoToolTip;
    public double upgradeVideoCost;
    public double upgradeVideoProduction;
    public double upgradeVideoAmount;

    public Text motivationalClassText;
    public Text motivationalClassToolTip;
    public double motivationalClassCost;
    public double motivationalClassProduction;
    public double motivationalClassAmount;
    public Text upgradeMotivationalClassText;
    public Text upgradeMotivationalClassToolTip;
    public double upgradeMotivationalClassCost;
    public double upgradeMotivationalClassProduction;
    public double upgradeMotivationalClassAmount;

    public Text motivationalSpeakingText;
    public Text motivationalSpeakingToolTip;
    public double motivationalSpeakingCost;
    public double motivationalSpeakingProduction;
    public double motivationalSpeakingAmount;
    public Text upgradeMotivationalSpeakingText;
    public Text upgradeMotivationalSpeakingToolTip;
    public double upgradeMotivationalSpeakingCost;
    public double upgradeMotivationalSpeakingProduction;
    public double upgradeMotivationalSpeakingAmount;

    public Text motivationalSerumText;
    public Text motivationalSerumToolTip;
    public double motivationalSerumCost;
    public double motivationalSerumProduction;
    public double motivationalSerumAmount;
    public Text upgradeMotivationalSerumText;
    public Text upgradeMotivationalSerumToolTip;
    public double upgradeMotivationalSerumCost;
    public double upgradeMotivationalSerumProduction;
    public double upgradeMotivationalSerumAmount;

    public Text motivationalBookText;
    public Text motivationalBookToolTip;
    public double motivationalBookCost;
    public double motivationalBookProduction;
    public double motivationalBookAmount;
    public Text upgradeMotivationalBookText;
    public Text upgradeMotivationalBookToolTip;
    public double upgradeMotivationalBookCost;
    public double upgradeMotivationalBookProduction;
    public double upgradeMotivationalBookAmount;

    public Text motivationalCultText;
    public Text motivationalCultToolTip;
    public double motivationalCultCost;
    public double motivationalCultProduction;
    public double motivationalCultAmount;
    public Text upgradeMotivationalCultText;
    public Text upgradeMotivationalCultToolTip;
    public double upgradeMotivationalCultCost;
    public double upgradeMotivationalCultProduction;
    public double upgradeMotivationalCultAmount;

    public Text motivationalTEDTalksText;
    public Text motivationalTEDTalksToolTip;
    public double motivationalTEDTalksCost;
    public double motivationalTEDTalksProduction;
    public double motivationalTEDTalksAmount;
    public Text upgradeMotivationalTEDTalksText;
    public Text upgradeMotivationalTEDTalksToolTip;
    public double upgradeMotivationalTEDTalksCost;
    public double upgradeMotivationalTEDTalksProduction;
    public double upgradeMotivationalTEDTalksAmount;

    public void CloseApplication()
    {
        Application.Quit();
    }

    //have FULL HARD RESET
    public void reset()
    {
        currency = 0;
        currencyPerClickValue = 1;
        
        bookCost = 10;
        bookProduction = 0;
        bookAmount = 0;
        upgradeBookCost = 50;
        upgradeBookProduction = 1;
        upgradeBookAmount = 0;

        posterCost = 50;
        posterProduction = 0;
        posterAmount = 0;
        upgradePosterCost = 100;
        upgradePosterProduction = 1;
        upgradePosterAmount = 0;
    
        videoCost = 100;
        videoProduction = 0;
        videoAmount = 0;
        upgradeVideoCost = 200;
        upgradeVideoProduction = 1;
        upgradeVideoAmount = 0;
        
        motivationalClassCost = 500;
        motivationalClassProduction = 0;
        motivationalClassAmount = 0;
        upgradeMotivationalClassCost = 1000;
        upgradeMotivationalClassProduction = 1;
        upgradeMotivationalClassAmount = 0;

        motivationalSpeakingCost = 1000;
        motivationalSpeakingProduction = 0;
        motivationalSpeakingAmount = 0;
        upgradeMotivationalSpeakingCost = 2000;
        upgradeMotivationalSpeakingProduction = 1;
        upgradeMotivationalSpeakingAmount = 0;

        motivationalSerumCost = 1500;
        motivationalSerumProduction = 0;
        motivationalSerumAmount = 0;
        upgradeMotivationalSerumCost = 3000;
        upgradeMotivationalSerumProduction = 1;
        upgradeMotivationalSerumAmount = 0;

        motivationalBookCost = 2000;
        motivationalBookProduction = 0;
        motivationalBookAmount = 0;
        upgradeMotivationalBookCost = 4000;
        upgradeMotivationalBookProduction = 1;
        upgradeMotivationalBookAmount = 0;

        motivationalCultCost = 2500;
        motivationalCultProduction = 0;
        motivationalCultAmount = 0;
        upgradeMotivationalCultCost = 5000;
        upgradeMotivationalCultProduction = 1;
        upgradeMotivationalCultAmount = 0;

        motivationalTEDTalksCost = 3000;
        motivationalTEDTalksProduction = 0;
        motivationalTEDTalksAmount = 0;
        upgradeMotivationalTEDTalksCost = 6000;
        upgradeMotivationalTEDTalksProduction = 1;
        upgradeMotivationalTEDTalksAmount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        currency = 0;
        currencyPerClickValue = 1;
        
        bookCost = 10;
        bookProduction = 0;
        bookAmount = 0;
        upgradeBookCost = 50;
        upgradeBookProduction = 1;
        upgradeBookAmount = 0;

        posterCost = 50;
        posterProduction = 0;
        posterAmount = 0;
        upgradePosterCost = 100;
        upgradePosterProduction = 1;
        upgradePosterAmount = 0;
    
        videoCost = 100;
        videoProduction = 0;
        videoAmount = 0;
        upgradeVideoCost = 200;
        upgradeVideoProduction = 1;
        upgradeVideoAmount = 0;
        
        motivationalClassCost = 500;
        motivationalClassProduction = 0;
        motivationalClassAmount = 0;
        upgradeMotivationalClassCost = 1000;
        upgradeMotivationalClassProduction = 1;
        upgradeMotivationalClassAmount = 0;

        motivationalSpeakingCost = 1000;
        motivationalSpeakingProduction = 0;
        motivationalSpeakingAmount = 0;
        upgradeMotivationalSpeakingCost = 2000;
        upgradeMotivationalSpeakingProduction = 1;
        upgradeMotivationalSpeakingAmount = 0;

        motivationalSerumCost = 1500;
        motivationalSerumProduction = 0;
        motivationalSerumAmount = 0;
        upgradeMotivationalSerumCost = 3000;
        upgradeMotivationalSerumProduction = 1;
        upgradeMotivationalSerumAmount = 0;

        motivationalBookCost = 2000;
        motivationalBookProduction = 0;
        motivationalBookAmount = 0;
        upgradeMotivationalBookCost = 4000;
        upgradeMotivationalBookProduction = 1;
        upgradeMotivationalBookAmount = 0;

        motivationalCultCost = 2500;
        motivationalCultProduction = 0;
        motivationalCultAmount = 0;
        upgradeMotivationalCultCost = 5000;
        upgradeMotivationalCultProduction = 1;
        upgradeMotivationalCultAmount = 0;

        motivationalTEDTalksCost = 3000;
        motivationalTEDTalksProduction = 0;
        motivationalTEDTalksAmount = 0;
        upgradeMotivationalTEDTalksCost = 6000;
        upgradeMotivationalTEDTalksProduction = 1;
        upgradeMotivationalTEDTalksAmount = 0;

        load();
    }

    public void load()
    {
        
    }

    public void save()
    {

    }

    //function to calculate production
    void CalculateCurrency()
    {
        currencyPerSec = bookProduction + posterProduction + videoProduction + motivationalSpeakingProduction + motivationalClassProduction + motivationalSerumProduction + motivationalBookProduction + motivationalCultProduction + motivationalTEDTalksProduction;
        currency += currencyPerSec * Time.deltaTime; //multiple by delta time
    }

    
    string exponentConvert(double amount)
    {   
        string returnString;
        if(amount > 1000)
        {
            double exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(amount))));
            double shrunkValue = (amount / System.Math.Pow(10, exponent));
            return returnString = shrunkValue.ToString("F2") + "e" + exponent.ToString();
        }
        else
            return returnString = amount.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCurrency();
        currencyText.text  = "Motivation: " + exponentConvert(currency);
        currencyPerSecText.text = "Motivation/sec: " + exponentConvert(currencyPerSec);

        bookText.text = "Book Cost:" + exponentConvert(bookCost);
        bookToolTip.text = "Book production: " + exponentConvert(bookProduction) + "\nAmount: " + exponentConvert(bookAmount);
        upgradeBookText.text = "Upgrade Book \nCost: " + exponentConvert(upgradeBookCost);
        upgradeBookToolTip.text = "Boost: *" + exponentConvert(upgradeBookProduction) + "\nAmount: " + exponentConvert(upgradeBookAmount);

        posterText.text = "Poster Cost:" + exponentConvert(posterCost);
        posterToolTip.text = "Poster production: " + exponentConvert(posterProduction) + "\nAmount: " + exponentConvert(posterAmount);
        upgradePosterText.text = "Upgrade Poster \nCost:" + exponentConvert(upgradePosterCost);
        upgradePosterToolTip.text = "Boost: *" + exponentConvert(upgradePosterProduction) + "\nAmount: " + exponentConvert(upgradePosterAmount);

        videoText.text = "Video Cost:" + exponentConvert(videoCost);
        videoToolTip.text = "Video production: " + exponentConvert(videoProduction) + "\nAmount: " + exponentConvert(videoAmount);
        upgradeVideoText.text = "Upgrade Video \nCost:" + exponentConvert(upgradeVideoCost);
        upgradeVideoToolTip.text = "Boost: *" + exponentConvert(upgradeVideoProduction) + "\nAmount: "+ exponentConvert(upgradeVideoAmount);

        motivationalClassText.text = "Motivational Class Cost:" + exponentConvert(motivationalClassCost);
        motivationalClassToolTip.text = "Motivational Class production: " + exponentConvert(motivationalClassProduction) + "\nAmount: " + exponentConvert(motivationalClassAmount);
        upgradeMotivationalClassText.text = "Upgrade Motivational Class \nCost:" + exponentConvert(upgradeMotivationalClassCost); 
        upgradeMotivationalClassToolTip.text = "Boost: *" + exponentConvert(upgradeMotivationalClassProduction) + "\nAmount: " + exponentConvert(upgradeMotivationalClassAmount);

        motivationalSpeakingText.text = "Motivational Speaking Cost:" + exponentConvert(motivationalSpeakingCost);
        motivationalSpeakingToolTip.text = "Motivational Speaking production: " + exponentConvert(motivationalSpeakingProduction) + "\nAmount: " + exponentConvert(motivationalSpeakingAmount);
        upgradeMotivationalSpeakingText.text = "Upgrade Motivational Speaking \nCost:" + exponentConvert(upgradeMotivationalSpeakingCost);
        upgradeMotivationalSpeakingToolTip.text = "Boost: *" + exponentConvert(upgradeMotivationalSpeakingProduction) + "\nAmount: " + exponentConvert(upgradeMotivationalSpeakingAmount);

        motivationalSerumText.text = "Motivational Serum Cost:" + exponentConvert(motivationalSerumCost);
        motivationalSerumToolTip.text = "Motivational Serum production: " + exponentConvert(motivationalSerumProduction) + "\nAmount: " + exponentConvert(motivationalSerumAmount);
        upgradeMotivationalSerumText.text = "Upgrade Motivational Serum \nCost: " + exponentConvert(upgradeMotivationalSerumCost);
        upgradeMotivationalSerumToolTip.text = "Boost: *" + exponentConvert(upgradeMotivationalSerumProduction) + "\nAmount: " + exponentConvert(upgradeMotivationalSerumAmount);

        motivationalBookText.text = "Motivational Book Cost:" + exponentConvert(motivationalBookCost);
        motivationalBookToolTip.text = "Motivational Book production: " + exponentConvert(motivationalBookProduction) + "\nAmount: " + exponentConvert(motivationalBookAmount);
        upgradeMotivationalBookText.text = "Upgrade Motivational Book \nCost:" + exponentConvert(upgradeMotivationalBookCost);
        upgradeMotivationalBookToolTip.text = "Boost: *" + exponentConvert(upgradeMotivationalBookProduction) + "\nAMount: " + exponentConvert(upgradeMotivationalBookAmount);
 
        motivationalCultText.text = "Motivational Cult Cost:" + exponentConvert(motivationalCultCost);
        motivationalCultToolTip.text = "Motivational Cult production: " + exponentConvert(motivationalCultProduction) + "\nAmount: " + exponentConvert(motivationalCultAmount);
        upgradeMotivationalCultText.text = "Upgrade Motivational Cult \nCost:" + exponentConvert(upgradeMotivationalCultCost);
        upgradeMotivationalCultToolTip.text = "Boost: *" + exponentConvert(upgradeMotivationalCultProduction) + "\nAmount: " + exponentConvert(upgradeMotivationalClassAmount);

        motivationalTEDTalksText.text = "Motivational TED Talks Cost:" + exponentConvert(motivationalTEDTalksCost);
        motivationalTEDTalksToolTip.text = "Motivational TED Talks production: " + exponentConvert(motivationalTEDTalksProduction) + "\nAmount: " + exponentConvert(motivationalTEDTalksAmount);
        upgradeMotivationalTEDTalksText.text = "Upgrade Motivational TED Talks \nCost: " + exponentConvert(upgradeMotivationalTEDTalksCost);
        upgradeMotivationalTEDTalksToolTip.text = "Boost: *" + exponentConvert(upgradeMotivationalTEDTalksProduction) + "\nAmount: " + exponentConvert(upgradeMotivationalTEDTalksAmount);
    }

    public void ClickCurrency()
    {
        currency += currencyPerClickValue;
    }

    public void BuyBook()
    {
        if(currency >= bookCost)
        {
            currency = currency - bookCost;
            bookProduction += 0.1;
            bookAmount += 1;
            bookCost *= 1.5;
        }
    }

    public void BuyPoster()
    {
        if(currency >= posterCost)
        {
            currency = currency - posterCost;
            posterProduction += 1;
            posterAmount += 1;
            posterCost *= 1.6;
        }
    }

    public void BuyVideo()
    {
        if(currency >= videoCost)
        {
            currency = currency - videoCost;
            videoProduction += 5;
            videoAmount += 1;
            videoCost *= 1.7;
        }
    }

    public void BuyMotivationalClass()
    {
        if(currency >= motivationalClassCost)
        {
            currency = currency - motivationalClassCost;
            motivationalClassProduction += 10;
            motivationalClassAmount += 1;
            motivationalClassCost *= 1.8;
        }
    }

    public void BuyMotivationalSpeaking()
    {
        if(currency >= motivationalSpeakingCost)
        {
            currency = currency - motivationalSpeakingCost;
            motivationalSpeakingProduction += 50;
            motivationalSpeakingAmount += 1;
            motivationalSpeakingCost *= 1.9;
        }
    }

    public void BuyMotivationalSerum()
    {
        if(currency >= motivationalSerumCost)
        {
            currency = currency - motivationalSerumCost;
            motivationalSerumProduction += 100;
            motivationalSerumAmount += 1;
            motivationalSerumCost *= 2;
        }
    }

    public void BuyMotivationalBook()
    {
        if(currency >= motivationalBookCost)
        {
            currency = currency - motivationalBookCost;
            motivationalBookProduction += 200;
            motivationalBookAmount += 1;
            motivationalBookCost *= 2.1;
        }
    }
    
    public void BuyMotivationalCult()
    {
        if(currency >= motivationalCultCost)
        {
            currency = currency - motivationalCultCost;
            motivationalCultProduction += 400;
            motivationalCultAmount += 1;
            motivationalCultCost *= 2.2;
        }
    }

    public void BuyMotivationalTEDTalks()
    {
        if(currency >= motivationalTEDTalksCost)
        {
            currency = currency - motivationalTEDTalksCost;
            motivationalTEDTalksProduction += 800;
            motivationalTEDTalksAmount += 1;
            motivationalTEDTalksCost *= 2.3;
        }
    }

    //Upgrades PEOPLE UPGRADES!!!
    public void BuyBookUpgrade()
    {
        if(currency >= upgradeBookCost)
        {
            currency = currency - upgradeBookCost; 
            upgradeBookProduction += 0.1;
            bookProduction *= upgradeBookProduction;
            upgradeBookAmount += 1;
            upgradeBookCost *= 3.2;
        }
    }

    public void BuyPosterUpgrade()
    {
        if(currency >= upgradePosterCost)
        {
            currency = currency - upgradePosterCost; 
            upgradePosterProduction += 0.2;
            posterProduction *= upgradePosterProduction;
            upgradePosterAmount += 1;
            upgradePosterCost *= 3.3;
        }
    }

    public void BuyVideoUpgrade()
    {
        if(currency >= upgradeVideoCost)
        {
            currency = currency - upgradeVideoCost; 
            upgradeVideoProduction += 0.3;
            videoProduction *= upgradeVideoProduction;
            upgradeVideoAmount += 1;
            upgradeVideoCost *= 3.4;
        }
    }

    public void BuyMotivationalClassUpgrade()
    {
        if(currency >= upgradeMotivationalClassCost)
        {
            currency = currency - upgradeMotivationalClassCost; 
            upgradeMotivationalClassProduction += 0.5;
            motivationalClassProduction *= upgradeMotivationalClassProduction;
            upgradeMotivationalClassAmount += 1;
            upgradeMotivationalClassCost *= 3.5;
        }
    }

    public void BuyMotivationalSpeakingUpgrade()
    {
        if(currency >= upgradeMotivationalSpeakingCost)
        {
            currency = currency - upgradeMotivationalSpeakingCost; 
            upgradeMotivationalSpeakingProduction += 0.6;
            motivationalSpeakingProduction *= upgradeMotivationalSpeakingProduction;
            upgradeMotivationalSpeakingAmount += 1;
            upgradeMotivationalSpeakingCost *= 3.6;
        }
    }

    public void BuyMotivationalSerumUpgrade()
    {
        if(currency >= upgradeMotivationalSerumCost)
        {
            currency = currency - upgradeMotivationalSerumCost; 
            upgradeMotivationalSerumProduction += 0.7;
            motivationalSerumProduction *= upgradeMotivationalSerumProduction;
            upgradeMotivationalSerumAmount += 1;
            upgradeMotivationalSerumCost *= 3.7;
        }
    }

    public void BuyMotivationalBookUpgrade()
    {
        if(currency >= upgradeMotivationalBookCost)
        {
            currency = currency - upgradeMotivationalBookCost; 
            upgradeMotivationalBookProduction += 0.8;
            motivationalBookProduction *= upgradeMotivationalBookProduction;
            upgradeMotivationalBookAmount += 1;
            upgradeMotivationalBookCost *= 3.8;
        }
    }

    public void BuyMotivationalCultUpgrade()
    {
        if(currency >= upgradeMotivationalCultCost)
        {
            currency = currency - upgradeMotivationalCultCost; 
            upgradeMotivationalCultProduction += 0.9;
            motivationalCultProduction *= upgradeMotivationalCultProduction;
            upgradeMotivationalCultAmount += 1;
            upgradeMotivationalCultCost *= 3.9;
        }
    }

    public void BuyMotivationalTEDTalksUpgrade()
    {
        if(currency >= upgradeMotivationalTEDTalksCost)
        {
            currency = currency - upgradeMotivationalTEDTalksCost; 
            upgradeMotivationalTEDTalksProduction += 1;
            motivationalTEDTalksProduction *= upgradeMotivationalTEDTalksProduction;
            upgradeMotivationalTEDTalksAmount += 1;
            upgradeMotivationalTEDTalksCost *= 4;
        }
    }
}
