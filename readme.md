<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /readme.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# <img src="/src/icon.png" height="30px"> Verify.SqlServer

[![Build status](https://ci.appveyor.com/api/projects/status/enh6mjugcbmoun0e?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-sqlserver)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.SqlServer.svg)](https://www.nuget.org/packages/Verify.SqlServer/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of SqlServer bits.

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-verify?utm_source=nuget-verify&utm_medium=referral&utm_campaign=enterprise).

<a href='https://dotnetfoundation.org' alt='Part of the .NET Foundation'><img src='https://raw.githubusercontent.com/VerifyTests/Verify/master/docs/dotNetFoundation.svg' height='30px'></a><br>
Part of the <a href='https://dotnetfoundation.org' alt=''>.NET Foundation</a>

<!-- toc -->
## Contents

  * [Usage](#usage)
    * [SqlServer Schema](#sqlserver-schema)
  * [Security contact information](#security-contact-information)<!-- endtoc -->


## NuGet package

https://nuget.org/packages/Verify.SqlServer/


## Usage

Enable VerifySqlServer once at assembly load time:

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
VerifySqlServer.Enable();
```
<sup><a href='/src/Tests/Tests.cs#L17-L19' title='File snippet `enable` was extracted from'>snippet source</a> | <a href='#snippet-enable' title='Navigate to start of snippet `enable`'>anchor</a></sup>
<!-- endsnippet -->


### SqlServer Schema

This test:

<!-- snippet: SqlServerSchema -->
<a id='snippet-sqlserverschema'></a>
```cs
[Test]
public async Task SqlServerSchema()
{
    await using var database = await sqlInstance.Build();
    await Verifier.Verify(database.Connection);
}
```
<sup><a href='/src/Tests/Tests.cs#L61-L70' title='File snippet `sqlserverschema` was extracted from'>snippet source</a> | <a href='#snippet-sqlserverschema' title='Navigate to start of snippet `sqlserverschema`'>anchor</a></sup>
<!-- endsnippet -->

Will result in the following verified file:

<!-- snippet: Tests.SqlServerSchema.verified.sql -->
<a id='snippet-Tests.SqlServerSchema.verified.sql'></a>
```sql
CREATE TABLE [dbo].[MyTable](
	[Value] [int] NULL
) ON [PRIMARY]

CREATE VIEW MyView
AS
  SELECT Value
  FROM MyTable
  WHERE (Value > 10);

CREATE PROCEDURE MyProcedure
AS
BEGIN
  SET NOCOUNT ON;
  SELECT Value
  FROM MyTable
  WHERE (Value > 10);
END;

CREATE FUNCTION MyFunction(
  @quantity INT,
  @list_price DEC(10,2),
  @discount DEC(4,2)
)
RETURNS DEC(10,2)
AS
BEGIN
    RETURN @quantity * @list_price * (1 - @discount);
END;
```
<sup><a href='/src/Tests/Tests.SqlServerSchema.verified.sql#L1-L29' title='File snippet `Tests.SqlServerSchema.verified.sql` was extracted from'>snippet source</a> | <a href='#snippet-Tests.SqlServerSchema.verified.sql' title='Navigate to start of snippet `Tests.SqlServerSchema.verified.sql`'>anchor</a></sup>
<!-- endsnippet -->


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Database](https://thenounproject.com/term/database/310841/) designed by [Creative Stall](https://thenounproject.com/creativestall/) from [The Noun Project](https://thenounproject.com/creativepriyanka).
