﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
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
		

		if (Input.GetKeyUp (KeyCode.F)) {
			if(attackTimer == 0) {
				attack();
				attackTimer = cooldown;
			}
		}
	}

	private void attack()
	{
		float distance = Vector3.Distance (target.transform.position, transform.position);

		Vector3 dir = (target.transform.position - transform.position).normalized;

		float direction = Vector3.Dot (dir, transform.forward);


		Debug.Log (direction);

		if (distance < 2.5f) {
			if(direction > 0) {
				EnemyHealth eh = (EnemyHealth)target.GetComponent ("EnemyHealth");
				eh.adjustCurrentHealth (-10);
			}
		}
	}
}
