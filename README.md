# My Tools

## Create project structure

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

## Better Component Use

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

## Better Singletons

The other open source package I like is [Unity Singleton](https://github.com/UnityCommunity/UnitySingleton).
This one just saves me time when declaring singletons, instead of 
creating my own singletons all the time, I just use this package

```csharp
public class ExampleSingletonMonobehaviour : PersistentMonoSingleton<ExampleSingletonMonobehaviour> {
    void Start(){}
    void Update {}
```

## Create Repository

You can create a GitHub repository with just one click, as this 
button creates the `.gitignore` and runs `git init` command. I 
just have to add it to a new repo.