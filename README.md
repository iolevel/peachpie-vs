# PeachPie extension for Visual Studio

This extension adds support for PHP projects running compiled on .NET/.NET Core using [PeachPie compiler](https://www.peachpie.io). The extension is designed to simplify working with PeachPie compiler in Microsoft's Visual Studio IDE.

[PeachPie](https://www.peachpie.io) is a PHP compiler and runtime on top of .NET & .NET Core. 

>Note: this extension is a Preview, as PeachPie is still a work in progress. Please refer to our [roadmap](https://docs.peachpie.io/roadmap) for the current status of development.

## Project Templates

Easily create a new **PHP (PeachPie)** project with just a few clicks and get started with PeachPie:

![New Project](https://raw.githubusercontent.com/iolevel/peachpie-vs/master/imgs/new-project.png?raw=true "New PeachPie Project Templates")

## Full .NET Dependencies

Integrate your PHP (PeachPie) app as a reference within your other .NET projects:

![Dependencies](https://github.com/iolevel/peachpie-vs/blob/master/imgs/project-nuget-manager.gif?raw=true "NuGet Packages, Project References")

## Make use of Diagnostic Tools

Profile your PHP code for performance bottlenecks, memory leaks or CPU usage:

![Diagnostic Tools](https://github.com/iolevel/peachpie-vs/blob/master/imgs/diagnostic-tools-cpu.gif?raw=true "Diagnostic Tools")

## What this allows you to do

PeachPie compiles PHP code to .NET/.NET Core and replaces its runtime with the modern, secure and performant .NET environment. As a result, you can use this extension to treat PHP projects as if they were written in .NET and interoperate seamlessly with your applications written, for example, in C#:

* __Compile PHP__: compile PHP code into a standard .NET assembly file
* __Manage Dependencies__: reference NuGet packages, other .NET projects or provide your PHP library as a package itself
* __Interoperate Between PHP and .NET__: seamlessly connect PHP and .NET code within a single solution
* __Sourceless Distribution__: distribute compiled PHP applications without their source code
* __Build and Debug__: treat PHP code with .NET's tools and the .NET debugger
* __Profiling and Diagnostics__: take advantage of running PHP compiled to .NET with Visual Studio's powerful performance and memory profiling tools

> Note: this extension is only designed for PHP projects running on .NET via PeachPie compiler.
