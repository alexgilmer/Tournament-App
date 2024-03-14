using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers;

public class JumpGameAnalyzer : GameAnalyzer<int[], bool, JumpGameAnalyzer.CodeInputObject>
{
    public override int[] ScriptPrimer => new int[]{ 0 };

    public override string FlagCode => "a062fb18956fa1910f45e";

    public override Tester<int[], bool> Tester => new JumpGameTester();

    public override string ExtraCode => "return CanJump(CodeInput);";

    public override CodeInputObject GetCodeInput(int[] input) => new(input);

    public class CodeInputObject
    {
        public int[] CodeInput { get; set; } = Array.Empty<int>();
        public CodeInputObject() { }
        public CodeInputObject(int[] codeInput) { CodeInput = codeInput; }
    }
}
