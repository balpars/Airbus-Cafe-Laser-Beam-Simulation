using UnityEngine;

public class LEOOrbit : MonoBehaviour
{
    public Transform earth;
    public int numberOfAsteroids = 100;
    public GameObject[] asteroidPrefabs; // Array of asteroid prefabs
    public float minAltitude = 5.0f; // in Unity units (500 km, adjusted for larger Earth)
    public float maxAltitude = 10.0f; // in Unity units (1000 km, adjusted for larger Earth)
    public float minAsteroidScale = 0.5f; // Minimum scale for asteroids
    public float maxAsteroidScale = 2.5f; // Maximum scale for asteroids

    void Start()
    {
        if (asteroidPrefabs == null || asteroidPrefabs.Length == 0)
        {
            Debug.LogError("Asteroid prefabs array is not assigned or empty!");
            return;
        }

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            PlaceAsteroid();
        }
    }

    void PlaceAsteroid()
    {
        float altitude = Random.Range(minAltitude, maxAltitude);
        float distanceFromEarth = earth.localScale.x / 2 + altitude;
        float inclination = Random.Range(0, 360) * Mathf.Deg2Rad; // Convert degrees to radians
        float speed = CalculateOrbitalSpeed(altitude);

        Vector3 position = new Vector3(
            distanceFromEarth * Mathf.Cos(inclination),
            distanceFromEarth * Mathf.Sin(inclination),
            0
        );

        // Randomly select a prefab from the array
        int prefabIndex = Random.Range(0, asteroidPrefabs.Length);
        if (prefabIndex >= asteroidPrefabs.Length || prefabIndex < 0)
        {
            Debug.LogError("Random prefab index is out of range: " + prefabIndex);
            return;
        }

        GameObject asteroidPrefab = asteroidPrefabs[prefabIndex];
        GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity, transform);

        // Randomly scale the asteroid
        float randomScale = Random.Range(minAsteroidScale, maxAsteroidScale);
        asteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        AsteroidOrbit asteroidOrbit = asteroid.AddComponent<AsteroidOrbit>();
        asteroidOrbit.earth = earth;
        asteroidOrbit.orbitSpeed = speed;
    }

    float CalculateOrbitalSpeed(float altitude)
    {
        float G = 6.67430e-11f; // Gravitational constant
        float earthMass = 5.972e24f; // Mass of the Earth in kg
        float earthRadius = 6371.0f; // Earth's radius in km
        float radius = (earthRadius + altitude * 1000.0f) * 1000.0f; // Convert Unity units to meters
        return Mathf.Sqrt(G * earthMass / radius) / 1000.0f; // Convert m/s to km/s
    }
}

public class AsteroidOrbit : MonoBehaviour
{
    public Transform earth;
    public float orbitSpeed;

    void Update()
    {
        transform.RotateAround(earth.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
