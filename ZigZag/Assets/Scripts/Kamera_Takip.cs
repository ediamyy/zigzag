using UnityEngine;

public class Kamera_Takip : MonoBehaviour
{
    public GameObject hedef;
    Vector3 uzaklik;


    
    void Start()
    {
        uzaklik = transform.position - hedef.transform.position;
    }

  
  

    private void LateUpdate()
    {
        if (Player.dustuMu)
        {
            return;
        }
        transform.position = hedef.transform.position + uzaklik;
    }


}


