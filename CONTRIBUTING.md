# Contributing to Selkie.DefCon

First off, thank you for considering contributing to Selkie.DefCon! It's people like you that make Selkie.DefCon such a great tool.

## Code of Conduct

This project and everyone participating in it is governed by our [Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code.

## How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check the existing issues as you might find out that you don't need to create one. When you are creating a bug report, please include as many details as possible:

* **Use a clear and descriptive title** for the issue to identify the problem.
* **Describe the exact steps which reproduce the problem** in as many details as possible.
* **Provide specific examples to demonstrate the steps**.
* **Describe the behavior you observed after following the steps** and point out what exactly is the problem with that behavior.
* **Explain which behavior you expected to see instead and why.**
* **Include code samples and stack traces** if applicable.

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, please include:

* **Use a clear and descriptive title** for the issue to identify the suggestion.
* **Provide a step-by-step description of the suggested enhancement** in as many details as possible.
* **Provide specific examples to demonstrate the steps** or provide code samples.
* **Describe the current behavior** and **explain which behavior you expected to see instead** and why.
* **Explain why this enhancement would be useful** to most Selkie.DefCon users.

### Pull Requests

* Fill in the pull request template
* Follow the C# coding style used throughout the project
* Include thoughtfully-worded, well-structured tests
* Document new code based on the existing documentation style
* End all files with a newline
* Ensure all tests pass before submitting

## Development Process

1. **Fork the repository** and create your branch from `main`.

2. **Clone your fork** locally:
   ```bash
   git clone https://github.com/YOUR_USERNAME/Selkie.DefCon.git
   cd Selkie.DefCon
   ```

3. **Create a branch** for your changes:
   ```bash
   git checkout -b feature/my-new-feature
   ```

4. **Make your changes** and commit them:
   ```bash
   git add .
   git commit -m "Add some feature"
   ```

5. **Run the tests** to ensure everything works:
   ```bash
   cd src
   dotnet test
   ```

6. **Push to your fork**:
   ```bash
   git push origin feature/my-new-feature
   ```

7. **Submit a pull request** through the GitHub website.

## Coding Standards

* Follow the existing code style and conventions
* Use meaningful variable and method names
* Write clear comments for complex logic
* Keep methods focused and concise
* Write unit tests for new functionality
* Ensure code is properly formatted

### C# Style Guidelines

* Use 4 spaces for indentation (not tabs)
* Use PascalCase for class names and method names
* Use camelCase for local variables and parameters
* Use meaningful names that convey intent
* Add XML documentation comments for public APIs
* Follow the existing patterns in the codebase

## Testing

* Write tests for all new functionality
* Ensure all existing tests pass
* Aim for high code coverage
* Use descriptive test names that explain what is being tested
* Follow the AAA pattern (Arrange, Act, Assert)

## Commit Messages

* Use the present tense ("Add feature" not "Added feature")
* Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
* Limit the first line to 72 characters or less
* Reference issues and pull requests liberally after the first line

## Additional Notes

### Issue and Pull Request Labels

This project uses labels for both issue tracking and automated release management.

#### Issue Labels

* `bug` - Something isn't working
* `enhancement` - New feature or request
* `documentation` - Improvements or additions to documentation
* `good first issue` - Good for newcomers
* `help wanted` - Extra attention is needed

#### Pull Request Labels for Release Management

When creating a pull request, add appropriate labels to control versioning and changelog generation:

**Version Control Labels** (add one):
* `major` - Breaking changes or significant releases (bumps major version)
* `minor` - New features and enhancements (bumps minor version)
* `patch` - Bug fixes and small updates (bumps patch version, default if no label)

**Category Labels** (add one or more):
* `feature` or `enhancement` - New features
* `fix`, `bugfix`, or `bug` - Bug fixes
* `chore` or `maintenance` - Maintenance work
* `documentation` or `docs` - Documentation updates
* `security` - Security-related changes

These labels help automatically generate release notes and determine the next version number. See [VERSION_MANAGEMENT.md](VERSION_MANAGEMENT.md) for more details.

## Questions?

Feel free to open an issue with your question, or reach out to the maintainers directly.

Thank you for contributing to Selkie.DefCon! 🎉
