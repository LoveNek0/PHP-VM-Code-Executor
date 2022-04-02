using PHP.VM.Runtime.Buffers;
using PHP.VM.Runtime.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime
{
    public class Executor
    {
        public delegate void OnMessageEvent(string message);
        
        private readonly Operation[] operations;

        private readonly MemoryBuffer memory = new MemoryBuffer();
        private readonly PointBuffer pointBuffer;
        private bool _IsRun = false;

        public OnMessageEvent OnMessageEventHandler = null;
        public bool IsRun
        {
            get { return _IsRun; }
        }

        public Executor(Operation[] operations)
        {
            this.operations = operations;
            this.pointBuffer = new PointBuffer(operations);
        }

        public int Run()
        {
            _IsRun = true;
            int result = ExecuteOperations();
            _IsRun = false;
            return result;
        }

        private int ExecuteOperations()
        {
            memory.Clear();
            for (int i = 0; i < operations.Length; i++)
            {
                Operation operation = operations[i];
                switch (operation.type)
                {
                    case Operation.Type.ECHO:
                        {
                            dynamic left = operation.arguments[0].value;
                            if (operation.arguments[0].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[0].value);
                            OnMessageEventHandler(left.ToString());
                        }
                        break;
                    case Operation.Type.EXIT:
                        {
                            dynamic left = operation.arguments[0].value;
                            if (operation.arguments[0].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[0].value);
                            return (int)left;
                        }
                    case Operation.Type.UNSET:
                        memory.Unset(operation.arguments[0].value);
                        break;
                    case Operation.Type.POINT:
                        break;
                    case Operation.Type.GOTO:
                        i = pointBuffer.Get(operation.arguments[0].value.ToString());
                        break;

                    case Operation.Type.ASSIGN:
                        {
                            dynamic left = operation.arguments[1].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            memory.Set(operation.arguments[0].value, left);
                        }
                        continue;
                    case Operation.Type.CONCAT:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left + right);
                        }
                        break;

                    case Operation.Type.ADD:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left + right);
                        }
                        break;
                    case Operation.Type.SUB:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left - right);
                        }
                        break;
                    case Operation.Type.MUL:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left * right);
                        }
                        break;
                    case Operation.Type.DIV:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left / right);
                        }
                        break;
                    case Operation.Type.MOD:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left % right);
                        }
                        break;
                    case Operation.Type.POW:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, Math.Pow(left, right));
                        }
                        break;
                    case Operation.Type.IF:
                        {
                            bool status = (bool)memory.Get(operation.arguments[0].value);
                            int success = pointBuffer.Get((string)operation.arguments[1].value);
                            int failture = pointBuffer.Get((string)operation.arguments[2].value);
                            i = status ? success : failture;
                        }
                        break;
                    case Operation.Type.EQUAL:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left == right);
                        }
                        break;
                    case Operation.Type.NOT_EQUAL:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left != right);
                        }
                        break;
                    case Operation.Type.MORE:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left > right);
                        }
                        break;
                    case Operation.Type.LESS:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left < right);
                        }
                        break;
                    case Operation.Type.MORE_EQUAL:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left >= right);
                        }
                        break;
                    case Operation.Type.LESS_EQUAL:
                        {
                            dynamic left = operation.arguments[1].value;
                            dynamic right = operation.arguments[2].value;
                            if (operation.arguments[1].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[1].value);
                            if (operation.arguments[2].type == Argument.Type.VAR)
                                right = memory.Get(operation.arguments[2].value);

                            memory.Set(operation.arguments[0].value, left <= right);
                        }
                        break;

                }
            }
            return 0;
        }
    }
}
