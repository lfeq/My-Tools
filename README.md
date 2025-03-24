# My Tools

## Install and Usage

To install the package, open Package Manager in Unity and add using git link, and paste
`https://github.com/lfeq/My-Tools.git`.

After installation in the upper menu there should be a new context menu called `Tools`,
click it and there are the set-up processes I use the most when starting a new project.

## Included Behaviours

### Create project structure

This Custom Package lets me set up my new projects the way I like:

```
├── Assets
│   ├── _Project
│   │   ├── _Scripts
│   │   ├── Art
│   │   ├── Materials
│   │   ├── Scriptable Objects
│   │   ├── Prefabs
│   │   ├── Scenes
│   │   └── Settings
│   ├── External
│   └── Plugins
```

### Better Component Use

There is also a button to import the open source assets I use the
most [Scene Ref Attribute](https://github.com/KyleBanks/scene-ref-attribute),
this allows me to use ValidatedMonoBehaviour, this helps to prevent
using `GetComponent()` in start for every component, as it can get
expensive in large projects.

```csharp
// BEFORE

[SerializeField] private Player _player; 
[SerializeField] private Collider _collider;
[SerializeField] private Renderer _renderer;
[SerializeField] private Rigidbody _rigidbody;
[SerializeField] private ParticleSystem[] _particles;
[SerializeField] private Button _button;

private void Awake()
{
    this._player = Object.FindObjectByType<Player>();
    this._collider = this.GetComponent<Collider>();
    this._renderer = this.GetComponentInChildren<Renderer>();
    this._rigidbody = this.GetComponentInParent<Rigidbody>();
    this._particles = this.GetComponentsInChildren<ParticleSystem>();
}

// AFTER
[SerializeField, Scene] private Player _player; 
[SerializeField, Self] private Collider _collider;
[SerializeField, Child] private Renderer _renderer;
[SerializeField, Parent] private Rigidbody _rigidbody;
[SerializeField, Child] private ParticleSystem[] _particles;
[SerializeField, Anywhere] private Button _button;
```

### Better Singletons

The other open source package I like is [Unity Singleton](https://github.com/UnityCommunity/UnitySingleton).
This one just saves me time when declaring singletons, instead of
creating my own singletons all the time, I just use this package

```csharp
public class ExampleSingletonMonobehaviour : PersistentMonoSingleton<ExampleSingletonMonobehaviour> {
    void Start(){}
    void Update {}
```

### Scene Reference

This open source package is called [SceneReference](https://github.com/starikcetin/Eflatun.SceneReference), and it
allows you to reference scenes directly without using strings.

## Create Repository

You can create a GitHub repository with just one click, as this
button creates the `.gitignore` and runs `git init` command. I
just have to add it to a new repo.

## Change Semantic Versioning with One Click

I added a submenu to the `Tools` menu that lets me change the semantic versioning
of the project with just one click. This is useful when I want to change the version
of the project and I don't want to go to the project settings and change it manually.

## Useful Extension Methods

Extension methods
from [Adam Myhre Unity Utils](https://github.com/adammyhre/Unity-Utils/tree/master/UnityUtils/Scripts/Extensions), as
there are some really useful ones. For example:

```csharp 
var myComponent = gameObject.GetOrAdd<MyComponent>();
```