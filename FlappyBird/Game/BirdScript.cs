using UnityEngine;

// The function is adapated from https://www.youtube.com/watch?v=XtQMytORBmM&t=1979s
public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRidigbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject gameOverScreen;

    public SettingsScreenController settingsController; // reference to SettingsScreenController
    public MotionInputController MotionInputController; // reference to MotionInputController

    private Vector3 lastMousePosition;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // If MotionInputController or one of its buttons is not present.
        if (MotionInputController == null ||
    MotionInputController.MotionInput1Button == null ||
    MotionInputController.MotionInput2Button == null ||
    MotionInputController.MotionInput3Button == null)
        {
            // Check the status of the mouse toggle button.
            if (settingsController.MouseToggleButton.value && Input.GetMouseButtonDown(0) && birdIsAlive)
            {
                myRidigbody.velocity = Vector2.up * flapStrength;
            }
            // Check the status of the Keyboard toggle button.
            else if (settingsController.KeyboardToggleButton.value && Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                myRidigbody.velocity = Vector2.up * flapStrength;
            }
        }
        else
        {
            // MotionInputController and all its buttons if present.

            // Check the status of the mouse toggle button.
            if (settingsController.MouseToggleButton.value && Input.GetMouseButtonDown(0) && birdIsAlive)
            {
                myRidigbody.velocity = Vector2.up * flapStrength;
            }
            // Check the status of the Keyboard toggle button.
            else if (settingsController.KeyboardToggleButton.value && Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                myRidigbody.velocity = Vector2.up * flapStrength;
            }
            // Check the status of MotionInput1Button or MotionInput2Button.
            else if ((MotionInputController.MotionInput1Button.value || MotionInputController.MotionInput2Button.value) && Input.GetMouseButtonDown(0) && birdIsAlive)
            {
                myRidigbody.velocity = Vector2.up * flapStrength;
            }
            // Check the status of MotionInput3Button.
            else if (MotionInputController.MotionInput3Button.value && birdIsAlive)
            {
                Vector3 currentMousePosition = Input.mousePosition;

                if (currentMousePosition.y > lastMousePosition.y)
                {
                    myRidigbody.velocity = (Vector2.up / 2.5f) * flapStrength;
                }

                lastMousePosition = currentMousePosition;
            }
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
