using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SimpleGame.Pages;
using SimpleGame.Math;
using SimpleGame.Coordinate;
 
namespace SimpleGame.Shared {
    public interface IController {
        void  MouseMovement(double x, double y);
        Coordinates2D GetMCoord();

        Angles2D GetBoomAngles();

        Vector3 GetMovement();

    }

   public partial class Controller: LayoutComponentBase, IController {

        public double WindowWidth=1.0;
        public double WindowHeight=1.0;

        public double MouseEffect=1.0;

        public double BoomRate=1.0;

        public double ScaleMovement {get; set;}

     public void ResetBoomYaw(){
         Angles2D angles = this.boomAngles;
         angles.Yaw=0;
         this.boomAngles=angles;
     }

      public void MouseMovement(double x, double y){

            

            Coordinates2D mC = new Coordinates2D(x,y);
            Coordinates2D delta;
            delta = mC - this.mCoord;
            this.mCoord = mC;
            if (mouseStopped){
                mouseStopped=false;
                return;
            }

            boomTarget = new Angles2D(boomTarget.Yaw + MouseEffect * delta.X,
                    boomTarget.Pitch + MouseEffect * delta.Y);
            boomAngles = boomAngles + BoomRate*(boomTarget-boomAngles);
            

        }
        public bool GamePlaying=false;
        private bool mouseStopped=true;
        private Coordinates2D mCoord = new Coordinates2D();

        private Angles2D boomAngles = new Angles2D();
        private Angles2D boomTarget = new Angles2D();

        private Vector3 MovementInput = new Vector3(0.0f,0.0f,0.0f);

        private void mouseEvent(MouseEventArgs e){
            if(!this.GamePlaying)
                return;
            if(e.Buttons<1)
            {
                this.mouseStopped=true;
                return;
            }
             
            double x = e.ClientX;
            double y = e.ClientY;


            x = x/WindowWidth;
            y= y/WindowHeight;

           MouseMovement(x,y);


        }

        private void keydownEvent(KeyboardEventArgs e){
            if(!this.GamePlaying)
                return;
            double f = System.Math.PI/180;                        
            double yaw = f*boomAngles.Yaw;
            Console.WriteLine("KeyDown");
            switch(e.Key){
                case "w" :
                    MovementInput.x = -(float)System.Math.Sin(yaw);
                    MovementInput.z = -(float)System.Math.Cos(yaw);
                    MovementInput.y=0.0f;
                    MovementInput = this.ScaleMovement* MovementInput;
                    break;
            
                case "s":
                    MovementInput.x = (float)System.Math.Sin(yaw);
                    MovementInput.z = (float)System.Math.Cos(yaw);
                    MovementInput.y=0.0f;
                    MovementInput = this.ScaleMovement* MovementInput;
                    break;
                case "a":
                    MovementInput.x = (float)System.Math.Sin(yaw)-1;
                    MovementInput.z = (float)System.Math.Cos(yaw)-1;
                    MovementInput.y=0.0f;
                    MovementInput = this.ScaleMovement* MovementInput;
                    break;
                 case "d":
                    MovementInput.x = -(float)System.Math.Sin(yaw)+1;
                    MovementInput.z = -(float)System.Math.Cos(yaw)+1;
                    MovementInput.y=0.0f;
                    MovementInput = this.ScaleMovement* MovementInput;
                    break;    
                default:
                break;
            }
        }


        private void keyupEvent(KeyboardEventArgs e){

            switch(e.Key){
                case "w" :
                    MovementInput.x = 0.0f;
                    MovementInput.y = 0.0f;
                    MovementInput.z= 0.0f;
                    break;
                case "s" :
                MovementInput.x = 0.0f;
                MovementInput.y = 0.0f;
                MovementInput.z= 0.0f;
                    break;
                case "a" :
                MovementInput.x = 0.0f;
                MovementInput.y = 0.0f;
                MovementInput.z= 0.0f;
                    break;
                case "d" :
                MovementInput.x = 0.0f;
                MovementInput.y = 0.0f;
                MovementInput.z= 0.0f;
                    break;
                default:
                    break;
                    

            }
        }



        public Coordinates2D GetMCoord(){
            return this.mCoord;
        }

        public Angles2D GetBoomAngles(){
            return this.boomAngles;
        }

        public Vector3 GetMovement(){
            return this.MovementInput;
        }

    protected ElementReference ctrlDiv;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {

    if (firstRender) 
    {
        this.boomAngles = new Angles2D();
        this.ScaleMovement = 0.1;
        
        //await JSRuntime.InvokeVoidAsync("SetFocusToElement", ctrlDiv);
    }   
    return;         
    }      
    }
}
