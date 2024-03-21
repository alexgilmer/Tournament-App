using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers
{
    public class TextJustificationAnalyzer : GameAnalyzer<string, int, IList<string>, TextJustificationAnalyzer.CodeInputObject>
    {
        public override Tuple<string, int> ScriptPrimer => new("hello", 5);

        public override string FlagCode => "042d4d5753d55d9c1064ca90f766ded9e1";

        public override Tester<string, int, IList<string>> Tester => new JustificationTester();

        public override string ExtraCode => "return JustifyText(CodeInput1, CodeInput2);";

        public override CodeInputObject GetCodeInput(string input1, int input2) => new(input1, input2);

        public class CodeInputObject
        {
            public string CodeInput1 { get; set; }
            public int CodeInput2 { get; set; }
            public CodeInputObject() { }
            public CodeInputObject(string a, int b) { CodeInput1 = a; CodeInput2 = b; }
        }

    }
}
