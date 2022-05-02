using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileGenerator : MonoBehaviour
{

    public GameObject emptyTile;
    public GameObject finalTile;
    public List<GameObject> tiles;
    public int tilesAmount;
    public float speed;
    public float planeSize;
    public bool randomizedSideways = false;
    public int emptyTilesBeforeStart = 3;
    public bool useCounter = true;
    public bool useTitan = false;

    private int totalUsedTiles = 0;
    private bool lastTilePlaced = false;
    private JerryCanCounter counter;
    private TitanController titanController;

    private List<GameObject> planes = new List<GameObject>();

    private float startingZ;
    private float endingZ;


    private GameObject GetNextTile()
    {
        GameObject tile;
        if (useTitan && titanController.dead)
        {
            tile = emptyTile;
        } else if (useCounter && counter && counter.count >= counter.target && !lastTilePlaced)
        {
            tile = finalTile;
            lastTilePlaced = true;
        }
        else if (useCounter && counter && counter.count >= counter.target && lastTilePlaced)
        {
            tile = emptyTile;
        }
        else
        if (totalUsedTiles < emptyTilesBeforeStart)
        {
            tile = emptyTile;
        }
        else
        {
            tile = tiles[Random.Range(0, tiles.Count-1)];
        }
    

        totalUsedTiles = totalUsedTiles + 1;
        return tile;
    }

    private void Start()
    {
        if (useCounter)
        {
            counter = GameObject.FindWithTag("Player").GetComponent("JerryCanCounter") as JerryCanCounter;
        }

        if (useTitan)
        {
            titanController  = GameObject.FindWithTag("Titan").GetComponent("TitanController") as TitanController;
        }

        lastTilePlaced = false;
        totalUsedTiles = 0;
        startingZ = planeSize * (tilesAmount - 1);
        endingZ = -planeSize;

        for (int i = tilesAmount - 1; i >= 0; i--)
        {
            GameObject plane = Instantiate(GetNextTile(), transform);
            if (randomizedSideways)
            {
                plane.transform.position = new Vector3(Random.Range(-1f, 2f), 0, startingZ - (i * planeSize));
            }
            else
            {
                plane.transform.position = new Vector3(0, 0, startingZ - (i * planeSize));
            }

            planes.Add(plane);
        }

    }

    private void Update()
    {

        for (int i = 0; i < tilesAmount; i++)
        {
            GameObject plane = planes[i];
            if (plane.transform.position.z <= endingZ)
            {
                GameObject temp = plane;
                float diff = endingZ - plane.transform.position.z;
                planes[i] = Instantiate(GetNextTile(), transform);
                if (randomizedSideways)
                {
                    planes[i].transform.position = new Vector3(Random.Range(-1f, 2f), 0, startingZ - diff - speed * Time.deltaTime);
                }
                else
                {
                    planes[i].transform.position = new Vector3(0, 0, startingZ - diff - speed * Time.deltaTime);
                }

                Destroy(temp);
            }
            else
            {
                plane.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
    }



}