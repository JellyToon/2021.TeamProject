using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float y_pos;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
        y_pos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        y_pos += speed;

        transform.Translate(0.0f, y_pos * Time.deltaTime, 0.0f);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
