![Mauve Banner](/.resources/mauve-banner.png "Mauve Banner")

From basic extension methods to complete implementations of design patterns, Mauve offers a colorful suite of functionality for utilization in even the grandest applications.

<sub>***Note**: Our chosen shade of mauve has a hexadecimal color code of `0xe0b0ff`.*</sub>

## Features
The following features are available for use through Mauve:

|Feature|Description|
|-|-|
|Serialization|Mauve contains two extension methods for out of the box serialization support using `T.Serialize(SerializationMethod)` and `string.Deserialize(SerializationMethod)`. There is currently support for raw, binary, XML, JSON, and YAML serialization methods.|
|Rules|Creating rules for various behaviors (e.g. validation) can be done using concrete implementations (via `IRule<T>`) and on-the-fly definitions (via `IDynamicRuleBuilder<T>`). Additionally, rules can be added to a `Ruleset` for easy group creation and application.|
|Cryptography|Mauve aims to simplify cryptography implementations for consumers.|
|Validation|Validation should be simple, concise, and encapsulated.|

There are many more features available in the framework of course, but the above are easily the most popular. For more information, see the [wiki](https://github.com/tacosontitan/Mauve/wiki).

## Extension Methods
Mauve offers a variety of useful extension methods for the most common data types in the `C#` language:

 - `int`
 - `string`
 - `DateTime`
 - `Exception`
 - `IComparable`
 - `IEnumerable<T>`

 Additionally, there are a few extension methods using generics for type safety that apply to all types.

*See our [wiki](https://github.com/tacosontitan/Mauve/wiki/Mauve.Extensibility) for more details.*

## Design Patterns
Mauve offers comprehensive implementations of the following design patterns:

 - *Dependency Injection* using `IDependencyCollection` and `IInjector`.
 - *Chain of Responsibility* using `IMiddleware`.
 - *Mediator* using `IMediator`, `IRequest`, and `IHandler`.
 - *Factory* using `IFactory`.
 - *Builder* using `IBuilder<T>`.
 - *Interpreter* using `IInterpreter` and `IInterpretationContext`.
 - *Command* using `ICommand` and `IExecutable`.
 - *Memento* using `IRestorable`.
 - *Adapter* using `IAdapter<T1, T2>`.

## Release Notes
Here you can find the most recent release notes for each Mauve product.

### Framework
 - Current Version: 🐣 Pre-Release

### Extension
 - Visual Studio Community: 🐣 Pre-Release
 - Visual Studio Code: 🐣 Pre-Release