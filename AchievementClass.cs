using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementClass
{
    static int[] buildingAmounts = new int[10]{ 1, 10, 50, 100, 200, 300, 400, 500, 600, 700};
    static int[] upgradeAmounts = new int[10]{ 1, 10, 25, 50, 100, 150, 200, 250, 300, 350};
    

    static public int AssignNextKey(double amount, int key)
    {
        if(buildingAmounts[KeyConversion(key)] == amount)
        {
            key += 1;
        }
    
        return key;
    }

    public static void CheckBuildingAchievement(double amount,int key)
    {
        if(buildingAmounts[KeyConversion(key)] == amount)
            AchievementManager.instance.Unlock(key); 
    }

    public static void CheckUpgradeAchievement(double amount, int key)
    {
        if(upgradeAmounts[KeyConversion(key)] == amount)
            AchievementManager.instance.Unlock(key);
    }

    public static int KeyConversion(int key)
    {
        int conversion = key % 10;

        return conversion;
    }

    public static int CheckWispBuyMax(double amount)
    {
        int wispkey = 0;
        for(int index = 0; index < buildingAmounts.Length;index++)
        {
            if(buildingAmounts[wispkey] <= amount)
            {
                AchievementManager.instance.Unlock(wispkey);
                wispkey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) wispkey, (int) amount);
        return wispkey;
    }
    
    public static int CheckBushBuyMax(double amount)
    {
        int bushkey = 10;
        for(int index = 0; index < buildingAmounts.Length;index++)
        {
            if(buildingAmounts[KeyConversion(bushkey)] <= amount)
            {
                AchievementManager.instance.Unlock(bushkey);
                bushkey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) bushkey, (int) amount);
        return bushkey;
    }

    public static int CheckSmallTreeBuyMax(double amount)
    {
        int smallTreekey = 20;
        for(int index = 0; index < buildingAmounts.Length;index++)
        {
            if(buildingAmounts[KeyConversion(smallTreekey)] <= amount)
            {
                AchievementManager.instance.Unlock(smallTreekey);
                smallTreekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) smallTreekey, (int) amount);
        return smallTreekey;
    }

    public static int CheckLargeTreeBuyMax(double amount)
    {
        int largeTreekey = 30;
        for(int index = 0; index < buildingAmounts.Length;index++)
        {
            if(buildingAmounts[KeyConversion(largeTreekey)] <= amount)
            {
                AchievementManager.instance.Unlock(largeTreekey);
                largeTreekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) largeTreekey, (int) amount);
        return largeTreekey;
    }

    public static int CheckGroveBuyMax(double amount)
    {
        int grovekey = 40;
        for(int index = 0; index < buildingAmounts.Length;index++)
        {
            if(buildingAmounts[KeyConversion(grovekey)] <= amount)
            {
                AchievementManager.instance.Unlock(grovekey);
                grovekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) grovekey, (int) amount);
        return grovekey;
    }

    public static int CheckDruidBuyMax(double amount)
    {
        int druidkey = 50;
        for(int index = 0; index < buildingAmounts.Length;index++)
        {
            if(buildingAmounts[KeyConversion(druidkey)] <= amount)
            {
                AchievementManager.instance.Unlock(druidkey);
                druidkey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) druidkey, (int) amount);
        return druidkey;
    }

    public static int CheckForestGuardBuyMax(double amount)
    {
        int forestGuardkey = 60;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(buildingAmounts[KeyConversion(forestGuardkey)] <= amount)
            {
                AchievementManager.instance.Unlock(forestGuardkey);
                forestGuardkey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) forestGuardkey, (int) amount);
        return forestGuardkey;
    }

    public static int CheckEntBuyMax(double amount)
    {
        int entkey = 70;
        for(int index = 0; index < buildingAmounts.Length;index++)
        {
            if(buildingAmounts[KeyConversion(entkey)] <= amount)
            {
                AchievementManager.instance.Unlock(entkey);
                entkey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) entkey, (int) amount);
        return entkey;
    }

       public static int CheckWispUpgradeBuyMax(double amount)
    {
        int wispUpgradekey = 80;
        Debug.Log("amount being passed into wisp buymax upgrade checker is " + amount);
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            bool istrue = upgradeAmounts[KeyConversion(wispUpgradekey)] <= amount;
            Debug.Log("the bool before the if statement is " + istrue);
            if(upgradeAmounts[KeyConversion(wispUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(wispUpgradekey);
                wispUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) wispUpgradekey, (int) amount);
        return wispUpgradekey;
    }
    
    public static int CheckBushUpgradeBuyMax(double amount)
    {
        int bushUpgradekey = 90;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(upgradeAmounts[KeyConversion(bushUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(bushUpgradekey);
                bushUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) bushUpgradekey, (int) amount);
        return bushUpgradekey;
    }

    public static int CheckSmallTreeUpgradeBuyMax(double amount)
    {
        int smallTreeUpgradekey = 100;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(upgradeAmounts[KeyConversion(smallTreeUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(smallTreeUpgradekey);
                smallTreeUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) smallTreeUpgradekey, (int) amount);
        return smallTreeUpgradekey;
    }

    public static int CheckLargeTreeUpgradeBuyMax(double amount)
    {
        int largeTreeUpgradekey = 110;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(upgradeAmounts[KeyConversion(largeTreeUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(largeTreeUpgradekey);
                largeTreeUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) largeTreeUpgradekey, (int) amount);
        return largeTreeUpgradekey;
    }

    public static int CheckGroveUpgradeBuyMax(double amount)
    {
        int groveUpgradekey = 120;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(upgradeAmounts[KeyConversion(groveUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(groveUpgradekey);
                groveUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) groveUpgradekey, (int) amount);
        return groveUpgradekey;
    }

    public static int CheckDruidUpgradeBuyMax(double amount)
    {
        int druidUpgradekey = 130;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(upgradeAmounts[KeyConversion(druidUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(druidUpgradekey);
                druidUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) druidUpgradekey, (int) amount);
        return druidUpgradekey;
    }

    public static int CheckForestGuardUpgradeBuyMax(double amount)
    {
        int forestGuardUpgradekey = 140;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(upgradeAmounts[KeyConversion(forestGuardUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(forestGuardUpgradekey);
                forestGuardUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) forestGuardUpgradekey, (int) amount);
        return forestGuardUpgradekey;
    }

    public static int CheckEntUpgradeBuyMax(double amount)
    {
        int entUpgradekey = 150;
        for(int index = 0; index < upgradeAmounts.Length;index++)
        {
            if(upgradeAmounts[KeyConversion(entUpgradekey)] <= amount)
            {
                AchievementManager.instance.Unlock(entUpgradekey);
                entUpgradekey++;
            }
        }
        AchievementManager.instance.SetAchievementProgress( (int) entUpgradekey, (int) amount);
        return entUpgradekey;
    }
}
