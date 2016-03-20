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

Set `g:processStart#urlPattern` to improve URL detection.

```vimL
let g:processStart#urlPattern = "\\v(http|https):\\/\\/[-_.a-zA-Z0-9=*'!?#%&(){}|~/]+"
```

## Install (Pathogen)

```vimL
git clone https://github.com/retorillo/processstart.vim.git ~/.vim/bundle/processstart.vim
```

## License

The MIT License
Copyright (C) Retorillo
