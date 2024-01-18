using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMovement : MonoBehaviour
{
    Image _hUD;
    public Vector3 _tergetPos;
    public Vector3 _homePos;
    public MagnetTimer _spawn;
    public GameObject _parent;
    // Start is called before the first frame update
    void Start()
    {
        _hUD = GetComponent<Image>();
    }

    // Update is called once per 
    void Update()
    {
        if(_spawn._spawn)
        {
            _hUD.rectTransform.anchoredPosition = Vector3.Lerp(_hUD.rectTransform.anchoredPosition, _tergetPos, 2f * Time.deltaTime);
        }
        else{
            _hUD.rectTransform.anchoredPosition = Vector3.Lerp(_hUD.rectTransform.anchoredPosition, _homePos, 2f * Time.deltaTime);
            Vector3 _3d = _hUD.rectTransform.anchoredPosition;
            if( _3d.y < 0f)
            {
                if (transform.root != null)
                {
                    _parent.SetActive(false);
                }
            }
        }
    }
}