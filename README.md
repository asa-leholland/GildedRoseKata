# Gilded Rose Kata with C# Core

_What's this kata thing?_ Code katas are concise exercises that focus on principles of design patterns and refactoring in software engineering. They serve as hands-on training grounds where developers practice applying these principles to real-world scenarios. By working on katas, software engineers learn how to recognize and implement design patterns effectively and refine their refactoring skills.

_Why the Gilded Rose?_ This repo is branched off a template created from Emily Bache's [GildedRose-Refactoring-Kata](https://github.com/emilybache/GildedRose-Refactoring-Kata) repository, which in turn is derivative of Terry Hughes [original work](https://github.com/NotMyself/GildedRose). You can also read [Bobby Johnson's description of the origin of the kata](https://iamnotmyself.com/refactor-this-the-gilded-rose-kata/). I picked this kata to try specifically because a\) I had seen it repeatedly referenced across the internet and b\) as a kid I used to play World of Warcraft, from which the 'requirements' have been derived. Who knows, its possible that my long-abandoned WoW character could be in the trade district of Stormwind, drinking a pint at the Gilded Rose Inn as you read this very sentence...

_Why C# Core?_ I'd never used C# before this Kata, and wanted to learn after I read Bobby Johnson's article ["Why Most Solutions to Gilded Rose Miss The Bigger Picture"](https://iamnotmyself.com/why-most-solutions-to-gilded-rose-miss-the-bigger-picture/), which suggests better practice at handling a legacy code situation if the Kata is performed in the original C#. After some desk research, it seemed to me at the time that most C# applications were done in tandem with the .NET core framework - not written using C# in isolation, so I chose to use C# within the .NET framework (aka C# Core).

On that note, here are the [Gilded Rose Kata Requirements](GildedRoseRequirements.md).

## Changes from Emily Bache's Refactoring Kata

The following changes were made before starting:

- all non-English requirements.txt files were removed because sadly I am only fluent in English
- all non-C# Core projects (including standard C# and 'C# Verify') were removed
- the N-Unit style [Fact] based Approval Tests file was removed, while the X-Unit style tests were kept - this was because I am more familiar with X-Unit style test suites like Pytest for Python and Jest for Typescript, and based on my limited desk research it appears that N-unit style frameworks are less common and less in style. Also, since both the N-Unit and X-Unit test suites in Emaily Bache's repostiory were failing (IE, this follows Michael Feathers definition of a 'legacy system' - one with no passing tests), the kata is starting from square zero.
- the GildedRoseRequirements.txt file was converted to Markdown, because I prefer reading text files in Markdown using VS Code's live preview functionalities

## Setting up the Kata

I ran the Kata inside Visual Studio Code (my preferred IDE) on a Windows 11 PC. At first I thought I needed to use Visual Studio and struggled to configure equivalent of the Conventional Commits extension there before just trying the .NET build on VSCode - lo and behold, works just fine. The following steps were taken to get things up and running:

- Install the .NET SDK (<https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.401-windows-x64-installer?journey=vs-code>)
- Add the .NET SDK installation directory to Path (on Windows)
- Install the .Net Framework (<https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net481-web-installer>)
- run `cd csharpcore`
- run `dotnet build` to check the build and ensure eveything runs correctly
- run `dotnet test` to run the unit test suite

These last three commands have been abstracted into a bash script, which can be executed from the root with `bash main.sh`.

You can also run just the unit tests or just the acceptance tests using `bash unit.sh` or `bash acceptance.py` respectively.

## CodeSense Score Report

The following scores are intended to be used to document the code health before and after the refactoring kata was performed:

| Metric                    | Details                      | Before | After      |
| ------------------------- | ---------------------------- | ------ | ---------- |
| Overall Code Health Score | ---                          | 8.35   | 10         |
| Bumpy Road Ahead*         | Bump Count                   | 5      | not listed |
| Deep, Nested Complexity*  | Nesting Depth (conditionals) | 6      | not listed |
| Complex Method*           | Code Complexity              | 19     | not listed |
| Large Method*             | LoC                          | 71     | not listed |

*Note: these indicate the highest score warning (least desirable) on any method in the system under test. Ideally the metric is not listed.

To read more about CodeSense, check out :

