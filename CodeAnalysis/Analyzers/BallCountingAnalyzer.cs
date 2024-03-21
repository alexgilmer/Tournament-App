using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers;

public class BallCountingAnalyzer : GameAnalyzer<BigInteger, BigInteger, BallCountingAnalyzer.CodeInputObject>
{
    private bool _IsEasyMode { get; init; }
    public override BigInteger ScriptPrimer => 1;

    public override string FlagCode => 
        _IsEasyMode ? "48b7ca5c188b18679814861a61fbe40f053fb410d3f9c2f73105dc4eea947826.  Now try standard difficulty at: /ball-counting-bdb7de8471436ae5b336dd02e414e8b1"
        : "24d9ebf4ca86fef131adc8a82f89aa2d40778e0ae77c28aa05b42ab9d0624592";

    public override Tester<BigInteger, BigInteger> Tester => 
        _IsEasyMode ? new BallCountingTesterEasy()
        : new BallCountingTester();

    public override string ExtraCode => "return CountBalls(CodeInput);";

    public override CodeInputObject GetCodeInput(BigInteger input) => new(input);

    public BallCountingAnalyzer(bool isEasyMode)
    {
        _IsEasyMode = isEasyMode;
    }

    public class CodeInputObject
    {
        public BigInteger CodeInput { get; set; }
        public CodeInputObject() { }
        public CodeInputObject(BigInteger codeInput) { CodeInput = codeInput; }
    }
}
