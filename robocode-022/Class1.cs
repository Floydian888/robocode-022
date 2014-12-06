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

        
        double kierunek = 1;
        public void Move() {
            
            Ahead(5000);
            TurnRight(90);
            //TurnRadarRight(Heading + 90);
            while (DistanceRemaining > 0 && TurnRemaining > 0)
            {
                Execute();
            }
            
        }

        public double ObliczKat(double x, double y)
        {
            double kat;
            return kat = (Math.Atan(x / y)) * (180 / Math.PI);
        }

        public void skanujOscylacyjnie(double kierunek)
        {
            SetTurnRadarRight( 50 * kierunek);
           // SetTurnGunRight(50 * kierunek);
            kierunek *= -1;
            SetTurnRadarRight( 100 * kierunek);
            //SetTurnGunRight(100 * kierunek);
        }

        public override void Run()
        {

            IsAdjustGunForRobotTurn = true;
            IsAdjustRadarForRobotTurn = true;
            TurnRight(360 - Heading);
            Ahead(5000);
            TurnRight(90);
            Ahead(5000);
            TurnRight(90);
            //TurnRadarRight(90);

            //double kat = ObliczKat(BattleFieldWidth, BattleFieldHeight);
            while (true)
            {
                Move();
                
            }

        }

        public override void OnHitRobot(HitRobotEvent evnt)
        {

            Reset();
            Move();
        }
        public void Reset()
        {
            TurnRight(360 - Heading);
            Ahead(5000);
            TurnRight(90);
            Ahead(5000);
        }
        
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            //IsInterruptible = true;
            SetTurnGunRight(Heading - GunHeading + evnt.Bearing);
            while(GunTurnRemaining > 0){
                Execute();
            }
            if (evnt.Distance < 100)
            {
                SetFire(3);
            }
            else
            {
                SetFire(1);
            }
            Console.WriteLine("wyskanowano, distance: " + evnt.Distance + ", gun heat: " + GunHeat);
            skanujOscylacyjnie(kierunek);
            kierunek *= -1;
        }
    }
}
