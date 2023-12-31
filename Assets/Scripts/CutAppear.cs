using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutAppear : MonoBehaviour
{
    public GameObject[] tileprefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    private bool timeIsUp = true;
   // private string maintag;
    public static int randomInt;

    public static bool change=false;

  //  public SpriteRenderer spriteRenderer;
  //  public Sprite newSprite;

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
        Quaternion newQuaternion = new Quaternion(0, 0, Random.Range(10, 130), 1);

        GameObject go = Instantiate(tileprefabs[tileIndex], position, newQuaternion);
        activeTiles.Add(go);
      // maintag = go.tag;
      //  go.tag = "notactive";
    }

    public void SpawnTileReal()
    {
        activeTiles[0].SetActive(true);
        //activeTiles[0].tag = maintag;

        // GameObject go = Instantiate(activeTiles[0], transform.position, transform.rotation);
        //  activeTiles.Add(go);
    }

    //����� �������� ��� � �������
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
            FindObjectOfType<AudioManager>().Play("knife_miss");
        }

        CutManagement.isHit = false;
    }

    private IEnumerator WaitforReal()
    {
        timeIsUp = false;
        yield return new WaitForSeconds(1f);


        randomInt = Random.Range(0, 3);
        SpawnTile(randomInt);
     

       // DeleteTile();
       // yield return new WaitForSeconds(2f);


        SpawnTileReal();
        yield return new WaitForSeconds(3f);
       //DeleteTile();
       // yield return new WaitForSeconds(2f);
       // change = true;
        
      

        DeleteAll();
        //change = false;
        timeIsUp = true;
    }
}