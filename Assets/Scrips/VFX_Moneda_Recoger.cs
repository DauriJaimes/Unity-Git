using UnityEngine;

public class EfectosRecoleccionMonedas : MonoBehaviour
{
    public GameObject efectoVFX;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Moneda"))  // Detecta si toco una moneda
        {
            Debug.Log("==========================================Toco una moneda========================================================================================================");
            if (efectoVFX != null)
            {
                Instantiate(efectoVFX, transform.position, Quaternion.identity);
            }

        }

    }
}
