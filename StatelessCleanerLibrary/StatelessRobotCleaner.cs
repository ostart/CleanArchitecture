using System;

namespace StatelessCleanerLibrary
{
    public class StatelessRobotCleaner
    {
        public void Move(int meters, State state, Action<string> transferDelegate)
        {
            var currentPosition = state.Position;
            var angleInRadian = Math.PI * state.AngleInDegrees / 180.0;
            var newPosition = new Position();
            newPosition.X = currentPosition.X + meters * Math.Cos(angleInRadian);
            newPosition.Y = currentPosition.Y + meters * Math.Sin(angleInRadian);
            state.Position = newPosition;
            
            transferDelegate($"POS {state.Position.X},{state.Position.Y}");
        }

        public void Turn(int angleDegrees, State state, Action<string> transferDelegate)
        {
            var currentAngle = state.AngleInDegrees;
            state.AngleInDegrees = currentAngle + angleDegrees;

            transferDelegate($"ANGLE {state.AngleInDegrees}");
        }

        public void Set(Tools tool, State state, Action<string> transferDelegate)
        {
            state.Tool = tool;
            var stateName = Enum.GetName<Tools>(state.Tool);

            transferDelegate($"STATE {stateName}");
        } 
        
        public void Start(State state, Action<string> transferDelegate)
        {
            var stateName = Enum.GetName<Tools>(state.Tool);

            transferDelegate($"START WITH {stateName}");
        }
        
        public void Stop(Action<string> transferDelegate)
        {
           transferDelegate("STOP");
        }
    }
}
