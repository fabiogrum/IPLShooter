using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	public int health; 
	private int currentHealth;

	public EventsManager eventsManager;

	void OnEnable(){
		currentHealth = health;
	}


	void Awake() {
		if (!eventsManager) {
			eventsManager = GetComponentInParent<EventsManager> ();
		}
	}

	public void TakeDamage(int damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Die();
		}
	}

	void Die() {
		eventsManager.Die ();
	}

}
