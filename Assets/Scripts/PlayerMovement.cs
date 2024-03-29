﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody playerRigidbody;
    public int Coins;
    private int TotalCoins;
    public Text coinText;
    private int NextSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        TotalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        NextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0, MoveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }
    void Update()
    {
        coinText.text = "Coins Collected: " + Coins;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("Game Over");
        }

        if (collision.gameObject.tag == "Coin")
        {
            Coins++;
            Destroy(collision.gameObject);
            if (Coins == TotalCoins)
            {
                SceneManager.LoadScene(NextSceneToLoad);
            }
        }
    }

    
}
