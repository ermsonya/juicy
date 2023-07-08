using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutManagement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yes");
        if (other.tag == gameObject.tag)
        {
            //FindObjectOfType<AudioManager>().PlaySound("");
            SceneManagment.numberScore += 1;
            Destroy(gameObject);
            Debug.Log("yes");
        }
    }
}
