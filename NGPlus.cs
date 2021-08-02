using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGPlus
{
    private double newGameCount; //keep track of how many New games there the player does
    private double runCurrency;
    private double currentAmount;
    private double currentAmountBoost;
    private double newGamePlusAmount;
    private double newGamePlusAmountBoost;

    public double NGCount
    {
        get
        {
            return newGameCount;
        }
        set
        {
            newGameCount = value;
        }
    }

    public double RunCurrency
    {
        get
        {
            return runCurrency;
        }
        set
        {
            runCurrency = value;   
        }
    }

    public double CurrentAmount
    {
        get
        {
            return currentAmount;
        }
        set
        {
            currentAmount = value;
        }
    }

    public double CurrentAmountBoost
    {
        get
        {
            return currentAmountBoost;
        }
        set
        {
            currentAmountBoost = value;
        }
    }

    public double NGPlusAmount
    {
        get
        {
            return newGamePlusAmount;
        }
        set
        {
            newGamePlusAmount = value;
        }
    }

    public double NGPlusAmountBoost
    {
        get
        {
            return newGamePlusAmountBoost;
        }
        set
        {
            newGamePlusAmountBoost = value;
        }
    }

    public void CalcNGPlus()
    {
        NGPlusAmount = System.Math.Sqrt(RunCurrency/1e9);
        NGPlusAmountBoost = NGPlusAmount;
    }
}
