using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bapet_Spawn : MonoBehaviour
{
    public float spawnInterval;
    public GameObject objectToSpawn;
    //public float X1, X2, Z1, Z2;
    public float[] arrayX;
    public float[] arrayZ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBapet", 2f, spawnInterval);
    }

    public void Cancel()
    {
        CancelInvoke("SpawnBapet");
    }

    void SpawnBapet()
    {
        float Xnow = arrayX[Random.Range(0, arrayX.Length)];
        float Znow = arrayZ[Random.Range(0, arrayZ.Length)];
        Vector3 posisiRandom = new Vector3(Xnow, 0f, Znow);
        Instantiate(objectToSpawn, posisiRandom, transform.rotation);
    }

}
