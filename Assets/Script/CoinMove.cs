using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    public bool _tarik = false;
    private GameObject _truk;
    private float _magnetForce = 8f;

    void Start()
    {
        _truk = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(_tarik)
        {
            Vector3 targetPosition = new Vector3(_truk.transform.position.x, _truk.transform.position.y, _truk.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _magnetForce * Time.deltaTime);
            if(transform.position == _truk.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }
}
