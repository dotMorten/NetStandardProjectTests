# .NET Standard Project Tests

This is a repo that demonstrates multi-targeting .NET projects, creates a set of platform-specific APIs on top (UI), then bring them back together into a .NET Standard compatible Xamarin.Forms project.

The solution allows you to write internal platform specific code, even expose platform-specific members to non-.NET Standard projects, and use platform-specific UI inside a .NET Standard Forms assembly.

All these things are accomplished using bait'n'switch, where the .NET Standard library is only used during compilation, but the application deployment instead deploys the platform specific DLLs.

### Project Architecture

#### Core assembly
`NetStandardTests`
     - .NET Standard 2.0 Reference assembly (this is an empty dummy assembly for compilation against - it's never used at runtime)
     - .NET Framework 4.6.1
     - Windows Universal (UWP) build 16299
     - Xamarin.iOS
     - Xamarin.Android
     
#### Platform specific assembly (relies on the Core assembly)
`NetStandardTests.UI.WPF`
     - Native WPF UI control library
`NetStandardTests.UI.UWP`
     - Native UWP UI control library
`NetStandardTests.UI.Android`
     - Native Android UI control library
`NetStandardTests.UI.iOS`
     - Native iOS UI control library

#### Xamarin.Forms .NET Assembly
`NetStandardTests.Forms`
     - Xamarin.Forms UI Control library, wrapping above native UI Controls as a cross-platform .NET Standard assembly


### Acknowledgements
None of this would be possible without [Oren Novotny's](https://twitter.com/onovotny) awesome blogposts and nuget packages. Useful articles:
 - https://oren.codes/2017/01/04/multi-targeting-the-world-a-single-project-to-rule-them-all/
 - https://oren.codes/2017/04/23/using-xamarin-forms-with-net-standard-vs-2017-edition/
 
