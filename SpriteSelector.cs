using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelector : MonoBehaviour
{
    public Sprite wisp, bush, smallTree, largeTree, grove, druid, forestGuard, ent;

    const int wispEnum = 0, bushEnum = 1, smallTreeEnum = 2, largeTreeEnum = 3;
    const int groveEnum = 4, druidEnum = 5, forestGuardEnum = 6, entEnum = 7;

    public Color normalColor;

    Color mainColor;

    SpriteRenderer rend;

    void PickSprite()
    {
        int randomSprite = (int) Random.value % 8;
        switch (randomSprite)
        {
            case wispEnum:
                rend.sprite = wisp;
                break;
            case bushEnum:
                rend.sprite = bush;
                break;
            case smallTreeEnum:
                rend.sprite = smallTree;
                break;
            case largeTreeEnum:
                rend.sprite = largeTree;
                break;
            case groveEnum:
                rend.sprite = grove;
                break;
            case druidEnum:
                rend.sprite = druid;
                break;
            case forestGuardEnum:
                rend.sprite = forestGuard;
                break;
            case entEnum:
                rend.sprite = ent;
                break;
            default:
                break;
        }
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        mainColor = normalColor;
        PickSprite();
    }


}
