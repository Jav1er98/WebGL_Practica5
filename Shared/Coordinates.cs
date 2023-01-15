using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SimpleGame.Pages;
using SimpleGame.Math;

namespace SimpleGame.Coordinate
{
    public class Coordinates2D {
        public double X {get; set;}
        public double Y {get; set;}

        
        public Coordinates2D(){
            X=0.0;
            Y=0.0;
        }

        public Coordinates2D(double x, double y){
            X=x;
            Y=y;
        }

        public Coordinates2D(Coordinates2D mC){
            X=mC.X;
            Y=mC.Y;
        }

        public static Coordinates2D operator+(Coordinates2D mC1,Coordinates2D mC2)  
            => new Coordinates2D(mC1.X+mC2.X,mC1.Y+mC2.Y);            
        public static Coordinates2D operator-(Coordinates2D mC1,Coordinates2D mC2)  
            => new Coordinates2D(mC1.X-mC2.X,mC1.Y-mC2.Y);            


    }

    public class Angles2D {
        public double Yaw {get; set;}
        public double Pitch{get; set;}

        
        public Angles2D(){
            Yaw=0.0;
            Pitch=0.0;
        }
        public Angles2D(double y, double p){
            Yaw = y % 360.0;
            if(Yaw>180)
                Yaw=-(360-Yaw);
            Pitch = clampPitch(p % 360.0);

        }

        public Angles2D(Angles2D ang){
            Yaw = ang.Yaw;
            Pitch = ang.Pitch;
        }


        public static Angles2D operator+(Angles2D bA1,Angles2D bA2){
            double yaw,pitch;
            yaw = bA1.Yaw + bA2.Yaw;
               
            yaw  = yaw % 360.0;
            if(yaw>180)
                yaw=-(360.0-yaw);
            pitch = bA1.Pitch + bA2.Pitch;
            pitch = clampPitch(pitch % 360.0);

            return new Angles2D(yaw,pitch);
        }
        public static Angles2D operator-(Angles2D bA1,Angles2D bA2){
            double yaw,pitch;
            yaw = bA1.Yaw - bA2.Yaw;
            yaw  = yaw % 360.0;
            pitch = bA1.Pitch - bA2.Pitch;
            pitch = clampPitch(pitch % 360.0);
            return new Angles2D(yaw,pitch);
        }

        public static Angles2D operator*(double f, Angles2D bA)
            => new Angles2D(f*bA.Yaw,f*bA.Pitch);
        public static Angles2D operator*(Angles2D bA,double f)
            => new Angles2D(f*bA.Yaw,f*bA.Pitch);

        
        private static double clampPitch(double p){
            double lim=89.9;
            if(p<-lim)
                return -lim;
            if(p>lim)
                return lim;
            return p;
        }


    }
}