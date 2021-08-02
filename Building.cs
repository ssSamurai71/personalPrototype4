using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    private double baseCost;
    private double cost;
    private double amount = 0;
    private double production = 0;
    private double baseProduction;
    private double upgradedProduction = 0;
    private string tooltip;
    private double buyMaxAmount;
    private int achievementKey;

    public double Cost
    {
        get
        {
            return cost;
        }
        set
        {
            cost = value;
        }
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
        get
        {
            return production;
        }
        set
        {
            production = value;
        }
    }

    public double BaseProduction
    {
        get
        {
            return baseProduction;
        }
        set
        {
            baseProduction = value;
        }
    }

    public double UpgradedProduction
    {
        get
        {
            return upgradedProduction;
        }
        set
        {
            upgradedProduction = value;
        }
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
            if(value >= 0)
            {
                achievementKey = value;
            }
            else
            {
                achievementKey = -1;
            }
            
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
        if(amount > 100000)
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
            return "Cost: " + ExponentConvert(Cost) + "\nProduction: " + ExponentConvert(Production) + "\nProduction On Purchase: " + BaseProduction.ToString()   
            + "\nAmount: " + ExponentConvert(Amount) + "\nUpgraded Production: " + ExponentConvert(UpgradedProduction);
        }
    }

    public double Buy(double currency, double prodIncrease, double costIncrease, int achievementKey)
    {
        currency -= Cost;
        Production += prodIncrease;
        Amount += 1;
        Cost = BaseCost * System.Math.Pow(costIncrease,Amount);
        AchievementClass.CheckBuildingAchievement( Amount, achievementKey);
        AchievementManager.instance.SetAchievementProgress((int) achievementKey, (int)Amount);
        return currency;
    }

    public double CalcBuyMax(double currency, double costIncrease)
    {

        /*
        b = base cost
        c = currency
        r = cost increase 
        k = current amount of building
        n = the amount we are buying 
        */
        double singlePurchase = BaseCost * System.Math.Pow(costIncrease, Amount);
        BuyMaxAmount = System.Math.Floor(System.Math.Log(1 + ((costIncrease - 1) * currency / singlePurchase), costIncrease));

        if(singlePurchase > currency)
        {
            return 0;
        }        

        return BuyMaxAmount;
    }

    public double BuyMax(double currency, double prodIncrease, double costIncrease,int achievementKey)
    {
        //floor(log_r(\frac{c(r-1)}{b(r^k)}+1))
        double singlePurchase = BaseCost * System.Math.Pow(costIncrease, Amount);
        //double newCost = BaseCost * (System.Math.Pow(costIncrease, Amount) * (System.Math.Pow(costIncrease, BuyMaxAmount)-1) / (costIncrease -1 );
        //Debug.Log("new cost cost is " + newCost);

        double newCost = BaseCost * (System.Math.Pow(costIncrease, Amount) * (System.Math.Pow(costIncrease, BuyMaxAmount) - 1) / (costIncrease - 1));
        Debug.Log("buy max building new cost " + newCost);
        if(currency >= newCost)
        {
            currency -= newCost;
            Amount += BuyMaxAmount;
            Production = prodIncrease * Amount;
            Cost = BaseCost * System.Math.Pow(costIncrease, Amount);
        }

        return currency;
    }
}
