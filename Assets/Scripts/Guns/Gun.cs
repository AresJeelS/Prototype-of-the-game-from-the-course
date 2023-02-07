using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;

    public AudioSource ShotSound;
    public GameObject Flash;
    public ParticleSystem ShotEffect;

    public float BulletSpeed = 10f;
    public float ShotPeriod = 0.2f;

    private float _timer;
    private bool _isShoot;

    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _isShoot = true;
                _timer = 0f;

            }
        }
    }
    private void FixedUpdate()
    {
        if (_isShoot)
        {
            CreateBullet();
            _isShoot = false;
        }
    }
    public virtual void CreateBullet()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);

        // Метод вызывающийся с задержкой для отключения эффекта 
        Invoke("HideFlash", 0.08f);
        ShotEffect.Play();
    }
    private void HideFlash()
    {
        Flash.SetActive(false);
    }
    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void AddBullets(int numberOfBullets)
    {

    }
}
