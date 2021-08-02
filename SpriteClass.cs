using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteClass
{
    public Vector2 gridPos;

    public int type;

    public SpriteClass(Vector2 _gridPos, int _type)
    {
        gridPos = _gridPos;
        type = _type;
    }
}
