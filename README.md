# Random Test Helper

[![Meta file check](https://github.com/nowsprinting/test-helper.random/actions/workflows/metacheck.yml/badge.svg)](https://github.com/nowsprinting/test-helper.random/actions/workflows/metacheck.yml)
[![Test](https://github.com/nowsprinting/test-helper.random/actions/workflows/test.yml/badge.svg)](https://github.com/nowsprinting/test-helper.random/actions/workflows/test.yml)
[![openupm](https://img.shields.io/npm/v/com.nowsprinting.test-helper.random?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.nowsprinting.test-helper.random/)

Wrapper and test stubs reference implementation for `UnityEngine.Random`.

Required Unity 2019 LTS or later.



## Features

### Wrapper class for UnityEngine.Random

`UnityEngine.Random` class provides static methods.
You can inject test stub in your tests by replacing it with a `RandomImpl` instance.



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

![](Documentation~/PackageManager_Dark.png/#gh-dark-mode-only)
![](Documentation~/PackageManager_Light.png/#gh-light-mode-only)


### Install via OpenUPM-CLI

If you installed [openupm-cli](https://github.com/openupm/openupm-cli), run the command below:

```bash
openupm add com.nowsprinting.test-helper.random
```


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

Add this repository as a submodule to the Packages/ directory in your project.

```bash
git submodule add https://github.com/nowsprinting/test-helper.random.git Packages/com.nowsprinting.test-helper.random
```

Generate a temporary project and run tests on each Unity version from the command line.

```bash
make create_project
UNITY_VERSION=2019.4.40f1 make -k test
```



## Release workflow

Run **Actions > Create release pull request > Run workflow** and merge created pull request.
(Or bump version in package.json on default branch)

Then, Will do the release process automatically by [Release](.github/workflows/release.yml) workflow.
And after tagging, OpenUPM retrieves the tag and updates it.

Do **NOT** manually operation the following operations:

- Create a release tag
- Publish draft releases
