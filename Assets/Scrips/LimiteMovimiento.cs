using UnityEngine;

public class LimiteMovimiento : MonoBehaviour

{
    public float velocidad = 5f;

    // Limites del barco
    public float minX = 434f;
    public float maxX = 489f;
    public float minZ = 278f;
    public float maxZ = 278f;

    public GameObject personaje;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float playervelocidad = 5f;
        if (personaje.CompareTag("Player1"))
        {
            playervelocidad = PuntajeManager.instance.getvelocidadPlayer1();
            Debug.Log(playervelocidad + "Soy el 1");
        }

        if (personaje.CompareTag("Player2"))
        {
            playervelocidad = PuntajeManager.instance.getvelocidadPlayer2();
            Debug.Log(playervelocidad + "Soy el 2");
        }

        velocidad = playervelocidad;

        float moverX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float moverZ = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        Vector3 nuevaPosicion = transform.position + new Vector3(moverX, 0, moverZ);

        // Limitar dentro del barco
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, minX, maxX);
        nuevaPosicion.z = Mathf.Clamp(nuevaPosicion.z, minZ, maxZ);

        transform.position = nuevaPosicion;
    }
}