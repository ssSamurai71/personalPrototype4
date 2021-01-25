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

    float autoSaveTimer = 30;

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
        load();
    }

    public void load()
    {
        currency = double.Parse(PlayerPrefs.GetString("currency", "0"));
        currencyPerClickValue = double.Parse(PlayerPrefs.GetString("currencyPerClickValue", "1"));
        
        bookCost = double.Parse(PlayerPrefs.GetString("bookCost", "10"));
        bookProduction = double.Parse(PlayerPrefs.GetString("bookProduction", "0"));
        bookAmount = double.Parse(PlayerPrefs.GetString("bookAmount", "0"));
        upgradeBookCost = double.Parse(PlayerPrefs.GetString("upgradeBookCost", "50"));
        upgradeBookProduction = double.Parse(PlayerPrefs.GetString("upgradeBooKProduction", "1"));
        upgradeBookAmount = double.Parse(PlayerPrefs.GetString("UpgradeBookAmount", "0"));

        posterCost = double.Parse(PlayerPrefs.GetString("posterCost", "50"));
        posterProduction = double.Parse(PlayerPrefs.GetString("posterProduction", "0"));
        posterAmount = double.Parse(PlayerPrefs.GetString("posterAmount", "0"));
        upgradePosterCost = double.Parse(PlayerPrefs.GetString("upgradePosterCost", "100"));
        upgradePosterProduction = double.Parse(PlayerPrefs.GetString("upgradePosterProduction", "1"));
        upgradePosterAmount = double.Parse(PlayerPrefs.GetString("upgradePosterAmount", "0"));

        videoCost = double.Parse(PlayerPrefs.GetString("videoCost", "100"));
        videoProduction = double.Parse(PlayerPrefs.GetString("videoProduction", "0"));
        videoAmount = double.Parse(PlayerPrefs.GetString("videoAmount", "0"));
        upgradeVideoCost = double.Parse(PlayerPrefs.GetString("upgradeVideoCost", "200"));
        upgradeVideoProduction = double.Parse(PlayerPrefs.GetString("upgradeVideoProduction", "1"));
        upgradeVideoAmount = double.Parse(PlayerPrefs.GetString("upgradeVideoAmount", "0"));
        
        motivationalClassCost = double.Parse(PlayerPrefs.GetString("motivationalClassCost", "500");
        motivationalClassProduction = double.Parse(PlayerPrefs.GetString("motivationalClassProduction", "0");
        motivationalClassAmount = double.Parse(PlayerPrefs.GetString("motivationalClassAmount", "0");
        upgradeMotivationalClassCost = double.Parse(PlayerPrefs.GetString("upgradeMotivationalClassCost", "1000");
        upgradeMotivationalClassProduction = double.Parse(PlayerPrefs.GetString("upgradeMotivationalClassProduction", "1");
        upgradeMotivationalClassAmount = double.Parse(PlayerPrefs.GetString("upgradeMotivationalClassAmount", "0");

        motivationalSpeakingCost = double.Parse(PlayerPrefs.GetString("motivationalSpeakingCost", "1000"));
        motivationalSpeakingProduction = double.Parse(PlayerPrefs.GetString("motivationalSpeakingProduction", "0"));
        motivationalSpeakingAmount = double.Parse(PlayerPrefs.GetString("motivationalSpeakingAmount", "0"));
        upgradeMotivationalSpeakingCost = double.Parse(PlayerPrefs.GetString("upgradeMotivationalSpeakingCost", "2000"));
        upgradeMotivationalSpeakingProduction = double.Parse(PlayerPrefs.GetString("upgradeMotivationalSpeakingProduction", "1"));
        upgradeMotivationalSpeakingAmount = double.Parse(PlayerPrefs.GetString("upgradeMotivationalSpeakingAmount", "0"));

        motivationalSerumCost = double.Parse(PlayerPrefs.GetString("motivationalSerumCost", "1500"));
        motivationalSerumProduction = double.Parse(PlayerPrefs.GetString("motivationalSerumProduction", "0"));
        motivationalSerumAmount = double.Parse(PlayerPrefs.GetString("motivationalSerumAmount", "0"));
        upgradeMotivationalSerumCost = double.Parse(PlayerPrefs.GetString("upgradeMotivationalSerumCost", "3000"));
        upgradeMotivationalSerumProduction = double.Parse(PlayerPrefs.GetString("upgradeMotivationalSerumProduction", "1"));
        upgradeMotivationalSerumAmount = double.Parse(PlayerPrefs.GetString("upgradeMotivationalSerumAmount", "0"));

        motivationalBookCost = double.Parse(PlayerPrefs.GetString("motivationalBookCost", "2000"));
        motivationalBookProduction = double.Parse(PlayerPrefs.GetString("motivationalBookProduction", "0"));
        motivationalBookAmount = double.Parse(PlayerPrefs.GetString("motivationalBookAmount", "0"));
        upgradeMotivationalBookCost = double.Parse(PlayerPrefs.GetString("upgradeMotivationalBookCost", "4000"));
        upgradeMotivationalBookProduction = double.Parse(PlayerPrefs.GetString("upgradeMotivationalBookProduction", "1"));
        upgradeMotivationalBookAmount = double.Parse(PlayerPrefs.GetString("upgradeMotivationalBookAmount", "0"));

        motivationalCultCost = double.Parse(PlayerPrefs.GetString("motivationalCultCost", "2500"));
        motivationalCultProduction = double.Parse(PlayerPrefs.GetString("motivationalCultProduction", "0"));
        motivationalCultAmount = double.Parse(PlayerPrefs.GetString("motivationalCultAmount", "0"));
        upgradeMotivationalCultCost = double.Parse(PlayerPrefs.GetString("upgradeMotivationalCultCost", "5000"));
        upgradeMotivationalCultProduction = double.Parse(PlayerPrefs.GetString("upgradeMotivationalCultProduction", "1"));
        upgradeMotivationalCultAmount = double.Parse(PlayerPrefs.GetString("upgradeMotivationalCultAmount", "0"));

        motivationalTEDTalksCost = double.Parse(PlayerPrefs.GetString("motivationalTEDTalksCost", "3000"));
        motivationalTEDTalksProduction = double.Parse(PlayerPrefs.GetString("motivationalTEDTalksProduction", "0"));
        motivationalTEDTalksAmount = double.Parse(PlayerPrefs.GetString("motivationalTEDTalksAmount", "0"));
        upgradeMotivationalTEDTalksCost = double.Parse(PlayerPrefs.GetString("upgradeMotivationalTEDTalksCost", "6000"));
        upgradeMotivationalTEDTalksProduction = double.Parse(PlayerPrefs.GetString("upgradeMotivationalTEDTalksProduction", "1"));
        upgradeMotivationalTEDTalksAmount = double.Parse(PlayerPrefs.GetString("upgradeMotivationalTEDTalksAmount", "0"));

        //double.Parse(PlayerPrefs.GetString(""))
    }

    public void save()
    {
       
        PlayerPrefs.SetString("currency", currency.ToString());
        PlayerPrefs.SetString("currencyPerClickValue", currencyPerClickValue.ToString());
        
        PlayerPrefs.SetString("bookCost", bookCost.ToString());
        PlayerPrefs.SetString("bookProduction", bookProduction.ToString());
        PlayerPrefs.SetString("bookAmount", bookAmount.ToString());
        PlayerPrefs.SetString("upgradeBookCost", upgradeBookCost.ToString());
        PlayerPrefs.SetString("upgradeBookProduction", upgradeBookProduction.ToString());
        PlayerPrefs.SetString("upgradeBookAmount", upgradeBookAmount.ToString());

        PlayerPrefs.SetString("posterCost", posterCost.ToString());
        PlayerPrefs.SetString("posterProduction", posterProduction.ToString());
        PlayerPrefs.SetString("posterAmount", posterAmount.ToString());
        PlayerPrefs.SetString("upgradePosterCost", upgradePosterCost.ToString());
        PlayerPrefs.SetString("upgradePosterProduction", upgradePosterProduction.ToString());
        PlayerPrefs.SetString("upgradePosterAmount", upgradePosterAmount.ToString());

        PlayerPrefs.SetString("videoCost", videoCost.ToString());
        PlayerPrefs.SetString("videoProduction", videoProduction.ToString());
        PlayerPrefs.SetString("videoAmount", videoAmount.ToString());
        PlayerPrefs.SetString("upgradeVideoCost", upgradeVideoCost.ToString());
        PlayerPrefs.SetString("upgradeVideoProduction", upgradeVideoProduction.ToString());
        PlayerPrefs.SetString("upgradeVideoAmount", upgradeVideoAmount.ToString());
        
        PlayerPrefs.SetString("motivationalClassCost", motivationalClassCost.ToString());
        PlayerPrefs.SetString("motivationalClassProduction", motivationalClassProduction.ToString());
        PlayerPrefs.SetString("motivationalClassAmount", motivationalClassAmount.ToString());
        PlayerPrefs.SetString("upgradeMotivationalClassCost", upgradeMotivationalClassCost.ToString());
        PlayerPrefs.SetString("upgradeMotivationalClassProduction", upgradeMotivationalClassProduction.ToString());
        PlayerPrefs.SetString("upgradeMotivationalClassAmount ", upgradeMotivationalClassAmount.ToString());

        PlayerPrefs.SetString("motivationalSpeakingCost", motivationalSpeakingCost.ToString());
        PlayerPrefs.SetString("motivationalSpeakingProduction", motivationalSpeakingProductio.ToString());
        PlayerPrefs.SetString("motivationalSpeakingAmount", motivationalSpeakingAmount.ToString());
        PlayerPrefs.SetString("upgradeMotivationalSpeakingCost", upgradeMotivationalSpeakingCost.ToString());
        PlayerPrefs.SetString("upgradeMotivationalSpeakingProduction", upgradeMotivationalSpeakingProduction.ToString());
        PlayerPrefs.SetString("upgradeMotivationalSpeakingAmount", upgradeMotivationalSpeakingAmount.ToString());

        PlayerPrefs.SetString("motivationalSerumCost", motivationalSerumCost.ToString());
        PlayerPrefs.SetString("motivationalSerumProduction", motivationalSerumProduction.ToString());
        PlayerPrefs.SetString("motivationalSerumAmount", motivationalSerumAmount.ToString);
        PlayerPrefs.SetString("upgradeMotivationalSerumCost", upgradeMotivationalSerumCost.ToString());
        PlayerPrefs.SetString("upgradeMotivationalSerumProduction", upgradeMotivationalSerumProduction.ToString());
        PlayerPrefs.SetString("upgradeMotivationalSerumAmount", upgradeMotivationalSerumAmount.ToString());

        PlayerPrefs.SetString("motivationalBookCost", motivationalBookCost.ToString())
        PlayerPrefs.SetString("motivationalBookProduction", motivationalBookProduction.ToString())
        PlayerPrefs.SetString("motivationalBookAmount", motivationalBookAmount.ToString())
        PlayerPrefs.SetString("upgradeMotivationalBookCost", upgradeMotivationalBookCost.ToString())
        PlayerPrefs.SetString("upgradeMotivationalBookProduction", upgradeMotivationalBookProduction.ToString())
        PlayerPrefs.SetString("upgradeMotivationalBookAmount", upgradeMotivationalBookAmount.ToString())

        PlayerPrefs.SetString("motivationalCultCost", motivationalCultCost.ToString());
        PlayerPrefs.SetString("motivationalCultProduction",motivationalCultProduction.ToString());
        PlayerPrefs.SetString("motivationalCultAmount", motivationalCultAmount.ToString());
        PlayerPrefs.SetString("upgradeMotivationalCultCost", upgradeMotivationalCultCost.ToString());
        PlayerPrefs.SetString("upgradeMotivationalCultProduction", upgradeMotivationalCultProduction.ToString());
        PlayerPrefs.SetString("upgradeMotivationalCultAmount", upgradeMotivationalCultAmount.ToString());

        PlayerPrefs.SetString("motivationalTEDTalksCost", motivationalTEDTalksCost.ToString());
        PlayerPrefs.SetString("motivationalTEDTalksProduction", motivationalTEDTalksProduction.ToString());
        PlayerPrefs.SetString("motivationalTEDTalksAmount", motivationalTEDTalksAmount.ToString());
        PlayerPrefs.SetString("upgradeMotivationalTEDTalksCost", upgradeMotivationalTEDTalksCost.ToString());
        PlayerPrefs.SetString("upgradeMotivationalTEDTalksProduction", upgradeMotivationalTEDTalksProduction.ToString());
        PlayerPrefs.SetString("upgradeMotivationalTEDTalksAmount", upgradeMotivationalTEDTalksAmount.ToString());
   
        //PlayerPrefs.SetString();
    }

    //function to calculate production
    void CalculateCurrency()
    {
        currencyPerSec = bookProduction + posterProduction + videoProduction + motivationalSpeakingProduction + motivationalClassProduction + motivationalSerumProduction + motivationalBookProduction + motivationalCultProduction + motivationalTEDTalksProduction;
        currency += currencyPerSec * Time.deltaTime; //multiple by delta time
    }

    void autoSave()
    {
        if(autoSaveTimer < 0)
        {
            save();
            autoSaveTimer = 30;
        }
        autoSaveTimer = autoSaveTimer - Time.deltaTime;
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

        autoSave();
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
