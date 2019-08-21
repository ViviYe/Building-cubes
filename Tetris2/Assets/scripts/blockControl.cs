using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockControl : MonoBehaviour
{
    [SerializeField] public KeyCode left;
    [SerializeField] public KeyCode right;

    bool onground = false;
    int speed = 10;
    Rigidbody2D block;

    void Start()
    {
        block = GetComponent<Rigidbody2D>();
     
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left) && !onground)
        {
            AdjustXSpeed(-speed);
        }
        else if (Input.GetKey(right) &&!onground)
        {
            AdjustXSpeed(speed);
        }
        else if (!onground)
        {
            AdjustXSpeed(0);
        }

    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "ground"||colInfo.collider.tag == "groundblock")
        {
            AdjustXSpeed(0);
            onground = true;
            gameObject.tag = "groundblock";
            GameControl.Next();
        }
    }

    void AdjustXSpeed(int newSpeed)
    {
        Vector2 vel = block.velocity;
        vel.x = newSpeed;
        block.velocity = vel;
    }

}
