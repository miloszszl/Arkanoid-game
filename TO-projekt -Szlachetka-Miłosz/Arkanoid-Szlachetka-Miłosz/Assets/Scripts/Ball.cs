using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Player player;
	private float ballVelocity;
	private Vector3 ballForce;
	private Rigidbody rigbody;
	private BallState actualBallState;
	private List<BallState> ballStates;
	private Vector3 ballPosition;

	public Vector3 BallPosition
	{
		get{ return this.ballPosition; }
		set{ this.ballPosition = value;}
	}

	public Rigidbody Rigbody
	{
		get{ return this.rigbody;}
		set{ this.rigbody = value;}
	}

	public Vector3 BallForce
	{
		get{ return this.ballForce;}
		set{ this.ballForce = value;}
	}

	public BallState ActualBallState
	{
		get{ return this.actualBallState;}
		set{ this.actualBallState = value;}
	}

	public List<BallState> BallStates
	{
		get{return this.ballStates; }
		set{ this.ballStates = value;}
	}

	// Use this for initialization
	void Awake () {
		ballStates = new List<BallState> ();
		ballStates.Add (new NotActiveState());
		ballStates.Add (new ActiveState ());
		ballStates.Add (new SleepState ());
		actualBallState = ballStates [0];
		ballPosition = new Vector3 (0,-8,0);
		ballVelocity = 700f;
		rigbody = GetComponent<Rigidbody> ();
	}

	public void CalculateBallForce()
	{
		int xInitialDirection = Random.Range (0, 2)==1 ? 1 : -1;
		int yInitialDirection = Random.Range (0, 2)==1 ? 1 : -1;
		ballForce = new Vector3 (xInitialDirection*ballVelocity,yInitialDirection*ballVelocity,0);
	}

	// Update is called once per frame
	void Update () {
		actualBallState.doAction (this);	
	}
}
