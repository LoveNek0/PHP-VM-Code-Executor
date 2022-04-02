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
        public Executor() { }


        public int Run(Operation[] operations) => Run(new Queue<Operation>(operations));
        public int Run(Queue<Operation> operations)
        {
            MemoryBuffer memory = new MemoryBuffer();
            OutputBuffer output = new OutputBuffer();
            while (operations.Count > 0)
            {
                Operation operation = operations.Dequeue();
                switch (operation.type)
                {
                    case Operation.Type.ECHO:
                        {
                            dynamic left = operation.arguments[0].value;
                            if (operation.arguments[0].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[0].value);
                            output.Write(left);
                        }
                        break;
                    case Operation.Type.EXIT:
                        {
                            dynamic left = operation.arguments[0].value;
                            if (operation.arguments[0].type == Argument.Type.VAR)
                                left = memory.Get(operation.arguments[0].value);
                            return (int)left;
                        }
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
                }
            }
            return 0;
        }
    }
}
