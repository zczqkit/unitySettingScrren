using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRidigbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject gameOverScreen;

    public SettingsScreenController settingsController; // reference to SettingsScreenController


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the state of the MouseToggleButton
        if (settingsController.MouseToggleButton.value && Input.GetMouseButtonDown(1) && birdIsAlive)
        {
            myRidigbody.velocity = Vector2.up * flapStrength;
        }
        // Check the state of the KeyboardToggleButton
        else if (settingsController.KeyboardToggleButton.value && Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRidigbody.velocity = Vector2.up * flapStrength;
        }

        // Check if bird is out of the screen
        Vector3 birdInViewport = Camera.main.WorldToViewportPoint(transform.position);
        if (birdInViewport.y > 1 || birdInViewport.y < 0)
        {
            GameOver();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverScreen.SetActive(true);
        birdIsAlive = false;
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        birdIsAlive = false;
    }
}
