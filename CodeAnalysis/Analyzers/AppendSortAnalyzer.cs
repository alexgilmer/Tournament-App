using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers
{
    public class AppendSortAnalyzer : GameAnalyzer<IList<int>, int, AppendSortAnalyzer.CodeInputObject>
    {
        public override IList<int> ScriptPrimer => new List<int>() { 2, 3 };

        public override string FlagCode => "0e6f78728493d1f85cef0ecc262e4aa";

        public override Tester<IList<int>, int> Tester => new AppendSortTester();

        public override string ExtraCode => "return AppendSort(CodeInput);";

        public override CodeInputObject GetCodeInput(IList<int> input) => new(input);

        public class CodeInputObject
        {
            public IList<int> CodeInput { get; set; }
            public CodeInputObject() { }
            public CodeInputObject(IList<int> codeInput) { CodeInput = codeInput; }
        }

    }
}
