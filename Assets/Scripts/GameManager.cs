using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{



    private Sesler Ses; 
    public GameObject sesobje; 

    public int seslerackapa;
    public int timersesackapa;

    public Text soruText; 
    public Text aText;
    public Text bText;
    public Text cText;
    public Text dText;
    public Button aButton, bButton, cButton, dButton; 
    public Color yesilRenk, kirmiziRenk, beyazRenk, sariRenk;

    public static int do�ruCevap;
    public static int do�ruCevapButonu; 
    public static string islem;


    public int soruSayisi = 1;
    public int puan = 0;
    public int dogruSayisi;
    public int yanlisSayisi;

    public float sure;
    public Text puanText, soruSayisiText, sureText;

    public GameObject panel;
    public Text panelpuan;
    public Text panelDSayisi;
    public Text panelYSayisi;

    public GameObject rekabetcipanel;
    public int panelSoruSayisi = 1;
    public Text rpanelpuan;
    public Text rpanelDSayisi;
    public Text rpanelYSayisi;
    public Text rpanelskor;
    public Text rpaneltebrikler;

    int karisikOncekiIslem;  

    public List<string> sorulanlar = new List<string>(); 

 



    void Start()
    {
        
        sorulanlar.Add("99999999");

        panel.SetActive(false);
        rekabetcipanel.SetActive(false);

        soruSayisi = 1;
        puan = 0;
        islem = MainMenu.islem; 
        

        seslerackapa = PlayerPrefs.GetInt("seslerackapa");
        timersesackapa = PlayerPrefs.GetInt("timersesackapa");


        Ses = sesobje.GetComponent<Sesler>();   

        SoruEkle();
    }


    void Update()
    {

        if (sure > 0 && sure != 99)                                                                      
        {
            sure -= Time.deltaTime;
            sureText.text = sure.ToString("00");
        }

        if (sure <= 0)  
        {

            if ((MainMenu.islem) == "rekabetci")
            {
                rpaneltebrikler.text += "S�re Bitti.";
                RekabetciBitis();
                puan -= 1;
                puanText.text = puan.ToString();
            }
            else
            {
                puan -= 1;
                puanText.text = puan.ToString();
                soruSayisi++;  
                SoruEkle();
            }

            
            

        }

    }

    public void SoruEkle()
    {
        if (timersesackapa == 1)
        {
            Invoke("TimerSes", 6.0f);  
        }


        if (soruSayisi <= 15)
        {
            



            aButton.enabled = true; 
            bButton.enabled = true;
            cButton.enabled = true;
            dButton.enabled = true;

            aButton.image.color = beyazRenk;
            bButton.image.color = beyazRenk;
            cButton.image.color = beyazRenk;
            dButton.image.color = beyazRenk;

            if ((MainMenu.islem) == "rekabetci")
            {
                soruSayisiText.text = panelSoruSayisi.ToString();
                rpaneltebrikler.text = "";
            }
            else
            {
                soruSayisiText.text = soruSayisi.ToString() + " / 15"; 
            }
            

            SoruUret();  
        }
        else
        {
            sure = 99; 
            Debug.Log("Tebrikler Bitti");
            panel.SetActive(true);
            panelDSayisi.text = dogruSayisi.ToString();
            panelYSayisi.text = yanlisSayisi.ToString();
            panelpuan.text = puan.ToString();

            MainMenu.totalpuan += puan; 
            PlayerPrefs.SetInt("totalpuan", MainMenu.totalpuan); 

            MainMenu.toplamSoru += dogruSayisi + yanlisSayisi;  
            PlayerPrefs.SetInt("toplamSoru", MainMenu.toplamSoru);

            MainMenu.toplamDogru += dogruSayisi;  
            PlayerPrefs.SetInt("toplamDogru", MainMenu.toplamDogru);

            MainMenu.toplamYanlis += yanlisSayisi; 
            PlayerPrefs.SetInt("toplamYanlis", MainMenu.toplamYanlis);


            sorulanlar.Clear(); 

        }




    }

    public void SoruUret()
    {
       

       Random.InitState(Random.Range(1,99999999));  // Bunun Yeni Tohum ayarlamas� ve rastgeleli�i art�rmas� laz�m

       string birsoru = "";

        int a=5, b=3, yanlis1, yanlis2, yanlis3;

        if ((MainMenu.islem) == "karisik")  
        {
            
            islem = "karisik";
            
            do
            {
                do
                {
                    a = Random.Range(1, 5);
                }
                while (karisikOncekiIslem == a);

                if (a == 1 && (ToggleManager.karisiktoplama == 1))
                {
                    islem = "toplama";
                    karisikOncekiIslem = a;
                }
                else if (a == 2 && (ToggleManager.karisikcikarma == 1))
                {
                    islem = "cikarma";
                    karisikOncekiIslem = a;
                } 
                else if (a == 3 && (ToggleManager.karisikcarpma == 1))
                {
                    islem = "carpma";
                    karisikOncekiIslem = a;
                }
                else if (a == 4 && (ToggleManager.karisikbolme == 1))
                {
                    islem = "bolme";
                    karisikOncekiIslem = a;
                }
                       

            } while (islem == "karisik");  


                
            

            
        }

        if ((MainMenu.islem) == "rekabetci")
        {
            MainMenu.zorluk = 1; 

            do
            {
                a = Random.Range(1, 5);
            }
            while (karisikOncekiIslem == a);

            if (a == 1)
            {
                islem = "toplama";
                karisikOncekiIslem = a;
            }
            else if (a == 2)
            {
                islem = "cikarma";
                karisikOncekiIslem = a;
            }
            else if (a == 3)
            {
                islem = "carpma";
                karisikOncekiIslem = a;
            }
            else if (a == 4)
            {
                islem = "bolme";
                karisikOncekiIslem = a;
            }

           
        }

        if ((MainMenu.zorluk) == 0) // 0 = KOLAY // Zorlu�a G�re Soru �retiliyor
        {
           
            

            if (islem == "toplama") 
            {

                a = Random.Range(1, 11);
                b = Random.Range(1, 11);

               
               
                soruText.text = (a + " + " + b).ToString();
                do�ruCevap = a + b;
            }
            else if (islem == "cikarma")
            {
                do  // a n�n b den b�y�k olmas� i�in
                {
                    a = Random.Range(5, 20);  
                    b = Random.Range(4, 15);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                do�ruCevap = a - b;
            }
            else if (islem == "carpma")
            {
                a = Random.Range(1, 11);
                b = Random.Range(1, 11);
                soruText.text = (a + " x " + b).ToString();
                do�ruCevap = a * b;
            }
            else if (islem == "bolme")
            {

                do  
                {
                    a = Random.Range(15, 61);
                    b = Random.Range(2, 7);
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                do�ruCevap = a / b;
            }


            do // ayn� olmas�n diye
            {
                

                int d = Random.Range(1, 3);
                if (d == 1)
                    yanlis1 = do�ruCevap + Random.Range(1, 4);
                else
                    yanlis1 = do�ruCevap - Random.Range(1, 4);

                d = Random.Range(1, 3);
                if (d == 1)
                    yanlis2 = do�ruCevap + Random.Range(1, 4);
                else
                    yanlis2 = do�ruCevap - Random.Range(1, 4);

                d = Random.Range(1, 3);
                if (d == 1)
                    yanlis3 = do�ruCevap + Random.Range(1, 4); 
                else
                    yanlis3 = do�ruCevap - Random.Range(1, 4);

            } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3); 

            SecenekleriYazdirma(yanlis1, yanlis2, yanlis3);
        }




        else if ((MainMenu.zorluk) == 1) // 1 = ORTA
        {

            if (islem == "toplama")
            {
                a = Random.Range(30, 99);
                b = Random.Range(20, 99);
                soruText.text = (a + " + " + b).ToString();
                do�ruCevap = a + b;
            }
            else if (islem == "cikarma")
            {
                do 
                {
                    a = Random.Range(45, 99);
                    b = Random.Range(15, 99);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                do�ruCevap = a - b;
            }
            else if (islem == "carpma")  // orta
            {
                a = Random.Range(12, 21);
                b = Random.Range(6, 21);
                soruText.text = (a + " x " + b).ToString();
                do�ruCevap = a * b;
            }
            else if (islem == "bolme")
            { 

                do 
                {
                    a = Random.Range(20, 121);
                    b = Random.Range(3, 11); 
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                do�ruCevap = a / b;
            }

            do
            {

                if (islem == "bolme")  
                {                              


                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = do�ruCevap + Random.Range(1, 4);
                    else
                        yanlis1 = do�ruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = do�ruCevap + Random.Range(1, 4);
                    else
                        yanlis2 = do�ruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = do�ruCevap + Random.Range(1, 4); 
                    else
                        yanlis3 = do�ruCevap - Random.Range(1, 4);


                }
                else
                {
                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = do�ruCevap + (Random.Range(10, 35) / 10) * 10; 
                                                                                 
                    else
                        yanlis1 = do�ruCevap - (Random.Range(10, 35) / 10) * 10;

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = do�ruCevap + Random.Range(1, 7);   
                    else
                        yanlis2 = do�ruCevap - Random.Range(1, 7);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = do�ruCevap + (Random.Range(10, 25) / 10) * 10; 
                    else
                        yanlis3 = do�ruCevap - (Random.Range(10, 25) / 10) * 10;

                }






            } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

            SecenekleriYazdirma(yanlis1, yanlis2, yanlis3);
        }





        else if ((MainMenu.zorluk) == 2) // 2 = ZOR
        {

            if (islem == "toplama")
            {
                a = Random.Range(200, 799);
                b = Random.Range(200, 799);
                soruText.text = (a + " + " + b).ToString();
                do�ruCevap = a + b;
            }
            else if (islem == "cikarma")
            {
                do  
                {
                    a = Random.Range(350, 999);
                    b = Random.Range(200, 699);
                } while (b > a);
                soruText.text = (a + " - " + b).ToString();
                do�ruCevap = a - b;
            }
            else if (islem == "carpma")
            {
                a = Random.Range(25, 60);
                b = Random.Range(15, 45); 
                soruText.text = (a + " x " + b).ToString();
                do�ruCevap = a * b;
            }
            else if (islem == "bolme")
            { 

                do  
                {
                    a = Random.Range(250, 888);
                    b = Random.Range(4, 30); 
                } while (a % b != 0);
                soruText.text = (a + " / " + b).ToString();
                do�ruCevap = a / b;
            }

            do
            {
                if (islem == "bolme")
                {
                    

                    int d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis1 = do�ruCevap + Random.Range(1, 4);
                    else
                        yanlis1 = do�ruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = do�ruCevap + Random.Range(1, 4);
                    else
                        yanlis2 = do�ruCevap - Random.Range(1, 4);

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = do�ruCevap + Random.Range(1, 4); 
                    else
                        yanlis3 = do�ruCevap - Random.Range(1, 4);


                }
                else
                {

                    int d = Random.Range(1, 3); 
                    if (d == 1)
                        yanlis1 = do�ruCevap + (Random.Range(10, 45) / 10) * 10 - (Random.Range(10, 25) / 10) * 100; 
                    else
                        yanlis1 = do�ruCevap - (Random.Range(10, 45) / 10) * 10 + (Random.Range(10, 25) / 10) * 100;  

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis2 = do�ruCevap /*+ (Random.Range(10, 45) / 10) * 10*/ + /*(Random.Range(10, 19) / 10) * 100*/ 100;  
                    else
                        yanlis2 = do�ruCevap /*- (Random.Range(10, 45) / 10) * 10*/ - /*(Random.Range(10, 19) / 10) * 100*/ 100;  

                    d = Random.Range(1, 3);
                    if (d == 1)
                        yanlis3 = do�ruCevap + (Random.Range(12, 35) / 10) * 10 + (Random.Range(10, 25) / 10) * 100; 
                    else
                        yanlis3 = do�ruCevap - (Random.Range(10, 35) / 10) * 10 - (Random.Range(10, 25) / 10) * 100;
                }

            } while (yanlis1 == yanlis2 || yanlis1 == yanlis3 || yanlis2 == yanlis3);

            SecenekleriYazdirma(yanlis1, yanlis2, yanlis3);

        }

        birsoru += a.ToString();
        birsoru += b.ToString();

        Debug.Log(birsoru);
      
        KontrolEt(birsoru);
        


    }

    public void KontrolEt(string birsoru) 
    {

        if(sorulanlar.Count<=200)
        {
            for (int i = 0; i < (sorulanlar.Count); i++) 
            {
                Debug.Log("Forday�m");
                Debug.Log(i);
                if (birsoru == sorulanlar[i])
                {
                    Debug.Log("Bu soru Var");
                    SoruUret(); 
                }

            }
            sorulanlar.Add(birsoru); 
        }
        else
        {
            sorulanlar.Clear();
        }
        
    }


    public void SecenekleriYazdirma(int yanlis1, int yanlis2, int yanlis3)
    {
        int c = Random.Range(1, 5);
        if (c == 1)
        {
            do�ruCevapButonu = 1;
            aText.text = do�ruCevap.ToString();
            bText.text = yanlis1.ToString();
            cText.text = yanlis2.ToString();
            dText.text = yanlis3.ToString();
        }
        if (c == 2)
        {
            do�ruCevapButonu = 2;
            bText.text = do�ruCevap.ToString();
            aText.text = yanlis1.ToString();
            cText.text = yanlis2.ToString();
            dText.text = yanlis3.ToString();
        }
        if (c == 3)
        {
            do�ruCevapButonu = 3;
            cText.text = do�ruCevap.ToString();
            bText.text = yanlis1.ToString();
            aText.text = yanlis2.ToString();
            dText.text = yanlis3.ToString();
        }
        if (c == 4)
        {
            do�ruCevapButonu = 4;
            dText.text = do�ruCevap.ToString();
            bText.text = yanlis1.ToString();
            cText.text = yanlis2.ToString();
            aText.text = yanlis3.ToString();
        }

        sure = 25; 

    }





    public void VerilenCevap(string x)
    {
        if (sure != 99) 
        {

            if (timersesackapa == 1)  
            {
                Ses.TimerSesiKapa();  
                CancelInvoke(); 
                               
            }

            string a = aText.text;  // Butonlardaki se�enekler al�n�yor
            string b = bText.text;
            string c = cText.text;
            string d = dText.text;
            int verilenCevap;

            if ((MainMenu.islem) == "rekabetci")
            {
                panelSoruSayisi++;
            }
            else
            {
                soruSayisi++;  
            }


            if (x == "a") 
            {
               
                bButton.enabled = false; 
                cButton.enabled = false;
                dButton.enabled = false;

                verilenCevap = int.Parse(a); 

                if (verilenCevap == do�ruCevap)
                {
                    if (seslerackapa == 1) 
                    {
                        Ses.DogruSesiCal(); 
                    }

                    aButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    aButton.image.color = kirmiziRenk;
                   
                    if (do�ruCevapButonu == 2)
                    {
                        bButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 3)
                    {
                        cButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 4)
                    {
                        dButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();

                }
                sure = 99;
                if (((MainMenu.islem) == "rekabetci") && (verilenCevap != do�ruCevap))  
                {
                    Invoke("RekabetciBitis", (float)1.2); 
                }
                else
                {
                    Invoke("SoruEkle", (float)1.2);  
                }
                
               

            }
            if (x == "b")
            {
                aButton.enabled = false;
                cButton.enabled = false;
                dButton.enabled = false;

                verilenCevap = int.Parse(b);
                if (verilenCevap == do�ruCevap)
                {
                    if (seslerackapa == 1) 
                    {
                        Ses.DogruSesiCal(); 
                    }

                    bButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    bButton.image.color = kirmiziRenk;

                    if (do�ruCevapButonu == 1)
                    {
                        aButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 3)
                    {
                        cButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 4)
                    {
                        dButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();
                }
                sure = 99;
                if (((MainMenu.islem) == "rekabetci") && (verilenCevap != do�ruCevap))
                {
                    Invoke("RekabetciBitis", (float)1.2);
                }
                else
                {
                    Invoke("SoruEkle", (float)1.2);  
                }
            }
            if (x == "c")
            {
                bButton.enabled = false;
                aButton.enabled = false;
                dButton.enabled = false;

                verilenCevap = int.Parse(c);
                if (verilenCevap == do�ruCevap)
                {
                    if (seslerackapa == 1)
                    {
                        Ses.DogruSesiCal();
                    }

                    cButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    cButton.image.color = kirmiziRenk;
                    if (do�ruCevapButonu == 2)
                    {
                        bButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 1)
                    {
                        aButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 4)
                    {
                        dButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();
                }
                sure = 99;
                if (((MainMenu.islem) == "rekabetci") && (verilenCevap != do�ruCevap))
                {
                    Invoke("RekabetciBitis", (float)1.2);
                }
                else
                {
                    Invoke("SoruEkle", (float)1.2);  
                }
            }
            if (x == "d")
            {
                bButton.enabled = false;
                cButton.enabled = false;
                aButton.enabled = false;

                verilenCevap = int.Parse(d);
                if (verilenCevap == do�ruCevap)
                {
                    if (seslerackapa == 1)
                    {
                        Ses.DogruSesiCal();
                    }

                    dButton.image.color = yesilRenk;
                    puan += 3;
                    dogruSayisi++;
                    puanText.text = puan.ToString();
                }
                else
                {
                    if (seslerackapa == 1)
                    {
                        Ses.YanlisSesiCal();
                    }

                    dButton.image.color = kirmiziRenk;
                    if (do�ruCevapButonu == 2)
                    {
                        bButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 3)
                    {
                        cButton.image.color = sariRenk;
                    }
                    else if (do�ruCevapButonu == 1)
                    {
                        aButton.image.color = sariRenk;
                    }
                    puan -= 1;
                    yanlisSayisi++;
                    puanText.text = puan.ToString();
                }
                sure = 99;
                if (((MainMenu.islem) == "rekabetci") && (verilenCevap != do�ruCevap))
                {
                    Invoke("RekabetciBitis", (float)1.2);
                }
                else
                {
                    Invoke("SoruEkle", (float)1.2);
                }
            }
        }
    }

    public void RekabetciBitis()
    { 


        sure = 99; 

        rekabetcipanel.SetActive(true); 
        rpanelDSayisi.text = dogruSayisi.ToString();
        rpanelYSayisi.text = yanlisSayisi.ToString();
        rpanelpuan.text = puan.ToString();
        if(puan>(MainMenu.rekabetcipuan))
        {          
            rpaneltebrikler.text += "Tebrikler Yeni Rekor.";
            (MainMenu.rekabetcipuan) = puan;
            PlayerPrefs.SetInt("rekabetcipuan", (MainMenu.rekabetcipuan));
            rpanelskor.text = (MainMenu.rekabetcipuan).ToString();
        }
        else
        {
            rpanelskor.text = (MainMenu.rekabetcipuan).ToString();
            rpaneltebrikler.text += "Rekoru K�ramad�n�z! Tekrar Deneyiniz.";
        }      

        MainMenu.totalpuan += puan;  
        PlayerPrefs.SetInt("totalpuan", MainMenu.totalpuan); 

        MainMenu.toplamSoru += dogruSayisi + yanlisSayisi;  
        PlayerPrefs.SetInt("toplamSoru", MainMenu.toplamSoru);

        MainMenu.toplamDogru += dogruSayisi;  
        PlayerPrefs.SetInt("toplamDogru", MainMenu.toplamDogru);

        MainMenu.toplamYanlis += yanlisSayisi; 
        PlayerPrefs.SetInt("toplamYanlis", MainMenu.toplamYanlis);


    }

    public void AnaMenuDon()
    {
        SceneManager.LoadScene(0); 

    }

    public void YeniTest()
    {
        SceneManager.LoadScene(1);
    }

    public void TimerSes()
    {

        Ses.TimerSesiCal();
       
    }





}
