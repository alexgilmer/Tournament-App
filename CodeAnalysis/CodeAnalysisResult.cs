using Flex_Day_Challenge_Tester_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis;

public class CodeAnalysisResult
{
    public bool Passed { get; init; }
    public bool Failed
    {
        get
        {
            return !Passed;
        }
    }

    public string Message { get; set; } = string.Empty;
    public string Input { get; init; } = string.Empty;
    public string ExpectedOutput { get; init; } = string.Empty;
    public string ActualOutput { get; init; } = string.Empty;
    public long StudentSolutionComputationTime { get; init; }
    public long SystemSolutionComputationTime { get; init; }

    public CodeAnalysisResult() { }
}
