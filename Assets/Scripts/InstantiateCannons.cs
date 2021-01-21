using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class InstantiateCannons : MonoBehaviour
{
    private float _nextShootTimer = 3f;
    Random random = new Random();
    private const int MINIMUM_TIME_TO_SHOOT_IN_MILISECONDS = 100;
    private const int MAXIMUM_TIME_TO_SHOOT_IN_MILISECONDS = 1000;
    private const int DIVIDER_TO_CHANGE_MS_TO_SECONDS = 1000;

    public GameObject newCannon;

    public List<GameObject> cannons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateCannons();
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    //Instantiates few gameobjects from cannon prefab
    //If we build arena, we can create public list of coordinates where should cannons spawn
    //And use it here instead of hardcoded values
    void CreateCannons()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject cannon = Instantiate(newCannon, new Vector3((i + 1) * 10, 0, 0), Quaternion.identity);
            cannons.Add(cannon);
        }
    }

    void Shooting()
    {
        _nextShootTimer -= Time.deltaTime;
        if (_nextShootTimer < 0)
        {
            var cannonIndex = random.Next(0, 3);
            var cannon = cannons[cannonIndex];
            //Instantiate(bullet,
            //    new Vector3(cannon.transform.position.x, cannon.transform.position.y, cannon.transform.position.z),
            //    Quaternion.identity);
            print($"Cannon no. {cannonIndex + 1} shot");
            _nextShootTimer = (float)random.Next(MINIMUM_TIME_TO_SHOOT_IN_MILISECONDS, MAXIMUM_TIME_TO_SHOOT_IN_MILISECONDS)/DIVIDER_TO_CHANGE_MS_TO_SECONDS;
        }
    }
}
