using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Robocode;

namespace DLKWGD
{
    class zero22 : AdvancedRobot
    {
        double kierunek = 1;
        public void Move() {
            SetAhead(5000);
            WaitFor(new MoveCompleteCondition(this));
            TurnRight(90);
               
        }

        public void skanujOscylacyjnie(double kierunek)
        {
            SetTurnRadarRight( 70 * kierunek);
            kierunek *= -1;
            SetTurnRadarRight( 140 * kierunek);
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

            while (true)
            {
                Move();
            }
        }
        public void Scanner() {
            SetTurnRadarRight(360 - RadarHeading);
            SetTurnRadarRight(Heading + 90);
        
        }
        public override void OnHitRobot(HitRobotEvent evnt)
        {
            SetAhead(5000);
            WaitFor(new MoveCompleteCondition(this));
            TurnRight(90); 
        }
        
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            //IsInterruptible = true;
            SetTurnGunRight(Heading - GunHeading + evnt.Bearing);
            
            while(GunTurnRemaining > 0){
                Execute();
            }
            if (evnt.Distance < 100 && GunHeat < 1)
            {
                SetFire(3);
            }
            else if(GunHeat < 1)
            {
                SetFire(1);
            }
            Console.WriteLine("wyskanowano, distance: " + evnt.Distance + ", gun heat: " + GunHeat);
            skanujOscylacyjnie(kierunek);
            kierunek *= -1;
        }
    }
}
