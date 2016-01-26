using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use pathfinding
using Pathfinding;

public class MobAI : MonoBehaviour
{
  //The point to move to
	private GameObject target;
	public Vector3 tempPos;
	private Seeker seeker;
	public float attackDamage;
  	//The calculated path
	public Path path;
	private string direction;
	
	public int movementSpeed;
	private bool isCalculating = true;

	public float nextWaypointDistance = 3;

 	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	Rigidbody2D rb;
	public void Start (){
		rb = GetComponent<Rigidbody2D> ();
    	seeker = GetComponent<Seeker>();
        target = GameObject.Find("Character");
		SetupPath ();
	}

  public void OnPathComplete ( Path p ){
    //Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
    if (!p.error) {
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
			isCalculating = false;
			tempPos = target.transform.position;
		}
  }

	public void SetupPath(){
		seeker.StartPath( transform.position, target.transform.position, OnPathComplete );
        Debug.LogWarning("");   //The code doesn't work without this...
	}
	
	public void FixedUpdate (){
		
    	if (path == null){
      		return;
    	}

    	if (currentWaypoint >= path.vectorPath.Count){
			if (Mathf.Floor (rb.velocity.y) != 0) {
				rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y / 2);
			} else {
				rb.velocity = new Vector2 (0, 0);
			}
			currentWaypoint = 0;
            SetupPath();
			return;
    	}

		if (Mathf.Round(target.transform.position.x) != Mathf.Round(tempPos.x) || Mathf.Round(target.transform.position.y) != Mathf.Round(tempPos.y) && isCalculating == false) {
			isCalculating = true;
			SetupPath();
		}
		Vector3 dir = ( path.vectorPath[ currentWaypoint] - transform.position ).normalized;
        if (!MenuManager.windowOpen) {
            rb.velocity = new Vector2(dir.x, dir.y) * movementSpeed;
        } else {
            if (Mathf.Floor(rb.velocity.y) != 0) {
                rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y / 2);
            } else {
                rb.velocity = new Vector2(0, 0);
            }
        }

		if (Vector3.Distance( transform.position, path.vectorPath[ currentWaypoint ] ) < nextWaypointDistance){
	      currentWaypoint++;
	      return;
		}
	}

	void OnCollisionStay(Collision coll){
        if (coll.gameObject.Equals(target.gameObject))
		target.GetComponent<Health> ().Damage (attackDamage);
	}
}