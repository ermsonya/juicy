using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutManagement : MonoBehaviour
{
    private FruitSpawn _fruitSpawn;

    public static bool isHit;

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

            isHit = true;
            
            switch (CutAppear.randomInt)
            {
                case 0:
                    FindObjectOfType<AudioManager>().Play("knife_big");
                    break;
                case 1:
                    FindObjectOfType<AudioManager>().Play("knife_medium");
                    break;
                case 2:
                    FindObjectOfType<AudioManager>().Play("knife_small");
                    break;
            }
        }
    }
}