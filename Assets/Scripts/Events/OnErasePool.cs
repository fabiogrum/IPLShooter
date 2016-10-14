using UnityEngine;
using System.Collections;

public class OnErasePool : MonoBehaviour {

	public EventsManager eventsManager;

	void Awake(){
		if(!eventsManager){
			eventsManager = GetComponentInParent<EventsManager> ();
		}
	}

	void OnEnable(){
		eventsManager.OnErase += Pool; // on rajoute un pointeur vers la fonction. c'est comme un add listener
	}

	void OnDisable(){
		eventsManager.OnErase -= Pool; // on rajoute un pointeur vers la fonction. c'est comme un add listener
	}

	void Pool(){
		ObjectPoolsManager.GetInstance ().PoolObject (eventsManager.gameObject);
	}

}
