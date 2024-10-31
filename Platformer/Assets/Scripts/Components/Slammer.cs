using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour
{
    public float height = 3;

    public float upDuration = 1.0f;
    public float upTimer { protected set; get; }

    public float floorDuration = 0.5f;
    public float floorTimer { protected set; get; }

    public float slamDuration = 0.15f;
    public float slamTimer { protected set; get; }

    public float raiseDuration = 0.75f;
    public float raiseTimer { protected set; get; }

    public enum State { Floor, Raising, Up, Slamming };
    public State state;

    public Vector3 startPosition { protected set; get; }

    public bool randomizeStart = true;


    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;

        if(this.randomizeStart)
        {
            int r = Random.Range(0, 4);
            switch(r)
            {
                case 0:
                    this.state = State.Floor;
                    this.floorTimer = Random.Range(0, this.floorDuration);
                    break;

                case 1:
                    this.state = State.Raising;
                    this.raiseTimer = Random.Range(0, this.raiseDuration);
                    break;

                case 2:
                    this.state = State.Up;
                    this.upTimer = Random.Range(0, this.upDuration);
                    break;

                case 3:
                    this.state = State.Slamming;
                    this.slamTimer = Random.Range(0, this.slamDuration);
                    break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        switch(this.state)
        {
            case State.Up:
                UpdateUpState();
                break;

            case State.Slamming:
                UpdateSlamState();
                break;

            case State.Floor:
                UpdateFloorState();
                break;

            case State.Raising:
                UpdateRaiseState();
                break;
        }
    }



    protected void UpdateUpState()
    {
        this.upTimer += Time.deltaTime;
        if(this.upTimer > this.upDuration)
        {
            this.upTimer = 0;
            this.state = State.Slamming;
        }
    }


    protected void UpdateFloorState()
    {
        this.floorTimer += Time.deltaTime;
        if (this.floorTimer > this.floorDuration)
        {
            this.floorTimer = 0;
            this.state = State.Raising;
        }
    }


    protected void UpdateSlamState()
    {
        this.slamTimer += Time.deltaTime;
        if(this.slamTimer > this.slamDuration)
        {
            this.slamTimer = 0;
            this.state = State.Floor;
        }
        else
        {
            Vector3 upPosition = this.startPosition + new Vector3(0, this.height, 0);
            this.transform.position = EaseUtility.GetEaseInPosition(this.slamTimer, this.slamDuration, upPosition, this.startPosition);
        }
    }


    protected void UpdateRaiseState()
    {
        this.raiseTimer += Time.deltaTime;
        if (this.raiseTimer > this.raiseDuration)
        {
            this.raiseTimer = 0;
            this.state = State.Up;
        }
        else
        {
            Vector3 upPosition = this.startPosition + new Vector3(0, this.height, 0);
            this.transform.position = EaseUtility.GetEaseOutPosition(this.raiseTimer, this.raiseDuration, this.startPosition, upPosition);
        }
    }
}
