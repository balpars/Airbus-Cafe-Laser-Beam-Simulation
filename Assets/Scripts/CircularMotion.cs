using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float speed = 2.0f; // Speed of rotation
    public float radius = 2.0f; // Radius of the circular path

    private float angle = 0.0f;

    void Update()
    {
        // Update the angle based on time and speed
        angle += speed * Time.deltaTime;

        // Calculate the new position using trigonometry (circular motion formula)
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Set the object's position
        transform.position = new Vector3(x, 0, z);
    }
}
