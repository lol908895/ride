using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public bool startPlay = true;
    public LogicScript logic;
    public bool birdIsAlive;
    public GameObject spawner;
    public GameObject gameOverScreen;

    void Start()
    {
        birdIsAlive = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        var touch = false;
        try
        {
            touch = Input.GetTouch(0).phase == TouchPhase.Began;
        }
        catch { }
        if ((touch || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            if (startPlay)
            {
                spawner.SetActive(true);
                myRigidbody.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                startPlay = false;
            }
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        birdIsAlive = false;
        spawner.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
