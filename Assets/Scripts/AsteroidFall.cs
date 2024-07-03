using UnityEngine;

public class AsteroidFall : MonoBehaviour
{
    public Transform earth; // The Earth object
    public float fallDelay = 10f; // Time delay before the asteroid falls
    public float fallSpeed = 10f; // Speed of the asteroid fall

    private bool isFalling = false;
    private float timer = 0f;

    void Update()
    {
        // Start timer and check if the asteroid should fall
        timer += Time.deltaTime;
        if (timer >= fallDelay)
        {
            isFalling = true;
        }

        // Move the asteroid towards the Earth if it is falling
        if (isFalling)
        {
            MoveTowardsEarth();
        }
    }

    void MoveTowardsEarth()
    {
        // Ensure the Earth reference is assigned
        if (earth == null)
        {
            Debug.LogError("Please assign the Earth reference in the Inspector.");
            return;
        }

        // Move the asteroid towards the Earth
        transform.position = Vector3.MoveTowards(transform.position, earth.position, fallSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == earth)
        {
            Destroy(gameObject); // Destroy the asteroid upon collision with Earth
        }
    }
}
