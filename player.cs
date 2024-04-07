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
    private mouse_input_handler MouseIn;
    private wasd_input_movement WasdIn;
    private Camera3D FPCamera;
    private Vector2 DeltaMouse;
    public override void _Ready()
    {
        base._Ready();
        MouseIn = GetNode<mouse_input_handler>("MouseInput");
        WasdIn = GetNode<wasd_input_movement>("WasdInput");
        FPCamera = GetNode<Camera3D>("FPCamera");
      //
          if (CameraForward)
          {
            MouseIn.mousemotion += ApplySensitivity;
          }
          
        
    }
    private void ApplySensitivity(float deltax, float deltay)
    {

        DeltaMouse =  new Vector2 (deltax, deltay) * MouseSensitivity;
        GD.Print("DeltaMouse", DeltaMouse);
    }
    private void CameraOnlyRotation()
    {
        
    }
    

    public override void _Process(double delta)
    {

        //Currently this does a rotate body with camera around y
        GD.Print("DeltaDoom", DeltaMouse);
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
}
