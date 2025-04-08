using UnityEngine;

public class Recoleccion : MonoBehaviour
{
    public GameObject efectoVFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recolector"))  // Detecta si tocó un recogible
        {
            if (efectoVFX != null)  // activa el efecto especial
            {
                Vector3 posicion = transform.position + new Vector3(0, 5f, 0);
                Instantiate(efectoVFX, posicion, Quaternion.identity);
            }
            Destroy(other.gameObject);  // Elimina el recogible
        }
    }
}