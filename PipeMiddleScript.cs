using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        if (logic == null)
        {
            Debug.LogError("Cannot find 'LogicScript' object or component. Please check if it exists and is correctly tagged.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore();
        }

    }

}
