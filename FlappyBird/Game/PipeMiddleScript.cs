using UnityEngine;

// The function is adapated from https://www.youtube.com/watch?v=XtQMytORBmM&t=1979s
public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    void Awake()
    {
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");

        if (logicObject != null)
        {
            logic = logicObject.GetComponent<LogicScript>();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore();
        }

    }

}
