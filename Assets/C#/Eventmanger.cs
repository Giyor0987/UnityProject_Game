using UnityEngine;

public class Eventmanger : MonoBehaviour
{
    public bool _Istextevent;

    void Start()
    {
        _Istextevent = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _Istextevent = true;
        }
        else _Istextevent = false;
    }
}
