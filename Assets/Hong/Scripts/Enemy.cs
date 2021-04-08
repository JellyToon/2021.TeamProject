using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rbody;
    Vector3 moveVec;
    [SerializeField] float speed;

    [SerializeField] Transform shootPosition;
    [SerializeField] GameObject bullet;

    private float time_f;
    private int time_i;


    void Start()
    {
        time_f = 0f;
        time_i = 0;

        transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        rbody = GetComponent<Rigidbody>();
        moveVec.Set(0,0,1f);

        moveVec = moveVec.normalized * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        rbody.MovePosition(transform.position - moveVec);

        TimeController();

        if (time_i >= 3)
        {
            Instantiate(bullet, shootPosition.position, shootPosition.rotation);
            bullet.GetComponent<Bullet>().SetSpeed(0.2f);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(this.gameObject, 0f);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        Destroy(this.gameObject,0f);
    //    }
    //}
}
