using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Upgrades
{
    private double baseCost;
    private double cost;
    private double amount;
    private double production;
    private string tooltip;
    private double buyMaxAmount;
    private int achievementKey;


    public double Cost
    {
        get;
        set;
    }

    public double Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }

    public double Production
    {
        get;
        set;
    }

    public double BuyMaxAmount
    {
        get
        {
            return buyMaxAmount;
        }
        set
        {
            buyMaxAmount = value;
        }
    }

    public int AchievementKey
    {
        get
        {
            return achievementKey;
        }
        set
        {
            achievementKey = value;
        }
    }

    public double BaseCost
    {
        get
        {
            return baseCost;
        }
        set
        {
            baseCost = value;
        }
    }

    //function to convert numbers larger than 1000 into scientific notation
    string ExponentConvert(double amount)
    {   
        string returnString;
        if(amount > 10000)
        {
            double exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(amount))));
            double shrunkValue = (amount / System.Math.Pow(10, exponent));
            return returnString = shrunkValue.ToString("F3") + "e" + exponent.ToString();
        }
        else
            return returnString = amount.ToString("F3");
    }

    public string ToolTip
    {
        get
        {
            return "Cost: " + ExponentConvert(Cost) + "\nProduction: " + ExponentConvert(Production) + "\nAmount: " + ExponentConvert(Amount);
        }
    }

    public double Buy(double currency, double prodIncrease, double costIncrease, int achievementKey)
    {
        currency -= Cost;
        Production += prodIncrease;
        Amount += 1;
        Cost *= System.Math.Pow(costIncrease,Amount);
        AchievementClass.CheckUpgradeAchievement(Amount, achievementKey);
        AchievementManager.instance.SetAchievementProgress((int) achievementKey, (int)Amount);
        return currency;
    }

    public double CalcBuyMax(double currency, double costIncrease)
    {
        //figure out the cost of a single purchase
        double singlePurchase = BaseCost * System.Math.Pow(costIncrease, Amount);
         //BuyMaxAmount = System.Math.Floor(System.Math.Log(1 + ((costIncrease - 1) * currency / singlePurchase)) / System.Math.Log(costIncrease));
        //Debug.Log("a single purchase is " + singlePurchase);
        
        BuyMaxAmount = System.Math.Floor(System.Math.Log(1 + ((costIncrease - 1) * currency / singlePurchase)) / System.Math.Log(costIncrease));
        //Debug.Log("Buy max amount is " + BuyMaxAmount.ToString("F0"));
        //make sure it displays something
        if(singlePurchase > currency)
        {
            return 0;
        }        

        return BuyMaxAmount;
    }

    public double BuyMax(double currency, double prodIncrease, double costIncrease, int achievementKey)
    {

        double singlePurchase = BaseCost * System.Math.Pow(costIncrease,Amount);
        double newCost = BaseCost * (System.Math.Pow(costIncrease, Amount)*(System.Math.Pow(costIncrease, BuyMaxAmount)-1) / (costIncrease -1));
        
        if(currency >= newCost)
        {
            currency = currency - newCost;
            Amount += BuyMaxAmount;
            Production += prodIncrease * Amount;
            Cost = BaseCost * System.Math.Pow(costIncrease,Amount);
        }

        return currency;
    }
}
