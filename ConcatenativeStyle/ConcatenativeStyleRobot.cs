using System;
using System.Collections.Generic;
using StatelessCleanerLibrary;

namespace ConcatenativeStyle
{
    public class ConcatenativeStyleRobot
    {
        private readonly StatelessRobotCleaner _robot;
        private readonly State _robotState;

        private readonly Action<string> _transferToCleaner;
        
        public ConcatenativeStyleRobot(StatelessRobotCleaner robot, State robotState, Action<string> transferToCleaner)
        {
            _robot = robot;
            _robotState = robotState;
            _transferToCleaner = transferToCleaner;
        }

        public void Process(string commands)
        {
            var allCommandsList = ParseCommands(commands);
            InterpretCommands(allCommandsList);
        }

        private List<string> ParseCommands(string commands)
        {
            var stack = new Stack<string>();
            var commandNames = new List<string> {"move", "turn", "set", "start", "stop"};
            var result = new List<string>();

            var splittedCommands = commands.Split(' ', StringSplitOptions.TrimEntries);
            foreach(var word in splittedCommands)
            {
                if(commandNames.Contains(word))
                {
                    if(word == "start" || word == "stop")
                        result.Add(word);
                    else
                    {
                        var argument = stack.Pop();
                        result.Add($"{word} {argument}");
                    }
                }
                else
                {
                    stack.Push(word);
                }
            }
            return result;
        }

        private void InterpretCommands(List<string> commands)
        {
            foreach(var command in commands)
            {
                var arrayOfActionsWithParameter = command.Split(' ');
                var action = arrayOfActionsWithParameter[0];
                var parameter = arrayOfActionsWithParameter.Length > 1 ? arrayOfActionsWithParameter[1] : null;
                switch(action)
                {
                    case "move":
                        var meters = Convert.ToInt32(parameter);
                        _robot.Move(meters, _robotState, _transferToCleaner);
                        break;
                    case "turn":
                        var angle = Convert.ToInt32(parameter);
                        _robot.Turn(angle, _robotState, _transferToCleaner);
                        break;
                    case "set":
                        if (Enum.TryParse(parameter, out Tools tool))
                            _robot.Set(tool, _robotState, _transferToCleaner);
                        else
                            _robot.Set(Tools.water, _robotState, _transferToCleaner);;
                        break;
                    case "start":
                        _robot.Start(_robotState, _transferToCleaner);
                        break;
                    case "stop":
                        _robot.Stop(_transferToCleaner);
                        break;
                    default:
                        throw new NotImplementedException($"Action {action} not supported");
                }
            }
        }
    }
}

