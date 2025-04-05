using UnityEngine;

public class Per_moveAD : MonoBehaviour
{
    public float speed = 5f;
    private Animator anime;
    private Rigidbody rb;
    private void Start()
    {

        anime = GetComponent<Animator>();  // Obtiene el Animator
        rb = GetComponent<Rigidbody>();   // Obtiene el Rigidbody
    }

    void Update()
    {
        float move = 0;

        //detecta las teclas 
        if (Input.GetKey(KeyCode.A))
        {
            move = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 1;
        }

        transform.position += Vector3.right * move * speed * Time.deltaTime;


        // Actualizar animación
        if (move != 0)
            anime.SetBool("isRunning", true);  // Activa animación de correr
        else
            anime.SetBool("isRunning", false); // Vuelve a Idle cuando no hay movimiento

        // Rotar personaje
        if (move > 0)
            transform.rotation = Quaternion.Euler(0, 90, 0);  // Derecha
        if (move == 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);  // Derecha
        else if (move < 0)
            transform.rotation = Quaternion.Euler(0, -90, 0); // Izquierda
    }
}
