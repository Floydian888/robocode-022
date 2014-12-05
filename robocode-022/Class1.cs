using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace DLKWGD
{
    // The name of your robot is MyRobot, and the robot type is Robot
    class zero22 : Robot
    {
        double x_pole = 0, y_pole = 0;
        public void okreslWymiaryPola()
        {
            //Console.WriteLine("heading: " + Heading);
            TurnRight(360 - Heading);
            //Console.WriteLine("heading: " + Heading);
            Ahead(5000);
            TurnRight(90);
            Ahead(5000);
            Console.WriteLine(X + ", " + Y);
            x_pole = X;
            y_pole = Y;
        }
        public override void Run()
        {
            //Console.WriteLine("gun heading: " + GunHeading);
            //TurnGunRight(360);
            //TurnGunRight(360 - GunHeading);
            //Console.WriteLine("gun heading: " + GunHeading);

            //ustalam rozmiar pola bitwy
            okreslWymiaryPola();
            Console.WriteLine(x_pole + " " + y_pole);

        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            Console.WriteLine("wyskanowano robota, gun heat: " + GunHeat);
            Fire(1);
        }

        //// The main method of your robot containing robot logics
        //public override void Run()
        //{
        //    // -- Initialization of the robot --

        //    // Here we turn the robot to point upwards, and move the gun 90 degrees
        //    TurnLeft(Heading - 90);
        //    TurnGunRight(90);

        //    // Infinite loop making sure this robot runs till the end of the battle round
        //    while (true)
        //    {
        //        // -- Commands that are repeated forever --

        //        // Move our robot 5000 pixels ahead
        //        Ahead(5000);

        //        // Turn the robot 90 degrees
        //        TurnRight(90);

        //        // Our robot will move along the borders of the battle field
        //        // by repeating the above two statements.
        //    }
        //}

        //// Robot event handler, when the robot sees another robot
        //public override void OnScannedRobot(ScannedRobotEvent e)
        //{
        //    // We fire the gun with bullet power = 1
        //    Fire(1);
        //}

    }
}
