using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzik : MonoBehaviour
{
    


    AudioSource muzik;
    public int muzikackapa;
    public static Muzik obje; 

    void Awake()  
    {
       

        if (obje == null)
        {
            obje = this;

        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }


    void Start()
    {



        muzik = GetComponent<AudioSource>(); 

    }


    void Update()
    {
        muzikackapa = PlayerPrefs.GetInt("muzikackapa");

        if (muzikackapa == 1)
        {
            sesac();
        }
        if (muzikackapa == 0)
        {
            seskapa();
        }

    }

    void sesac()
    {
        muzik.mute = false;

    }
    void seskapa()
    {
        muzik.mute = true;
    }
}