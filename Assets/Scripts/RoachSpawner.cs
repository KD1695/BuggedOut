using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoachSpawner : MonoBehaviour
{
    const int BOUNDS_X = 1920;
    const int BOUNDS_Y = 1080;

    [SerializeField] private float spawnInterval = 6.0f;
    [SerializeField] private List<RoachController> roachPrefabList;

    private float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= spawnInterval)
        {
            float x = 0, y = 0;
            //spawn roach
            int choice = Random.Range(0, 3);
            switch(choice)
            {
                case 0:
                    x = -BOUNDS_X / 20;
                    y = Random.Range(-BOUNDS_Y / 20, BOUNDS_Y / 20);
                    break;
                case 1:
                    x = BOUNDS_X / 20;
                    y = Random.Range(-BOUNDS_Y / 20, BOUNDS_Y / 20);
                    break;
                case 2:
                    y = -BOUNDS_Y / 20;
                    x = Random.Range(-BOUNDS_X / 20, BOUNDS_X / 20);
                    break;
                case 3:
                    y = BOUNDS_Y / 20;
                    x = Random.Range(-BOUNDS_X / 20, BOUNDS_X / 20);
                    break;
            }
            //can expand to instantiate each type based on some logic instead of random selection
            int index = Random.Range(0, roachPrefabList.Count);
            GameObject.Instantiate<RoachController>(roachPrefabList[index], new Vector3(x, y, 150f), Quaternion.identity, this.transform);
            currentTime = 0;
        }
    }
}
