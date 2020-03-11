﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

public GameObject following;
[Range(0.0f, 1.0f)]
public float interested; //how interested the follower is in the thing it's following :)

	void Awake(){
		transform.position = Vector3.MoveTowards(transform.position, following.transform.position, interested);
	}

	void LateUpdate () {
		transform.position = Vector3.MoveTowards(transform.position, following.transform.position, interested);
	}

} 

