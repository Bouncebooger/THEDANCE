using Godot;
using System;
using Godot.Collections;

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
    private object_pick_3D ObjQuery ;
    private Vector2 DeltaMouse;
    private bool carryingplant;

    //
    private PhysicsRayQueryParameters3D Cacheparam;
    private Godot.Collections.Dictionary ground;
    //  private scene_event_bus_autoload SEB;
    //Lord forgive me for what im doin
    private Node3D parentscene;
    private PackedScene proplant;

    public override void _Ready()
    {
        base._Ready();
        carryingplant = false;
        proplant = ResourceLoader.Load<PackedScene>("res://Scenes/PlantScenes/protection_plant.tscn");
        //  SEB = GetNode<scene_event_bus_autoload>("/root/SceneEventBusAutoload");
        parentscene = GetNode<Node3D>("/root/Main/GameWorld/TestScene");
        Cacheparam = new PhysicsRayQueryParameters3D();
        Cacheparam.To = this.GlobalPosition* new Vector3(0,-10,0);
        Cacheparam.From = this.GlobalPosition;
       
        MouseIn = GetNode<mouse_input_handler>("MouseInput");
        WasdIn = GetNode<wasd_input_movement>("WasdInput");
        FPCamera = GetNode<Camera3D>("FPCamera");
        FPMovement = GetNode<fp_movement>("FPMovement");
        ObjQuery = GetNode<object_pick_3D>("TempLMMech");
        ground = ObjQuery.PerspRayQuery(Cacheparam);
        //Below is a remnant of when was stunlocked thinking about a universally applicable player for any game
        if (CameraForward)
          {
            MouseIn.mousemotion += ApplySensitivity;
            MouseIn.Lmousejustpressed += FPRayCast;
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

    private void FPRayCast(Vector2 clickpos)
    {
        GD.Print("got to cast");
        Cacheparam.From = FPCamera.ProjectRayOrigin(clickpos);
        Cacheparam.To = Cacheparam.From+ FPCamera.ProjectRayNormal(clickpos) * 10;
       var gotdictionary = ObjQuery.PerspRayQuery(Cacheparam);
        //  GD.Print(gotdictionary["collider"], " is equal to?? ", ground["collider"]);
        GD.Print(carryingplant);
        if (gotdictionary.Count == 0)
        {
            return;
        }
        if((GD.VarToStr(gotdictionary["collider"])==GD.VarToStr(ground["collider"]))  );
       {
            if (carryingplant == true)
            {
                Node3D plantmade = proplant.Instantiate<Node3D>();
                parentscene.AddChild(plantmade);
                plantmade.GlobalPosition = (gotdictionary["position"].AsVector3());
                //    GD.Print(plantmade.GlobalPosition,"position passed");
                //     GD.Print(parentscene.GetChildCount(), " children before");
                //  parentscene.AddChild(plantmade);
                //   GD.Print(parentscene.GetChildCount(),  " children after");
                // GD.Print("yippeee");
                carryingplant = false;
            }
            else
            {
             //   return;
            }
      }
        GD.Print("gets before seebox check", (gotdictionary["collider"]).AsString().Remove(7));
        if ((gotdictionary["collider"]).AsString().Remove(7) == "SeedBox")
        {
            GD.Print("passes seedbox");
            carryingplant = true;
        }
      //  ObjQuery.PerspRayQuery(Cacheparam);
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
