using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TMP_Text bulletText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int totalBullets = BulletMovement.counterB + Bullet.counterA + BossBullet.bulletC;
        bulletText.text = "Bullets: " + totalBullets.ToString();
    }
}
