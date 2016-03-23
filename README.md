# ProcessStart.vim

For Windows Only. Simple lancher for Vim that calls .NET `System.Diagnostics.Process.Start`

`ii` is an abbrev for `ProcessStart`. Type `:ii` and whitespace, then
it will be automatically replaced by `:ProcessStart `.

## Example

Find URL from the current line and open it. (No arguments)

```vimL
:ProcessStart
```

Open 'example.com' by default browser.

```vimL
:ProcessStart http://example.com/
```
Execute new instance of gvim
(`!gvim` will unexpectedly display `Press ENTER or command to continue`)

```vimL
:ProcessStart gvim example.md
```

Open current editing file by associated application.

```vimL
:ProcessStart %
```

Open current directory by file explorer.

```vimL
:ProcessStart .
```

## Configuration

### g:processStart#urlPattern

Set `g:processStart#urlPattern` to improve URL detection.

```vimL
let g:processStart#urlPattern = "\\v(http|https):\\/\\/[-_.a-zA-Z0-9=*'!?#%&(){}|~/]+"
```

### g:processStart#path

Set `g:processStart#path` to add "PATH" only for this plugin.
If you specify multiple path, use `?` as seperator as follow:

```vimL
let g:processStart#path = "/your/special/bin1?/your/special/bin2"
```

SHOULD NOT use this variable for main programs,
use machine specific environment variable `PATH` alternatively.
This is optimal for batch files for Vim.

## Install (Pathogen)

```vimL
git clone https://github.com/retorillo/processstart.vim.git ~/.vim/bundle/processstart.vim
```

## License

The MIT License
Copyright (C) Retorillo
