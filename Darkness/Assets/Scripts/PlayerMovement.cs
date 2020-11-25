using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Transform trans;
    private Rigidbody2D rigid;
    public float jumpspeed;
    public bool canjump;

    void Start()
    {
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        var move = Input.GetAxis("Horizontal");
        trans.position += new Vector3(move, 0, 0) * Time.deltaTime * speed;
        if (Mathf.Abs(rigid.velocity.y) < 0.001f)
            canjump = true;
        else
            canjump = false;
        if (Input.GetButtonDown("Jump") && canjump == true)
        {
            rigid.AddForce(new Vector2(0, jumpspeed), ForceMode2D.Impulse);
        }
        if (!Mathf.Approximately(0, move))
            trans.rotation = move < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
}
