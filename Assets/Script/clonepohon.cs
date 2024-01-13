using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonepohon : MonoBehaviour
{
    public GameObject pohon;
    public float batasy;
    public float batasx;
    public float x;
    public float y;
    public float ukuranx;
    public float ukurany;
    float xawal;
    private GameObject pohonclone;

    void Start()
    {
        //GameObject pohonclone = Instantiate(pohon);
        xawal = x;
        createpohon();
    }
    void createpohon()
    {
        while (y>=batasy)
        {
            pohonclone = Instantiate(pohon, new Vector3(x,y, 0f), Quaternion.identity);
            x += ukuranx;
            if (x > batasx){
                x = xawal;
                y -= ukurany;
            }
        }
    }
}
