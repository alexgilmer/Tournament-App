﻿using CodeAnalysis.Analyzers;
using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;

namespace CodeAnalysis;

public static class CodeAnalyzer
{
    public static CodeAnalysisResult GetTestResult(CodeProblem problem, string code)
    {
        return problem switch
        {
            CodeProblem.JumpGame => new JumpGameAnalyzer().GetResult(code),
            CodeProblem.BallCountingEasy => new BallCountingAnalyzer(isEasyMode: true).GetResult(code),
            CodeProblem.BallCounting => new BallCountingAnalyzer(isEasyMode: false).GetResult(code),
            CodeProblem.NestingDepth => new NestingDepthAnalyzer().GetResult(code),
            CodeProblem.AverageBases => new AverageBasesAnalyzer().GetResult(code),
            _ => throw new InvalidOperationException()
        };
    }
}

public enum CodeProblem
{
    JumpGame,
    BallCountingEasy,
    BallCounting,
    NestingDepth,
    AverageBases,
    None
}