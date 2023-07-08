using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAppear : MonoBehaviour
{
    public GameObject[] tileprefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    public float min;
    public float max;
    private bool timeIsUp = true;
    void Start()
    {
       
    }

    void Update()
    {
      
       if (timeIsUp)
       {
            StartCoroutine(WaitforReal());
        }
    }
    public void SpawnTile(int tileIndex)
    {
        var wanted = Random.Range(min, max);
        var position = new Vector3(wanted, transform.position.y);

        GameObject go = Instantiate(tileprefabs[tileIndex], position, transform.rotation);
        activeTiles.Add(go);
    }
    public void SpawnTileReal()
    {
        activeTiles[0].SetActive(true);
       // GameObject go = Instantiate(activeTiles[0], transform.position, transform.rotation);
      //  activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        activeTiles[0].SetActive(false);
        //activeTiles.RemoveAt(0);
    }
    private void DeleteAll()
    {
       // Destroy(activeTiles[1]);
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
      //  activeTiles.RemoveAt(1);
    }

    private IEnumerator WaitforReal()
    {
        timeIsUp = false;
        SpawnTile(Random.Range(0, 3));
        yield return new WaitForSeconds(1f);
        DeleteTile();
        yield return new WaitForSeconds(2f);
        SpawnTileReal();
        yield return new WaitForSeconds(2f);
        DeleteAll();
        timeIsUp = true;
    }
}

