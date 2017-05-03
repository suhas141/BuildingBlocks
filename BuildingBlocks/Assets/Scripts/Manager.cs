using UnityEngine;
using System.Collections;
using System;

public enum BackTexture
{
    White =0,
    Red = 1,
    Green = 2,
    Blue = 3,
    Black = 4
}

public class Block
{

    public Transform blockTransform;

}

public class Manager : MonoBehaviour
{
   

    private float blockSize = 0.25f;

    public Block[,,] blocks = new Block[20, 20, 20];
    public GameObject blockPrefab;

    public BackTexture selectedColour;
    public Material[] blockMaterial;

    private GameObject FoundationObject;
    private Vector3 blockOffset; 
    private Vector3 FoundationCenter = new Vector3(1.25f, 0, 1.25f);


    private void Start()
    {

        FoundationObject = GameObject.Find("BasePlane");
        blockOffset = (Vector3.one * 0.5f) / 4;
        selectedColour = BackTexture.White;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

          // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          //  if (Physics.Raycast(ray, out hit, 1000.0f))

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30.0f))
            {
                Vector3 index = BlockPosition(hit.point);
                //Vector3 index = hit.point + hit.normal / 2.0f;

                int x =  (int)index.x
                    , y = (int)index.y 
                    , z = (int)index.z;

                if (blocks[x, y, z] == null)
                {
                    GameObject go = CreateBlock();
                    go.transform.localScale = Vector3.one * blockSize;
                    PositionBlock(go.transform, index);
                    blocks[x, y, z] = new Block
                    {
                        blockTransform = go.transform
                    };
                }

                else
                {
                    GameObject go = CreateBlock();
                    go.transform.localScale = Vector3.one * blockSize;
                    Vector3 newIndex = BlockPosition(hit.point + hit.normal * blockSize);
                    PositionBlock(go.transform, newIndex);
                }
            }
        }
    }


    private GameObject CreateBlock()
    {
        GameObject go = Instantiate(blockPrefab) as GameObject;
        go.GetComponent<Renderer>().material = blockMaterial[(int)selectedColour];
        return go;

    }
    private Vector3 BlockPosition(Vector3 hit)
    {


        int x = (int)(hit.x / blockSize);
        int y = (int)(hit.y / blockSize);
        int z = (int)(hit.z / blockSize);



        //transform world point into block array
        // Vector3 find = FoundationObject.transform.position - FoundationCenter;
        //float x = (int)(hit.x + find.x);
        // float y = (int)(hit.y + find.y);
        // float z = (int)(hit.z + find.z);

        return new Vector3(x, y, z);

    }

    private void PositionBlock(Transform t, Vector3 index)
    {
        t.position = ((index * blockSize) + blockOffset ) + (FoundationObject.transform.position - FoundationCenter);

    }

    public void ChangeBackTexture(int color)
    {
        selectedColour = (BackTexture)color;
        /*switch(c)
        {
            case BackTexture.White:
                break;
            case BackTexture.Red:
                break;
            case BackTexture.Green:
                break;
            case BackTexture.Blue:
                break;
        } */
    }

}
