using System;
using StatelessCleanerLibrary;

namespace FunctionalDependencyInjection
{
    public class ApiClass
    {
        private StatelessRobotCleaner _robot = new StatelessRobotCleaner();
        private State _robotState = new State();

        private void TransferToCleaner(string message)
        {
            Console.WriteLine(message);
        }

        public void Move(int meters, State state, Action<string> transferDelegate, Action<int, State, Action<string>> moveFunction)
        {
            moveFunction(meters, state, transferDelegate);
        }

        public void Turn(int angleDegrees, State state, Action<string> transferDelegate, Action<int, State, Action<string>> turnFunction)
        {
            turnFunction(angleDegrees, state, transferDelegate);
        }

        public void Set(Tools tool, State state, Action<string> transferDelegate, Action<Tools, State, Action<string>> setFunction)
        {
            setFunction(tool, state, transferDelegate);
        } 
        
        public void Start(State state, Action<string> transferDelegate, Action<State, Action<string>> startFunction)
        {
            startFunction(state, transferDelegate);
        }
        
        public void Stop(Action<string> transferDelegate, Action<Action<string>> stopFunction)
        {
            stopFunction(transferDelegate);
        }

    }
}
