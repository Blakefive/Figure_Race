using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class object_move : MonoBehaviour
{
    Stopwatch watch = new Stopwatch();
    public GameObject tire1;
    public GameObject tire2;
    public GameObject tire3;
    public GameObject tire4;
    public Text ScriptTxt;
    public Text fastTxt;
    public Text time;
    public Text besttime;
    public Text sidebreakok;
    public AudioClip start;
    public AudioClip keep;
    public AudioClip maxspeed;
    public AudioClip speeddown;
    public AudioClip speedkeep;
    private AudioSource musicPlayer;
    int wsad = 1;
    int check = 1;
    int besttimecheck = 0;
    int checkpoint = 0;
    int nextfast = 0;
    float startX = 0.0f;
    float startZ = 0.0f;
    float oldfast = 0.0f;
    float fast = 0.0f;
    bool rlcheck = false;
    bool fastup = false;
    bool plane = true;
    bool finaltime = false;
    bool finishfirstcheck = false;
    bool sidebreak = true;
    bool startup = false;
    string[] lines;
    string mapname = "";
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        musicPlayer = GetComponent<AudioSource>();
        lines = File.ReadAllLines("best(auto).txt");
        if (Convert.ToInt32(lines[mapselect.mapselectcheck]) > 0.0f )
        {
            int M = Convert.ToInt32(lines[mapselect.mapselectcheck]);
            besttime.text = M.ToString();
            besttimecheck = M;
        }
        else
        {
            finishfirstcheck = true;
        }
        if (mapselect.mapselectcheck == 0)
        {
            startX = -446.5f;
            startZ = -220.18f;
            mapname = "1";
        }
        else if (mapselect.mapselectcheck == 1)
        {
            startX = -446.5f;
            startZ = 1032.0f;
            mapname = "2";
        }
        transform.position = new Vector3(startX, 0.65f, startZ);
    }
    void Update()
    {
        int N = (int)(watch.ElapsedMilliseconds / 1000);
        time.text = N.ToString();
        UnityEngine.Debug.Log(tire1.transform.eulerAngles.y);
        if (transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        int txtfast = (int)Math.Round(fast);
        fastTxt.text = txtfast.ToString();
        if (Input.GetKey(KeyCode.S))
        {
            tire1.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - 115, tire1.transform.eulerAngles.z);  //-90-25=-115
            tire3.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 65, tire2.transform.eulerAngles.z);   //90-25=65
        }
        else if (Input.GetKey(KeyCode.F))
        {
            tire1.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - 65, tire1.transform.eulerAngles.z);   //-90+25=-65
            tire3.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 115, tire1.transform.eulerAngles.z);  //90+25=115
        }
        else if (Input.GetKey(KeyCode.A))
        {
            tire1.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - 145, tire1.transform.eulerAngles.z);  //-90-55=-145
            tire3.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 35, tire1.transform.eulerAngles.z);   //90-55=35
        }
        else if (Input.GetKey(KeyCode.G))
        {
            tire1.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - 35, tire1.transform.eulerAngles.z);   //-90+55=-35
            tire3.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 145, tire1.transform.eulerAngles.z);  //90+55=145
        }
        else
        {
            tire1.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y-90, tire1.transform.eulerAngles.z);
            tire3.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 90, tire1.transform.eulerAngles.z);
            UnityEngine.Debug.Log("check");
        }
        if(transform.position.y < 0.5f)
        {
            if (checkpoint == 0)
            {
                transform.position = new Vector3(startX, 0.65f, startZ);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (checkpoint == 1)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint1" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint1" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint1" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 2)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint2" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint2" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint2" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 3)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint3" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint3" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint3" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 4)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint4" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint4" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint4" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 5)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint5" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint5" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint5" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 6)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint6" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint6" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint6" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 7)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint7" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint7" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint7" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 8)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint8" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint8" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint8" + mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 9)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint9" + mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint9" + mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint9" + mapname).transform.eulerAngles.y + 180, 0);
            }
            fast = 0.0f;
        }
        if (transform.position.y > 2.0f)
        {
            transform.position = new Vector3(transform.position.x, 0.65f, transform.position.z);
            fast = 0.0f;
        }
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.T))
        {
            if (fastup)
            {
                if (fast < 200)
                {
                    if (rlcheck == false)
                    {
                        fast += 0.11f;
                        if (musicPlayer.isPlaying == false)
                        {
                                musicPlayer.clip = speedkeep;
                                musicPlayer.loop = false;
                            musicPlayer.volume = (fast/ 200);
                            musicPlayer.pitch = 1.0f + (fast / 600);
                            musicPlayer.time = 0;
                                musicPlayer.Play();
                        }
                    }
                    if (rlcheck == true)
                    {
                        if (fast <= 0.0f)
                        {
                            rlcheck = false;
                            fast = 0.0f;
                        }
                        else if (fast > 0.0f)
                        {
                            fast -= 0.11f;

                            if (musicPlayer.isPlaying == false)
                            {
                                musicPlayer.clip = speeddown;
                                musicPlayer.loop = false;
                                musicPlayer.time = 0;
                                musicPlayer.Play();
                            }
                        }
                    }
                }
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (fastup)
            {
                if (fast < 200)
                {
                    if (rlcheck == false)
                    {
                        fast += 0.2f;

                        if (musicPlayer.isPlaying == false)
                        {
                            musicPlayer.clip = speedkeep;
                                musicPlayer.loop = false;
                            musicPlayer.volume = (fast / 200);
                            musicPlayer.pitch = 1.0f + (fast / 600);
                            musicPlayer.time = 0;
                                musicPlayer.Play();
                        }
                    }
                    if (rlcheck == true)
                    {
                        if (fast <= 0.0f)
                        {
                            rlcheck = false;
                            fast = 0.0f;
                        }
                        else if (fast > 0.0f)
                        {
                            fast -= 0.2f;

                            if(musicPlayer.isPlaying == false)
                            {
                                musicPlayer.clip = speeddown;
                                musicPlayer.loop = false;
                                musicPlayer.time = 0;
                                musicPlayer.Play();
                            }
                        }
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.N) || Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Z))
        {
            if (fastup)
            {
                if(fast > 0.0f)
                {
                    fast -= 0.15f;
                    if (musicPlayer.isPlaying == false)
                    {
                        musicPlayer.clip = speeddown;
                        musicPlayer.loop = false;
                        musicPlayer.time = 0;
                        musicPlayer.Play();
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.V) || Input.GetKey(KeyCode.X))
        {
            if (fastup)
            {
                if (fast > 0.0f)
                {
                    fast -= 0.25f;
                    if (musicPlayer.isPlaying == false)
                    {
                        musicPlayer.clip = speeddown;
                        musicPlayer.loop = false;
                        musicPlayer.time = 0;
                        musicPlayer.Play();
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (fastup)
            {
                if (fast > 0.0f)
                {
                    fast -= 0.5f;
                        if (musicPlayer.isPlaying == false)
                    {
                        musicPlayer.clip = speeddown;
                        musicPlayer.loop = false;
                        musicPlayer.time = 0;
                        musicPlayer.Play();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            fastup = true;
            ScriptTxt.text = "D";
            if (fast <= 0.0f)
            {
                wsad = 0;
                check = 0;
            }
            else
            {
                check = 0;
                rlcheck = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            fastup = true;
            ScriptTxt.text = "R";
            if (fast <= 0.0f)
            {
                wsad = 2;
                check = 2;
            }
            else
            {
                check = 2;
                rlcheck = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ScriptTxt.text = "N";
            fastup = false;
            wsad = 1;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (fast <= 0.0f)
            {
                ScriptTxt.text = "P";
                fastup = false;
                wsad = 1;
                fast = 0.0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (sidebreak == false)
            {
                sidebreakok.text = "O";
                fastup = false;
                sidebreak = true;
            }
            else if (sidebreak)
            {
                sidebreakok.text = "X";
                sidebreak = false;
                fastup = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (startup == false)
            {
                musicPlayer.Stop();
                musicPlayer.clip = start;
                musicPlayer.loop = false;
                musicPlayer.time = 0;
                musicPlayer.volume = 0.1f;
                musicPlayer.Play();
                fastup = true;
                startup = true;
            }
            else if (startup)
            {
                startup = false;
                fastup = false;
            }
        }
        if (sidebreak)
        {
            if(fast > 0.0f)
            {
                fast = fast - 1.0f;
            }
        }
        if (startup == false)
        {
            musicPlayer.Stop();
            if (fast > 0.0f)
            {
                fast = fast - 1.0f;
            }
        }
        else if((startup == true) && (musicPlayer.isPlaying == false)){
            if (fast >= 190)
            {
                if (musicPlayer.isPlaying == true)
                {
                    musicPlayer.Stop();
                }
                else
                {
                    musicPlayer.clip = maxspeed;
                    musicPlayer.loop = false;
                    musicPlayer.time = 0;
                    musicPlayer.volume = 1.0f;
                    musicPlayer.Play();
                }
            }
            else if (musicPlayer.isPlaying == false && fast == 0.0f)
            {
                if (musicPlayer.isPlaying == true)
                {
                    musicPlayer.Stop();
                }
                else
                {
                    musicPlayer.clip = keep;
                    musicPlayer.loop = false;
                    musicPlayer.time = 0;
                    musicPlayer.volume = 0.05f ;
                    musicPlayer.Play();
                }
            }
            else
            {
                    musicPlayer.clip = speedkeep;
                    musicPlayer.loop = false;
                    musicPlayer.time = 0;
                musicPlayer.volume = (fast / 200);
                musicPlayer.pitch = 1.0f + (fast / 600);
                musicPlayer.Play();
            }
        }
        if (fast < 0.0f)
        {
            fast = 0.0f;
        }
        if (fast != 0.0f)
        {
            if (wsad == 0)
            {
                transform.Translate(0, 0, -(fast * Time.deltaTime));
                tire1.transform.eulerAngles = new Vector3(tire1.transform.eulerAngles.x, tire1.transform.eulerAngles.y, tire1.transform.eulerAngles.z + fast);
                tire2.transform.eulerAngles = new Vector3(tire2.transform.eulerAngles.x, tire2.transform.eulerAngles.y, tire2.transform.eulerAngles.z + fast);
                tire3.transform.eulerAngles = new Vector3(tire3.transform.eulerAngles.x, tire3.transform.eulerAngles.y, tire3.transform.eulerAngles.z + fast);
                tire4.transform.eulerAngles = new Vector3(tire4.transform.eulerAngles.x, tire4.transform.eulerAngles.y, tire4.transform.eulerAngles.z + fast);
                if (fast > 0.0f)
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 0.6f, transform.eulerAngles.z);
                        }
                        
                    }
                    else if (Input.GetKey(KeyCode.F))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 0.6f, transform.eulerAngles.z);
                        }
                        
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 1.0f, transform.eulerAngles.z);
                        }
                        
                    }
                    else if (Input.GetKey(KeyCode.G))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 1.0f, transform.eulerAngles.z);
                        }
                        
                    }
                    fast -= 0.1f;
                }
                else if (fast < 0.0f)
                {
                    fast = 0.0f;
                    if(check != wsad)
                    {
                        wsad = check;
                    }
                }
            }
            if (wsad == 2)
            {
                transform.Translate(0, 0, (fast * Time.deltaTime));
                tire1.transform.eulerAngles = new Vector3(tire1.transform.eulerAngles.x, tire1.transform.eulerAngles.y, tire1.transform.eulerAngles.z - fast);
                tire2.transform.eulerAngles = new Vector3(tire2.transform.eulerAngles.x, tire2.transform.eulerAngles.y , tire2.transform.eulerAngles.z - fast);
                tire3.transform.eulerAngles = new Vector3(tire3.transform.eulerAngles.x, tire3.transform.eulerAngles.y, tire3.transform.eulerAngles.z - fast);
                tire4.transform.eulerAngles = new Vector3(tire4.transform.eulerAngles.x, tire4.transform.eulerAngles.y, tire4.transform.eulerAngles.z - fast);
                if (fast > 0)
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 0.6f, transform.eulerAngles.z);
                        }
                    }
                    else if (Input.GetKey(KeyCode.F))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 0.6f, transform.eulerAngles.z);
                        }
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 1.0f, transform.eulerAngles.z);
                        }
                    }
                    else if (Input.GetKey(KeyCode.G))
                    {
                        if (plane)
                        {
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 1.0f, transform.eulerAngles.z);
                        }
                    }
                    fast -= 0.1f;
                }
                else if(fast < 0.0f)
                {
                    fast = 0.0f;
                    if(check != wsad)
                    {
                        wsad = check;
                    }
                }
            }
            if(wsad == 1)
            {
                if (check == 0)
                {
                    transform.Translate(0, 0, -(fast * Time.deltaTime));
                    if (fast > 0 && fast < 0.5)
                    {
                        fast -= 0.00625f;
                    }
                    if (fast >= 0.5)
                    {
                        fast -= 0.00625f;
                    }
                    else if (fast < 0.0f)
                    {
                        fast = 0.0f;
                        if (check != wsad)
                        {
                            wsad = check;
                        }
                    }
                }
                else if (check == 2)
                {
                    transform.Translate(0, 0, (fast * Time.deltaTime));
                    if (fast >0 && fast < 0.5)
                    {
                        fast -= 0.003125f;
                    }
                    if (fast >= 0.5)
                    {
                        fast -= 0.00625f;
                    }
                    else if (fast < 0.0f)
                    {
                        fast = 0.0f;
                        if (check != wsad)
                        {
                            wsad = check;
                        }
                    }
                }
            }
        }
        if (transform.position.y < 0.0f)
        {
            fast = 0.0f;
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        oldfast = fast;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "Plane")
        {
            plane = true;
        }

    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Plane")
        {
            plane = false;
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Cube (3)")
        {
            Vector3 target = new Vector3(transform.position.x - (fast / 7), transform.position.y, transform.position.z);
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
            transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
            
            fast = fast / 1.5f;
        }
        if (other.gameObject.name == "Cube (4)")
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z + (fast / 7));
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            fast = fast / 1.5f;
        }
        if (other.gameObject.name == "Cube")
        {
            Vector3 target = new Vector3(transform.position.x + (fast / 7), transform.position.y, transform.position.z);
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
            transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            fast = fast / 1.5f;
        }
        if (other.gameObject.name == "Cube (7)")
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z - (fast / 7));
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
            fast = fast/1.5f;
        }
        if ((other.gameObject.name == "checkpoint1" + mapname || other.gameObject.name == "checkpoint2" + mapname || other.gameObject.name == "checkpoint3" + mapname || other.gameObject.name == "checkpoint4" + mapname || other.gameObject.name == "checkpoint5" + mapname || other.gameObject.name == "checkpoint6" + mapname || other.gameObject.name == "checkpoint7" + mapname || other.gameObject.name == "checkpoint8" + mapname || other.gameObject.name == "checkpoint9" + mapname) == false)
        {
            if (other.gameObject.tag == "track")
            {
                GameObject eulardatacheck = GameObject.Find(other.gameObject.name);
                float eulardata = eulardatacheck.transform.eulerAngles.y;
                if (eulardata == 0)
                {
                    if ((transform.eulerAngles.y > 140 && transform.eulerAngles.y < 220) || ((transform.eulerAngles.y > 320 && transform.eulerAngles.y < 360) || (transform.eulerAngles.y > 0 && transform.eulerAngles.y < 40)))
                    {
                        fast = fast / 1.01f;
                    }
                    else
                    {
                        if ((transform.eulerAngles.y < 320) && (transform.eulerAngles.y > 220))
                        {
                            transform.position = new Vector3(transform.position.x - fast, transform.position.y, transform.position.z);
                        }
                        else if((transform.eulerAngles.y < 140) && (transform.eulerAngles.y > 40))
                        {
                            transform.position = new Vector3(transform.position.x + fast, transform.position.y, transform.position.z);
                        }
                        fast = fast / 1.5f;
                    }
                }
                if (eulardata == 90)
                {
                    UnityEngine.Debug.Log(transform.eulerAngles.y);
                    if ((transform.eulerAngles.y > 230 && transform.eulerAngles.y < 310) || (transform.eulerAngles.y > 50 && transform.eulerAngles.y < 130))
                    {
                        fast = fast / 1.01f;
                    }
                    else
                    {
                        if (transform.eulerAngles.y > 130 && transform.eulerAngles.y < 230)
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - fast);
                        }
                        else if ((transform.eulerAngles.y > 310 && transform.eulerAngles.y < 360) || (transform.eulerAngles.y < 50 && transform.eulerAngles.y > 0))
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + fast);
                        }
                            fast = fast / 1.5f;
                    }
                }
            }
        }
        if(other.gameObject.tag == "kill")
        {
            if (checkpoint == 0)
            {
                transform.position = new Vector3(startX, 0.65f, startZ);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (checkpoint == 1)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint1"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint1"+mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint1"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 2)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint2"+ mapname).transform.position.x, 0.65f ,GameObject.Find("checkpoint2"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint2"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 3)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint3"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint3"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint3"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 4)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint4"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint4"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint4"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 5)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint5"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint5"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint5"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 6)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint6"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint6"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint6"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 7)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint7"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint7"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint7"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 8)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint8"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint8"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint8"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            if (checkpoint == 9)
            {
                transform.position = new Vector3(GameObject.Find("checkpoint9"+ mapname).transform.position.x, 0.65f, GameObject.Find("checkpoint9"+ mapname).transform.position.z);
                transform.eulerAngles = new Vector3(0, GameObject.Find("checkpoint9"+ mapname).transform.eulerAngles.y + 180, 0);
            }
            fast = 0.0f;
        }
        if(other.gameObject.tag == "finish")
        {
            if (finaltime == false)
            {
                watch.Start();
                finaltime = true;
            }
            else if (finaltime == true)
            {
                watch.Stop();
                if (finishfirstcheck)
                {
                    int M = (int)(watch.ElapsedMilliseconds / 1000);
                    besttime.text = M.ToString();
                    besttimecheck = M;
                    StreamWriter sw = new StreamWriter("best(auto).txt");
                    if (mapselect.mapselectcheck == 0)
                        sw.WriteLine(M.ToString() + "\n" + lines[1]);
                    else if (mapselect.mapselectcheck == 1)
                    {
                        sw.WriteLine(lines[0] + "\n" + M.ToString());
                    }
                    sw.Close();
                    finishfirstcheck = false;
                }
                else if (finishfirstcheck == false)
                {
                    if (besttimecheck > (int)(watch.ElapsedMilliseconds / 1000))
                    {
                        int M = (int)(watch.ElapsedMilliseconds / 1000);
                        besttime.text = M.ToString();
                        besttimecheck = M;
                        StreamWriter sw = new StreamWriter("best(auto).txt");
                        if (mapselect.mapselectcheck == 0)
                            sw.WriteLine(M.ToString() + "\n" + lines[1]);
                        else if (mapselect.mapselectcheck == 1)
                        {
                            sw.WriteLine(lines[0] + "\n" + M.ToString());
                        }
                        sw.Close();

                    }
                }
                watch.Reset();
                watch.Start();
                checkpoint = 0;
            }
        }
        if(other.gameObject.name == "checkpoint1"+ mapname)
        {
            checkpoint = 1;
        }
        if (other.gameObject.name == "checkpoint2"+ mapname)
        {
            checkpoint = 2;
        }
        if (other.gameObject.name == "checkpoint3"+ mapname)
        {
            checkpoint = 3;
        }
        if (other.gameObject.name == "checkpoint4"+ mapname)
        {
            checkpoint = 4;
        }
        if (other.gameObject.name == "checkpoint5"+ mapname)
        {
            checkpoint = 5;
        }
        if (other.gameObject.name == "checkpoint6"+ mapname)
        {
            checkpoint = 6;
        }
        if (other.gameObject.name == "checkpoint7"+ mapname)
        {
            checkpoint = 7;
        }
        if (other.gameObject.name == "checkpoint8"+ mapname)
        {
            checkpoint = 8;
        }
        if (other.gameObject.name == "checkpoint9"+ mapname)
        {
            checkpoint = 9;
        }
    }
}