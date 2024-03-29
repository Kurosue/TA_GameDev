using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracka : MonoBehaviour
{
    public GameObject trackawal;
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
    public float kecepatan = 0.15f;
    public float timer = 0f;
    public float percepatan = 0.15f;
    public float _timerAccel = 0;

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
    private int randomTrackIndexatas;
    private int randomTrackIndexbawah;
    public GameManager _jalan;
    private float _currSpeed;

    void Start()
    {
        gameObjects = new List<GameObject> {track1, track2, track3, track4, track5, track6, track7, track8, trackawal};
        pohonObject = new List<GameObject> {pohon1, pohon2, pohon3};
        Respawntrackatas(8);
        Respawnpohonatas();
        Respawntrackbawah(0f, 8);
        Respawnpohonbawah(2.5f);
        _currSpeed = kecepatan;
    }
    void FixedUpdate()
    {
        if(_jalan._gas == 1)
        {
            tambahcepat();
            Debug.Log("oaisjdfjiaosf");
            geraktrack();
            if (trackatas.transform.position.y <= batasbawah)
            {
                Destroy(trackatas);
                randomTrackIndexatas = Random.Range(0,8);
                Respawntrackatas(randomTrackIndexatas);
            }
            if (trackbawah.transform.position.y <=batasbawah)
            {
                Destroy(trackbawah);
                randomTrackIndexbawah = Random.Range(0,8);
                Respawntrackbawah(respawny, randomTrackIndexbawah);
            }
            if (pohonkananatas.transform.position.y <=destroypohony)
            {
                Destroy(pohonkananatas);
                Destroy(pohonkiriatas);
                Respawnpohonatas();
            }
            if (pohonkananbawah.transform.position.y <=destroypohony)
            {
                Destroy(pohonkiribawah);
                Destroy(pohonkananbawah);
                Respawnpohonbawah(respawnypohon);
            }
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
        if(_currSpeed > kecepatan)
        {
            kecepatan += percepatan * Time.deltaTime;
        }else
        {
            timer += Time.deltaTime;
            kecepatan = 0.5f*Mathf.Sqrt(timer);
            _currSpeed = kecepatan;
        }

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