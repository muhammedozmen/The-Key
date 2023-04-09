using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookAtObjects : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOB;
    [SerializeField] private string description = "Description";
    
    void Start()
    {
        textOB.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            textOB.GetComponent <TextMeshProUGUI>().enabled = true;
            textOB.text = description.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            textOB.GetComponent<TextMeshProUGUI>().enabled = false;
            textOB.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
