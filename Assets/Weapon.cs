using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject firebullet1;
    public GameObject ultibullet1;

    public PlayerMovement playerMovement;
    
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShootFireBullet();
        }
        

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShootUltiBullet();
        }
        


        void ShootFireBullet()
        {
            GameObject bullet = Instantiate(firebullet1, firePoint.position, firePoint.rotation);
            SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();

            // Karakter sola döndüğünde merminin şeklini de sola döndür
            // Karakter sola döndüğünde merminin hareket yönünü de sola döndür
            if (playerSprite != null && playerSprite.flipX)
            {
                bullet.transform.localScale = new Vector3(-Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
                SetBulletDirection(false);
            }
            else
            {
                SetBulletDirection(true);
            }
        }

        void ShootUltiBullet(){
            GameObject bullet = Instantiate(ultibullet1, firePoint.position, firePoint.rotation);
            SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
            
            // Karakter sola döndüğünde merminin şeklini de sola döndür
            // Karakter sola döndüğünde merminin hareket yönünü de sola döndür
            if (playerSprite != null && playerSprite.flipX)
            {
                bullet.transform.localScale = new Vector3(-Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);
                SetUltiBulletDirection(false);
            }
            else
            {
                SetUltiBulletDirection(true);
            }
        }

    }
    public void SetBulletDirection(bool isRight)
    {
        firebullet1[] bullets = FindObjectsOfType<firebullet1>();

        foreach (firebullet1 bullet in bullets)
        {
            bullet.SetDirection(isRight);
        }

        
    }
    public void SetUltiBulletDirection(bool isRight)
    {
        ultibullet1[] bullets = FindObjectsOfType<ultibullet1>();

        foreach (ultibullet1 bullet in bullets)
        {
            bullet.SetDirection(isRight);
        }

        
    }
}    