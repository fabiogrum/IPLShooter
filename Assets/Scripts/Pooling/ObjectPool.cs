using UnityEngine;
using System.Collections;
using System.Collections.Generic; // ajouter pour utiliser une liste

public class ObjectPool {

	private List<GameObject> pool = new List<GameObject> (); //il faut faire le new parce qu'il est private
	public GameObject prefab;

	public ObjectPool(GameObject obj){
		prefab = obj;
	}

	public GameObject GetObject(){
		GameObject obj;
		if(pool.Count == 0){
			obj = Object.Instantiate (prefab);
			obj.name = prefab.name; // pour avoir Ennemi et pas Ennemi(clone)
			obj.SetActive(true);
			return obj;
		}
		obj = pool [0];
		pool.RemoveAt (0);
		obj.SetActive (true); // pour s'assurer qu'il est actif
		return obj;
	}
		
	public void PoolObject(GameObject obj){
		if (pool.IndexOf(obj) < 0) { // pour s'assurer de ne pas avoir déjà une référence de l'objet dans la liste 
			pool.Add(obj);
			obj.SetActive (false);
		}
	}

}
