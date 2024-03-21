using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers
{
    public class RestockingAnalyzer : GameAnalyzer<int, Dictionary<int, decimal>, decimal, RestockingAnalyzer.CodeInputObject>
    {
        private bool _IsEasyMode { get; }
        public override Tuple<int, Dictionary<int, decimal>> ScriptPrimer => new(4, new() { { 1, 1m } });

        public override string FlagCode =>
            _IsEasyMode ? $"db1d75dd4fdfca43b58a73f7578d721b87708dc6a0ef5e8842b62a9ac7dc7715.  Now try standard difficulty at: /restocking-b3e447d68b22122b9796746c0b7241d0"
            : "67e281a848c6648aa6dda40a693e766bebf533623d1e8b58b9fbdb204ab1dadc";

        public override Tester<int, Dictionary<int, decimal>, decimal> Tester => 
            _IsEasyMode ? new RestockingSuppliesTesterEasy()
            : new RestockingSuppliesTester();

        public override string ExtraCode => "return Restock(CodeInput1, CodeInput2);";

        public override CodeInputObject GetCodeInput(int input1, Dictionary<int, decimal> input2) => new(input1, input2);

        public RestockingAnalyzer(bool isEasyMode)
        {
            _IsEasyMode = isEasyMode;
        }

        public class CodeInputObject
        {
            public int CodeInput1 { get; set; }
            public Dictionary<int, decimal> CodeInput2 { get; set; }
            public CodeInputObject(int a, Dictionary<int, decimal> b) { CodeInput1 = a; CodeInput2 = b; }
        }

    }
}
