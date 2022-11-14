using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Vector3 yon;
    [SerializeField]
    public float hiz = 1f;

    public Zemin_Olusturma zemin_olusturr;

    public static bool dustuMu = true;

    public float hizlanma_zorlugu;

    float skor = 0f, artisMiktari = 1f;
    [SerializeField]
    Text skorText,bestScoreText,scoreText;


    int enIyiSkor = 0;

    public Text enIyiSkorText;

    public GameObject restartGamePanel, playGamePanel;

   

    void Start()
    {
        bestScoreText.text = "Best Score: "+ PlayerPrefs.GetInt("enIyiSkor").ToString();
        if (RestartGame.isRestart == true)
        {
            playGamePanel.SetActive(false);
            dustuMu = false;
            skorText.gameObject.SetActive(true);
            enIyiSkorText.gameObject.SetActive(true);
        }

        yon = Vector3.left;

        enIyiSkor = PlayerPrefs.GetInt("enIyiSkor");

        enIyiSkorText.text ="Best Score: "+ enIyiSkor.ToString();

    }

    public void startGame()
    {
        dustuMu = false;
        playGamePanel.SetActive(false);
        
            skorText.gameObject.SetActive(true);
            enIyiSkorText.gameObject.SetActive(true);
        
     
        

    }

    // Update is called once per frame
    void Update()
    {
        if (dustuMu)
        {
            return;
        }



        hareket();

        olmek();
  
    }

    void hareket()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.z == 0)
            {
                yon = Vector3.back;
            }
            else
            {
                yon = Vector3.left;
            }
        }
    }

    void olmek()
    {
        if (transform.position.y < 0.1f)
        {
            dustuMu = true;
            restartGamePanel.SetActive(true);
            Destroy(gameObject, 2f);
            skorText.gameObject.SetActive(false);
            enIyiSkorText.gameObject.SetActive(false);
            scoreText.text = "Score: " + ((int)skor).ToString();

            if (enIyiSkor < skor)
            {
                enIyiSkor = (int)skor;

                PlayerPrefs.SetInt("enIyiSkor", enIyiSkor);
                PlayerPrefs.Save();

            }

        }
    }

    private void FixedUpdate()
    {
        if (dustuMu)
        {
            return;
        }
        Vector3 hareket = yon * hiz * Time.deltaTime;

        transform.position += hareket;

        hiz += hizlanma_zorlugu * Time.deltaTime;

        skor += artisMiktari * hiz * Time.deltaTime;

        skorText.text = "Skor: "+ ((int)skor).ToString();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            StartCoroutine(yokEt(collision.gameObject));
            zemin_olusturr.zemin_Olustur();
        }
    }

    IEnumerator yokEt(GameObject obje)
    {
        yield return new WaitForSeconds(0.3f);
        obje.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(obje);
    }


}
