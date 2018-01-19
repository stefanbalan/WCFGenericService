using System.Runtime.Serialization;
using System.ServiceModel;

    namespace GenericWcfService
    {
        [ServiceKnownType(typeof(Pair))] //there's another way to add more, look it up
        [ServiceContract]
        public interface ICalculatorService
        {
            [OperationContract]
            OperationResult GetResult(Operation op, object[] parameteres);
        }

        public enum Operation
        {
            Add,
            Substract,
            Multiply,
            Divide,
            Print,
            AddPair
        }

        [DataContract]
        public class OperationResult
        {
            [DataMember]
            public object Result { get; set; }

            [DataMember]
            public string Error { get; set; }
        }

        [DataContract]
        public class Pair
        {
            [DataMember]
            public int V1;
            [DataMember]
            public int V2;
        }
    }
