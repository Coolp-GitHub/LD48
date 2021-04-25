using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Generation : MonoBehaviour
{

    [SerializeField] private int width , height;
    [SerializeField] private int minStoneHeight, maxStoneHeight;
    [SerializeField] private GameObject dirt;
    [SerializeField] private GameObject grass;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject iron;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject diamonds;

     private int rand;

    public Camera cam;

    void Awake()
    {
        Generate();
    }


    private void Generate()
    {
        for (float x = width * -1; x < width; x++)
        {
            
            int minHeight = height - 1;
            int maxHeight = height + 2;

            int minStoneSpawnDistance = height - minStoneHeight;
            int maxStoneSpawnDistance = height - maxStoneHeight;

            int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);
            if (height >= 7)
            {
                height -= 1;
            }
            else
            {
                height = Random.Range(minHeight, maxHeight);

            }
            
            for (float y = -64f; y < height; y++)
            {
                rand = Random.Range(1,Random.Range(1,6));
                
                if (y < totalStoneSpawnDistance)
                {
                    switch (rand)
                    {
                        case 1:
                            spawnObj(stone,x,y);
                            break;
                        case 2:
                            spawnObj(stone, x, y);
                            break;
                        case 3:
                            spawnObj(iron,x,y);
                            break;
                        case 4:
                            spawnObj(gold,x,y);
                            break;
                        case 5:
                            spawnObj(diamonds,x,y);
                            break;
                       
                    }
                }
                else
                {
                    spawnObj(dirt, x, y);
                }
            }

            spawnObj(grass, x, height);
        }
    }

  
    

    void spawnObj(GameObject obj, float width, float height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
        obj.AddComponent<Rigidbody2D>();
        obj.AddComponent<BoxCollider2D>();
        obj.AddComponent<Loader>();
        obj.AddComponent<BreakingBlocks>();
        obj.gameObject.layer = 3;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
       rb.gravityScale = 0;
       rb.constraints = RigidbodyConstraints2D.FreezeAll | RigidbodyConstraints2D.FreezeAll;

       


    }
}
