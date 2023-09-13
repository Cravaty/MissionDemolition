using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject cloudSphere;
    public int numSpheresMin = 6;
    public int numSpheresMax = 10;
    public Vector3 sphereOffSetScale = new Vector3(5, 2, 1);
    public Vector2 sphereScaleRangeX = new Vector2(4, 8);
    public Vector2 sphereScaleRangeY = new Vector2(3, 4);
    public Vector2 sphereScaleRangeZ = new Vector2(2, 4);
    public float scaleYMin = 2f;
    private List<GameObject> spheres;

    void Start()
    {
        spheres = new List<GameObject>();
        int num = Random.Range(numSpheresMin, numSpheresMax);
        for (int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate<GameObject>(cloudSphere);
            spheres.Add(sp);
            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);
            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphereOffSetScale.x;
            offset.y *= sphereOffSetScale.y;
            offset.z *= sphereOffSetScale.z;
            spTrans.localPosition = offset;
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);
            scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffSetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYMin);
            spTrans.localScale = scale;
        }
    }
    void Update()
    {
        //if (input.getkeydown(keycode.space))
        //    restart();
    }
    void Restart()
    {
        foreach (GameObject sp in spheres)
            Destroy(sp);
        Start();
    }
}
