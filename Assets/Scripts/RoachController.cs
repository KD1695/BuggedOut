using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoachController : MonoBehaviour
{
    private float speed = 5.0f;
    private float health = 100f;
    private float damageScale = 20f;
    private Vector3 destination;
    private bool isDestinationSet = false;
    private bool isRotated = false;
    const int BOUNDS_X = 1920;
    const int BOUNDS_Y = 1080;

    public void SetValues(float _speed, float _damageScale)
    {
        speed = _speed;
        damageScale = _damageScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(!isDestinationSet)
        {
            //set new destination
            destination = new Vector3(Random.Range(-BOUNDS_X / 20, BOUNDS_X / 20), Random.Range(-BOUNDS_Y / 20, BOUNDS_Y / 20), 150f);
            isDestinationSet = true;
        }
        else if(!isRotated)
        {
            //rotate towards target destination
            Vector3 targetDirection = destination - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: targetDirection);
            transform.rotation = targetRotation;
            isRotated = true;
        }
        else
        {
            //move towards target destination
            float step = speed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, destination, step);
            transform.position = new Vector3(newPosition.x, newPosition.y, 150f);
            if (Vector3.Distance(transform.position, destination) < 2)
            {
                isDestinationSet = false;
                isRotated = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Damage received when click down(spraying)
        if(Input.GetMouseButton(0))
        {
            health -= Time.deltaTime * damageScale;
        }
    }
}
