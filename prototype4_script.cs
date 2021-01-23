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
    }

    //function to calculate production
    void CalculateCurrency()
    {
        currencyPerSec = bookProduction + posterProduction + videoProduction + motivationalSpeakingProduction + motivationalClassProduction + motivationalSerumProduction + motivationalBookProduction + motivationalCultProduction + motivationalTEDTalksProduction;
        currency += currencyPerSec * Time.deltaTime; //multiple by delta time
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCurrency();
        currencyText.text  = "Motivation: " + currency.ToString("F0");
        currencyPerSecText.text = "Motivation/sec: " + currencyPerSec.ToString("F0");

        bookText.text = "Book Cost:" + bookCost.ToString("F0");
        bookToolTip.text = "Book production: " + bookProduction.ToString("F0") + "\nAmount: " + bookAmount.ToString("F0");
        upgradeBookText.text = "Upgrade Book \nCost: " + upgradeBookCost.ToString("F0");
        upgradeBookToolTip.text = "Boost: *" + upgradeBookProduction.ToString("F0") + "\nAmount: " + upgradeBookAmount.ToString("F0");

        posterText.text = "Poster Cost:" + posterCost.ToString("F0");
        posterToolTip.text = "Poster production: " + posterProduction.ToString("F0") + "\nAmount: " + posterAmount.ToString("F0");
        upgradePosterText.text = "Upgrade Poster \nCost:" + upgradePosterCost.ToString("F0");
        upgradePosterToolTip.text = "Boost: *" + upgradePosterProduction.ToString("F0") + "\nAmount: " + upgradePosterAmount.ToString("F0");

        videoText.text = "Video Cost:" + videoCost.ToString("F0");
        videoToolTip.text = "Video production: " + videoProduction.ToString("F0") + "\nAmount: " + videoAmount.ToString("F0");
        upgradeVideoText.text = "Upgrade Video \nCost:" + upgradeVideoCost.ToString("F0");
        upgradeVideoToolTip.text = "Boost: *" + upgradeVideoProduction.ToString("F0") + "\nAmount: "+ upgradeVideoAmount.ToString("F0");

        motivationalClassText.text = "Motivational Class Cost:" + motivationalClassCost.ToString("F0");
        motivationalClassToolTip.text = "Motivational Class production: " + motivationalClassProduction.ToString("F0") + "\nAmount: " + motivationalClassAmount.ToString("F0");
        upgradeMotivationalClassText.text = "Upgrade Motivational Class \nCost:" + upgradeMotivationalClassCost.ToString("F0"); 
        upgradeMotivationalClassToolTip.text = "Boost: *" + upgradeMotivationalClassProduction.ToString("F0") + "\nAmount: " + upgradeMotivationalClassAmount.ToString("F0");

        motivationalSpeakingText.text = "Motivational Speaking Cost:" + motivationalSpeakingCost.ToString("F0");
        motivationalSpeakingToolTip.text = "Motivational Speaking production: " + motivationalSpeakingProduction.ToString("F0") + "\nAmount: " + motivationalSpeakingAmount.ToString("F0");
        upgradeMotivationalSpeakingText.text = "Upgrade Motivational Speaking \nCost:" + upgradeMotivationalSpeakingCost.ToString("F0");
        upgradeMotivationalSpeakingToolTip.text = "Boost: *" + upgradeMotivationalSpeakingProduction.ToString("F0") + "\nAmount: " + upgradeMotivationalSpeakingAmount.ToString("F0");

        motivationalSerumText.text = "Motivational Serum Cost:" + motivationalSerumCost.ToString("F0");
        motivationalSerumToolTip.text = "Motivational Serum production: " + motivationalSerumProduction.ToString("F0") + "\nAmount: " + motivationalSerumAmount.ToString("F0");
        upgradeMotivationalSerumText.text = "Upgrade Motivational Serum \nCost: " + upgradeMotivationalSerumCost.ToString("F0");
        upgradeMotivationalSerumToolTip.text = "Boost: *" + upgradeMotivationalSerumProduction.ToString("F0") + "\nAmount: " + upgradeMotivationalSerumAmount.ToString("F0");

        motivationalBookText.text = "Motivational Book Cost:" + motivationalBookCost.ToString("F0");
        motivationalBookToolTip.text = "Motivational Book production: " + motivationalBookProduction.ToString("F0") + "\nAmount: " + motivationalBookAmount.ToString("F0");
        upgradeMotivationalBookText.text = "Upgrade Motivational Book \nCost:" + upgradeMotivationalBookCost.ToString("F0");
        upgradeMotivationalBookToolTip.text = "Boost: *" + upgradeMotivationalBookProduction.ToString("F0") + "\nAMount: " + upgradeMotivationalBookAmount.ToString("F0");
 
        motivationalCultText.text = "Motivational Cult Cost:" + motivationalCultCost.ToString("F0");
        motivationalCultToolTip.text = "Motivational Cult production: " + motivationalCultProduction.ToString("F0") + "\nAmount: " + motivationalCultAmount.ToString("F0");
        upgradeMotivationalCultText.text = "Upgrade Motivational Cult \nCost:" + upgradeMotivationalCultCost.ToString("F0");
        upgradeMotivationalCultToolTip.text = "Boost: *" + upgradeMotivationalCultProduction.ToString("F0") + "\nAmount: " + upgradeMotivationalClassAmount.ToString("F0");

        motivationalTEDTalksText.text = "Motivational TED Talks Cost:" + motivationalTEDTalksCost.ToString("F0");
        motivationalTEDTalksToolTip.text = "Motivational TED Talks production: " + motivationalTEDTalksProduction.ToString("F0") + "\nAmount: " + motivationalTEDTalksAmount.ToString("F0");
        upgradeMotivationalTEDTalksText.text = "Upgrade Motivational TED Talks \nCost: " + upgradeMotivationalTEDTalksCost.ToString("F0");
        upgradeMotivationalTEDTalksToolTip.text = "Boost: *" + upgradeMotivationalTEDTalksProduction.ToString("F0") + "\nAmount: " + upgradeMotivationalTEDTalksAmount.ToString("F0");
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
            bookProduction += 1;
            bookAmount += 1;
            bookCost *= 1.2;
        }
    }

    public void BuyPoster()
    {
        if(currency >= posterCost)
        {
            currency = currency - posterCost;
            posterProduction += 5;
            posterAmount += 1;
            posterCost *= 1.3;
        }
    }

    public void BuyVideo()
    {
        if(currency >= videoCost)
        {
            currency = currency - videoCost;
            videoProduction += 10;
            videoAmount += 1;
            videoCost *= 1.4;
        }
    }

    public void BuyMotivationalClass()
    {
        if(currency >= motivationalClassCost)
        {
            currency = currency - motivationalClassCost;
            motivationalClassProduction += 50;
            motivationalClassAmount += 1;
            motivationalClassCost *= 1.5;
        }
    }

    public void BuyMotivationalSpeaking()
    {
        if(currency >= motivationalSpeakingCost)
        {
            currency = currency - motivationalSpeakingCost;
            motivationalSpeakingProduction += 100;
            motivationalSpeakingAmount += 1;
            motivationalSpeakingCost *= 1.6;
        }
    }

    public void BuyMotivationalSerum()
    {
        if(currency >= motivationalSerumCost)
        {
            currency = currency - motivationalSerumCost;
            motivationalSerumProduction += 200;
            motivationalSerumAmount += 1;
            motivationalSerumCost *= 1.7;
        }
    }

    public void BuyMotivationalBook()
    {
        if(currency >= motivationalBookCost)
        {
            currency = currency - motivationalBookCost;
            motivationalBookProduction += 250;
            motivationalBookAmount += 1;
            motivationalBookCost *= 1.8;
        }
    }
    
    public void BuyMotivationalCult()
    {
        if(currency >= motivationalCultCost)
        {
            currency = currency - motivationalCultCost;
            motivationalCultProduction += 500;
            motivationalCultAmount += 1;
            motivationalCultCost *= 1.9;
        }
    }

    public void BuyMotivationalTEDTalks()
    {
        if(currency >= motivationalTEDTalksCost)
        {
            currency = currency - motivationalTEDTalksCost;
            motivationalTEDTalksProduction += 1000;
            motivationalTEDTalksAmount += 1;
            motivationalTEDTalksCost *= 2;
        }
    }

    //Upgrades PEOPLE UPGRADES!!!
    public void BuyBookUpgrade()
    {
        if(currency >= upgradeBookCost)
        {
            currency = currency - upgradeBookCost; 
            upgradeBookProduction *= 1.1;
            bookProduction *= upgradeBookProduction;
            upgradeBookAmount += 1;
            upgradeBookCost *= 1.2;
        }
    }

    public void BuyPosterUpgrade()
    {
        if(currency >= upgradePosterCost)
        {
            currency = currency - upgradePosterCost; 
            upgradePosterProduction *= 1.2;
            posterProduction *= upgradePosterProduction;
            upgradePosterAmount += 1;
            upgradePosterCost *= 1.3;
        }
    }

    public void BuyVideoUpgrade()
    {
        if(currency >= upgradeVideoCost)
        {
            currency = currency - upgradeVideoCost; 
            upgradeVideoProduction *= 1.3;
            videoProduction *= upgradeVideoProduction;
            upgradeVideoAmount += 1;
            upgradeVideoCost *= 1.4;
        }
    }

    public void BuyMotivationalClassUpgrade()
    {
        if(currency >= upgradeMotivationalClassCost)
        {
            currency = currency - upgradeMotivationalClassCost; 
            upgradeMotivationalClassProduction *= 1.5;
            motivationalClassProduction *= upgradeMotivationalClassProduction;
            upgradeMotivationalClassAmount += 1;
            upgradeMotivationalClassCost *= 1.5;
        }
    }

    public void BuyMotivationalSpeakingUpgrade()
    {
        if(currency >= upgradeMotivationalSpeakingCost)
        {
            currency = currency - upgradeMotivationalSpeakingCost; 
            upgradeMotivationalSpeakingProduction *= 1.6;
            motivationalSpeakingProduction *= upgradeMotivationalSpeakingProduction;
            upgradeMotivationalSpeakingAmount += 1;
            upgradeMotivationalSpeakingCost *= 1.6;
        }
    }

    public void BuyMotivationalSerumUpgrade()
    {
        if(currency >= upgradeMotivationalSerumCost)
        {
            currency = currency - upgradeMotivationalSerumCost; 
            upgradeMotivationalSerumProduction *= 1.7;
            motivationalSerumProduction *= upgradeMotivationalSerumProduction;
            upgradeMotivationalSerumAmount += 1;
            upgradeMotivationalSerumCost *= 1.7;
        }
    }

    public void BuyMotivationalBookUpgrade()
    {
        if(currency >= upgradeMotivationalBookCost)
        {
            currency = currency - upgradeMotivationalBookCost; 
            upgradeMotivationalBookProduction *= 1.8;
            motivationalBookProduction *= upgradeMotivationalBookProduction;
            upgradeMotivationalBookAmount += 1;
            upgradeMotivationalBookCost *= 1.8;
        }
    }

    public void BuyMotivationalCultUpgrade()
    {
        if(currency >= upgradeMotivationalCultCost)
        {
            currency = currency - upgradeMotivationalCultCost; 
            upgradeMotivationalCultProduction *= 1.9;
            motivationalCultProduction *= upgradeMotivationalCultProduction;
            upgradeMotivationalCultAmount += 1;
            upgradeMotivationalCultCost *= 1.9;
        }
    }

    public void BuyMotivationalTEDTalksUpgrade()
    {
        if(currency >= upgradeMotivationalTEDTalksCost)
        {
            currency = currency - upgradeMotivationalTEDTalksCost; 
            upgradeMotivationalTEDTalksProduction *= 2;
            motivationalTEDTalksProduction *= upgradeMotivationalTEDTalksProduction;
            upgradeMotivationalTEDTalksAmount += 1;
            upgradeMotivationalTEDTalksCost *= 2;
        }
    }
}
