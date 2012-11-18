@set builddir=.\IntegralApproximation\bin\Release

"%PROGRAMFILES(X86)%\Microsoft\ILMerge\ILMerge.exe" ^
/target:winexe /out:"Integral Approximator.exe" ^
%builddir%\IntegralApproximator.exe %builddir%\YAMP.dll %builddir%\ZedGraph.dll
