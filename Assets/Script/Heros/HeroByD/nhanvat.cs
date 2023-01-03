using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nhanvat : MonoBehaviour
{
    public float vantoc = 7; // van toc cua nha vat
    private float tocdo = 0; // doc do cua nha vat
    public bool chamdat = true; // kiểm tra nv có ở dưới đất không

    private float nhaycao = 500;
    private float nhaythap = 5; // asp dung khi nhan len 1 lan va buong phim
    private float roixuong = 5; // luc hap dan
    private bool quayphai = true; // kieerm tra xem nhan vat di huong nao
    public int maxHealth = 100;
    public int currentHealth;
    // khai báo các biến để bắn
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float runRate = 0.35f;
    float nextFire = 0;
    // thời gian delay trước khi gọi đến hàm destroy
    public float timeDelayDie;

    // các biến khai báo khi tại thanh máu cho player
    public Slider playerHealthSlider;

    // Start is called before the first frame update
    private Animator hd;
    private Rigidbody2D rigidbody2d;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        hd = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hd.SetFloat("tocdo", tocdo);
        hd.SetBool("chamdat", chamdat);
        hd.SetInteger("hp", currentHealth);
        Nhay();
        if (transform.position.y < -30)
            transform.position = new Vector2(transform.position.x, 0);
    }
    private void FixedUpdate()
    {
        DiChuyen();
        // chức năng bắn
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
        }
        hd.SetInteger("hp", currentHealth);

    }

    // chuc nang ban dan

    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            Sound("gunsound2");

            nextFire = Time.time+ fireRate;
            if (quayphai)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if(!quayphai)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));

            }
        }
    }

    void DiChuyen()
    {
        
        float phimtraiphai = Input.GetAxis("Horizontal");
        if(phimtraiphai != 0 && Time.time > nextFire && vantoc >0)
        {
            Sound("runnew");
            nextFire = Time.time + runRate;
        }
        rigidbody2d.velocity = new Vector2(vantoc * phimtraiphai, rigidbody2d.velocity.y);
        tocdo = Mathf.Abs(vantoc * phimtraiphai);
        if (phimtraiphai > 0 && !quayphai)
        {
            huongNV();
        }
            
        if (phimtraiphai < 0 && quayphai)
        {
            huongNV();
        }     
    }
    void huongNV()
    {
        quayphai = !quayphai;
        Vector2 huongquay = transform.localScale;
        huongquay.x *= -1;
        transform.localScale = huongquay;
    }
    void Nhay()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && chamdat == true)
        {
            rigidbody2d.AddForce((Vector2.up) * nhaycao);
            Sound("jump");
            chamdat = false;
        }
        // asp dung trong luc cho nhan vat
        if (rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (roixuong - 1) * Time.deltaTime;
        }
        else if (rigidbody2d.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (nhaythap - 1) * Time.deltaTime;

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "NenDat")
        {
            chamdat = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "NenDat")
        {
            chamdat = true;
        }
    }

    // hàm gây dame cho nhân vật
    public void addDamage(int dame)
    {
        currentHealth -= dame;
        playerHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Sound("die2");
            makeDead();
        }
    }
    // cái chết cho player
    void makeDead()
    {

        Destroy(gameObject,timeDelayDie);
    }

    public void TakeHit()
    {
        Debug.Log("Hurt");
    }

    public void Sound(string File)
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("Sound/" + File));
    }
}
