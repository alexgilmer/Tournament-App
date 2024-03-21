using Flex_Day_Challenge_Tester_2;
using Flex_Day_Challenge_Tester_2.Testers;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis.Analyzers;

public abstract class GameAnalyzer<TInput, TOutput, TGlobal>
{
    public abstract TInput ScriptPrimer { get; }
    public abstract string FlagCode { get; }
    public abstract Tester<TInput, TOutput> Tester { get; }
    public abstract string ExtraCode { get; }
    public abstract TGlobal GetCodeInput(TInput input);
    public CodeAnalysisResult GetResult(string code)
    {
        var script = GetScript(code + ExtraCode);

        try
        {
            _ = RunScript(script, GetCodeInput(ScriptPrimer));
        }
        catch (CompilationErrorException e)
        {
            return new CodeAnalysisResult()
            {
                Passed = false,
                Message = "Compilation error: " + e.Message
            };
        }
        catch (Exception e)
        {
            return new CodeAnalysisResult()
            {
                Passed = false,
                Message = "Runtime error: " + e.Message
            };
        }

        CodeAnalysisResult result = RunTests(script);
        if (result.Passed)
        {
            result.Message = $"Congratulations!  You passed!  Here's your code: {FlagCode}";
        }

        return result;
    }


    private CodeAnalysisResult RunTests(Script<TOutput> script)
    {
        var studentData = Tester.GetTests();
        var solutionData = Tester.GetTests();

        for (int i = 0; i < studentData.Count; i++)
        {
            CodeAnalysisResult r = RunSingleTest(script, studentData[i], solutionData[i]);

            if (r.Failed)
            {
                return r;
            }
        }

        return new CodeAnalysisResult()
        {
            Passed = true
        };
    }

    private CodeAnalysisResult RunSingleTest(Script<TOutput> script, TInput studentTestData, TInput solutionTestData)
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        TOutput solution = Tester.SolutionFunction(solutionTestData);
        stopwatch.Stop();
        long systemSolutionTimeMilliseconds = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();

        Task<CodeAnalysisResult> studentTask = Task.Run(() =>
        {
            try
            {
                stopwatch.Start();
                TOutput studentResult = RunScript(script, GetCodeInput(studentTestData));
                stopwatch.Stop();

                bool pass = Tester.SolutionsMatch(studentResult, solution);
                return new CodeAnalysisResult()
                {
                    Passed = pass,
                    Input = Tester.GetInputString(solutionTestData),
                    ExpectedOutput = Tester.GetOutputString(solution),
                    ActualOutput = Tester.GetOutputString(studentResult),
                    StudentSolutionComputationTime = stopwatch.ElapsedMilliseconds,
                    SystemSolutionComputationTime = systemSolutionTimeMilliseconds,
                    Message = pass ? "Success!" : "Test failed"
                };
            }
            catch (Exception e)
            {
                stopwatch.Stop();
                return new CodeAnalysisResult()
                {
                    Passed = false,
                    Input = Tester.GetInputString(solutionTestData),
                    ExpectedOutput = Tester.GetOutputString(solution),
                    ActualOutput = "Run time error: " + e.Message,
                    SystemSolutionComputationTime = systemSolutionTimeMilliseconds,
                    StudentSolutionComputationTime = stopwatch.ElapsedMilliseconds,
                    Message = "Runtime error: " + e.Message
                };
            }
        });
        Task<CodeAnalysisResult> timerTask = Task.Run(() =>
        {
            Thread.Sleep(Tester.TimeLimitMilliseconds);
            return new CodeAnalysisResult()
            {
                Passed = false,
                Input = Tester.GetInputString(solutionTestData),
                ExpectedOutput = Tester.GetOutputString(solution),
                ActualOutput = "Time Limit Exceeded",
                SystemSolutionComputationTime = systemSolutionTimeMilliseconds,
                StudentSolutionComputationTime = Tester.TimeLimitMilliseconds,
                Message = "Time Limit Exceeded"
            };
        });

        int result = Task.WaitAny(studentTask, timerTask);
        return result switch
        {
            0 => studentTask.Result,
            1 => timerTask.Result,
            _ => throw new Exception("Task.WaitAny returned an unexpected value")
        };
    }


    public static Script<TOutput> GetScript(string code)
    {
        return CSharpScript.Create<TOutput>(
            code,
            globalsType: typeof(TGlobal),
            options: ScriptOptions.Default
                .AddImports(
                    "System.Numerics",
                    "System.Text",
                    "System.Collections.Generic"
                ).AddReferences(
                    "System",
                    "System.Numerics",
                    "System.Text",
                    "System.Collections.Generic")
            );
    }

    public static TOutput RunScript(Script<TOutput> script, TGlobal inputObject)
    {
        ArgumentNullException.ThrowIfNull(script);
        ArgumentNullException.ThrowIfNull(inputObject);

        var scriptResult = script.RunAsync(globals: inputObject).Result;
        TOutput output = scriptResult.ReturnValue;

        return output;
    }

}

public abstract class GameAnalyzer<TInput1, TInput2, TOutput, TGlobal>
{
    public abstract Tuple<TInput1, TInput2> ScriptPrimer { get; }
    public abstract string FlagCode { get; }
    public abstract Tester<TInput1, TInput2, TOutput> Tester { get; }
    public abstract string ExtraCode { get; }
    public abstract TGlobal GetCodeInput(TInput1 input1, TInput2 input2);
    public CodeAnalysisResult GetResult(string code)
    {
        var script = GetScript(code + ExtraCode);

        try
        {
            _ = RunScript(script, GetCodeInput(ScriptPrimer.Item1, ScriptPrimer.Item2));
        }
        catch (CompilationErrorException e)
        {
            return new CodeAnalysisResult()
            {
                Passed = false,
                Message = "Compilation error: " + e.Message
            };
        }
        catch (Exception e)
        {
            return new CodeAnalysisResult()
            {
                Passed = false,
                Message = "Runtime error: " + e.Message
            };
        }

        CodeAnalysisResult result = RunTests(script);
        if (result.Passed)
        {
            result.Message = $"Congratulations!  You passed!  Here's your code: {FlagCode}";
        }

        return result;
    }


    private CodeAnalysisResult RunTests(Script<TOutput> script)
    {
        var studentData = Tester.GetTests();
        var solutionData = Tester.GetTests();

        for (int i = 0; i < studentData.Count; i++)
        {
            CodeAnalysisResult r = RunSingleTest(script, studentData[i], solutionData[i]);

            if (r.Failed)
            {
                return r;
            }
        }

        return new CodeAnalysisResult()
        {
            Passed = true
        };
    }

    private CodeAnalysisResult RunSingleTest(Script<TOutput> script, Tuple<TInput1, TInput2> studentTestData, Tuple<TInput1, TInput2> solutionTestData)
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        TOutput solution = Tester.SolutionFunction(solutionTestData.Item1, solutionTestData.Item2);
        stopwatch.Stop();
        long systemSolutionTimeMilliseconds = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();

        Task<CodeAnalysisResult> studentTask = Task.Run(() =>
        {
            try
            {
                stopwatch.Start();
                TOutput studentResult = RunScript(script, GetCodeInput(studentTestData.Item1, studentTestData.Item2));
                stopwatch.Stop();

                bool pass = Tester.SolutionsMatch(studentResult, solution);
                return new CodeAnalysisResult()
                {
                    Passed = pass,
                    Input = Tester.GetInputString(solutionTestData),
                    ExpectedOutput = Tester.GetOutputString(solution),
                    ActualOutput = Tester.GetOutputString(studentResult),
                    StudentSolutionComputationTime = stopwatch.ElapsedMilliseconds,
                    SystemSolutionComputationTime = systemSolutionTimeMilliseconds,
                    Message = pass ? "Success!" : "Test failed"
                };
            }
            catch (Exception e)
            {
                stopwatch.Stop();
                return new CodeAnalysisResult()
                {
                    Passed = false,
                    Input = Tester.GetInputString(solutionTestData),
                    ExpectedOutput = Tester.GetOutputString(solution),
                    ActualOutput = "Run time error: " + e.Message,
                    SystemSolutionComputationTime = systemSolutionTimeMilliseconds,
                    StudentSolutionComputationTime = stopwatch.ElapsedMilliseconds,
                    Message = "Runtime error: " + e.Message
                };
            }
        });
        Task<CodeAnalysisResult> timerTask = Task.Run(() =>
        {
            Thread.Sleep(Tester.TimeLimitMilliseconds);
            return new CodeAnalysisResult()
            {
                Passed = false,
                Input = Tester.GetInputString(solutionTestData),
                ExpectedOutput = Tester.GetOutputString(solution),
                ActualOutput = "Time Limit Exceeded",
                SystemSolutionComputationTime = systemSolutionTimeMilliseconds,
                StudentSolutionComputationTime = Tester.TimeLimitMilliseconds,
                Message = "Time Limit Exceeded"
            };
        });

        int result = Task.WaitAny(studentTask, timerTask);
        return result switch
        {
            0 => studentTask.Result,
            1 => timerTask.Result,
            _ => throw new Exception("Task.WaitAny returned an unexpected value")
        };
    }


    public static Script<TOutput> GetScript(string code)
    {
        return CSharpScript.Create<TOutput>(
            code,
            globalsType: typeof(TGlobal),
            options: ScriptOptions.Default
                .AddImports(
                    "System.Numerics",
                    "System.Text",
                    "System.Collections.Generic"
                ).AddReferences(
                    "System",
                    "System.Numerics",
                    "System.Text",
                    "System.Collections.Generic")
            );
    }

    public static TOutput RunScript(Script<TOutput> script, TGlobal inputObject)
    {
        ArgumentNullException.ThrowIfNull(script);
        ArgumentNullException.ThrowIfNull(inputObject);

        var scriptResult = script.RunAsync(globals: inputObject).Result;
        TOutput output = scriptResult.ReturnValue;

        return output;
    }

}
