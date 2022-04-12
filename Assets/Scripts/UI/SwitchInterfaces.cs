using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInterfaces : MonoBehaviour
{
    [SerializeField] private GameObject interface1, interface2;
    // Start is called before the first frame update
    void Start()
    {
        interface1.SetActive(true);
        interface2.SetActive(false);
    }

    public void SwitchInterface()
    {
        interface1.SetActive(!interface1.activeInHierarchy);
        interface2.SetActive(!interface2.activeInHierarchy);
    }
}
