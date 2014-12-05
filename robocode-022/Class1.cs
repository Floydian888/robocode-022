using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace DLKWGD
{
    class zero22 : AdvancedRobot
    {
        double x_pole = 0, y_pole = 0;
        double kierunek = 1;
        public void okreslWymiaryPola()
        {
            TurnRight(360 - Heading);
            SetAhead(5000);
            SetTurnRight(90);
            SetAhead(5000);
            Console.WriteLine(X + ", " + Y);
            x_pole = X;
            y_pole = Y;
        }

        public void skanujOscylacyjnie(double kierunek)
        {
            SetTurnRadarRight( 50 * kierunek);
            SetTurnGunRight(50 * kierunek);
            kierunek *= -1;
            SetTurnRadarRight( 100 * kierunek);
            SetTurnGunRight(100 * kierunek);
        }

        public override void Run()
        {
            okreslWymiaryPola();
            Console.WriteLine(x_pole + " " + y_pole);
            while (DistanceRemaining > 0 && TurnRemaining > 0 && RadarTurnRemaining> 0)
            {
                Execute();
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            if (evnt.Distance < 100)
            {
                SetFire(3);
            }
            else
            {
                SetFire(1);
            }
            IsAdjustRadarForRobotTurn = true;
            Console.WriteLine("wyskanowano, distance: " + evnt.Distance + ", gun heat: " + GunHeat);
            skanujOscylacyjnie(kierunek);
            kierunek *= -1;
        }
    }
}
