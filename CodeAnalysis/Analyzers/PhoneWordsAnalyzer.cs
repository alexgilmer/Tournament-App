using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers
{
    public class PhoneWordsAnalyzer : GameAnalyzer<string, IList<string>, PhoneWordsAnalyzer.CodeInputObject>
    {
        public override string ScriptPrimer => "4";

        public override string FlagCode => "366a2221b50695e34be4f41ea517254a22a";

        public override Tester<string, IList<string>> Tester => new PhoneWordsTester();

        public override string ExtraCode => "return PhoneWords(CodeInput);";

        public override CodeInputObject GetCodeInput(string input) => new(input);

        public class CodeInputObject
        {
            public string CodeInput { get; set; }
            public CodeInputObject() { }
            public CodeInputObject(string codeInput) { CodeInput = codeInput; }
        }

    }
}
