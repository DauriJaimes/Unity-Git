using UnityEngine;

public class Obstaculo_mov: MonoBehaviour
{
    public float speed = 1f;  // Velocidad del objeto
    private float destroyZ = -10f; // Posición donde se destruirá el objeto
    private Renderer objRenderer;
    private Renderer[] renderers; // Arreglo de Renderers


    void Start()
    {
        // La posición de eliminación depende de la dirección de la cámara
        destroyZ = Camera.main.transform.position.z - 2f; // Un poco más atrás de la cámara
                                                          // Obtener todos los renderers dentro del objeto y sus hijos
        renderers = GetComponentsInChildren<Renderer>();

        // Ocultar todos los renderers al inicio
        SetRenderersVisible(false);

        // Obtener el Renderer del objeto
        objRenderer = GetComponent<Renderer>();

        // Asegurar que el objeto esté oculto al inicio
        objRenderer.enabled = false;
    }

    void Update()
    {

        // Mueve el objeto hacia la cámara en el eje Z
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // Si el objeto pasa la cámara, se destruye
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }

        // Activa todos los renderers
        if (transform.position.z <= 350.9f)
        {
            SetRenderersVisible(true); 
        }

       //Debug.Log(gameObject.name + " - Speed: " + speed + " - Pos Z: " + transform.position.z);
    }


    // Método para activar/desactivar todos los renderers
    void SetRenderersVisible(bool state)
    {
        foreach (Renderer r in renderers)
        {
            r.enabled = state;
        }
    }

 

}
