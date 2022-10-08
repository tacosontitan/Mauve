The following `C#` snippet demonstrates all of our standardized styling rules.

### Using Directives
Always remove and sort using directives before saving. Visual Studio Community will ensure they look similar to the following snippet:


```csharp
using System;

using Mauve.Math;
```

### Namespaces
Only one namespace per file is permitted.

### Classes
All classes should be named using pascal case and start in an `internal sealed` state, at least mentally. Justification should be identified for adjusting the access level and allowing inheritance. In most cases, classes will be given a `public` access level and inheritance will be allowed, but we prefer that contributors determine if it makes more sense to seal a class or mark it as `internal`.

### Interfaces
All interfaces should be named with a capital `I` prefix, and the interface name in pascal case. Additionally, and similar to classes, interfaces should start in an `internal` state and justification should be identified for adjusting the access level.

### Structs
All structs should be named using pascal case and similar to classes and interfaces, structs should start in an `internal` state and justification should be identified for adjusting the access level.

### Directives
All `#` directives should include a line of whitespace before and after, for example with regions:

```csharp
...

#region Sample Region

private readonly string _sampleString;

#endregion

...
```

### Expression Bodied Methods
Expression bodied methods should be use wherever possible. However, the contents of the expression should go on a new line based on the following check list:

 - ❌ DO NOT move expressions to a new line in getters.
 - ❌ DO NOT move expressions to a new line in setters.
 - ✅ DO move expressions to a new line in constructors.
 - ✅ DO move expressions to a new line in methods.