using System;
using StatelessCleanerLibrary;

namespace FunctionalDependencyInjection
{
    public class ApiClass
    {
        private readonly StatelessRobotCleaner _robot;
        private readonly State _robotState;

        private readonly Action<string> _transferToCleaner;

        public ApiClass(StatelessRobotCleaner robot, State robotState, Action<string> transferToCleaner)
        {
            _robot = robot;
            _robotState = robotState;
            _transferToCleaner = transferToCleaner;
        }

        public void Move(int meters)
        {
            _robot.Move(meters, _robotState, _transferToCleaner);
        }

        public void Turn(int angleDegrees)
        {
            _robot.Turn(angleDegrees, _robotState, _transferToCleaner);
        }

        public void Set(Tools tool)
        {
            _robot.Set(tool, _robotState, _transferToCleaner);
        } 
        
        public void Start()
        {
            _robot.Start(_robotState, _transferToCleaner);
        }
        
        public void Stop()
        {
            _robot.Stop(_transferToCleaner);
        }
    }
}
