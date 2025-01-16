using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayerString : MonoBehaviour
{
    [SerializeField] GameObject source;
    private Text _txt;

    // Start is called before the first frame update
    void Start()
    {
        _txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _txt.text = source.GetComponent<IDisplayString>().display();
    }
}
