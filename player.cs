using Godot;
using System;

public partial class player : CharacterBody3D
{

    //replace export with resources at some point
    [Export]
    private bool CameraForward = true;
    [Export]
    private float RotationClamp = 70f;
    [Export]
    private float MouseSensitivity = 0.2f;
    [Export]
    private Vector3 GravityVal = new Vector3(0,8.69f,0);
    private mouse_input_handler MouseIn;
    private wasd_input_movement WasdIn;
    private Camera3D FPCamera;
    private fp_movement FPMovement;
    private Vector2 DeltaMouse;

   

    public override void _Ready()
    {
        base._Ready();
        MouseIn = GetNode<mouse_input_handler>("MouseInput");
        WasdIn = GetNode<wasd_input_movement>("WasdInput");
        FPCamera = GetNode<Camera3D>("FPCamera");
        FPMovement = GetNode<fp_movement>("FPMovement");
      //Below is a remnant of when was stunlocked thinking about a universally applicable player for any game
          if (CameraForward)
          {
            MouseIn.mousemotion += ApplySensitivity;
            MouseIn.Lmousejustpressed += RayCastAction;
            WasdIn.MovementAxes += PlayerMove;
          }

        //Temporary  mouse capture, will change when I run into an aspect of the game that requires 
        // changing mouse modes
        
        Input.MouseMode = Input.MouseModeEnum.Captured ;
       
       
    }
    private void ApplySensitivity(float deltax, float deltay)
    {

        DeltaMouse =  new Vector2 (deltax, deltay) * MouseSensitivity;
   //     GD.Print("DeltaMouse", DeltaMouse);
    }
    private void PlayerMove(float XAxis, float YAxis)
    {
         
        FPMovement.MoveRelative(this, XAxis, YAxis);
        
    }

    private void RayCastAction(Vector2 clickpos)
    {
       // FPCamera.p
    }
    
    

    public override void _Process(double delta)
    {

        //Currently this does a rotate body with camera around y
     //   GD.Print("DeltaDoom", DeltaMouse);
        var DeltaDeltaMouse = DeltaMouse * Convert.ToSingle(delta);
        FPCamera.RotateX(-DeltaDeltaMouse.Y);
       // FPCamera.RotationDegrees = new Vector3( Mathf.Clamp(FPCamera.RotationDegrees.X,
     //       -RotationClamp, RotationClamp),
    //        this.RotationDegrees.Y,this.RotationDegrees.Z);
     //   GD.Print(RotationDegrees, "Roation before y reotate \n");
        this.RotateY(-DeltaDeltaMouse.X);
        //GD.Print(RotationDegrees, "Roation aafter y reotate \n");

        DeltaMouse = Vector2.Zero;
      /*  this.RotateObjectLocal(new Vector3(0f, 1f, 0f),0.02f);
        GD.Print(this.GlobalTransform, "is the global transform");
        GD.Print(this.Transform, "local transform \n");
        GD.Print(this.Basis, " local basis \n");
        GD.Print(this.GlobalBasis, " Global basis \n");
      */

    }
    public override void _PhysicsProcess(double delta)
    {
     
        this.Velocity = this.Velocity -=( GravityVal * Convert.ToSingle(delta));
        this.MoveAndSlide();
    }
}
