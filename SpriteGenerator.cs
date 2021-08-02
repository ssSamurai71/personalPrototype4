using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGenerator : MonoBehaviour
{
    Vector2 layoutSize = new Vector2(4,4);

    SpriteClass [,] spriteSpots;

    List<Vector2> takenSpot = new List<Vector2>();

    int gridSizeX, gridSizeY, numberOfRooms = 20;

    public GameObject spriteObject;

    void CreateSpirtes()
    {
        spriteSpots = new SpriteClass[gridSizeX * 2, gridSizeY * 2];
        spriteSpots[gridSizeX,gridSizeY] =  new SpriteClass(Vector2.zero, 1);
        takenSpot.Insert(0,Vector2.zero);
        Vector2 checkSpot = Vector2.zero;

        //magic numbers for comparing sprites
        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f, randomPerc;

        //place sprites 
        for(int index = 0; index < numberOfRooms - 1; index++)
        {
            randomPerc = (float) index / ((float) numberOfRooms - 1);
            randomCompare =  Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc);
            
            //grab new spot
            checkSpot = NewSpot();

            //test new spot
            if(NumberOfNeighbors(checkSpot, takenSpot) > 1 && Random.value > randomCompare)
            {
                int iterations = 0;
                do{
                    checkSpot = SelectNewSpot();
                    iterations++;
                } while(NumberOfNeighbors(checkSpot, takenSpot) > 1 && iterations < 100);
                if(iterations >= 50)
                    print("error: could not create with fewer neighbors than: " + NumberOfNeighbors(checkSpot, takenSpot));

            }

            //finalize the spots
            spriteSpots[(int) checkSpot.x + gridSizeX, (int) checkSpot.y + gridSizeY] = new SpriteClass(checkSpot, 0);
            takenSpot.Insert(0,checkSpot);
        }
    }

    Vector2 NewSpot()
    {
        int x = 0, y = 0, index = 0, inc = 0;
        Vector2 checkingSpot = Vector2.zero;
        do
        {
            inc = 0;
            do
            {
                index = Mathf.RoundToInt(Random.value * (takenSpot.Count-1));
                inc++;
            }while (NumberOfNeighbors(takenSpot[index], takenSpot) > 1 && inc < 100);
            
            x = (int) takenSpot[index].x;
            y = (int) takenSpot[index].y;
            bool UpDown = (Random.value < 0.5f), positive = (Random.value < 0.5f);
        
            if(UpDown)
            {
                if(positive)
                    y += 1;
                else
                    y -= 1;
            }
            else
            {
                if(positive)
                    x += 1;
                else
                    x -= 1;
            }
            checkingSpot = new Vector2(x,y);
        }while(takenSpot.Contains(checkingSpot) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);

        if(inc >= 100)
            print("Error: could not find position with only one neighbor");
        return checkingSpot;
    }

    int NumberOfNeighbors(Vector2 checkingSpot, List<Vector2> usedSpot)
    {
        int retValue = 0;
        if(usedSpot.Contains(checkingSpot + Vector2.right))
            retValue++;
        
        if(usedSpot.Contains(checkingSpot + Vector2.left))
            retValue++;
        
        if(usedSpot.Contains(checkingSpot + Vector2.up))
            retValue++;
        
        if(usedSpot.Contains(checkingSpot + Vector2.down))
            retValue++;

        return retValue;
    } 
    
    Vector2 SelectNewSpot()
    {
        int x = 0, y = 0, index;
        Vector2 checkingSpot = Vector2.zero;
        do
        {
            index = Mathf.RoundToInt(Random.value * (takenSpot.Count-1));
            x = (int) takenSpot[index].x;
            y = (int) takenSpot[index].y;
            bool UpDown = (Random.value < 0.5f), positive = (Random.value < 0.5f);
        
            if(UpDown)
            {
                if(positive)
                    y += 1;
                else
                    y -= 1;
            }
            else
            {
                if(positive)
                    x += 1;
                else
                    x -= 1;
            }
            checkingSpot = new Vector2(x,y);
        }while(takenSpot.Contains(checkingSpot) || x >= gridSizeX || x < -gridSizeX || y >= gridSizeY || y < -gridSizeY);
        return checkingSpot;
    }

    void DrawSpirtes()
    {
        foreach (SpriteClass sprites in spriteSpots)
        {
            if(sprites == null)
                continue;
            Vector2 drawSpot = sprites.gridPos;
            drawSpot.x *= 48;
            drawSpot.y *= 24;
            SpriteSelector placer = Object.Instantiate(spriteObject, drawSpot, Quaternion.identity).GetComponent<SpriteSelector>();
        }        
    }

    // Start is called before the first frame update
    void Start()
    {
        if(numberOfRooms >= (layoutSize.x * 2) * (layoutSize.y * 2))
            numberOfRooms = Mathf.RoundToInt((layoutSize.x * 2) * (layoutSize.y * 2));

        gridSizeX = Mathf.RoundToInt(layoutSize.x * 2);
        gridSizeY = Mathf.RoundToInt(layoutSize.y * 2);
        
        CreateSpirtes();
        DrawSpirtes();
    }

}
