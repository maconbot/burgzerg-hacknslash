using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {
	public List<Transform> targets;
	public Transform selectedTarget;
	private Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		targets = new List<Transform> ();
		selectedTarget = null;
		addAllEnemies ();
	}

	public void addAllEnemies ()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");

		foreach (GameObject enemy in go) {
			addTarget(enemy.transform);
		}
	}

	public void addTarget(Transform enemy)
	{
		targets.Add (enemy);
	}

	private void sortTargetsByDistance()
	{
		targets.Sort(delegate(Transform t1, Transform t2) { 
			return (Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position))); 
		});
	}

	private void targetEnemy()
	{
		if(selectedTarget == null) {
			sortTargetsByDistance();
			selectedTarget = targets [0];
		}
		else {
			int index = targets.IndexOf(selectedTarget);
			if(index < targets.Count - 1)
			{
				index++;
			}
			else
			{
				index = 0;
			}
			deselectTarget();
			selectedTarget = targets[index];
		}
		selectTarget ();
	}

	private void selectTarget()
	{
		selectedTarget.renderer.material.color = Color.red;

		PlayerAttack pa = (PlayerAttack)GetComponent ("PlayerAttack");
		pa.target = selectedTarget.gameObject;
	}

	private void deselectTarget()
	{
		selectedTarget.renderer.material.color = Color.blue;
		selectedTarget = null;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			targetEnemy();
		}
	}
}
