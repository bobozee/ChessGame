using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayerImage : MonoBehaviour
{
    [SerializeField] GameObject source;
    private Image _img;

    // Start is called before the first frame update
    void Start()
    {
        _img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _img.sprite = source.GetComponent<IDisplayImage>().display();
    }
}
