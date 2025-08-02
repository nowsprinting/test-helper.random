# Random Test Helper

[![Meta file check](https://github.com/nowsprinting/test-helper.random/actions/workflows/metacheck.yml/badge.svg)](https://github.com/nowsprinting/test-helper.random/actions/workflows/metacheck.yml)
[![Test](https://github.com/nowsprinting/test-helper.random/actions/workflows/test.yml/badge.svg)](https://github.com/nowsprinting/test-helper.random/actions/workflows/test.yml)
[![openupm](https://img.shields.io/npm/v/com.nowsprinting.test-helper.random?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.nowsprinting.test-helper.random/)
[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/nowsprinting/test-helper.random)

Library for mocking the [UnityEngine.Random](https://docs.unity3d.com/ScriptReference/Random.html).  
Required Unity 2019 LTS or later.



## Features

### Mocking `UnityEngine.Random`

The `UnityEngine.Random` class provides static methods.
You can inject test stubs into your tests by replacing `Random` with the `IRandom` interface.

Usage:

#### 1. Insert the code below into your product code to replace `UnityEngine.Random` with a `TestHelper.Random.RandomWrapper` instance

```csharp
#if UNITY_INCLUDE_TESTS
    internal IRandom Random { private get; set; } = new RandomWrapper();
#endif
```

> [!TIP]  
> `RandomWrapper` is a wrapper around `System.Random` that works at runtime, but you can remove the `TestHelper.Random` assembly from your build using the `#if UNITY_INCLUDE_TESTS` directive.

#### 2. Create test stub in your test

```csharp
public class StubRandom : RandomWrapper
{
    private readonly float[] _returnValues;
    private int _returnValueIndex;

    public StubRandom(params float[] returnValues)
    {
        Assert.That(returnValues, Is.Not.Empty);
        _returnValues = returnValues;
        _returnValueIndex = 0;
    }

    public override float value
    {
        get
        {
            return _returnValues[_returnValueIndex++];
        }
    }
}
```

#### 3. Write test using test stub

```csharp
[Test]
public void Value_ReturnSpecifiedValues()
{
    IRandom sut = new StubRandom(0.2f, 0.3f, 0.5f);

    Assert.That(sut.value, Is.EqualTo(0.2f), "1st value");
    Assert.That(sut.value, Is.EqualTo(0.3f), "2nd value");
    Assert.That(sut.value, Is.EqualTo(0.5f), "3rd value");
}
```


### Extensions useful for testing

`RandomExtensions` provides extension methods useful for testing.



## Installation

You can choose from two typical installation methods.

### Install via Package Manager window

1. Open the **Package Manager** tab in Project Settings window (**Editor > Project Settings**)
2. Click **+** button under the **Scoped Registries** and enter the following settings (figure 1.):
    1. **Name:** `package.openupm.com`
    2. **URL:** `https://package.openupm.com`
    3. **Scope(s):** `com.nowsprinting`
3. Open the Package Manager window (**Window > Package Manager**) and select **My Registries** in registries drop-down list (figure 2.)
4. Click **Install** button on the `com.nowsprinting.test-helper.random` package

**Figure 1.** Package Manager tab in Project Settings window.

![](Documentation~/ProjectSettings_Dark.png#gh-dark-mode-only)
![](Documentation~/ProjectSettings_Light.png#gh-light-mode-only)

**Figure 2.** Select registries drop-down list in Package Manager window.

![](Documentation~/PackageManager_Dark.png#gh-dark-mode-only)
![](Documentation~/PackageManager_Light.png#gh-light-mode-only)


### Add assembly reference

1. Open your product and test assembly definition file (.asmdef) in **Inspector** window
2. Add **TestHelper.Random** into **Assembly Definition References**



## License

MIT License



## How to contribute

Open an issue or create a pull request.

Be grateful if you could label the PR as `enhancement`, `bug`, `chore`, and `documentation`.
See [PR Labeler settings](.github/pr-labeler.yml) for automatically labeling from the branch name.



## How to development

### Clone repo as a embedded package

Add this repository as a submodule to the Packages/ directory in your project.

```bash
git submodule add git@github.com:nowsprinting/test-helper.random.git Packages/com.nowsprinting.test-helper.random
```

> [!WARNING]  
> Required installation packages for running tests (when embedded package or adding to the `testables` in manifest.json), as follows:
> - [Test Helper](https://github.com/nowsprinting/test-helper) package v1.2.1 or later


### Run tests

Generate a temporary project and run tests on each Unity version from the command line.

```bash
make create_project
UNITY_VERSION=2019.4.40f1 make -k test
```


### Release workflow

The release process is as follows:

1. Run **Actions > Create release pull request > Run workflow**
2. Merge created pull request

Then, will do the release process automatically by [Release](.github/workflows/release.yml) workflow.
After tagging, [OpenUPM](https://openupm.com/) retrieves the tag and updates it.

> [!CAUTION]  
> Do **NOT** manually operation the following operations:
> - Create a release tag
> - Publish draft releases

> [!CAUTION]  
> You must modify the package name to publish a forked package.

> [!TIP]  
> If you want to specify the version number to be released, change the version number of the draft release before running the "Create release pull request" workflow.
