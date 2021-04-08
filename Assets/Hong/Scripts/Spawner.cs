using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float x_random;
    private float y_random;

    private float time_f;
    private int time_i;

    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        time_f = 0f;
        time_i = 0; 
        
        x_random = Random.Range(-50, 50);
        y_random = Random.Range(-50, 50);

        Instantiate(enemy, new Vector3(transform.position.x + x_random, transform.position.y + y_random, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        TimeController();

        if (time_i >= 5)
        {
            x_random = Random.Range(-50, 50);
            y_random = Random.Range(-50, 50);

            transform.rotation = 
            Quaternion.Euler(0f, 180f, 0f);
            Instantiate(enemy, new Vector3(transform.position.x + x_random, transform.position.y+y_random,transform.position.z),Quaternion.identity);
            time_i = 0;
        }
    }

    private void TimeController()
    {
        time_f += Time.deltaTime;

        if (time_f >= 1f)
        {
            ++time_i;
            time_f = 0f;
        }
    }
}
