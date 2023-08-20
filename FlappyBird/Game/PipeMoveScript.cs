using UnityEngine;

// The function is adapated from https://www.youtube.com/watch?v=XtQMytORBmM&t=1979s
public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadZone = -50;

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
