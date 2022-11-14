using System.Collections.Generic;
using UnityEngine;

public class RenkDegisimi : MonoBehaviour
{
    public List<Color> renkler;

    Color ilkRenk, ikinciRenk;

    int birinci_renk, ikinci_renk;

    public Material zemin_material;

    void Start()
    {
        birinci_renk = Random.Range(0, renkler.Count);
        zemin_material.color = renkler[birinci_renk];
        Camera.main.backgroundColor = renkler[birinci_renk];
        ikinciRenk = renkler[ikinciRenkSec()];
    }

    // Update is called once per frame
    void Update()
    {
        Color fark = zemin_material.color - ikinciRenk;

        if ((Mathf.Abs(fark.r) + Mathf.Abs(fark.g) + Mathf.Abs(fark.b)) < 0.2f)
        {
            ikinciRenk = renkler[ikinciRenkSec()];
        }
        zemin_material.color = Color.Lerp(zemin_material.color, ikinciRenk, 0.003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, ikinciRenk, 0.0007f);
    }

    int ikinciRenkSec()
    {
        int ikincil_renk;

        ikincil_renk = Random.Range(0, renkler.Count);

        while (ikincil_renk == birinci_renk)
        {
            ikincil_renk = Random.Range(0, renkler.Count);

        }

        return ikincil_renk;

    }
}
