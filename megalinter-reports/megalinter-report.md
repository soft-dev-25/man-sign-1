## ✅⚠️[MegaLinter](https://megalinter.io/9.0.1) analysis: Success with warnings



| Descriptor  |                                               Linter                                                |Files|Fixed|Errors|Warnings|Elapsed time|
|-------------|-----------------------------------------------------------------------------------------------------|----:|----:|-----:|-------:|-----------:|
|✅ CSHARP    |[csharpier](https://megalinter.io/9.0.1/descriptors/csharp_csharpier)                                |   16|   13|     0|       0|       2.72s|
|⚠️ CSHARP    |[dotnet-format](https://megalinter.io/9.0.1/descriptors/csharp_dotnet_format)                        |  yes|  yes|     1|      no|       0.62s|
|⚠️ CSHARP    |[roslynator](https://megalinter.io/9.0.1/descriptors/csharp_roslynator)                              |    1|    1|     1|       0|      12.64s|
|✅ DOCKERFILE|[hadolint](https://megalinter.io/9.0.1/descriptors/dockerfile_hadolint)                              |    1|     |     0|       0|       0.27s|
|✅ JSON      |[prettier](https://megalinter.io/9.0.1/descriptors/json_prettier)                                    |    2|    2|     0|       0|        0.7s|
|✅ JSON      |[v8r](https://megalinter.io/9.0.1/descriptors/json_v8r)                                              |    2|     |     0|       0|       3.52s|
|✅ MARKDOWN  |[markdownlint](https://megalinter.io/9.0.1/descriptors/markdown_markdownlint)                        |    1|    0|     0|       0|       0.57s|
|✅ MARKDOWN  |[markdown-table-formatter](https://megalinter.io/9.0.1/descriptors/markdown_markdown_table_formatter)|    1|    0|     0|       0|       0.27s|
|✅ REPOSITORY|[gitleaks](https://megalinter.io/9.0.1/descriptors/repository_gitleaks)                              |  yes|     |    no|      no|       0.07s|
|✅ REPOSITORY|[git_diff](https://megalinter.io/9.0.1/descriptors/repository_git_diff)                              |  yes|     |    no|      no|        0.0s|
|✅ REPOSITORY|[grype](https://megalinter.io/9.0.1/descriptors/repository_grype)                                    |  yes|     |    no|      no|      27.94s|
|✅ REPOSITORY|[secretlint](https://megalinter.io/9.0.1/descriptors/repository_secretlint)                          |  yes|     |    no|      no|       0.48s|
|✅ REPOSITORY|[syft](https://megalinter.io/9.0.1/descriptors/repository_syft)                                      |  yes|     |    no|      no|       1.02s|
|✅ REPOSITORY|[trivy-sbom](https://megalinter.io/9.0.1/descriptors/repository_trivy_sbom)                          |  yes|     |    no|      no|        0.1s|
|✅ REPOSITORY|[trufflehog](https://megalinter.io/9.0.1/descriptors/repository_trufflehog)                          |  yes|     |    no|      no|        2.2s|
|✅ YAML      |[prettier](https://megalinter.io/9.0.1/descriptors/yaml_prettier)                                    |    1|    0|     0|       0|       0.37s|
|✅ YAML      |[v8r](https://megalinter.io/9.0.1/descriptors/yaml_v8r)                                              |    1|     |     0|       0|       4.98s|

## Detailed Issues

<details>
<summary>⚠️ CSHARP / dotnet-format - 1 error</summary>

```
Welcome to .NET 9.0!
---------------------
SDK Version: 9.0.110

----------------
Installed an ASP.NET Core HTTPS development certificate.
To trust the certificate, run 'dotnet dev-certs https --trust'
Learn about HTTPS: https://aka.ms/dotnet-https

----------------
Write your first app: https://aka.ms/dotnet-hello-world
Find out what's new: https://aka.ms/dotnet-whats-new
Explore documentation: https://aka.ms/dotnet-docs
Report issues and find source on GitHub: https://github.com/dotnet/core
Use 'dotnet --help' to see available commands or visit: https://aka.ms/dotnet-cli
--------------------------------------------------------------------------------------
Unhandled exception: System.IO.FileNotFoundException: Could not find a MSBuild project file or solution file in ''. Specify which to use with the <workspace> argument.
   at Microsoft.CodeAnalysis.Tools.Workspaces.MSBuildWorkspaceFinder.FindWorkspace(String searchDirectory, String workspacePath)
   at Microsoft.CodeAnalysis.Tools.Workspaces.MSBuildWorkspaceFinder.FindWorkspace(String searchDirectory, String workspacePath)
   at Microsoft.CodeAnalysis.Tools.FormatCommandCommon.ParseWorkspaceOptions(ParseResult parseResult, FormatOptions formatOptions)
   at Microsoft.CodeAnalysis.Tools.Commands.RootFormatCommand.FormatCommandDefaultHandler.InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken)
   at System.CommandLine.Invocation.InvocationPipeline.InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken)
```

</details>

<details>
<summary>⚠️ CSHARP / roslynator - 1 error</summary>

```
Results of roslynator linter (version 0.10.2.0)
See documentation on https://megalinter.io/9.0.1/descriptors/csharp_roslynator/
-----------------------------------------------

❌ [ERROR] backend/api/api.csproj - FIXED
    Loading project 'backend/api/api.csproj'...
    Analyze 'api'
    System.AggregateException: One or more errors occurred. (Could not load file or assembly 'System.Composition.AttributedModel, Version=9.0.0.8, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'. The system cannot find the file specified.
    )
     ---> System.IO.FileNotFoundException: Could not load file or assembly 'System.Composition.AttributedModel, Version=9.0.0.8, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'. The system cannot find the file specified.
    
    File name: 'System.Composition.AttributedModel, Version=9.0.0.8, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
       at System.ModuleHandle.ResolveType(QCallModule module, Int32 typeToken, IntPtr* typeInstArgs, Int32 typeInstCount, IntPtr* methodInstArgs, Int32 methodInstCount, ObjectHandleOnStack type)
       at System.ModuleHandle.ResolveTypeHandle(Int32 typeToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
       at System.Reflection.RuntimeModule.ResolveType(Int32 metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
       at System.Reflection.CustomAttribute.FilterCustomAttributeRecord(MetadataToken caCtorToken, MetadataImport& scope, RuntimeModule decoratedModule, MetadataToken decoratedToken, RuntimeType attributeFilterType, Boolean mustBeInheritable, ListBuilder`1& derivedAttributes, RuntimeType& attributeType, IRuntimeMethodInfo& ctorWithParameters, Boolean& isVarArg)
       at System.Reflection.CustomAttribute.AddCustomAttributes(ListBuilder`1& attributes, RuntimeModule decoratedModule, Int32 decoratedMetadataToken, RuntimeType attributeFilterType, Boolean mustBeInheritable, ListBuilder`1 derivedAttributes)
       at System.Reflection.CustomAttribute.GetCustomAttributes(RuntimeModule decoratedModule, Int32 decoratedMetadataToken, Int32 pcaCount, RuntimeType attributeFilterType)
       at System.Reflection.CustomAttribute.GetCustomAttributes(RuntimeType type, RuntimeType caType, Boolean inherit)
       at System.Attribute.GetCustomAttributes(MemberInfo element, Type attributeType, Boolean inherit)
       at Roslynator.AnalyzerAssembly.Load(Assembly analyzerAssembly, Boolean loadAnalyzers, Boolean loadFixers, String language) in /_/src/Workspaces.Core/AnalyzerAssembly.cs:line 129
       at Roslynator.AnalyzerLoader.GetAnalyzersAndFixers(Project project, Boolean loadFixers) in /_/src/Workspaces.Core/AnalyzerLoader.cs:line 112
       at Roslynator.AnalyzerLoader.GetAnalyzersAndFixers(Project project) in /_/src/Workspaces.Core/AnalyzerLoader.cs:line 62
       at Roslynator.CodeFixes.CodeFixer.FixProjectAsync(Project project, CancellationToken cancellationToken) in /_/src/Workspaces.Core/CodeFixes/CodeFixer.cs:line 99
       at Roslynator.CommandLine.FixCommand.FixAsync(ProjectOrSolution projectOrSolution, IEnumerable`1 analyzerAssemblies, CodeFixerOptions codeFixerOptions, IFormatProvider formatProvider, CancellationToken cancellationToken) in /_/src/CommandLine/Commands/FixCommand.cs:line 110
       at Roslynator.CommandLine.FixCommand.ExecuteAsync(ProjectOrSolution projectOrSolution, CancellationToken cancellationToken) in /_/src/CommandLine/Commands/FixCommand.cs:line 70
       at Roslynator.CommandLine.MSBuildWorkspaceCommand`1.ExecuteAsync(String path, MSBuildWorkspace workspace, CancellationToken cancellationToken) in /_/src/CommandLine/Commands/MSBuildWorkspaceCommand.cs:line 164
       at Roslynator.CommandLine.MSBuildWorkspaceCommand`1.ExecuteAsync(IEnumerable`1 paths, String msbuildPath, IEnumerable`1 properties) in /_/src/CommandLine/Commands/MSBuildWorkspaceCommand.cs:line 89
       at Roslynator.CommandLine.Program.FixAsync(FixCommandLineOptions options) in /_/src/CommandLine/Program.cs:line 325
       --- End of inner exception stack trace ---
       at System.Threading.Tasks.Task`1.GetResultCore(Boolean waitCompletionNotification)
       at Roslynator.CommandLine.Program.<>c.<Main>b__0_3(MSBuildCommandLineOptions options) in /_/src/CommandLine/Program.cs:line 177
       at CommandLine.ParserResultExtensions.MapResult[T1,T2,TResult](ParserResult`1 result, Func`2 parsedFunc1, Func`2 parsedFunc2, Func`2 notParsedFunc)
       at Roslynator.CommandLine.Program.Main(String[] args) in /_/src/CommandLine/Program.cs:line 169
```

</details>

See detailed reports in MegaLinter artifacts
_Set `VALIDATE_ALL_CODEBASE: true` in mega-linter.yml to validate all sources, not only the diff_

[![MegaLinter is graciously provided by OX Security](https://raw.githubusercontent.com/oxsecurity/megalinter/main/docs/assets/images/ox-banner.png)](https://www.ox.security/?ref=megalinter)