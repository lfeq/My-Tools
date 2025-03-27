## [1.3.2] - 26/03/2025

### Fixed a Bug that Prevented External and Plugins Folder from being Added to Source Control

- Fixed a bug where the `External` and `Plugins` folder would not be added to source control because of `gitignore`
  rules.

## [1.3.1] - 24/03/2025

### Fixed a Bug that Prevented Builds

- Move the code to Editor folder to prevent it from being included in the build and causing errors.

## [1.3.0] - 23/03/2025

### Added New Open Source Package and Extension Methods

- Added a new open source package to the project. This package is
  called [SceneReference](https://github.com/starikcetin/Eflatun.SceneReference). It allows you to reference scenes
  directly without using strings.
- Added new extension methods
  from [Adam Myhre Unity Utils](https://github.com/adammyhre/Unity-Utils/tree/master/UnityUtils/Scripts/Extensions), as
  there are some really useful ones. For example:

```csharp 
var myComponent = gameObject.GetOrAdd<MyComponent>();
```

## [1.2.0] - 19/03/2025

### Added Version Management

- Added new options to change the semantic version of the project
- Added a new option to increase the android bundle version code. Useful for Android builds

## [1.1.1] - 12-03-2025

### Fixed Folder Creation Bug

- Fixed a bug where the `External` and `Plugins` folder would not be created.

## [1.1.0] - 03-03-2025

### Initialize Repo

- New option creates `.gitignore` and runs `git init`

## [1.0.0] - 03-03-2025

### First release

- Allows the user to create a `_Project` folder, with the folders
  you would expect to use in a Unity project such as `Scripts`, `Materials`,
  `Scriptable Objects`, etc
- Downloads the open source packages I use the most, for example:
  [Better singletons](https://github.com/UnityCommunity/UnitySingleton.git)