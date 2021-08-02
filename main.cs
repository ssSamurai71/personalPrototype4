using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    //miscellaneous
    public double currency, currencyPerSec, autoSaveTimer, achievementBoost;
    public Text currencyText, currencyPerSecText;

    
    //buildings
    Building wisp = new Building(), bush = new Building(), smallTree = new Building(), largeTree = new Building();
    Building grove = new Building(), druid = new Building(), forestGuard = new Building(), ent = new Building();

    //upgrades
    Upgrades wispUpgrade = new Upgrades(), bushUpgrade = new Upgrades(), smallTreeUpgrade = new Upgrades(), largeTreeUpgrade = new Upgrades();
    Upgrades groveUpgrade = new Upgrades(), druidUpgrade = new Upgrades(), forestGuardUpgrade = new Upgrades(), entUpgrade = new Upgrades();

    //building and upgrade Text (collapse these lines a bit more)
    public Text wispText, bushText, smallTreeText, largeTreeText;
    public Text groveText, druidText, forestGuardText, entText;
    public Text buyMaxWispText,buyMaxBushText,buyMaxSmallTreeText,buyMaxLargeTreeText;
    public Text buyMaxGroveText,buyMaxDruidText,buyMaxForestGuardText,buyMaxEntText;

    public Text wispUpgradeText, bushUpgradeText, smallTreeUpgradeText, largeTreeUpgradeText;
    public Text groveUpgradeText, druidUpgradeText, forestGuardUpgradeText, entUpgradeText;
    public Text buyMaxWispUpgradeText,buyMaxBushUpgradeText,buyMaxSmallTreeUpgradeText,buyMaxLargeTreeUpgradeText;
    public Text buyMaxGroveUpgradeText,buyMaxDruidUpgradeText,buyMaxForestGuardUpgradeText,buyMaxEntUpgradeText;
    public Text buyMaxClickUpUpgradeText, buyMaxClickUpPercentUpgradeText; 

    //cost increase values (NO MAGIC NUMBERS)
    double wispCostIncrease = 1.3, bushCostIncrease = 1.4, smallTreeCostIncrease = 1.5, largeTreeCostIncrease = 1.6;
    double groveCostIncrease = 1.7, druidCostIncrease = 1.8, forestGuardCostIncrease = 1.9, entCostIncrease = 2;
    double wispUpgradeCostIncrease = 1.5, bushUpgradeCostIncrease = 1.6, smallTreeUpgradeCostIncrease = 1.7, largeTreeUpgradeCostIncrease = 1.8;
    double groveUpgradeCostIncrease = 1.9, druidUpgradeCostIncrease = 2, forestGuardUpgradeCostIncrease = 2.1, entUpgradeCostIncrease = 2.2;
    double clickUpCostIncrease = 1.3, clickUpPercentCostIncrease = 1.3;

    //production numbers (NO MAGIC NUMBERS)
    double wispProduction = 1, bushProduction = 5, smallTreeProduction = 20, largeTreeProduction = 100;
    double groveProduction = 500, druidProduction = 1000, forestGuardProduction = 5000, entProduction = 10000;
    double wispUpgradeProduction = 0.1, bushUpgradeProduction = 0.2, smallTreeUpgradeProduction = 0.3, largeTreeUpgradeProduction = 0.4;
    double groveUpgradeProduction = 0.5, druidUpgradeProduction = 0.6, forestGuardUpgradeProduction = 0.7, entUpgradeProduction = 0.8;
    double clickUpProduction = 1, clickUpPercentProduction = 0.005;
    
    //season mechanics here
    SeasonMech seasonInfo = new SeasonMech(); 
    Upgrades improveSummer = new Upgrades(), improveWinter = new Upgrades(), improveSpring = new Upgrades(), improveFall = new Upgrades();

    public Text seasonCostText, seasonInfoText;

        //have text for the season upgrades
    public Text summerUpgradeText, winterUpgradeText, springUpgradeText, fallUpgradeText; 

    //clicking info
    /*
        Ask about mechanic on having different base values 
        public List<BaseTree>= treeInfo = new List<BaseTree>=();
    */
    BaseTree clickTree = new BaseTree();
    Upgrades clickValueUp = new Upgrades();
    Upgrades clickPercentUp = new Upgrades();
    public Text clickValueText, clickValueUpText, clickPercentUpText;

    //new game plus stuff 
    NGPlus biChromaticButterfly = new NGPlus();
    public Text currentBiChromaticButterflyText, NGPlustBiChromaticButterflyText;

    //stuff for sprites
    public Sprite wispSprite, bushSprite, smallTreeSprite, largeTreeSprite;
    public Sprite groveSprite, druidSprite, forestGuardSprite, entSprite;
    enum buildingEnum {wispEnum, bushEnum, smallTreeEnum, largeTreeEnum, groveEnum, druidEnum, forestGuardEnum, entEnum}
    string [] buildingNames = new string[] { "wispBuilding", "bushBuilding", "smallTreeBuilding", "largeTreeBuilding", "groveBuilding", "druidBuilding", "forestGuardBuilding", "entBuilding"};
    static public List <GameObject> spriteList = new List <GameObject>();

    //need a way to close application on build. Can't forget this one
    public void closeApplication()
    {
        Application.Quit();
    }

    //function to convert numbers larger than 1000 into scientific notation
    string ExponentConvert(double amount)
    {   
        string returnString;
        if(amount >= 100000000)
        {
            double exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(amount))));
            double shrunkValue = (amount / System.Math.Pow(10, exponent));
            return returnString = shrunkValue.ToString("F4") + "e" + exponent.ToString();
        }
        else
            return returnString = amount.ToString("F2");
    }

    //basic click function
    public void click()
    {
        currency += clickTree.BaseValue + (clickTree.UpgradedValue - 1);
    }

    void Save()
    {
        //miscellaneuos
        PlayerPrefs.SetString("currency", currency.ToString());
        PlayerPrefs.SetString("achievementBoost", achievementBoost.ToString());

        //buildings
        PlayerPrefs.SetString("wisp.Cost", wisp.Cost.ToString());
        PlayerPrefs.SetString("wisp.Production", wisp.Production.ToString());
        PlayerPrefs.SetString("wisp.Amount", wisp.Amount.ToString());
        PlayerPrefs.SetString("wisp.UpgradedProduction", wisp.UpgradedProduction.ToString());
        PlayerPrefs.SetString("wisp.BaseProduction", wisp.BaseProduction.ToString());
        PlayerPrefs.SetString("wisp.AchievementKey", wisp.AchievementKey.ToString());
        
        PlayerPrefs.SetString("bush.Cost", bush.Cost.ToString());
        PlayerPrefs.SetString("bush.Production", bush.Production.ToString());
        PlayerPrefs.SetString("bush.Amount", bush.Amount.ToString());
        PlayerPrefs.SetString("bush.UpgradedProduction", bush.UpgradedProduction.ToString());
        PlayerPrefs.SetString("bush.BaseProduction", bush.BaseProduction.ToString());
        PlayerPrefs.SetString("bush.AchievementKey", bush.AchievementKey.ToString());

        PlayerPrefs.SetString("smallTree.Cost", smallTree.Cost.ToString());
        PlayerPrefs.SetString("smallTree.Production", smallTree.Production.ToString());
        PlayerPrefs.SetString("smallTree.Amount", smallTree.Amount.ToString());
        PlayerPrefs.SetString("smallTree.UpgradedProduction", smallTree.UpgradedProduction.ToString());
        PlayerPrefs.SetString("smallTree.BaseProduction", smallTree.BaseProduction.ToString());
        PlayerPrefs.SetString("smallTree.AchievementKey", smallTree.AchievementKey.ToString());

        PlayerPrefs.SetString("largeTree.Cost", largeTree.Cost.ToString());
        PlayerPrefs.SetString("largeTree.Production", largeTree.Production.ToString());
        PlayerPrefs.SetString("largeTree.Amount", largeTree.Amount.ToString());
        PlayerPrefs.SetString("largeTree.UpgradedProduction", largeTree.UpgradedProduction.ToString());
        PlayerPrefs.SetString("largeTree.BaseProduction", largeTree.BaseProduction.ToString());
        PlayerPrefs.SetString("largeTree.AchievementKey", largeTree.AchievementKey.ToString());

        PlayerPrefs.SetString("grove.Cost", grove.Cost.ToString());
        PlayerPrefs.SetString("grove.Production", grove.Production.ToString());
        PlayerPrefs.SetString("grove.Amount", grove.Amount.ToString());
        PlayerPrefs.SetString("grove.UpgradedProduction", grove.UpgradedProduction.ToString());
        PlayerPrefs.SetString("grove.BaseProduction", grove.BaseProduction.ToString());
        PlayerPrefs.SetString("grove.AchievementKey", grove.AchievementKey.ToString());

        PlayerPrefs.SetString("druid.Cost", druid.Cost.ToString());
        PlayerPrefs.SetString("druid.Production", druid.Production.ToString());
        PlayerPrefs.SetString("druid.Amount", druid.Amount.ToString());
        PlayerPrefs.SetString("druid.UpgradedProduction", druid.UpgradedProduction.ToString());
        PlayerPrefs.SetString("druid.BaseProduction", druid.BaseProduction.ToString());
        PlayerPrefs.SetString("druid.AchievementKey", druid.AchievementKey.ToString());

        PlayerPrefs.SetString("forestGuard.Cost", forestGuard.Cost.ToString());
        PlayerPrefs.SetString("forestGuard.Production", forestGuard.Production.ToString());
        PlayerPrefs.SetString("forestGuard.Amount", forestGuard.Amount.ToString());
        PlayerPrefs.SetString("forestGuard.UpgradedProduction", forestGuard.UpgradedProduction.ToString());
        PlayerPrefs.SetString("forestGuard.BaseProduction", forestGuard.BaseProduction.ToString());
        PlayerPrefs.SetString("forestGuard.AchievementKey", forestGuard.AchievementKey.ToString());

        PlayerPrefs.SetString("ent.Cost", ent.Cost.ToString());
        PlayerPrefs.SetString("ent.Production", ent.Production.ToString());
        PlayerPrefs.SetString("ent.Amount", ent.Amount.ToString());
        PlayerPrefs.SetString("ent.UpgradedProduction", ent.UpgradedProduction.ToString());
        PlayerPrefs.SetString("ent.BaseProduction", ent.BaseProduction.ToString());
        PlayerPrefs.SetString("ent.AchievementKey", ent.AchievementKey.ToString());

        //upgrade  
        PlayerPrefs.SetString("wispUpgrade.Cost", wispUpgrade.Cost.ToString());
        PlayerPrefs.SetString("wispUpgrade.Production", wispUpgrade.Production.ToString());
        PlayerPrefs.SetString("wispUpgrade.Amount", wispUpgrade.Amount.ToString());
        PlayerPrefs.SetString("wispUpgrade.AchievementKey", wispUpgrade.AchievementKey.ToString());

        PlayerPrefs.SetString("bushUpgrade.Cost", bushUpgrade.Cost.ToString());
        PlayerPrefs.SetString("bushUpgrade.Production", bushUpgrade.Production.ToString());
        PlayerPrefs.SetString("bushUpgrade.Amount", bushUpgrade.Amount.ToString());
        PlayerPrefs.SetString("bushUpgrade.AchievementKey", bushUpgrade.AchievementKey.ToString());

        PlayerPrefs.SetString("smallTreeUpgrade.Cost", smallTreeUpgrade.Cost.ToString());
        PlayerPrefs.SetString("smallTreeUpgrade.Production", smallTreeUpgrade.Production.ToString());
        PlayerPrefs.SetString("smallTreeUpgrade.Amount", smallTreeUpgrade.Amount.ToString());
        PlayerPrefs.SetString("smallTreeUpgrade.AchievementKey", smallTreeUpgrade.AchievementKey.ToString());

        PlayerPrefs.SetString("largeTreeUpgrade.Cost", largeTreeUpgrade.Cost.ToString());
        PlayerPrefs.SetString("largeTreeUpgrade.Production", largeTreeUpgrade.Production.ToString());
        PlayerPrefs.SetString("largeTreeUpgrade.Amount", largeTreeUpgrade.Amount.ToString());
        PlayerPrefs.SetString("largeTreeUpgrade.AchievementKey", largeTreeUpgrade.AchievementKey.ToString());

        PlayerPrefs.SetString("groveUpgrade.Cost", groveUpgrade.Cost.ToString());
        PlayerPrefs.SetString("groveUpgrade.Production", groveUpgrade.Production.ToString());
        PlayerPrefs.SetString("groveUpgrade.Amount", groveUpgrade.Amount.ToString());
        PlayerPrefs.SetString("groveUpgrade.AchievementKey", groveUpgrade.AchievementKey.ToString());

        PlayerPrefs.SetString("druidUpgrade.Cost", druidUpgrade.Cost.ToString());
        PlayerPrefs.SetString("druidUpgrade.Production", druidUpgrade.Production.ToString());
        PlayerPrefs.SetString("druidUpgrade.Amount", druidUpgrade.Amount.ToString());
        PlayerPrefs.SetString("druidUpgrade.AchievementKey", druidUpgrade.AchievementKey.ToString());

        PlayerPrefs.SetString("forestGuarddUpgrade.Cost", forestGuardUpgrade.Cost.ToString());
        PlayerPrefs.SetString("forestGuardUpgrade.Production", forestGuardUpgrade.Production.ToString());
        PlayerPrefs.SetString("forestGuardUpgrade.Amount", forestGuardUpgrade.Amount.ToString());
        PlayerPrefs.SetString("forestGuardUpgrade.AchievementKey", forestGuardUpgrade.AchievementKey.ToString());

        PlayerPrefs.SetString("entUpgrade.Cost", entUpgrade.Cost.ToString());
        PlayerPrefs.SetString("entUpgrade.Production", entUpgrade.Production.ToString());
        PlayerPrefs.SetString("entUpgrade.Amount", entUpgrade.Amount.ToString());
        PlayerPrefs.SetString("entUpgrade.AchievementKey", entUpgrade.AchievementKey.ToString());

        //New game plus   
        PlayerPrefs.SetString("biChromaticButterfly.CurrentAmount",biChromaticButterfly.CurrentAmount.ToString());
        PlayerPrefs.SetString("biChromaticButterfly.NGPlusAmount",biChromaticButterfly.NGPlusAmount.ToString());
        PlayerPrefs.SetString("biChromaticButterfly.CurrentAmountBoost",biChromaticButterfly.CurrentAmountBoost.ToString());
        PlayerPrefs.SetString("biChromaticButterfly.NGPlusAmountBoost",biChromaticButterfly.NGPlusAmountBoost.ToString());    
        PlayerPrefs.SetString("biChromaticButterfly.RunCurrency", biChromaticButterfly.RunCurrency.ToString());
    
        //seasons info
        PlayerPrefs.SetString("seasonInfo.SeasonTimer", seasonInfo.SeasonTimer.ToString());
        PlayerPrefs.SetString("seasonInfo.SummerBoost",seasonInfo.SummerBoost.ToString());
        PlayerPrefs.SetString("seasonInfo.WinterBoost",seasonInfo.WinterBoost.ToString());
        PlayerPrefs.SetString("seasonInfo.FallBoost",seasonInfo.FallBoost.ToString());
        PlayerPrefs.SetString("seasonInfo.SpringBoost",seasonInfo.SpringBoost.ToString());
        PlayerPrefs.SetString("seasonInfo.ActiveBoost", seasonInfo.ActiveBoost.ToString());
        PlayerPrefs.SetString("seasonInfo.SwitchCost", seasonInfo.SwitchCost.ToString());
        PlayerPrefs.SetString("seasonInfo.TimesSwitched", seasonInfo.TimesSwitched.ToString());

        PlayerPrefs.SetString("improveFall.Cost", improveFall.Cost.ToString());
        PlayerPrefs.SetString("improveFall.Production", improveFall.Production.ToString());
        PlayerPrefs.SetString("improveFall.Amount", improveFall.Amount.ToString());

        PlayerPrefs.SetString("improveSummer.Cost", improveSummer.Cost.ToString());
        PlayerPrefs.SetString("improveSummer.Production", improveSummer.Production.ToString());
        PlayerPrefs.SetString("improveSummer.Amount", improveSummer.Amount.ToString());

        PlayerPrefs.SetString("improveSpring.Cost", improveSpring.Cost.ToString());
        PlayerPrefs.SetString("improveSpring.Production", improveSpring.Production.ToString());
        PlayerPrefs.SetString("improveSpring.Amount", improveSpring.Amount.ToString());

        PlayerPrefs.SetString("improveWinter.Cost", improveFall.Cost.ToString());
        PlayerPrefs.SetString("improveWinter.Production", improveFall.Production.ToString());
        PlayerPrefs.SetString("improveWinter.Amount", improveFall.Amount.ToString());
    
        //clicking stuff
        PlayerPrefs.SetString("clickValueUp.Cost",clickValueUp.Cost.ToString());
        PlayerPrefs.SetString("clickValueUp.Amount", clickValueUp.Amount.ToString());
        PlayerPrefs.SetString("clickValueUp.Production", clickValueUp.Production.ToString());

        PlayerPrefs.SetString("clickPercentUp.Cost", clickPercentUp.Cost.ToString());
        PlayerPrefs.SetString("clickPercentUp.Amount", clickPercentUp.Amount.ToString());
        PlayerPrefs.SetString("clickPercentUp.Production", clickPercentUp.Production.ToString());
    }

    void Load()
    {
        //double.Parse(PlayerPrefs.GetString("" , ""));
        //miscellaneous
        currency = double.Parse(PlayerPrefs.GetString("currency" , "0"));
        clickTree.BaseValue = double.Parse(PlayerPrefs.GetString("clickTree.BaseValue" , "1"));
        clickTree.TreeName = PlayerPrefs.GetString("clickTree.TreeName" , "Tree");
        seasonInfo.SeasonTimer = double.Parse(PlayerPrefs.GetString("seasonInfo.SeasonTimer" , "3600"));
        achievementBoost = double.Parse(PlayerPrefs.GetString("achievementBoost", "0"));

        //building
        wisp.Cost = double.Parse(PlayerPrefs.GetString("wisp.Cost" , "10"));
        wisp.Production = double.Parse(PlayerPrefs.GetString("wisp.Production" , "0"));
        wisp.Amount = double.Parse(PlayerPrefs.GetString("wisp.Amount" , "0"));
        wisp.UpgradedProduction = double.Parse(PlayerPrefs.GetString("wisp.UpgradedProduction" , "0"));
        wisp.BaseProduction = double.Parse(PlayerPrefs.GetString("wisp.BaseProduction" , "1"));
        wisp.AchievementKey = int.Parse(PlayerPrefs.GetString("wisp.AchievementKey","0"));
        wisp.BaseCost = double.Parse(PlayerPrefs.GetString("wisp.BaseCost" , "10"));

        bush.Cost = double.Parse(PlayerPrefs.GetString("bush.Cost" , "50"));
        bush.Production = double.Parse(PlayerPrefs.GetString("bush.Production" , "0"));
        bush.Amount = double.Parse(PlayerPrefs.GetString("bush.Amount" , "0"));
        bush.UpgradedProduction = double.Parse(PlayerPrefs.GetString("bush.UpgradedProduction" , "0"));
        bush.BaseProduction = double.Parse(PlayerPrefs.GetString("bush.BaseProduction" , "5"));
        bush.AchievementKey = int.Parse(PlayerPrefs.GetString("bush.AchievementKey","10"));
        bush.BaseCost = double.Parse(PlayerPrefs.GetString("bush.BaseCost" , "50"));

        smallTree.Cost = double.Parse(PlayerPrefs.GetString("smallTree.Cost" , "100"));
        smallTree.Production = double.Parse(PlayerPrefs.GetString("smallTree.Production" , "0"));
        smallTree.Amount = double.Parse(PlayerPrefs.GetString("smallTree.Amount" , "0"));
        smallTree.UpgradedProduction = double.Parse(PlayerPrefs.GetString("smallTree.UpgradedProduction" , "0"));
        smallTree.BaseProduction = double.Parse(PlayerPrefs.GetString("smallTree.BaseProduction" , "20"));
        smallTree.AchievementKey = int.Parse(PlayerPrefs.GetString("smallTree.AchievementKey","20"));
        smallTree.BaseCost = double.Parse(PlayerPrefs.GetString("smallTree.BaseCost" , "100"));
        
        largeTree.Cost = double.Parse(PlayerPrefs.GetString("largeTree.Cost" , "500"));
        largeTree.Production = double.Parse(PlayerPrefs.GetString("largeTree.Production" , "0"));
        largeTree.Amount = double.Parse(PlayerPrefs.GetString("largeTree.Amount" , "0"));
        largeTree.UpgradedProduction = double.Parse(PlayerPrefs.GetString("largeTree.UpgradedProduction" , "0"));
        largeTree.BaseProduction = double.Parse(PlayerPrefs.GetString("largeTree.BaseProduction" , "100"));
        largeTree.AchievementKey = int.Parse(PlayerPrefs.GetString("largeTree.AchievementKey","30"));
        largeTree.BaseCost = double.Parse(PlayerPrefs.GetString("largeTree.BaseCost" , "500"));

        grove.Cost = double.Parse(PlayerPrefs.GetString("grove.Cost" , "1000"));
        grove.Production = double.Parse(PlayerPrefs.GetString("grove.Production" , "0"));
        grove.Amount = double.Parse(PlayerPrefs.GetString("grove.Amount" , "0"));
        grove.UpgradedProduction = double.Parse(PlayerPrefs.GetString("grove.UpgradedProduction" , "0"));
        grove.BaseProduction = double.Parse(PlayerPrefs.GetString("grove.BaseProduction" , "500"));
        grove.AchievementKey = int.Parse(PlayerPrefs.GetString("grove.AchievementKey","40"));
        grove.BaseCost = double.Parse(PlayerPrefs.GetString("grove.BaseCost" , "1000"));
        
        druid.Cost = double.Parse(PlayerPrefs.GetString("druid.Cost" , "2000"));
        druid.Production = double.Parse(PlayerPrefs.GetString("druid.Production" , "0"));
        druid.Amount = double.Parse(PlayerPrefs.GetString("druid.Amount" , "0"));
        druid.UpgradedProduction = double.Parse(PlayerPrefs.GetString("druid.UpgradedProduction" , "0"));
        druid.BaseProduction = double.Parse(PlayerPrefs.GetString("druid.BaseProduction" , "1000"));
        druid.AchievementKey = int.Parse(PlayerPrefs.GetString("druid.AchievementKey","50"));
        druid.BaseCost = double.Parse(PlayerPrefs.GetString("druid.BaseCost" , "2000"));
        
        forestGuard.Cost = double.Parse(PlayerPrefs.GetString("forestGuard.Cost" , "4000"));
        forestGuard.Production = double.Parse(PlayerPrefs.GetString("forestGuard.Production" , "0"));
        forestGuard.Amount = double.Parse(PlayerPrefs.GetString("forestGuard.Amount" , "0"));
        forestGuard.UpgradedProduction = double.Parse(PlayerPrefs.GetString("forestGuard.UpgradedProduction" , "0"));
        forestGuard.BaseProduction = double.Parse(PlayerPrefs.GetString("forestGuard.BaseProduction" , "5000"));
        forestGuard.AchievementKey = int.Parse(PlayerPrefs.GetString("forestGuard.AchievementKey","60"));
        forestGuard.BaseCost = double.Parse(PlayerPrefs.GetString("forestGuard.BaseCost" , "4000"));

        ent.Cost = double.Parse(PlayerPrefs.GetString("ent.Cost" , "8000"));
        ent.Production = double.Parse(PlayerPrefs.GetString("ent.Production" , "0"));
        ent.Amount = double.Parse(PlayerPrefs.GetString("ent.Amount" , "0"));
        ent.UpgradedProduction = double.Parse(PlayerPrefs.GetString("ent.UpgradedProduction" , "0"));
        ent.BaseProduction = double.Parse(PlayerPrefs.GetString("ent.BaseProduction" , "10000"));
        ent.AchievementKey = int.Parse(PlayerPrefs.GetString("ent.AchievementKey","70"));
        ent.BaseCost = double.Parse(PlayerPrefs.GetString("ent.BaseCost" , "8000"));

        //upgrade
        wispUpgrade.Cost = double.Parse(PlayerPrefs.GetString("wispUpgrade.Cost" , "50"));
        wispUpgrade.Production = double.Parse(PlayerPrefs.GetString("wispUpgrade.Production" , "1"));
        wispUpgrade.Amount = double.Parse(PlayerPrefs.GetString("wispUpgrade.Amount" , "0"));
        wispUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("wispUpgrade.AchievementKey","80"));
        wispUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("wispUpgrade.BaseCost" , "50"));

        bushUpgrade.Cost = double.Parse(PlayerPrefs.GetString("bushUpgrade.Cost" , "100"));
        bushUpgrade.Production = double.Parse(PlayerPrefs.GetString("bushUpgrade.Production" , "1"));
        bushUpgrade.Amount = double.Parse(PlayerPrefs.GetString("bushUpgrade.Amount" , "0"));
        bushUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("bushUpgrade.AchievementKey","90"));
        bushUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("bushUpgrade.BaseCost" , "100"));

        smallTreeUpgrade.Cost = double.Parse(PlayerPrefs.GetString("smallTreeUpgrade.Cost" , "500"));
        smallTreeUpgrade.Production = double.Parse(PlayerPrefs.GetString("smallTreeUpgrade.Production" , "1"));
        smallTreeUpgrade.Amount = double.Parse(PlayerPrefs.GetString("smallTreeUpgrade.Amount" , "0"));
        smallTreeUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("smallTreeUpgrade.AchievementKey","100"));
        smallTreeUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("smallTreeUpgrade.BaseCost" , "500"));

        largeTreeUpgrade.Cost = double.Parse(PlayerPrefs.GetString("largeTreeUpgrade.Cost" , "1000"));
        largeTreeUpgrade.Production = double.Parse(PlayerPrefs.GetString("largeTreeUpgrade.Production" , "1"));
        largeTreeUpgrade.Amount = double.Parse(PlayerPrefs.GetString("largeTreeUpgrade.Amount" , "0"));
        largeTreeUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("largeTreeUpgrade.AchievementKey","110"));
        largeTreeUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("largeTreeUpgrade.BaseCost" , "1000"));

        groveUpgrade.Cost = double.Parse(PlayerPrefs.GetString("groveUpgrade.Cost" , "2000"));
        groveUpgrade.Production = double.Parse(PlayerPrefs.GetString("groveUpgrade.Production" , "1"));
        groveUpgrade.Amount = double.Parse(PlayerPrefs.GetString("groveUpgrade.Amount" , "0"));
        groveUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("groveUpgrade.AchievementKey","120"));
        groveUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("groveUpgrade.BaseCost" , "2000"));

        druidUpgrade.Cost = double.Parse(PlayerPrefs.GetString("druidUpgrade.Cost" , "4000"));
        druidUpgrade.Production = double.Parse(PlayerPrefs.GetString("druidUpgrade.Production" , "1"));
        druidUpgrade.Amount = double.Parse(PlayerPrefs.GetString("druidUpgrade.Amount" , "0"));
        druidUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("druidUpgrade.AchievementKey","130"));
        druidUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("druidUpgrade.BaseCost" , "4000"));

        forestGuardUpgrade.Cost = double.Parse(PlayerPrefs.GetString("forestGuardUpgrade.Cost" , "8000"));
        forestGuardUpgrade.Production = double.Parse(PlayerPrefs.GetString("forestGuardUpgrade.Production" , "1"));
        forestGuardUpgrade.Amount = double.Parse(PlayerPrefs.GetString("forestGuardUpgrade.Amount" , "0"));
        forestGuardUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("forestGuardUpgrade.AchievementKey","140"));
        forestGuardUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("forestGuardUpgrade.BaseCost" , "8000"));

        entUpgrade.Cost = double.Parse(PlayerPrefs.GetString("entUpgrade.Cost" , "16000"));
        entUpgrade.Production = double.Parse(PlayerPrefs.GetString("entUpgrade.Production" , "1"));
        entUpgrade.Amount = double.Parse(PlayerPrefs.GetString("entUpgrade.Amount" , "0"));
        entUpgrade.AchievementKey = int.Parse(PlayerPrefs.GetString("entUpgrade.AchievementKey","150"));
        entUpgrade.BaseCost = double.Parse(PlayerPrefs.GetString("entUpgrade.BaseCost" , "16000"));

        //NG+
        biChromaticButterfly.CurrentAmount = double.Parse(PlayerPrefs.GetString("biChromaticButterfly.CurrentAmount" , "0"));
        biChromaticButterfly.NGPlusAmount = double.Parse(PlayerPrefs.GetString("biChromaticButterfly.NGPlusAmount" , "0"));
        biChromaticButterfly.CurrentAmountBoost = double.Parse(PlayerPrefs.GetString("biChromaticButterfly.CurrentAmountBoost" , "0"));
        biChromaticButterfly.NGPlusAmountBoost = double.Parse(PlayerPrefs.GetString("biChromaticButterfly.NGPlusAmountBoost" , "0"));
        biChromaticButterfly.RunCurrency = double.Parse(PlayerPrefs.GetString("biChromaticButterfly.RunCurrency","0"));

        //season boosts
        seasonInfo.SummerBoost = double.Parse(PlayerPrefs.GetString("seasonInfo.SummerBoost" , "100"));
        seasonInfo.SpringBoost = double.Parse(PlayerPrefs.GetString("seasonInfo.SpringBoost" , "75"));
        seasonInfo.WinterBoost = double.Parse(PlayerPrefs.GetString("seasonInfo.WinterBoost" , "0"));
        seasonInfo.FallBoost = double.Parse(PlayerPrefs.GetString("seasonInfo.FallBoost" , "25"));
        seasonInfo.ActiveBoost = double.Parse(PlayerPrefs.GetString("seasonInfo.ActiveBoost" , "100"));
        seasonInfo.SwitchCost = double.Parse(PlayerPrefs.GetString("seasonInfo.SwitchCost" , "1000"));
        seasonInfo.TimesSwitched = double.Parse(PlayerPrefs.GetString("seasonInfo.TimesSwitched" , "0"));

        improveSpring.Cost = double.Parse(PlayerPrefs.GetString("improveSpring.Cost" , "1000")); 
        improveSpring.Production = double.Parse(PlayerPrefs.GetString("improveSpring.Production" , "1")); 
        improveSpring.Amount = double.Parse(PlayerPrefs.GetString("improveSpring.Amount" , "0")); 

        improveSummer.Cost = double.Parse(PlayerPrefs.GetString("improveSummer.Cost" , "1000")); 
        improveSummer.Production = double.Parse(PlayerPrefs.GetString("improveSummer.Production" , "1")); 
        improveSummer.Amount = double.Parse(PlayerPrefs.GetString("improveSummer.Amount" , "0")); 

        improveFall.Cost = double.Parse(PlayerPrefs.GetString("improveFall.Cost" , "1000")); 
        improveFall.Production = double.Parse(PlayerPrefs.GetString("improveFall.Production" , "1")); 
        improveFall.Amount = double.Parse(PlayerPrefs.GetString("improveFall.Amount" , "0")); 

        improveWinter.Cost = double.Parse(PlayerPrefs.GetString("improveWinter.Cost" , "1000")); 
        improveWinter.Production = double.Parse(PlayerPrefs.GetString("improveWinter.Production" , "1")); 
        improveWinter.Amount = double.Parse(PlayerPrefs.GetString("improveWinter.Amount" , "0")); 
        
        clickValueUp.Cost = double.Parse(PlayerPrefs.GetString("clickValueUp.Cost" , "10"));
        clickValueUp.BaseCost = double.Parse(PlayerPrefs.GetString("clickValueUp.BaseCost" , "10"));
        clickValueUp.Production = double.Parse(PlayerPrefs.GetString("clickValueUp.Production" , "1"));
        clickValueUp.Amount = double.Parse(PlayerPrefs.GetString("clickValueUp.Amount" , "0"));
        
        clickPercentUp.Cost = double.Parse(PlayerPrefs.GetString("clickPercentUp.Cost" , "100"));
        clickPercentUp.BaseCost = double.Parse(PlayerPrefs.GetString("clickPercentUp.BaseCost" , "100"));
        clickPercentUp.Production = double.Parse(PlayerPrefs.GetString("clickPercentUp.Production" , "100"));
        clickPercentUp.Amount = double.Parse(PlayerPrefs.GetString("clickPercentUp.Amount" , "0"));

        LoadSprites();
    }

    //auto save function
    void AutoSave()
    {
        if(autoSaveTimer < 0)
        {
            Save();
            autoSaveTimer = 30;
        }
        autoSaveTimer = autoSaveTimer - Time.deltaTime;
    }

    public void Reset()
    {
        //Miscelleanious 
        currency = 0;
        AchievementManager.instance.ResetAchievementState();
        achievementBoost = 0;

        //buildings
        wisp.Cost = 10;
        wisp.Production = 0;
        wisp.Amount = 0;
        wisp.UpgradedProduction = 0;
        wisp.BaseProduction = 1;
        wisp.AchievementKey = 0;

        bush.Cost = 50;
        bush.Production = 0;
        bush.Amount = 0;
        bush.UpgradedProduction = 0;
        bush.BaseProduction = 5;
        bush.AchievementKey = 10;

        smallTree.Cost = 100;
        smallTree.Production = 0;
        smallTree.Amount = 0;
        smallTree.UpgradedProduction = 0;
        smallTree.BaseProduction = 20;
        smallTree.AchievementKey = 20;

        largeTree.Cost = 500;
        largeTree.Production = 0;
        largeTree.Amount = 0;
        largeTree.UpgradedProduction = 0;
        largeTree.BaseProduction = 100;
        largeTree.AchievementKey = 30;

        grove.Cost = 1000;
        grove.Production = 0;
        grove.Amount = 0;
        grove.UpgradedProduction = 0;
        grove.BaseProduction = 500;
        grove.AchievementKey = 40;

        druid.Cost = 2000;
        druid.Production = 0;
        druid.Amount = 0;
        druid.UpgradedProduction = 0;
        druid.BaseProduction = 1000;
        druid.AchievementKey = 50;

        forestGuard.Cost = 4000;
        forestGuard.Production = 0;
        forestGuard.Amount = 0;
        forestGuard.UpgradedProduction = 0;
        forestGuard.BaseProduction = 5000;
        forestGuard.AchievementKey = 60;

        ent.Cost = 8000;
        ent.Production = 0;
        ent.Amount = 0;
        ent.UpgradedProduction = 0;
        ent.BaseProduction = 10000;
        ent.AchievementKey = 70;

        wisp.BuyMaxAmount = 0;
        bush.BuyMaxAmount = 0;
        smallTree.BuyMaxAmount = 0;
        largeTree.BuyMaxAmount = 0;
        grove.BuyMaxAmount = 0;
        druid.BuyMaxAmount = 0;
        forestGuard.BuyMaxAmount = 0;
        ent.BuyMaxAmount = 0;

        //upgrades
        wispUpgrade.Cost = 50;
        wispUpgrade.Production = 1;
        wispUpgrade.Amount = 0;
        wispUpgrade.AchievementKey = 80;

        bushUpgrade.Cost = 100;
        bushUpgrade.Production = 1;
        bushUpgrade.Amount = 0;
        bushUpgrade.AchievementKey = 90;

        smallTreeUpgrade.Cost = 500;
        smallTreeUpgrade.Production = 1;
        smallTreeUpgrade.Amount = 0;
        smallTreeUpgrade.AchievementKey = 100;

        largeTreeUpgrade.Cost = 1000;
        largeTreeUpgrade.Production = 1;
        largeTreeUpgrade.Amount = 0;
        largeTreeUpgrade.AchievementKey = 110;

        groveUpgrade.Cost = 2000;
        groveUpgrade.Production = 1;
        groveUpgrade.Amount = 0;
        groveUpgrade.AchievementKey = 120;

        druidUpgrade.Cost = 4000;
        druidUpgrade.Production = 1;
        druidUpgrade.Amount = 0;
        druidUpgrade.AchievementKey = 130;

        forestGuardUpgrade.Cost = 8000;
        forestGuardUpgrade.Production = 1;
        forestGuardUpgrade.Amount = 0;
        forestGuardUpgrade.AchievementKey = 140;

        entUpgrade.Cost = 16000;
        entUpgrade.Production = 1;
        entUpgrade.Amount = 0;
        entUpgrade.AchievementKey = 150;

        wispUpgrade.BuyMaxAmount = 0;
        bushUpgrade.BuyMaxAmount = 0;
        smallTreeUpgrade.BuyMaxAmount = 0;
        largeTreeUpgrade.BuyMaxAmount = 0;
        groveUpgrade.BuyMaxAmount = 0;
        druidUpgrade.BuyMaxAmount = 0;
        forestGuardUpgrade.BuyMaxAmount = 0;
        entUpgrade.BuyMaxAmount = 0;

        wispUpgrade.BaseCost = 50;
        bushUpgrade.BaseCost = 100;
        smallTreeUpgrade.BaseCost = 500;
        largeTreeUpgrade.BaseCost = 1000;
        groveUpgrade.BaseCost = 2000;
        druidUpgrade.BaseCost = 4000;
        forestGuardUpgrade.BaseCost = 8000;
        entUpgrade.BaseCost = 16000;

        //ng+
        biChromaticButterfly.NGCount = 0;
        biChromaticButterfly.NGPlusAmount = 0;
        biChromaticButterfly.NGPlusAmountBoost = 0;
        biChromaticButterfly.CurrentAmount = biChromaticButterfly.NGPlusAmount;
        biChromaticButterfly.CurrentAmountBoost = biChromaticButterfly.CurrentAmount;
        biChromaticButterfly.RunCurrency = 0;

        //season info
        seasonInfo.SeasonTimer = 3600;

        improveSpring.Cost = 10000; 
        improveSpring.Production = 1; 
        improveSpring.Amount = 0; 

        improveFall.Cost = 10000; 
        improveFall.Production = 1; 
        improveFall.Amount = 0; 

        improveSummer.Cost = 10000; 
        improveSummer.Production = 1; 
        improveSummer.Amount = 0; 

        improveWinter.Cost = 10000; 
        improveWinter.Production = 1; 
        improveWinter.Amount = 0; 

        seasonInfo.WinterBoost = 0;
        seasonInfo.SpringBoost = 75;
        seasonInfo.FallBoost = 25;
        seasonInfo.SummerBoost = 100;
        seasonInfo.SwitchCost = 1000;
        seasonInfo.TimesSwitched = 0;

        //click info
        clickTree.BaseValue = 1;

        clickValueUp.Cost = 10;
        clickValueUp.Production = 0;
        clickValueUp.Amount = 0;
        clickValueUp.BuyMaxAmount = 0;
        
        clickPercentUp.Cost = 100;
        clickPercentUp.Production = 0;
        clickPercentUp.Amount = 0;
        clickPercentUp.BuyMaxAmount = 0;

        DeleteAllSprites();
    }

    //constanly keep track of the upgraded production
    void UpdateBuildingProductionUpgrades()
    {
        double butterFlyBoost = (1 + biChromaticButterfly.CurrentAmountBoost);
        double achievementBoost = (1 + (AchievementManager.instance.GetAchievedPercentage()/100));
        wisp.UpgradedProduction = (wisp.Production * wispUpgrade.Production) * butterFlyBoost * achievementBoost ;
        bush.UpgradedProduction = (bush.Production * bushUpgrade.Production) * butterFlyBoost * achievementBoost;
        smallTree.UpgradedProduction = (smallTree.Production * smallTreeUpgrade.Production) * butterFlyBoost * achievementBoost;
        largeTree.UpgradedProduction = (largeTree.Production * largeTreeUpgrade.Production) * butterFlyBoost * achievementBoost;
        grove.UpgradedProduction = (grove.Production * groveUpgrade.Production) * butterFlyBoost * achievementBoost;
        druid.UpgradedProduction = (druid.Production * druidUpgrade.Production) * butterFlyBoost * achievementBoost;
        forestGuard.UpgradedProduction = (forestGuard.Production * forestGuardUpgrade.Production) * butterFlyBoost * achievementBoost;
        ent.UpgradedProduction = (ent.Production * entUpgrade.Production) * butterFlyBoost * achievementBoost;
        clickTree.UpgradedValue = (clickTree.BaseValue + clickValueUp.Production + ( (clickPercentUp.Production) * currencyPerSec)) * butterFlyBoost * achievementBoost;
    }

    void CalcCurrency()
    {
        double firstHalf = wisp.UpgradedProduction + bush.UpgradedProduction + smallTree.UpgradedProduction + largeTree.UpgradedProduction;
        double secondHalf = grove.UpgradedProduction + druid.UpgradedProduction + forestGuard.UpgradedProduction + ent.UpgradedProduction;
        currencyPerSec = (firstHalf + secondHalf) * (1+(seasonInfo.ActiveBoost / 100));
        currency += currencyPerSec * Time.deltaTime;
        currencyPerSecText.text = "Life/sec: " + ExponentConvert(currencyPerSec);
    }

    void calcNGPlus()
    {
        biChromaticButterfly.RunCurrency += currencyPerSec * Time.deltaTime;
        biChromaticButterfly.CalcNGPlus();

        currentBiChromaticButterflyText.text = "Current Run\nBichromaticButterflies: " + ExponentConvert(biChromaticButterfly.CurrentAmount) + "\nBoost: " + ExponentConvert(biChromaticButterfly.CurrentAmountBoost);
        NGPlustBiChromaticButterflyText.text = "Next Run\nBichromaticButterflies: " + ExponentConvert(biChromaticButterfly.NGPlusAmount) + "\nBoost: " + ExponentConvert(biChromaticButterfly.NGPlusAmountBoost);
    }

    public void StartNGPlus()
    {
        //buildings
        wisp.Cost = 10;
        wisp.Production = 0;
        wisp.Amount = 0;
        wisp.UpgradedProduction = 0;

        bush.Cost = 50;
        bush.Production = 0;
        bush.Amount = 0;
        bush.UpgradedProduction = 0;

        smallTree.Cost = 100;
        smallTree.Production = 0;
        smallTree.Amount = 0;
        smallTree.UpgradedProduction = 0;

        largeTree.Cost = 500;
        largeTree.Production = 0;
        largeTree.Amount = 0;
        largeTree.UpgradedProduction = 0;

        grove.Cost = 1000;
        grove.Production = 0;
        grove.Amount = 0;
        grove.UpgradedProduction = 0;

        druid.Cost = 2000;
        druid.Production = 0;
        druid.Amount = 0;
        druid.UpgradedProduction = 0;

        forestGuard.Cost = 4000;
        forestGuard.Production = 0;
        forestGuard.Amount = 0;
        forestGuard.UpgradedProduction = 0;

        ent.Cost = 8000;
        ent.Production = 0;
        ent.Amount = 0;
        ent.UpgradedProduction = 0;

        wisp.BuyMaxAmount = 0;
        bush.BuyMaxAmount = 0;
        smallTree.BuyMaxAmount = 0;
        largeTree.BuyMaxAmount = 0;
        grove.BuyMaxAmount = 0;
        druid.BuyMaxAmount = 0;
        forestGuard.BuyMaxAmount = 0;
        ent.BuyMaxAmount = 0;

        //upgrades
        wispUpgrade.Cost = 50;
        wispUpgrade.Production = 1;
        wispUpgrade.Amount = 0;

        bushUpgrade.Cost = 100;
        bushUpgrade.Production = 1;
        bushUpgrade.Amount = 0;

        smallTreeUpgrade.Cost = 500;
        smallTreeUpgrade.Production = 1;
        smallTreeUpgrade.Amount = 0;

        largeTreeUpgrade.Cost = 1000;
        largeTreeUpgrade.Production = 1;
        largeTreeUpgrade.Amount = 0;

        groveUpgrade.Cost = 2000;
        groveUpgrade.Production = 1;
        groveUpgrade.Amount = 0;

        druidUpgrade.Cost = 4000;
        druidUpgrade.Production = 1;
        druidUpgrade.Amount = 0;

        forestGuardUpgrade.Cost = 8000;
        forestGuardUpgrade.Production = 1;
        forestGuardUpgrade.Amount = 0;

        entUpgrade.Cost = 16000;
        entUpgrade.Production = 1;
        entUpgrade.Amount = 0;

        wispUpgrade.BuyMaxAmount = 0;
        bushUpgrade.BuyMaxAmount = 0;
        smallTreeUpgrade.BuyMaxAmount = 0;
        largeTreeUpgrade.BuyMaxAmount = 0;
        groveUpgrade.BuyMaxAmount = 0;
        druidUpgrade.BuyMaxAmount = 0;
        forestGuardUpgrade.BuyMaxAmount = 0;
        entUpgrade.BuyMaxAmount = 0;

        //season info
        seasonInfo.SeasonTimer = 3600;

        improveSpring.Cost = 10000; 
        improveSpring.Production = 1; 
        improveSpring.Amount = 0; 

        improveFall.Cost = 10000; 
        improveFall.Production = 1; 
        improveFall.Amount = 0; 

        improveSummer.Cost = 10000; 
        improveSummer.Production = 1; 
        improveSummer.Amount = 0; 

        improveWinter.Cost = 10000; 
        improveWinter.Production = 1; 
        improveWinter.Amount = 0; 

        seasonInfo.WinterBoost = 0;
        seasonInfo.SpringBoost = 75;
        seasonInfo.FallBoost = 25;
        seasonInfo.SummerBoost = 100;
        seasonInfo.SwitchCost = 1000;
        seasonInfo.TimesSwitched = 0;

        //click info
        clickTree.BaseValue = 1;

        clickValueUp.Cost = 10;
        clickValueUp.Production = 0;
        clickValueUp.Amount = 0;
        clickValueUp.BuyMaxAmount = 0;
        
        clickPercentUp.Cost = 100;
        clickPercentUp.Production = 0;
        clickPercentUp.Amount = 0;
        clickPercentUp.BuyMaxAmount = 0;

        //set the boost for new game plus
        biChromaticButterfly.NGCount += 1;
        biChromaticButterfly.CurrentAmount += biChromaticButterfly.NGPlusAmount;
        biChromaticButterfly.CurrentAmountBoost = biChromaticButterfly.CurrentAmount;
        biChromaticButterfly.NGPlusAmount = 0;
        biChromaticButterfly.NGPlusAmountBoost = 0;

        biChromaticButterfly.RunCurrency = 0;

        DeleteAllSprites();
    
        currency = 0;
    }

    void ToolTipText()
    {
        //building
        wispText.text = wisp.ToolTip;
        bushText.text = bush.ToolTip;
        smallTreeText.text = smallTree.ToolTip;
        largeTreeText.text = largeTree.ToolTip;
        groveText.text = grove.ToolTip;
        druidText.text = druid.ToolTip;
        forestGuardText.text = forestGuard.ToolTip;
        entText.text = ent.ToolTip;

        //upgrdes 
        wispUpgradeText.text = wispUpgrade.ToolTip;
        bushUpgradeText.text = bushUpgrade.ToolTip;
        smallTreeUpgradeText.text = smallTreeUpgrade.ToolTip;
        largeTreeUpgradeText.text = largeTreeUpgrade.ToolTip;
        groveUpgradeText.text = groveUpgrade.ToolTip;
        druidUpgradeText.text = druidUpgrade.ToolTip;
        forestGuardUpgradeText.text = forestGuardUpgrade.ToolTip;
        entUpgradeText.text = entUpgrade.ToolTip;

        //seasons
        summerUpgradeText.text = improveSummer.ToolTip;
        winterUpgradeText.text = improveWinter.ToolTip;
        springUpgradeText.text = improveSpring.ToolTip;
        fallUpgradeText.text = improveFall.ToolTip;
        seasonCostText.text =  "Cost: "+ ExponentConvert(seasonInfo.SwitchCost) + "\nTimes Switched: " + seasonInfo.TimesSwitched.ToString("F0");
    
        //clicking
        clickValueText.text = "Base Value: " +  ExponentConvert(clickTree.BaseValue) + "\nUpgraded Value: " + ExponentConvert(clickTree.UpgradedValue);
        clickValueUpText.text = clickValueUp.ToolTip;
        clickPercentUpText.text = clickPercentUp.ToolTip;

        //buyMax text
        buyMaxWispText.text = "Amount: " + wisp.BuyMaxAmount.ToString("F0");
        buyMaxBushText.text = "Amount: " + bush.BuyMaxAmount.ToString("F0");
        buyMaxSmallTreeText.text = "Amount: " + smallTree.BuyMaxAmount.ToString("F0");
        buyMaxLargeTreeText.text = "Amount: " + largeTree.BuyMaxAmount.ToString("F0");
        buyMaxGroveText.text = "Amount: " + grove.BuyMaxAmount.ToString("F0");
        buyMaxDruidText.text = "Amount: " + druid.BuyMaxAmount.ToString("F0"); 
        buyMaxForestGuardText.text = "Amount: " + forestGuard.BuyMaxAmount.ToString("F0");
        buyMaxEntText.text = "Amount: " + ent.BuyMaxAmount.ToString("F0");
    
        buyMaxWispUpgradeText.text = "Amount: " + wispUpgrade.BuyMaxAmount.ToString("F0");
        buyMaxBushUpgradeText.text = "Amount: " + bushUpgrade.BuyMaxAmount.ToString("F0");
        buyMaxSmallTreeUpgradeText.text = "Amount: " + smallTreeUpgrade.BuyMaxAmount.ToString("F0");
        buyMaxLargeTreeUpgradeText.text = "Amount: " + largeTreeUpgrade.BuyMaxAmount.ToString("F0");
        buyMaxGroveUpgradeText.text = "Amount: " + groveUpgrade.BuyMaxAmount.ToString("F0");
        buyMaxDruidUpgradeText.text = "Amount: " + druidUpgrade.BuyMaxAmount.ToString("F0"); 
        buyMaxForestGuardUpgradeText.text = "Amount: " + forestGuardUpgrade.BuyMaxAmount.ToString("F0");
        buyMaxEntUpgradeText.text = "Amount: " + entUpgrade.BuyMaxAmount.ToString("F0");
        buyMaxClickUpUpgradeText.text = "Amount: " + clickValueUp.BuyMaxAmount.ToString("F0");
        buyMaxClickUpPercentUpgradeText.text = "Amount: " + clickPercentUp.BuyMaxAmount.ToString("F0"); 
    }

    void CreateSprite(buildingEnum buildingEnum)
    {
        //range for x -6,9.5 :y -3,4.99
        float newXSpot , newYSpot;
        //Random.Range(-6.0f,9.5f), Random.Range(-3.0f,4.99f)

        GameObject spriteObject = new GameObject(buildingNames[(int) buildingEnum], typeof(SpriteRenderer));
        //spriteObject.transform.position = new Vector3(newXSpot, newYSpot, 0);

        switch (buildingEnum)
        {
            case buildingEnum.wispEnum:
                spriteObject.transform.localScale = new Vector3(5,5,1);
                newXSpot = Random.Range(-4.2f, 7.4f); newYSpot = Random.Range(-4.0f,4.2f);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                SpriteRenderer wispRender = spriteObject.GetComponent<SpriteRenderer>();
                wispRender.sprite = wispSprite; 
                wispRender.sortingOrder = 8;
                break;
            case buildingEnum.bushEnum:
                newXSpot = Random.Range(-4.2f,7f); newYSpot = Random.Range(-3.5f,-3.4f);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                spriteObject.transform.localScale = new Vector3(5,5,1);               
                SpriteRenderer bushRender = spriteObject.GetComponent<SpriteRenderer>();
                bushRender.sprite = bushSprite; 
                bushRender.sortingOrder = 8; 
                break;
            case buildingEnum.smallTreeEnum:
                newXSpot = Random.Range(-4.2f,7f); newYSpot = Random.Range(-3.2f,-2.2f);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                spriteObject.transform.localScale = new Vector3(6,8,1);
                SpriteRenderer smallTreeRender = spriteObject.GetComponent<SpriteRenderer>();
                smallTreeRender.sprite = smallTreeSprite;
                smallTreeRender.sortingOrder = 7;
                break;
            case buildingEnum.largeTreeEnum:
                newXSpot = Random.Range(-3.25f,7.8f); newYSpot = Random.Range(-1.71f,-0.48f);
                spriteObject.transform.localScale = new Vector3(12,16,1);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                SpriteRenderer largeTreeRender = spriteObject.GetComponent<SpriteRenderer>();
                largeTreeRender.sortingOrder = 6;
                largeTreeRender.sprite = largeTreeSprite;
                break;
            case buildingEnum.groveEnum:
                newXSpot = Random.Range(-3f,7.8f); newYSpot = Random.Range(-1.7f,-0.2f);
                spriteObject.transform.localScale = new Vector3(12,16,1);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                SpriteRenderer groveRender = spriteObject.GetComponent<SpriteRenderer>();
                groveRender.sprite = groveSprite;
                groveRender.sortingOrder = 5;
                break;
            case buildingEnum.druidEnum:
                newXSpot = Random.Range(-4.2f,7.56f); newYSpot = Random.Range(-3.4f,-2f);
                spriteObject.transform.localScale = new Vector3(5,5,1);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                SpriteRenderer druidRender= spriteObject.GetComponent<SpriteRenderer>();
                druidRender.sprite = druidSprite;
                druidRender.sortingOrder = 8;
                if(Random.value % 2 == 0)
                    druidRender.flipX = true;
                break;
            case buildingEnum.forestGuardEnum:
                newXSpot = Random.Range(-4.2f,7.56f); newYSpot = Random.Range(-3.4f,-2f);
                spriteObject.transform.localScale = new Vector3(5,5,1);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                SpriteRenderer forestGuardRender = spriteObject.GetComponent<SpriteRenderer>();
                forestGuardRender.sprite = forestGuardSprite;
                forestGuardRender.sortingOrder = 8;
                if(Random.value % 2 == 0)
                    forestGuardRender.flipX = true;
                break;
            case buildingEnum.entEnum:
                newXSpot = Random.Range(-3.0f,6f); newYSpot = Random.Range(-2.4f,-1f);
                spriteObject.transform.localScale = new Vector3(12, 12, 1);
                spriteObject.transform.position = new Vector3(newXSpot,newYSpot, 0);
                SpriteRenderer entRender = spriteObject.GetComponent<SpriteRenderer>();
                entRender.sprite = entSprite;
                entRender.sortingOrder = 7;
                if(Random.value % 2 == 0)
                    entRender.flipX = true;
                break;
  
            default:
                return;
        }
        spriteList.Add(spriteObject);
        Debug.Log(spriteList.Count);
    }

    void BuyMaxCreateSprite(double oldAmount, double newAmount, buildingEnum buildingEnum)
    {
        int difference = (int) System.Math.Floor(newAmount - oldAmount);
        for(int spritesMade = 0; spritesMade < difference; spritesMade++)
        {
            CreateSprite(buildingEnum);
        } 
    }

    //destroys all sprits when NG plus happens
    void DeleteAllSprites()
    {
        foreach (GameObject sprites in spriteList)
        {
            Destroy(sprites);
        }
    }

    //draws all sprites back onto the screen when loading
    void LoadSprites()
    {  
        for(int spriteIndex = 0; spriteIndex < wisp.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.wispEnum);
        }

        for(int spriteIndex = 0; spriteIndex < bush.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.bushEnum);
        }

        for(int spriteIndex = 0; spriteIndex < smallTree.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.smallTreeEnum);
        }

        for(int spriteIndex = 0; spriteIndex < largeTree.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.largeTreeEnum);
        }
        
        for(int spriteIndex = 0; spriteIndex < grove.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.groveEnum);
        }

        for(int spriteIndex = 0; spriteIndex < druid.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.druidEnum);
        }

        for(int spriteIndex = 0; spriteIndex < forestGuard.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.forestGuardEnum);
        }

        for(int spriteIndex = 0; spriteIndex < ent.Amount; spriteIndex++)
        {
            CreateSprite(buildingEnum.entEnum);
        }
    }

    //constanly keep track of the max amount of buildings
    void CalcBuyMax()
    {
        //buildings
        wisp.BuyMaxAmount = wisp.CalcBuyMax(currency, wispCostIncrease);
        //Debug.Log(wisp.BuyMaxAmount);
        bush.BuyMaxAmount = bush.CalcBuyMax(currency, bushCostIncrease);
        smallTree.BuyMaxAmount = smallTree.CalcBuyMax(currency, smallTreeCostIncrease);
        largeTree.BuyMaxAmount = largeTree.CalcBuyMax(currency, largeTreeCostIncrease);
        grove.BuyMaxAmount = grove.CalcBuyMax(currency, groveCostIncrease);
        druid.BuyMaxAmount = druid.CalcBuyMax(currency, druidCostIncrease);
        forestGuard.BuyMaxAmount = forestGuard.CalcBuyMax(currency, forestGuardCostIncrease);
        ent.BuyMaxAmount = ent.CalcBuyMax(currency, entCostIncrease);
        
        //upgrades
        wispUpgrade.BuyMaxAmount = wispUpgrade.CalcBuyMax(currency, wispUpgradeCostIncrease);
        bushUpgrade.BuyMaxAmount = bushUpgrade.CalcBuyMax(currency, bushUpgradeCostIncrease);
        smallTreeUpgrade.BuyMaxAmount = smallTreeUpgrade.CalcBuyMax(currency, smallTreeUpgradeCostIncrease);
        largeTreeUpgrade.BuyMaxAmount = largeTreeUpgrade.CalcBuyMax(currency, largeTreeUpgradeCostIncrease);
        groveUpgrade.BuyMaxAmount = groveUpgrade.CalcBuyMax(currency, groveUpgradeCostIncrease);
        druidUpgrade.BuyMaxAmount = druidUpgrade.CalcBuyMax(currency, druidUpgradeCostIncrease);
        forestGuardUpgrade.BuyMaxAmount = forestGuardUpgrade.CalcBuyMax(currency, forestGuardUpgradeCostIncrease);
        entUpgrade.BuyMaxAmount = entUpgrade.CalcBuyMax(currency, entUpgradeCostIncrease);
        clickValueUp.BuyMaxAmount = clickValueUp.CalcBuyMax(currency, clickUpCostIncrease);
        clickPercentUp.BuyMaxAmount = clickPercentUp.CalcBuyMax(currency, clickUpPercentCostIncrease);
    }

    
    //buildings 
    public void BuyWisp()
    {
        if(currency >= wisp.Cost)
        {
            //arguments: currency, production increase, cost increase. Function increase amount automaticly
            currency = wisp.Buy(currency, wispProduction, wispCostIncrease, wisp.AchievementKey);
            wisp.AchievementKey = AchievementClass.AssignNextKey(wisp.Amount, wisp.AchievementKey);
            CreateSprite(buildingEnum.wispEnum);
        }
    }

    public void BuyMaxWisp()
    {
        double oldAmount = wisp.Amount;
        currency = wisp.BuyMax(currency, wispProduction, wispCostIncrease, wisp.AchievementKey);
        wisp.AchievementKey = AchievementClass.CheckWispBuyMax(wisp.Amount);
        BuyMaxCreateSprite(oldAmount, wisp.Amount, buildingEnum.wispEnum);
    }
    
    public void BuyBush()
    {
        if(currency >= bush.Cost)
        {
            currency = bush.Buy(currency, bushProduction, bushCostIncrease, bush.AchievementKey);
            bush.AchievementKey = AchievementClass.AssignNextKey(bush.Amount, bush.AchievementKey);
            CreateSprite(buildingEnum.bushEnum);
        }
    }
    
    public void BuyMaxBush()
    {
        double oldAmount = bush.Amount;
        currency = bush.BuyMax(currency, bushProduction, bushCostIncrease, bush.AchievementKey);
        bush.AchievementKey = AchievementClass.CheckBushBuyMax(bush.Amount);
        BuyMaxCreateSprite(oldAmount, bush.Amount, buildingEnum.bushEnum);
    }

    public void BuySmallTree()
    {
        if(currency >= smallTree.Cost)
        {
            currency = smallTree.Buy(currency, smallTreeProduction, smallTreeCostIncrease, smallTree.AchievementKey);
            smallTree.AchievementKey = AchievementClass.AssignNextKey(smallTree.Amount, smallTree.AchievementKey);
            CreateSprite(buildingEnum.smallTreeEnum);
        }
    }

    public void BuyMaxSmallTree()
    {
        double oldAmount = smallTree.Amount;
        currency = smallTree.BuyMax(currency, smallTreeProduction,  smallTreeCostIncrease, smallTree.AchievementKey);
        bush.AchievementKey = AchievementClass.CheckSmallTreeBuyMax(smallTree.Amount);
        BuyMaxCreateSprite(oldAmount, smallTree.Amount, buildingEnum.smallTreeEnum);
    }

    public void BuyLargeTree()
    {
        if(currency >= largeTree.Cost)
        {
            currency = largeTree.Buy(currency, largeTreeProduction, largeTreeCostIncrease, largeTree.AchievementKey);
            largeTree.AchievementKey = AchievementClass.AssignNextKey(largeTree.Amount, largeTree.AchievementKey);
            CreateSprite(buildingEnum.largeTreeEnum);
        }
    }

    public void BuyMaxLargeTree()
    {
        double oldAmount = largeTree.Amount;
        currency = largeTree.BuyMax(currency, largeTreeProduction, largeTreeCostIncrease, largeTree.AchievementKey);
        largeTree.AchievementKey = AchievementClass.CheckLargeTreeBuyMax(largeTree.Amount);
        BuyMaxCreateSprite(oldAmount, largeTree.Amount, buildingEnum.largeTreeEnum);
    }

    public void BuyGrove()
    {
        if(currency >= grove.Cost)
        {
            currency = grove.Buy(currency, groveProduction, groveCostIncrease, grove.AchievementKey);
            grove.AchievementKey = AchievementClass.AssignNextKey(grove.Amount, grove.AchievementKey);
            CreateSprite(buildingEnum.groveEnum);
        }           
    }

    public void BuyMaxGrove()
    {
        double oldAmount = grove.Amount;
        currency = grove.BuyMax(currency, groveProduction, groveCostIncrease, grove.AchievementKey);
        grove.AchievementKey = AchievementClass.CheckGroveBuyMax(grove.Amount);
        BuyMaxCreateSprite(oldAmount, grove.Amount, buildingEnum.groveEnum);
    }

    public void BuyDruid()
    {
        if(currency >= druid.Cost)
        {
            currency = druid.Buy(currency, druidProduction, druidCostIncrease, druid.AchievementKey);
            druid.AchievementKey = AchievementClass.AssignNextKey(druid.Amount, druid.AchievementKey);
            CreateSprite(buildingEnum.druidEnum);
        }   
    }

    public void BuyMaxDruid()
    {
        double oldAmount = druid.Amount;
        currency = druid.BuyMax(currency, druidProduction, druidCostIncrease, druid.AchievementKey);
        druid.AchievementKey = AchievementClass.CheckDruidBuyMax(druid.Amount);
        BuyMaxCreateSprite(oldAmount, druid.Amount, buildingEnum.druidEnum);
    }

    public void BuyForestGuard()
    {
        if(currency >= forestGuard.Cost)
        {
            currency = forestGuard.Buy(currency, 5000, 1.16, forestGuard.AchievementKey);
            forestGuard.AchievementKey = AchievementClass.AssignNextKey(forestGuard.Amount, forestGuard.AchievementKey);
            CreateSprite(buildingEnum.forestGuardEnum);
        }  
    }

    public void BuyMaxForestGuard()
    {
        double oldAmount = forestGuard.Amount;
        currency = forestGuard.BuyMax(currency, forestGuardProduction, forestGuardCostIncrease, forestGuard.AchievementKey);
        forestGuard.AchievementKey = AchievementClass.CheckForestGuardBuyMax(forestGuard.Amount);
        BuyMaxCreateSprite(oldAmount, forestGuard.Amount, buildingEnum.forestGuardEnum);
    }

    public void BuyEnt()
    {
        if(currency >= ent.Cost)
        {
            currency = ent.Buy(currency, entProduction, entCostIncrease, ent.AchievementKey);
            ent.AchievementKey = AchievementClass.AssignNextKey(ent.Amount, ent.AchievementKey);
            CreateSprite(buildingEnum.entEnum);
        }      
    }

    public void BuyMaxEnt()
    {
        double oldAmount = ent.Amount;
        currency = ent.BuyMax(currency, entProduction, entCostIncrease, ent.AchievementKey);
        ent.AchievementKey = AchievementClass.CheckEntBuyMax(ent.Amount);
        BuyMaxCreateSprite(oldAmount, ent.Amount, buildingEnum.entEnum);
    }

    //upgrades
    public void BuyWispUpgrade()
    {
        if(currency >= wispUpgrade.Cost)
        {
            currency = wispUpgrade.Buy(currency, wispUpgradeProduction, wispUpgradeCostIncrease, wispUpgrade.AchievementKey);
            wispUpgrade.AchievementKey = AchievementClass.AssignNextKey(wispUpgrade.Amount, wispUpgrade.AchievementKey);
        }
    }
    
    public void BuyMaxWispUpgrade()
    {
        currency = wispUpgrade.BuyMax(currency, wispUpgradeProduction, wispUpgradeCostIncrease, wispUpgrade.AchievementKey);
        wispUpgrade.AchievementKey = AchievementClass.CheckWispUpgradeBuyMax(wispUpgrade.Amount);
    }

    public void BuyBushUpgrade()
    {
        if(currency >= bushUpgrade.Cost)
        {
            currency = bushUpgrade.Buy(currency, bushUpgradeProduction, bushUpgradeCostIncrease, bushUpgrade.AchievementKey);
            bushUpgrade.AchievementKey = AchievementClass.AssignNextKey(bushUpgrade.Amount, bushUpgrade.AchievementKey);
        }   
    }

    public void BuyMaxBushUpgrade()
    {
        currency = bushUpgrade.BuyMax(currency, bushUpgradeProduction, bushUpgradeCostIncrease, bushUpgrade.AchievementKey);
        bushUpgrade.AchievementKey = AchievementClass.CheckBushUpgradeBuyMax(bushUpgrade.Amount);
    }

    public void BuySmallTreeUpgrade()
    {
        if(currency >= smallTreeUpgrade.Cost)
        {
            currency = smallTreeUpgrade.Buy(currency, smallTreeUpgradeProduction, smallTreeUpgradeCostIncrease, smallTreeUpgrade.AchievementKey);   
            smallTreeUpgrade.AchievementKey = AchievementClass.AssignNextKey(smallTreeUpgrade.Amount, smallTreeUpgrade.AchievementKey);        
        }
    }

    public void BuyMaxSmallTreeUpgrade()
    {
        currency = smallTreeUpgrade.BuyMax(currency, smallTreeUpgradeProduction, smallTreeUpgradeCostIncrease, smallTreeUpgrade.AchievementKey);
        smallTreeUpgrade.AchievementKey = AchievementClass.CheckSmallTreeUpgradeBuyMax(smallTreeUpgrade.Amount);
    }

    public void BuyLargeTreeUpgrade()
    {
        if(currency >= largeTreeUpgrade.Cost)
        {
            currency = largeTreeUpgrade.Buy(currency, largeTreeUpgradeProduction, largeTreeUpgradeCostIncrease, largeTreeUpgrade.AchievementKey);
            largeTreeUpgrade.AchievementKey = AchievementClass.AssignNextKey(largeTreeUpgrade.Amount, largeTreeUpgrade.AchievementKey);
        }
    }

    public void BuyMaxLargeTreeUpgrade()
    {
        currency = largeTreeUpgrade.BuyMax(currency, largeTreeUpgradeProduction, largeTreeUpgradeCostIncrease, largeTreeUpgrade.AchievementKey);
        largeTreeUpgrade.AchievementKey = AchievementClass.CheckLargeTreeUpgradeBuyMax(largeTreeUpgrade.Amount);
    }

    public void BuyGroveUpgrade()
    {
        if(currency >= groveUpgrade.Cost)
        {
            currency = groveUpgrade.Buy(currency, groveUpgradeProduction, groveUpgradeCostIncrease, groveUpgrade.AchievementKey);
            groveUpgrade.AchievementKey = AchievementClass.AssignNextKey(groveUpgrade.Amount, groveUpgrade.AchievementKey);
        }
    }

    public void BuyMaxGroveUpgrade()
    {
        currency = groveUpgrade.BuyMax(currency, groveUpgradeProduction, groveUpgradeCostIncrease, groveUpgrade.AchievementKey);
        groveUpgrade.AchievementKey = AchievementClass.CheckGroveUpgradeBuyMax(groveUpgrade.Amount);
    }

    public void BuyDruidUpgrade()
    {
        if(currency >= druidUpgrade.Cost)
        {
            currency = druidUpgrade.Buy(currency, druidUpgradeProduction, druidUpgradeCostIncrease, druidUpgrade.AchievementKey);
            druidUpgrade.AchievementKey = AchievementClass.AssignNextKey(druidUpgrade.Amount, druidUpgrade.AchievementKey);
        }
    }

   public void BuyMaxDruidUpgrade()
    {
        currency = druidUpgrade.BuyMax(currency, druidUpgradeProduction, druidUpgradeCostIncrease, druidUpgrade.AchievementKey);
        druidUpgrade.AchievementKey = AchievementClass.CheckDruidUpgradeBuyMax(druidUpgrade.Amount);
    }

    public void BuyForestGuardUpgrade()
    {
        if(currency >= forestGuardUpgrade.Cost)
        {
            currency = forestGuardUpgrade.Buy(currency, forestGuardUpgradeProduction, forestGuardUpgradeCostIncrease, forestGuardUpgrade.AchievementKey);
            forestGuardUpgrade.AchievementKey = AchievementClass.AssignNextKey(forestGuardUpgrade.Amount, forestGuardUpgrade.AchievementKey);
        }
    }

    public void BuyMaxForestGuardUpgrade()
    {
        currency = forestGuardUpgrade.BuyMax(currency, forestGuardUpgradeProduction, forestGuardUpgradeCostIncrease, forestGuardUpgrade.AchievementKey);
        forestGuardUpgrade.AchievementKey = AchievementClass.CheckForestGuardUpgradeBuyMax(forestGuardUpgrade.Amount);
    }

    public void BuyEntUpgrade()
    {
        if(currency >= entUpgrade.Cost)
        {
            currency = entUpgrade.Buy(currency, entUpgradeProduction, entUpgradeCostIncrease, entUpgrade.AchievementKey);
            entUpgrade.AchievementKey = AchievementClass.AssignNextKey(entUpgrade.Amount, entUpgrade.AchievementKey);
        }        
    }

    public void BuyMaxEntUpgrade()
    {
        currency = entUpgrade.BuyMax(currency, entUpgradeProduction, entUpgradeCostIncrease, entUpgrade.AchievementKey);
        entUpgrade.AchievementKey = AchievementClass.CheckEntUpgradeBuyMax(entUpgrade.Amount);
    }

    public void BuyClickUpUpgrade()
    {
        if(currency >= clickValueUp.Cost)
            currency = clickValueUp.Buy(currency, clickUpProduction, clickUpCostIncrease,clickValueUp.AchievementKey);
    }

    public void BuyMaxClickUpgrade()
    {
        currency = clickValueUp.BuyMax(currency, clickUpProduction, clickUpCostIncrease, clickValueUp.AchievementKey);
    }

    public void BuyPercentUpgrade()
    {
        if(currency >= clickPercentUp.Cost)
            currency = clickPercentUp.Buy(currency, clickUpPercentProduction, clickUpPercentCostIncrease, clickPercentUp.AchievementKey);
        
    }

    public void BuyMaxPercentUpgrade()
    {
        currency = clickPercentUp.BuyMax(currency, clickUpPercentProduction, clickUpPercentCostIncrease, clickPercentUp.AchievementKey);
    }

    //season upgrades
    public void BuySummerUpgrade()
    {
        if(currency >= improveSummer.Cost)
        {
            currency = improveSummer.Buy(currency, 1, 3,improveSpring.AchievementKey);
            seasonInfo.SummerBoost += improveSummer.Production;
        }
    }

    public void BuyWinterUpgrade()
    {
        if(currency >= improveWinter.Cost)
        {
            currency = improveWinter.Buy(currency, 1, 3,improveWinter.AchievementKey);
            seasonInfo.WinterBoost += improveWinter.Production;
        }
    }

    public void BuyFallUpgrade()
    {
        if(currency >= improveFall.Cost)
        {
            currency = improveFall.Buy(currency, 1, 3,improveFall.AchievementKey);
            seasonInfo.FallBoost += improveFall.Production;
        }
    }

    public void BuySpringUpgrade()
    {
        if(currency >= improveSpring.Cost)
        {
            currency = improveSpring.Buy(currency, 1, 3,improveSpring.AchievementKey);
            seasonInfo.SpringBoost += improveSpring.Production;
        }
    }

    public void SwitchSeason()
    {
        if(currency >= seasonInfo.SwitchCost)
        {
            currency -= seasonInfo.SwitchCost;
            seasonInfoText.text = seasonInfo.ForceSwitch();
            seasonInfo.SwitchCost *= 2;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Load();    
        autoSaveTimer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //functions go first except the autosave
        UpdateBuildingProductionUpgrades();
        CalcCurrency();
        ToolTipText();
        calcNGPlus();

        //Debug.Log("wisp upgrade buy max amount is " + wispUpgrade.BuyMaxAmount);
        //Debug.Log("wisp upgrade amount is " + wispUpgrade.Amount);

        CalcBuyMax();
        //all text goes second
        seasonInfoText.text = seasonInfo.RotateSeason;
        currencyText.text = "Life: " + ExponentConvert(currency);
        biChromaticButterfly.CurrentAmountBoost = biChromaticButterfly.CurrentAmount;

        AutoSave();
    }
}