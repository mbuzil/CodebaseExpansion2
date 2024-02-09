using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager


    public static GameManager Instance;
    public bool isTeleporting;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    #endregion

    Camera cam;
    public Transform firePoint;
    public GameObject seedPrefab;
    public GameObject seedling;


    public _Seed seed;
    public playerController player;
    public Trajectory trajectory; // Our seed reference
    [SerializeField] float pushforce = 4f;

    public bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    [SerializeField] public Vector2 force;
   [SerializeField]  public float distance;


    void Start()
    {
        cam = Camera.main;
        seed.DeactivateRb();
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown (0)) {
            isDragging = true;
            OnDragStart();
        }
        if(Input.GetMouseButtonUp(0)){
            isDragging= false;
            OnDragEnd();
        }

        if(isDragging)
        {
                OnDrag();
        
        }

        if(Input.GetMouseButtonDown(1) && player.isGrounded())
        {
            TeleportPlayer();
        }
    }

    void OnDragStart()
    {
        seed.DeactivateRb();
       // Instantiate(seedPrefab, firePoint.transform.position, firePoint.transform.rotation);
        startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

        trajectory.Show();
    }


    void OnDrag()
    {

        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance (startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushforce;

        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(seed.position, force);
        //Probably put the drag animation here or reference to it here. anim.SetBool(isAiming , IsAiming)
    }

     void OnDragEnd()
    {
        seed.ActivateRb();
        seed.Push(force);
        trajectory.Hide();
    }

    void TeleportPlayer()
    {   //replace with if Seed is grounded later in fix. 
        seedling.transform.position = this.seedPrefab.transform.position;
        
    }

    

       /* playerRb.simulated = false;
        yield return new WaitForSeconds(0.5f);
        seedling.transform.position = this.seedPrefab.transform.position;
        anim.Play("GROW"); 
        yield return new WaitForSeconds (0.5f);
        playerRb.simulated = true;   */ 



}


