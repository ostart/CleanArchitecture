using System;
using StatelessCleanerLibrary;

namespace MonadicState
{
    public class MonadicStateApi
    {
        private readonly StatelessRobotCleaner _robot;
        private readonly Action<string> _transferToCleaner;

        public MonadicStateApi(StatelessRobotCleaner robot, Action<string> transferToCleaner)
        {
            _robot = robot;
            _transferToCleaner = transferToCleaner;
        }

        public State Move(int meters, State robotState)
        {
            _robot.Move(meters, robotState, _transferToCleaner);
            return robotState;
        }

        public State Turn(int angleDegrees, State robotState)
        {
            _robot.Turn(angleDegrees, robotState, _transferToCleaner);
            return robotState;
        }

        public State Set(Tools tool, State robotState)
        {
            _robot.Set(tool, robotState, _transferToCleaner);
            return robotState;
        } 
        
        public State Start(State robotState)
        {
            _robot.Start(robotState, _transferToCleaner);
            return robotState;
        }
        
        public State Stop(State robotState)
        {
            _robot.Stop(_transferToCleaner);
            return robotState;
        }
    }
}