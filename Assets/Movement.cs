
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    Vector3 input;
    Vector2 direction_input;
    GameObject collectable;
    bool collected=false;
    public GameObject Prefab;
    public FixedJoystick joystick;
    public Text scoretext;
    public Text lifetext;
    float life=5;
    float score = 0;
    public GameObject gameover_panal;
    void Start()
    {
        
    }
    void Update()
    {
        input =new Vector3( joystick.Horizontal+Input.GetAxis("Horizontal"), joystick.Vertical + Input.GetAxis("Vertical"),0);
        transform.position=new Vector3( Mathf.Clamp(transform.position.x,30, 1050), Mathf.Clamp(transform.position.y, 3, 1880),0);
        transform.position=transform.position + input * 700f * Time.deltaTime;
        direction_input = input.normalized;
       if (input != Vector3.zero)
        {
            transform.eulerAngles = Vector3.forward*Mathf.Atan2(direction_input.y, direction_input.x) * Mathf.Rad2Deg;
        }
        if (collected == false)
        {
            collectable= Instantiate(Prefab, new Vector3(Random.Range(30f, 1050f), Random.Range(3, 1880), 0), transform.rotation) as GameObject;
            collected = true;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "collectable")
        {
            Destroy(collision.gameObject);
            collected = false;
            score = score + 1;
            scoretext.text = "Score : " + score.ToString();
        }
        if(collision.gameObject.name== "Enemy")
        {
            gameover_panal.SetActive(true);
        }
    

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            life = life - 1;
            lifetext.text = "Life : " + life.ToString();
        }
        if(life<=0)
        {
            gameover_panal.SetActive(true);
        }
        
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
