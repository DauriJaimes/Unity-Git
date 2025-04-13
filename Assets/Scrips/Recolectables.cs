using System.Collections;
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
    public GameObject VFX_Rayo;
    public GameObject VFX_Pocion;
    public GameObject VFX_RayoActivo;
    public GameObject Personaje;
    public GameObject VFX_Ancla;
    public GameObject VFX_AnclaActiva;
    public GameObject VFX_PerderVida;


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
            if (VFX_Rayo != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(VFX_Rayo, posicion, Quaternion.identity);
            }

            StartCoroutine(AumentarVelocidadTemporal());

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Posion"))
        {
            audioSource.PlayOneShot(sonidoPosion);
            if (VFX_Pocion != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(VFX_Pocion, posicion, Quaternion.identity);
            }
            if (vida < 3)
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
            if (efectoVFX != null || VFX_PerderVida != null)
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(efectoVFX, posicion, Quaternion.identity);
                Vector3 posicion2 = transform.position + new Vector3(0, 5f, 0);
                Instantiate(VFX_PerderVida, posicion2, Quaternion.identity);
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
            
                if (VFX_Ancla != null)
                {
                    Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                    Instantiate(VFX_Ancla, posicion, Quaternion.identity);
                }

                StartCoroutine(DisminuirVelocidadTemporal());

                Destroy(other.gameObject);
        }
    }

    IEnumerator AumentarVelocidadTemporal()
    {
        velocidad += 5;

        if (velocidad <= 0)
        {
            velocidad = 1f;
        }

        GameObject vfxActivo = null;
        if (VFX_RayoActivo != null)
        {
            Vector3 posicion = transform.position;
            vfxActivo = Instantiate(VFX_RayoActivo, posicion, Quaternion.identity);
            vfxActivo.transform.SetParent(transform); // Hace que el efecto siga al personaje
            vfxActivo.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            vfxActivo.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Personaje.CompareTag("Player1"))
        {
            PuntajeManager.instance.setvelocidadPlayer1(velocidad, Personaje.gameObject.name.ToString());
        }
        else if (Personaje.CompareTag("Player2"))
        {
            PuntajeManager.instance.setvelocidadPlayer2(velocidad, Personaje.gameObject.name.ToString());
        }

        yield return new WaitForSeconds(10f);

        velocidad = 10f;

        if (Personaje.CompareTag("Player1"))
        {
            PuntajeManager.instance.setvelocidadPlayer1(velocidad, Personaje.gameObject.name.ToString());
        }
        else if (Personaje.CompareTag("Player2"))
        {
            PuntajeManager.instance.setvelocidadPlayer2(velocidad, Personaje.gameObject.name.ToString());
        }

        if (vfxActivo != null)
        {
            StartCoroutine(EncogerYDestruir(vfxActivo, 1f));
        }
    }

    IEnumerator DisminuirVelocidadTemporal()
    {
        velocidad -= 5;

        if (velocidad <= 0)
        {
            velocidad = 1;
        }

        GameObject vfxActivo = null;
        if (VFX_AnclaActiva != null)
        {
            Vector3 posicion = transform.position;
            vfxActivo = Instantiate(VFX_AnclaActiva, posicion, Quaternion.identity);
            vfxActivo.transform.SetParent(transform); // Hace que el efecto siga al personaje
        }

        if (Personaje.CompareTag("Player1"))
        {
            PuntajeManager.instance.setvelocidadPlayer1(velocidad, Personaje.gameObject.name.ToString());
        }
        else if (Personaje.CompareTag("Player2"))
        {
            PuntajeManager.instance.setvelocidadPlayer2(velocidad, Personaje.gameObject.name.ToString());
        }

        yield return new WaitForSeconds(6f);

        velocidad = 10f;

        if (Personaje.CompareTag("Player1"))
        {
            PuntajeManager.instance.setvelocidadPlayer1(velocidad, Personaje.gameObject.name.ToString());
        }
        else if (Personaje.CompareTag("Player2"))
        {
            PuntajeManager.instance.setvelocidadPlayer2(velocidad, Personaje.gameObject.name.ToString());
        }

        if (vfxActivo != null)
        {
            StartCoroutine(EncogerYDestruir(vfxActivo, 1f));
        }
    }

    IEnumerator EncogerYDestruir(GameObject objeto, float duracion)
    {
        Vector3 escalaInicial = objeto.transform.localScale;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            float escala = Mathf.Lerp(1f, 0f, tiempo / duracion);
            objeto.transform.localScale = escalaInicial * escala;
            tiempo += Time.deltaTime;
            yield return null;
        }

        Destroy(objeto);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo")) // Reproduce sonido al colisionar con obstaculos
        {

            audioSource.PlayOneShot(sonidoObstaculos);
         
        }
    }
}


