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


    public Camera cam;
    void Start()
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
            
            height = Random.Range(minHeight, maxHeight);

            for (float y = -64f; y < height; y++)
            {
                if (y < totalStoneSpawnDistance)
                {
                    spawnObj(stone, x, y);
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
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
       rb.gravityScale = 0;
       rb.constraints = RigidbodyConstraints2D.FreezeAll | RigidbodyConstraints2D.FreezeAll;

       


    }
}
