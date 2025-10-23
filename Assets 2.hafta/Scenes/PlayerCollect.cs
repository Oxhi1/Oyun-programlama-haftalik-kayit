using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private int score = 0;

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject); 
            score++; 
            Debug.Log("Skor: " + score); 
        }
    }
}

