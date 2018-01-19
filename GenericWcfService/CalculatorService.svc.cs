using System;

    namespace GenericWcfService
    {
        public class CalculatorService : ICalculatorService
        {
            public OperationResult GetResult(Operation op, object[] parameteres)
            {
                var calc = new CalculatorImpl();
                var method = typeof(CalculatorImpl).GetMethod(op.ToString());

                var result = new OperationResult();
                if (method == null) { result.Error = "Incompatible"; return result; }
                var mParameters = method.GetParameters();
                if (mParameters.Length != parameteres.Length) { result.Error = "Incompatible"; return result; }
                for (int i = 0; i < parameteres.Length; i++)
                {
                    try
                    {
                        var paramVal = Convert.ChangeType(parameteres[i], mParameters[i].ParameterType);
                    }
                    catch (Exception)
                    {
                        { result.Error = $"Parameter [{i}]({mParameters[i]})={parameteres[i]} is incompatible"; return result; }
                    }
                }


                try
                {
                    result.Result = method?.Invoke(calc, parameteres);
                }
                catch (Exception e)
                {
                    result.Error = e.Message;
                }
                return result;
            }
        }

        public class CalculatorImpl
        {
            public int Add(int p1, int p2)
            {
                return p1 + p2;
            }

            public string Print(string text, int n1)
            {
                return $"{text}: {n1}";
            }

            public int AddPair(Pair p)
            {
                return p.V1 + p.V2;
            }
        }
    }
