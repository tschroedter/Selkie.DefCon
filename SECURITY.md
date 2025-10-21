# Security Policy

## Supported Versions

We release patches for security vulnerabilities. Currently supported versions:

| Version | Supported          |
| ------- | ------------------ |
| 1.0.x   | :white_check_mark: |

## Reporting a Vulnerability

The Selkie.DefCon team takes security bugs seriously. We appreciate your efforts to responsibly disclose your findings, and will make every effort to acknowledge your contributions.

To report a security issue, please use the GitHub Security Advisory ["Report a Vulnerability"](https://github.com/tschroedter/Selkie.DefCon/security/advisories/new) tab.

The team will send a response indicating the next steps in handling your report. After the initial reply to your report, the security team will keep you informed of the progress towards a fix and full announcement, and may ask for additional information or guidance.

### What to Include in Your Report

Please include the following information in your report:

* Type of issue (e.g. buffer overflow, SQL injection, cross-site scripting, etc.)
* Full paths of source file(s) related to the manifestation of the issue
* The location of the affected source code (tag/branch/commit or direct URL)
* Any special configuration required to reproduce the issue
* Step-by-step instructions to reproduce the issue
* Proof-of-concept or exploit code (if possible)
* Impact of the issue, including how an attacker might exploit the issue

This information will help us triage your report more quickly.

## Preferred Languages

We prefer all communications to be in English.

## Policy

* We will respond to your report within 3 business days with our evaluation of the report and an expected resolution date.
* If you have followed the instructions above, we will not take any legal action against you regarding the report.
* We will handle your report with strict confidentiality, and not pass on your personal details to third parties without your permission.
* We will keep you informed of the progress towards resolving the problem.
* In the public information concerning the problem reported, we will give your name as the discoverer of the problem (unless you desire otherwise).

## Disclosure Policy

* The security report is received and is assigned a primary handler. This person will coordinate the fix and release process.
* The problem is confirmed and a list of all affected versions is determined.
* Code is audited to find any potential similar problems.
* Fixes are prepared for all supported releases. These fixes are not committed to the public repository but rather held locally pending the announcement.
* A suggested embargo date for this vulnerability is chosen.
* On the embargo date, the changes are pushed to the public repository and new builds are deployed.

## Comments on this Policy

If you have suggestions on how this process could be improved, please submit a pull request.
