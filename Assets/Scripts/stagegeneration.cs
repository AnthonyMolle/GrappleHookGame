using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class stagegeneration : MonoBehaviour
{


    [SerializeField] GameObject[] blockPrefabs;
    [SerializeField] Color stageColor;
    public float stageOffset;
    public GameObject player;

    private GameObject[] blocks;

    //Start is called before the first frame update
    void Start()
    {
        blocks = new GameObject[3];
        CreateBlock();
        CreateBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= blocks[1].transform.position.y) {
            Destroy(blocks[0]);
            blocks[0] = blocks[1];
            blocks[1] = null;
            CreateBlock();
        }
    }

    void CreateBlock() {
        if (blocks[0] == null) {
            blocks[0] = Instantiate(blockPrefabs[0]); //0 is base stage 
            blocks[0].transform.position = new Vector3(0, 0, 0);
            blocks[0].GetComponentInChildren<Tilemap>().color = stageColor;
            Debug.Log(blocks[0]);
        }
        else {
            blocks[1] = Instantiate(blockPrefabs[Random.Range(1 ,blockPrefabs.Length)]); 
            blocks[1].transform.position = new Vector3(0, blocks[0].transform.position.y + stageOffset, 0);
            blocks[1].GetComponentInChildren<Tilemap>().color = stageColor;
        }
    }
}
