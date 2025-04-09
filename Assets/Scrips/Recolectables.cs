using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Recolectables : MonoBehaviour
{
    public AudioClip sonidoMoneda;
    public GameObject efectoVFXMoneda;
    public AudioClip sonidoRayo;
    public AudioClip sonidoPosion;
    public AudioClip sonidoPulpo;
    public AudioClip sonidoAncla;
    public AudioClip sonidoObstaculos;
    private AudioSource audioSource;
    public GameObject efectoVFX;
    public GameObject Personaje;


    private int score = 0; // puntuación por recoger monedas
    private int vida = 3; // puntuación vidas
    private float velocidad = 10f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Busca el AudioSource
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))  // colision con recolectables
        {
            audioSource.PlayOneShot(sonidoMoneda);
             if (efectoVFXMoneda != null)              // activa el efecto especial
            {
                 Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                 Instantiate(efectoVFXMoneda, posicion, Quaternion.identity);
              }
            score += 1;
            velocidad += 0.5f;
            if (vida != 0)
            {
                if (Personaje.CompareTag("Player1"))
                {
                    PuntajeManager.instance.setPuntajePlayer1(score, Personaje.gameObject.name.ToString());

                }
                if (Personaje.CompareTag("Player2"))
                {
                    PuntajeManager.instance.setPuntajePlayer2(score, Personaje.gameObject.name.ToString());

                }
            }
           


            Destroy(other.gameObject); // desaparición de objetos
        }
        else if (other.CompareTag("Rayo"))
        {
            audioSource.PlayOneShot(sonidoRayo);
            if (efectoVFX != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(efectoVFX, posicion, Quaternion.identity);
            }

            velocidad += 2;
            if (velocidad <= 0)
            {
                velocidad = 1;
            }
            if (Personaje.CompareTag("Player1"))
            {
                PuntajeManager.instance.setvelocidadPlayer1(velocidad, Personaje.gameObject.name.ToString());

            }
            if (Personaje.CompareTag("Player2"))
            {
                PuntajeManager.instance.setvelocidadPlayer2(velocidad, Personaje.gameObject.name.ToString());

            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Posion"))
        {
            audioSource.PlayOneShot(sonidoPosion);
            if (efectoVFX != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(efectoVFX, posicion, Quaternion.identity);
            }

            vida += 1;
            if (Personaje.CompareTag("Player1"))
            {
                PuntajeManager.instance.setvidaPlayer1(vida, Personaje.gameObject.name.ToString());

            }
            if (Personaje.CompareTag("Player2"))
            {
                PuntajeManager.instance.setvidaPlayer2(vida, Personaje.gameObject.name.ToString());

            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Pulpo"))
        {
            audioSource.PlayOneShot(sonidoPulpo);
            if (efectoVFX != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(efectoVFX, posicion, Quaternion.identity);
            }

            vida -= 1;
            if (vida <= 0)
            {
                vida = 0;
            }
            if (Personaje.CompareTag("Player1"))
            {
                PuntajeManager.instance.setvidaPlayer1(vida, Personaje.gameObject.name.ToString());

            }
            if (Personaje.CompareTag("Player2"))
            {
                PuntajeManager.instance.setvidaPlayer2(vida, Personaje.gameObject.name.ToString());

            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Ancla"))
        {
            audioSource.PlayOneShot(sonidoAncla);
            if (efectoVFX != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(efectoVFX, posicion, Quaternion.identity);
            }

            velocidad -= 2;
            if (velocidad <= 1) { 
                velocidad = 1.5f;
            }
            if (Personaje.CompareTag("Player1"))
            {
                PuntajeManager.instance.setvelocidadPlayer1(velocidad, Personaje.gameObject.name.ToString());

            }
            if (Personaje.CompareTag("Player2"))
            {
                PuntajeManager.instance.setvelocidadPlayer2(velocidad, Personaje.gameObject.name.ToString());

            }

            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo")) // Reproduce sonido al colisionar con obstaculos
        {

            audioSource.PlayOneShot(sonidoObstaculos);
         
        }
    }
}