using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAppear : MonoBehaviour
{
    public GameObject[] tileprefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    private bool timeIsUp = true;
    private string maintag;

    void Update()
    {
        if (timeIsUp && SceneManagment.isGameStarted)
        {
            StartCoroutine(WaitforReal());
        }
    }

    public void SpawnTile(int tileIndex)
    {
        var wantedx = Random.Range(minx, maxx);
        var wantedy = Random.Range(miny, maxy);
        var position = new Vector3(wantedx, wantedy);

        GameObject go = Instantiate(tileprefabs[tileIndex], position, transform.rotation);
        activeTiles.Add(go);
        maintag = go.tag;
        go.tag = "notactive";
    }

    public void SpawnTileReal()
    {
        activeTiles[0].SetActive(true);
        activeTiles[0].tag = maintag;

        // GameObject go = Instantiate(activeTiles[0], transform.position, transform.rotation);
        //  activeTiles.Add(go);
    }

    //нужно поменять тег и картину
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

        if (!CutManagement.isHit)
        {
            SceneManagment.RemoveHealth();
        }

        CutManagement.isHit = false;
        //  activeTiles.RemoveAt(1);
    }

    private IEnumerator WaitforReal()
    {
        timeIsUp = false;
        yield return new WaitForSeconds(1f);
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