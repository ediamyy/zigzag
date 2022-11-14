using UnityEngine;

public class Zemin_Olusturma : MonoBehaviour
{
    public GameObject son_zemin;
    

    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            zemin_Olustur();
        }
    }

  
    
    public void zemin_Olustur()
    {
        Vector3 yon;
        int randomSayi = Random.Range(0, 2);

        if(randomSayi == 0 )
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }

        son_zemin = Instantiate(son_zemin, son_zemin.transform.position + yon, son_zemin.transform.rotation);
    }
}
