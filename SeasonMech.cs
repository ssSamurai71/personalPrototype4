using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonMech
{
    private double seasonTimer;
    private string season;
    private double winterBoost;
    private double summerBoost;
    private double fallBoost;
    private double springBoost;
    private double activeBoost;
    private double switchCost;
    private double timesSwitched;

    public double SeasonTimer
    {
        get;
        set;
    }

    public string AccessSeason
    {
        get;
        set;
    }

    public double WinterBoost
    {
        get;
        set;
    }

    public double SummerBoost
    {
        get;
        set;
    }

    public double SpringBoost
    {
        get;
        set;
    }

    public double FallBoost
    {
        get;
        set;
    }

    public double ActiveBoost
    {
        get;
        set;
    }

    public double SwitchCost
    {
        get;
        set;
    }

    public double TimesSwitched
    {
        get;
        set;
    }

    public string RotateSeason
    {
        get
        {
            if(SeasonTimer > 2700)
            {
                ActiveBoost = SummerBoost;
                AccessSeason = "Summer\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + SummerBoost.ToString();
            }
            else if (SeasonTimer < 2699 & SeasonTimer > 1800)
            {
                ActiveBoost = FallBoost;
                AccessSeason = "Fall\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + FallBoost.ToString();
            }
            else if (SeasonTimer < 1799 & SeasonTimer > 900)
            {
                ActiveBoost = WinterBoost;
                AccessSeason = "Winter\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + WinterBoost.ToString(); 
            }
            else if (SeasonTimer < 899 & SeasonTimer >= 0)
            {
                ActiveBoost = SpringBoost;
                AccessSeason = "Spring\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + SpringBoost.ToString();
            }
            else if (SeasonTimer < 0)
            {
                SeasonTimer = 3600;
            }
            SeasonTimer = SeasonTimer - Time.deltaTime;
            return AccessSeason;
        } 
    }

    public string ForceSwitch()
    {
        TimesSwitched += 1;
        switch (TimesSwitched % 4)
        {
            case 0:
                SeasonTimer = 3600;
                AccessSeason = "Summer\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + SummerBoost.ToString();
                break;
            
            case 1:
                SeasonTimer = 2700;
                AccessSeason = "Fall\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + FallBoost.ToString();    
                break;

            case 2:
                SeasonTimer = 1800;
                AccessSeason = "Winter\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + WinterBoost.ToString();
                break;

            case 3:
                SeasonTimer = 900;
                AccessSeason = "Spring\nTime: " + SeasonTimer.ToString("F0") + "\nBoost: %" + SpringBoost.ToString();
                break;
        }
        return AccessSeason;
    
    }
}