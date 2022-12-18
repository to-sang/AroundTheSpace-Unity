using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhanvat : MonoBehaviour
{
    public float vantoc = 7; // van toc cua nha vat
    private float tocdo = 0; // doc do cua nha vat
    public bool chamdat = true; // kiểm tra nv có ở dưới đất không
    private bool chuyenhuong = false; // kiểm tra nv có chuyển huonngws không
    public int hp = 100;
    private float nhaycao = 500;
    private float nhaythap = 5; // asp dung khi nhan len 1 lan va buong phim
    private float roixuong = 10; // luc hap dan
    private bool quayphai = true; // kieerm tra xem nhan vat di huong nao
    public float maxHealth = 100;
    float currentHealth;
    // khai báo các biến để bắn
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;


    // Start is called before the first frame update
    private Animator hd;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        hd = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = hp;
    }

    // Update is called once per frame
    void Update()
    {
        hd.SetFloat("tocdo", tocdo);
        hd.SetBool("chamdat", chamdat);
        hd.SetInteger("hp", hp);
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
    }

    // chuc nang ban dan

    void fireBullet()
    {
        if(Time.time > nextFire)
        {
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
        rigidbody2d.velocity = new Vector2(vantoc * phimtraiphai, rigidbody2d.velocity.y);
        tocdo = Mathf.Abs(vantoc * phimtraiphai);
        if (phimtraiphai > 0 && !quayphai)
            huongNV();
        if (phimtraiphai < 0 && quayphai)
            huongNV();

    }
    void huongNV()
    {
        quayphai = !quayphai;
        Vector2 huongquay = transform.localScale;
        huongquay.x *= -1;
        transform.localScale = huongquay;
        if (tocdo > 1)
        {
            StartCoroutine(ChuyenHuong()); // thuc hien quay dau
        }
    }
    IEnumerator ChuyenHuong()
    {
        chuyenhuong = true;
        yield return new WaitForSeconds(0.2f);
        chuyenhuong = false;
    }

    void Nhay()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && chamdat == true)
        {
            rigidbody2d.AddForce((Vector2.up) * nhaycao);
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
    public void addDamage(float dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
    // cái chết cho player
    void makeDead()
    {
        Destroy(gameObject);
    }

    public void TakeHit()
    {
        Debug.Log("Hurt");
    }
}
