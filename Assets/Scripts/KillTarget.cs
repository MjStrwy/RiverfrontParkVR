using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillTarget : MonoBehaviour {

    //create public vars for target, hitEffect, killEffect, timeToSelect, and score
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;
    public Text scoreText;
    public Slider healthSlider;

    public Transform healthbar;

    private float countDown;

    // Use this for initialization
    void Start () {
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
        scoreText.text = "Score: 0";
        healthSlider.value = 100;
    }
	
	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        hitEffect.enableEmission = false;


        //hitEffect.emission.disabled(1);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject == target)
            {
                if(countDown > 0.0f)
                {
                    countDown -= Time.deltaTime;
                    healthSlider.value -= Time.deltaTime;
                    hitEffect.transform.position = hit.point;
                    hitEffect.enableEmission = true; 
                }
                else
                {
                    Instantiate(killEffect, target.transform.position, target.transform.rotation);
                    score += 1;
                    scoreText.text = "Score: " + score;
                    healthSlider.value = 100;
                    countDown = timeToSelect;
                    SetRandomPosition();
                }
            }
        }

        healthbar.LookAt(camera.position);
        healthbar.Rotate(0.0f, 180.0f, 0.0f);
    }

    //Respawn/move target to random position
    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
       
        float z = Random.Range(-5.0f, 5.0f);
        
        Debug.Log("New zombie position is: " + x.ToString("F2") + ", " + z.ToString("F2"));
        target.transform.position = new Vector3(x, 0.0f, z);
    }
}
