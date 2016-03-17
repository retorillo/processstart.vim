# ProcessStart.vim

For Windows Only. Execute .NET `System.Diagnostics.Process.Start` for specified path.

`ii` is an abbrev for `ProcessStart`. Type `:ii` and whitespace, then
it will be automatically replaced by `:ProcessStart `.

## Example

Open 'example.com' by default browser.

```vimL
:ProcessStart http://example.com/
```

Open current editing file by associated application.

```vimL
:ProcessStart %
```

Open current directory by file explorer.

```vimL
:ProcessStart .
```

## Install (Pathogen)

```vimL
git clone https://github.com/retorillo/processstart.vim.git ~/.vim/bundle/processstart.vim
```

## License

The MIT License
Copyright (C) Retorillo
