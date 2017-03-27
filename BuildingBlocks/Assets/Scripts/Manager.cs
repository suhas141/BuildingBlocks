using UnityEngine;
using System.Collections;
using System;

public class Block
{

    public Transform blockTransform;

}
public class Manager : MonoBehaviour
{
    private float blockSize = 0.25f;

    public Block[,,] blocks = new Block[5, 5, 5];
    public GameObject blockPrefab;
    private GameObject FoundationObject;
    private Vector3 blockOffset = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 FoundationCenter = new Vector3(2.5f, 0, 2.5f);


    private void Start()
    {

        FoundationObject = GameObject.Find("Foundation");

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30.0f))
            {   
                Vector3 index = BlockPosition(hit.point);
                int x =  (int)index.x ,
                     y = (int)index.y ,
                     z = (int)index.z;

                if (blocks[x, y, z] == null)
                {
                    GameObject go = Instantiate(blockPrefab) as GameObject;
                    PositionBlock(go.transform, index);
                    blocks[x, y, z] = new Block
                    {
                        blockTransform = go.transform
                    };
                }

                else
                {
                    GameObject go = Instantiate(blockPrefab) as GameObject;
                    Vector3 newIndex = BlockPosition(hit.point + hit.normal);
                    PositionBlock(go.transform, newIndex);
                }
            }
        }
    }

    private Vector3 BlockPosition(Vector3 hit)
    {
        //transform world point into block array
        Vector3 find = FoundationObject.transform.position - FoundationCenter;
        float x = (int)(hit.x + find.x);
        float y = (int)(hit.y + find.y);
        float z = (int)(hit.z + find.z);

        return new Vector3(x, y, z);

    }

    private void PositionBlock(Transform t, Vector3 index)
    {
        t.position = (index + blockOffset) + (FoundationObject.transform.position - FoundationCenter);
    }
}
