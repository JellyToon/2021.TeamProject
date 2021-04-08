using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    float hAxis;
    float yAxis;

    Vector3 moveVec;

    [SerializeField] Transform shootPosition;
    [SerializeField] GameObject bullet;

    Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void PlayerMove()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        //moveVec = new Vector3(hAxis, yAxis, 0).normalized;
        moveVec.Set(hAxis, yAxis, 0);

        moveVec = moveVec.normalized * speed * Time.deltaTime;

        rbody.MovePosition(transform.position + moveVec);

        //transform.position += moveVec * speed * Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(bullet, shootPosition.position,shootPosition.rotation);
    }
}
