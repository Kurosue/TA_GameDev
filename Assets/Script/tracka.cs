using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracka : MonoBehaviour
{
    public GameObject trackawal;
    public gerakplayer gerakplayer;
    public GameObject track1;
    public GameObject track2;
    public GameObject track3;
    public GameObject track4;
    public GameObject track5;
    public GameObject track6;
    public GameObject track7;
    public GameObject track8;
    public GameObject pohon1;
    public GameObject pohon2;
    public GameObject pohon3;
    public float batasbawah;
    public float respawny;
    private float kecepatanawal = 2f;
    private float percepatanawal = 0.1f;
    private float timer;
    public float kecepatan;
    public float percepatan;
    public float perubahanpercepatan;
    public float xpohonkanan;
    public float xpohonkiri;
    public float respawnypohon; 
    public float destroypohony;
    private List<GameObject> gameObjects;
    private List<GameObject> pohonObject;
    private GameObject trackatas;
    private GameObject trackbawah;
    private GameObject pohonkananbawah;
    private GameObject pohonkiribawah;
    private GameObject pohonkananatas;
    private GameObject pohonkiriatas;
    private int randompohonIndexkananatas;
    private int randompohonIndexkiriatas;
    private int randompohonIndexkananbawah;
    private int randompohonIndexkiribawah;
    public float waktucepat;
    public float nyawa;
    private int randomTrackIndexatas;
    private int randomTrackIndexbawah;

    void Start()
    {
        gameObjects = new List<GameObject> {track1, track2, track3, track4, track5, track6, track7, track8, trackawal};
        pohonObject = new List<GameObject> {pohon1, pohon2, pohon3};
        Respawntrackatas(8);
        Respawnpohonatas();
        Respawntrackbawah(0f, 8);
        Respawnpohonbawah(2.5f);
    }
    void FixedUpdate()
    {
        tambahcepat();
        geraktrack();
        if (trackatas.transform.position.y <= batasbawah){
            Destroy(trackatas);
            randomTrackIndexatas = Random.Range(0,8);
            Respawntrackatas(randomTrackIndexatas);
        }
        if (trackbawah.transform.position.y <=batasbawah){
            Destroy(trackbawah);
            randomTrackIndexbawah = Random.Range(0,8);
            Respawntrackbawah(respawny, randomTrackIndexbawah);
        }
        if (pohonkananatas.transform.position.y <=destroypohony){
            Destroy(pohonkananatas);
            Destroy(pohonkiriatas);
            Respawnpohonatas();
        }
        if (pohonkananbawah.transform.position.y <=destroypohony){
            Destroy(pohonkiribawah);
            Destroy(pohonkananbawah);
            Respawnpohonbawah(respawnypohon);
        }
    }
    void Respawntrackatas(int randomTrackIndexatas)
    {
        trackatas = Instantiate(gameObjects[randomTrackIndexatas], new Vector3(0f,respawny, 0f), Quaternion.identity);
    }
    void Respawnpohonatas(){
        randompohonIndexkananatas = Random.Range(0,3);
        randompohonIndexkiriatas = Random.Range(0,3);
        pohonkananatas = Instantiate(pohonObject[randompohonIndexkananatas], new Vector3(xpohonkanan,respawnypohon ,0f), Quaternion.identity);
        pohonkiriatas = Instantiate(pohonObject[randompohonIndexkiriatas], new Vector3(xpohonkiri,respawnypohon ,0f), Quaternion.identity);
    }
    void tambahcepat(){
        percepatan /= perubahanpercepatan;
        kecepatan += percepatan*Time.deltaTime;
        // timer += Time.deltaTime;
        // if (timer >= waktucepat){
        //     percepatan /= perubahanpercepatan;
        //     kecepatan += percepatan;
        //     timer = 0;
        // }
    }
    void geraktrack(){
        pohonkananatas.transform.Translate(Vector3.down * kecepatan * Time.deltaTime);
        pohonkiriatas.transform.Translate(Vector3.down * kecepatan * Time.deltaTime);
        trackatas.transform.Translate(Vector3.down * kecepatan * Time.deltaTime);
        trackbawah.transform.Translate(Vector3.down * kecepatan * Time.deltaTime);
        pohonkananbawah.transform.Translate(Vector3.down * kecepatan * Time.deltaTime);
        pohonkiribawah.transform.Translate(Vector3.down * kecepatan * Time.deltaTime);
    }
    void Respawntrackbawah(float respawny, int randomTrackIndexbawah){
        trackbawah = Instantiate(gameObjects[randomTrackIndexbawah], new Vector3(0f,respawny, 0f), Quaternion.identity);
    }
    void Respawnpohonbawah(float respawnypohon){
        randompohonIndexkananbawah = Random.Range(0,3);
        randompohonIndexkiribawah = Random.Range(0,3);
        pohonkananbawah = Instantiate(pohonObject[randompohonIndexkananbawah], new Vector3(xpohonkanan,respawnypohon ,0f), Quaternion.identity);
        pohonkiribawah = Instantiate(pohonObject[randompohonIndexkiribawah], new Vector3(xpohonkiri,respawnypohon ,0f), Quaternion.identity);
    }
}
