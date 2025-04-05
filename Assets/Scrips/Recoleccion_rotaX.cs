using UnityEngine;

public class Recoleccion_rotaX:MonoBehaviour
{
    public float rotationSpeed = 100f;  // Velocidad de rotación

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

    }

}
