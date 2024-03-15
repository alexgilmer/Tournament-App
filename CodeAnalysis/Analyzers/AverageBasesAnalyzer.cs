using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers;

public class AverageBasesAnalyzer : GameAnalyzer<int, string, AverageBasesAnalyzer.CodeInputObject>
{
    public override int ScriptPrimer => 5;

    public override string FlagCode => "b9c81f9d460eaf97331cdacbd5";

    public override Tester<int, string> Tester => new AverageBasesTester();

    public override string ExtraCode => "return AverageBases(CodeInput);";

    public override CodeInputObject GetCodeInput(int input) => new(input);

    public class CodeInputObject
    {
        public int CodeInput { get; set; }
        public CodeInputObject() { }
        public CodeInputObject(int codeInput) { CodeInput = codeInput; }
    }

}
