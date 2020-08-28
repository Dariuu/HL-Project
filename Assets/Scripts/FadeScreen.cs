using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{   
    public RawImage image;
    public float speed;
    public float alpha;
    
    void Update()
    {
        image.CrossFadeAlpha(alpha, Time.deltaTime * speed, false);
    }
}
