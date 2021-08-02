using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTree
{
    private double baseValue;
    private string treeName;
    private string toolTip;
    private double upgradedValue;

    public double BaseValue
    {
        get;
        set;
    }

    public string TreeName
    {
        get;
        set;
    }

    public double UpgradedValue
    {
        get;
        set;
    }

    public string ToolTip
    {
        get
        {
            return "Tree: " + TreeName + "\nClick Value: " + BaseValue;
        }
    }
}
