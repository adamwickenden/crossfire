using UnityEngine;

public abstract class Brain
{

    protected GameObject playerObject;
    protected float rotationSpeed;
    protected float slideSpeed;
    protected float minAngle;
    protected float maxAngle;
    protected float minSlide;
    protected float maxSlide;
    public bool right;
    public float Angle { get; protected set; }

    // Init class with gameobject of player
    public Brain(GameObject playerObject, float rotationSpeed, float slideSpeed, float minAngle, float maxAngle, float minSlide, float maxSlide, float Angle)
    {
        this.playerObject = playerObject;
        this.rotationSpeed = rotationSpeed;
        this.slideSpeed = slideSpeed;
        this.minAngle = minAngle;
        this.maxAngle = maxAngle;
        this.minSlide = minSlide;
        this.maxSlide = maxSlide;
        this.Angle = Angle;
    }

    // Abstract Tick function to execute all logic
    public abstract void Tick();

    public void GetSide()
    {
        Vector3 reference = playerObject.transform.position - SceneManager.Instance.board.transform.position;
        if (reference.x > 0) { right = true;  }
    }

}
