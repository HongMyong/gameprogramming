using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Snake Movement Var
    Vector2 dir = 2 * Vector2.right;
    private float size = 2;

    // Snake Direction Var
    float h;	// Horizontal
    float v;	// Vertical
    bool isHorizonMove;

    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    void Update()
    {
        // Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = (h != 0);

        // Determine Direction
        if (h != 0 || v != 0)
            dir = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
    }

    void Move()
    {
        transform.Translate(size * dir);
    }
}
