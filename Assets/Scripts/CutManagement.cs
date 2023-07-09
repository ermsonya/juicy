using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutManagement : MonoBehaviour
{
    private FruitSpawn _fruitSpawn;
    
    void Start()
    {
        _fruitSpawn = GameObject.Find("FruitSpawner").GetComponent<FruitSpawn>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yes");
        if (other.tag == gameObject.tag)
        {
            //FindObjectOfType<AudioManager>().PlaySound("");
            SceneManagment.numberScore += 1;
            _fruitSpawn.DeleteFruit(gameObject);
            Debug.Log("yes");
        }
    }
}
