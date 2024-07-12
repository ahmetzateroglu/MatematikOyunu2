using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{

    public static string islem; 
    public static int zorluk;

    public GameObject ayarlarpanel;
    public GameObject secimpanel;
    public GameObject puanpanel;

    public Dropdown dropdown;

    public Text totalpuantext;     
    public Text rekabetcipuantext;

    public static int totalpuan;
    public static int rekabetcipuan;
    public static int toplamSoru;
    public static int toplamDogru;
    public static int toplamYanlis;

    public Text toplamSoruText;
    public Text toplamDogruText;
    public Text toplamYanlisText;



    void Start()
    {

        ayarlarpanel.SetActive(false);
        secimpanel.SetActive(false);
        puanpanel.SetActive(false);

        if (PlayerPrefs.HasKey("zorluk"))
        {
            zorluk = PlayerPrefs.GetInt("zorluk");
        }
        else 
        {
            PlayerPrefs.SetInt("zorluk", 0); 
        }

        dropdown.value = zorluk; 




        if (PlayerPrefs.HasKey("totalpuan")) 
        {

            totalpuan = PlayerPrefs.GetInt("totalpuan"); 
            totalpuantext.text = totalpuan.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("totalpuan", 0);
            totalpuantext.text = PlayerPrefs.GetInt("totalpuan").ToString();
        }

        if (PlayerPrefs.HasKey("rekabetcipuan")) 
        {
            rekabetcipuan = PlayerPrefs.GetInt("rekabetcipuan");
            rekabetcipuantext.text = rekabetcipuan.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("rekabetcipuan", 0);
            rekabetcipuantext.text = PlayerPrefs.GetInt("rekabetcipuan").ToString();
        }






        if (PlayerPrefs.HasKey("toplamSoru"))
        {
            
            toplamSoru = PlayerPrefs.GetInt("toplamSoru"); 
            toplamSoruText.text = toplamSoru.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("toplamSoru", 0);
            toplamSoruText.text = PlayerPrefs.GetInt("toplamSoru").ToString();
        }

        if (PlayerPrefs.HasKey("toplamDogru")) 
        {
           
            toplamDogru = PlayerPrefs.GetInt("toplamDogru"); 
            toplamDogruText.text = toplamDogru.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("toplamDogru", 0);
            toplamDogruText.text = PlayerPrefs.GetInt("toplamDogru").ToString();
        }

        if (PlayerPrefs.HasKey("toplamYanlis")) 
        {
            
            toplamYanlis = PlayerPrefs.GetInt("toplamYanlis"); 
            toplamYanlisText.text = toplamYanlis.ToString();
        }
        else 
        {
            PlayerPrefs.SetInt("toplamYanlis", 0);
            toplamYanlisText.text = PlayerPrefs.GetInt("toplamYanlis").ToString();
        }


    }


    void Update()
    {
        

    }


    public void ZorlukSec(int deger)
    {
      

        if (deger == 0)
        {
            zorluk = 0;
            PlayerPrefs.SetInt("zorluk", 0);

        }
        if (deger == 1)
        {
            zorluk = 1;
            PlayerPrefs.SetInt("zorluk", 1);
        }
        if (deger == 2)
        {
            zorluk = 2;
            PlayerPrefs.SetInt("zorluk", 2);
        }
    }


    public void IslemSec(string islemsec)
    {
        islem = islemsec;
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
    }

    public void QuitGame()
    {
        Debug.Log("Çýktýk"); 
        Application.Quit();
    }


    public void PanelAyarlari(int x)
    {
       
        if (x == 0)
        {
            ayarlarpanel.SetActive(true);

        }
        if (x == 1)
        {
            ayarlarpanel.SetActive(false);
        }
        if (x == 2)
        {
            secimpanel.SetActive(true);
        }
        if (x == 3)
        {
            secimpanel.SetActive(false);
        }
        if (x == 4)
        {
            puanpanel.SetActive(true);
        }
        if (x == 5)
        {
            puanpanel.SetActive(false);
        }

    }




}
