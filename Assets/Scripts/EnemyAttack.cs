using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float cooldown;
	
	
	// Use this for initialization
	void Start () {
		attackTimer = 0.0f;
		cooldown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if(attackTimer < 0)
			attackTimer = 0;
		
		if(attackTimer == 0) {
			attack();
			attackTimer = cooldown;
		}
	}
	
	private void attack()
	{
		float distance = Vector3.Distance (target.transform.position, transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot (dir, transform.forward);
		
		if (distance < 2.5f) {
			if(direction > 0) {
				PlayerHealth ph = (PlayerHealth)target.GetComponent ("PlayerHealth");
				ph.adjustCurrentHealth (-10);
			}
		}
	}
}
