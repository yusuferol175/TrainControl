using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;


public class train_control_sc : MonoBehaviour
{
    [SerializeField] private GameObject pos_gate_1_;
    [SerializeField] private GameObject neg_gate_1_;
    [SerializeField] private GameObject pos_gate_2_;
    [SerializeField] private GameObject neg_gate_2_;
    [SerializeField] private GameObject pos_gate_3_;
    [SerializeField] private GameObject neg_gate_3_;

    [SerializeField] private GameObject vagonPrefab;
    [SerializeField] private TMP_Text vagon_sayi_t;
    [SerializeField] private TMP_Text skor;

    [SerializeField] private List<GameObject> vagons = new List<GameObject>();

    Rigidbody rigy;
    bool sol;
    bool sag;

    private bool bitti = false;

    float hiz = -10f;

    private int gateNumber;
    private int targetCount;

    private bool basla = false;

    [SerializeField] AudioClip korna;
    [SerializeField] AudioClip kaza;
    [SerializeField] AudioClip okay;
    [SerializeField] GameObject ses;

    [SerializeField] GameObject arti_1;
    [SerializeField] GameObject eksi_1;

    [SerializeField] List<Color> renkler = new List<Color>();
    


    //[SerializeField] GameObject insan;
    //[SerializeField] GameObject durak;
    //[SerializeField] GameObject durak_2;
    //[SerializeField] TMP_Text durak_t;
    //[SerializeField] TMP_Text durak_t_2;
    [SerializeField] TMP_Text level;

    [SerializeField] Camera kamera;

    System.Random rand = new System.Random();

    private string getRandColor()
    {
        System.Random rnd = new System.Random();
        string hexOutput = String.Format("{0:X}", rnd.Next(0, 0xFFFFFF));
        while (hexOutput.Length < 6)
            hexOutput = "0" + hexOutput;
        return  hexOutput;
    }
    void Start()
    {
        PlayerPrefs.SetInt("skor", 0);
        if (PlayerPrefs.GetInt("renk_sayi")==10)
        {
            PlayerPrefs.SetInt("renk_sayi", 0);
            kamera.GetComponent<Camera>().backgroundColor = renkler[PlayerPrefs.GetInt("renk_sayi")];
            PlayerPrefs.SetInt("renk_sayi", PlayerPrefs.GetInt("renk_sayi") + 1);
        }
        else
        {
            kamera.GetComponent<Camera>().backgroundColor = renkler[PlayerPrefs.GetInt("renk_sayi")];
            PlayerPrefs.SetInt("renk_sayi", PlayerPrefs.GetInt("renk_sayi")+1);
        }
        
        rigy = GetComponent<Rigidbody>();
        level.text = "Level "+(PlayerPrefs.GetInt("level")+1).ToString();
        arti_1.SetActive(false);
        eksi_1.SetActive(false);

        int kapý_deger = rand.Next(0, 2);
        int kapý_deger_2 = rand.Next(0, 2);
        int kapý_deger_3 = rand.Next(0, 2);
        if (kapý_deger == 0)
        {

        }
        else if (kapý_deger == 1)
        {
            pos_gate_1_.transform.position = new Vector3(-1.312f, pos_gate_1_.transform.position.y, pos_gate_1_.transform.position.z);
            neg_gate_1_.transform.position = new Vector3(1.224f, neg_gate_1_.transform.position.y, neg_gate_1_.transform.position.z);
        }
        if (kapý_deger_2 == 0)
        {

        }
        else if (kapý_deger_2 == 1)
        {
            pos_gate_2_.transform.position = new Vector3(-1.312f, pos_gate_2_.transform.position.y, pos_gate_2_.transform.position.z);
            neg_gate_2_.transform.position = new Vector3(1.224f, neg_gate_2_.transform.position.y, neg_gate_2_.transform.position.z);
        }
        if (kapý_deger_3 == 0)
        {

        }
        else if (kapý_deger_3 == 1)
        {
            pos_gate_3_.transform.position = new Vector3(-1.312f, pos_gate_3_.transform.position.y, pos_gate_3_.transform.position.z);
            neg_gate_3_.transform.position = new Vector3(1.224f, neg_gate_3_.transform.position.y, neg_gate_3_.transform.position.z);
        }

    }

   
    public GameObject _start;
    
    public GameObject tren_ses;
    void Update()
    {
        if (PlayerPrefs.GetInt("skor")<0)
        {
            PlayerPrefs.SetInt("skor", 0);
        }
        else
        {
            skor.text = PlayerPrefs.GetInt("skor").ToString();
        }
        
        if (Input.touchCount > 0)
        {
            basla = true;
            _start.SetActive(false);
            

        }
        if (basla)
        {
            
            
            vagon_sayi_gncll();
            transform.Translate(0, 0, hiz * Time.deltaTime);
            if (bitti==false)
            {
                if (tren_ses.GetComponent<AudioSource>().isPlaying == false)
                {
                    tren_ses.GetComponent<AudioSource>().Play();

                }

                Vector3 sag_git = new Vector3(1.69f, transform.position.y, transform.position.z);
                Vector3 sola_git = new Vector3(-2.3f, transform.position.y, transform.position.z);

                if (Input.touchCount > 0)
                {
                    Touch dokan = Input.GetTouch(0);
                    if (dokan.deltaPosition.x > 15.0f)
                    {
                        sag = true;
                        sol = false;
                    }
                    if (dokan.deltaPosition.x < -15.0f)
                    {
                        sag = false;
                        sol = true;
                    }
                    if (sag == true)
                    {
                        transform.position = Vector3.Lerp(transform.position, sag_git, 5 * Time.deltaTime);
                    }
                    if (sol == true)
                    {
                        transform.position = Vector3.Lerp(transform.position, sola_git, 5 * Time.deltaTime);
                    }
                }
            }

            
        }
       
        
    }
    private void finish_gel()
    {
        PlayerPrefs.SetInt("skor", PlayerPrefs.GetInt("skor") + (vagons.Count * 200));
        SceneManager.LoadScene("finish");
    }
    //private bool bi_sefer = true;
    private void vagon_sayi_gncll()
    {
        vagon_sayi_t.text = vagons.Count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("vagon"))
        {
            PlayerPrefs.SetInt("skor", PlayerPrefs.GetInt("skor") + 250);
            ses.GetComponent<AudioSource>().PlayOneShot(okay);
            arti_1.SetActive(true);
            Invoke("arti_1_gel", 0.5f);
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(-1.4f, 0f, vagons[vagons.Count - 1].transform.localPosition.z + 6f);
            vagons.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("kapi"))
        {
            gateNumber = other.gameObject.GetComponent<gate_control>().getGateNumber();
            targetCount = vagons.Count + gateNumber;
            if (gateNumber>0)
            {
                vagonGel();
            }
            else if (gateNumber<0)
            {
                vagonGit();                
            }
        }
        if (other.gameObject.CompareTag("finish"))
        {
            hiz = 0f;

            bitti = true;

            tren_ses.GetComponent<AudioSource>().loop = false;
            tren_ses.GetComponent<AudioSource>().volume = 0.5f;
            tren_ses.GetComponent<AudioSource>().PlayOneShot(korna);
            Invoke("finish_gel",1.5f);
            
            

        }
        if (other.gameObject.CompareTag("stop"))
        {
            PlayerPrefs.SetInt("skor", PlayerPrefs.GetInt("skor") - 250);
            ses.GetComponent<AudioSource>().PlayOneShot(kaza);
            titret();
            Destroy(other.gameObject);
            eksi_1.SetActive(true);
            Invoke("eksi_1_gel", 0.5f);
            Destroy(vagons[vagons.Count - 1]);
            vagons.RemoveAt(vagons.Count - 1);

            if (vagons.Count == 0)
            {
                SceneManager.LoadScene("olum");
            }
            vagon_sayi_gncll();
        }
        if (other.gameObject.CompareTag("car"))
        {
            PlayerPrefs.SetInt("skor", PlayerPrefs.GetInt("skor") - 250);
            titret();
            ses.GetComponent<AudioSource>().PlayOneShot(kaza);
            Destroy(other.gameObject);
            eksi_1.SetActive(true);
            Invoke("eksi_1_gel", 0.5f);
            
            Destroy(vagons[vagons.Count - 1]);
            vagons.RemoveAt(vagons.Count-1);
            
            if (vagons.Count == 0)
            {
                titret();
                SceneManager.LoadScene("olum");
            }
            vagon_sayi_gncll();

        }
        //if (other.gameObject.CompareTag("durak"))
        //{
        //    if (bi_sefer)
        //    {
        //        if (vagons.Count==1)
        //        {

        //        }
        //        else
        //        {
        //            for (int i =1; i < int.Parse(durak_t.GetComponent<TMP_Text>().text)+1; i++)
        //            {
                        
        //                if (vagons.Count - 1 < int.Parse(durak_t.GetComponent<TMP_Text>().text))
        //                {
        //                    for (int j = 0; j < vagons.Count - 1; j++)
        //                    {
        //                        durak.GetComponent<durak_sc>().insanlar[j].SetActive(false);
        //                    }
                           
        //                }
        //                else
        //                {
        //                    durak.GetComponent<durak_sc>().insanlar[i - 1].SetActive(false);
                            
        //                }
        //                try
        //                {
                            
        //                    Instantiate(insan, new Vector3(vagons[i].transform.position.x-0.4f, vagons[i].transform.position.y , vagons[i].transform.position.z+1f), Quaternion.identity).transform.SetParent(vagons[i].transform);
        //                }
        //                catch 
        //                {

                            
        //                }
                            
                        
                        
        //            }
                   

        //            bi_sefer = false;
        //        }
                
        //    }
           
        //}
        //if (other.gameObject.CompareTag("durak_2"))
        //{
            
        //    if (bi_sefer)
        //    {
        //        if (vagons.Count == 1)
        //        {

        //        }
        //        else
        //        {
        //            for (int i = 1; i < int.Parse(durak_t_2.GetComponent<TMP_Text>().text) + 1; i++)
        //            {
        //                Debug.Log("heey");
        //                if (vagons.Count - 1 < int.Parse(durak_t_2.GetComponent<TMP_Text>().text))
        //                {
        //                    for (int j = 0; j < vagons.Count - 1; j++)
        //                    {
        //                        durak_2.GetComponent<durak_sc>().insanlar2[j].SetActive(false);
        //                    }

        //                }
        //                else
        //                {
        //                    durak_2.GetComponent<durak_sc>().insanlar2[i - 1].SetActive(false);

        //                }
        //                try
        //                {

        //                    Instantiate(insan, new Vector3(vagons[i].transform.position.x - 0.4f, vagons[i].transform.position.y, vagons[i].transform.position.z + 1f), Quaternion.identity).transform.SetParent(vagons[i].transform);
        //                }
        //                catch
        //                {


        //                }



        //            }


        //            bi_sefer = false;
        //        }

        //    }

        //}
        
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("durak"))
    //    {
    //        bi_sefer = true;
    //    }
    //}
    public void titret()
    {
        Handheld.Vibrate();
    }
   
    private void eksi_1_gel()
    {
        eksi_1.SetActive(false);
    }
    private void arti_1_gel()
    {
        arti_1.SetActive(false);
    }
    private void vagonGel()
    {
        for (int i = 0; i < gateNumber; i++)
        {
            GameObject newVagon = Instantiate(vagonPrefab);
            newVagon.transform.SetParent(transform);
            newVagon.GetComponent<BoxCollider>().enabled = false;
            newVagon.gameObject.transform.localPosition = new Vector3(-1.4f, 0f, vagons[vagons.Count - 1].transform.localPosition.z + 6f);
            vagons.Add(newVagon);

        }
    }
    private void vagonGit()
    {
        for (int i = vagons.Count-1; i >= targetCount; i--)
        {
            try
            {
                Destroy(vagons[i]);
                //vagons[i].SetActive(false);
                vagons.RemoveAt(i);
                if (vagons.Count==0)
                {
                    titret();
                    SceneManager.LoadScene("olum");
                }
            }
            catch
            {
                titret();
                SceneManager.LoadScene("olum");               
            }
            
            
        }
    }

}
