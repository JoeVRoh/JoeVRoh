using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{
    public Text collectableText;
    public Text winText;

    private Rigidbody rb;
    private int collectable;
    private int blockage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collectable = 0;
        blockage = 0;
        SetCollecatableText();
        winText.text = "";
    }

// Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            collectable = collectable + 1;
            SetCollecatableText();
         }

        if (collectable >= 22)
        {
            if (other.gameObject.CompareTag("blockage"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    void SetCollecatableText()
    {
        collectableText.text = "Collectables: " + collectable.ToString() + "/22";
        if(collectable >= 22)
        {
            winText.text = "COMPLETE!";
        }
     }
}
