using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers;

public class NestingDepthAnalyzer : GameAnalyzer<string, string, NestingDepthAnalyzer.CodeInputObject>
{
    public override string ScriptPrimer => "0";

    public override string FlagCode => "3bf665e39fe0a8295ef9662f8216";

    public override Tester<string, string> Tester => new NestingDepthTester();

    public override string ExtraCode => "return NestingDepth(CodeInput);";

    public override CodeInputObject GetCodeInput(string input) => new(input);

    public class CodeInputObject
    {
        public string CodeInput { get; set; }
        public CodeInputObject() { }
        public CodeInputObject(string codeInput) { CodeInput = codeInput; }
    }
}
