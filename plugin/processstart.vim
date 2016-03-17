" ProcessStart.vim - Execute System.Diagnostics.Process.Start
" Copyright (C) Retorillo <http://github.com/retorillo/> 
" Distributed under the MIT license

" Usage:
" :ProcessStart {path}

command! -nargs=1 -complete=file ProcessStart :call ProcessStart("<args>")
cabbrev processstart <c-r>=getcmdtype() == ":" ? "ProcessStart" : "processstart"<CR>
cabbrev ii <c-r>=getcmdtype() == ":" ? "ProcessStart" : "ii"<CR>

function! ProcessStart(path)
   let s:bin = expand("<sfile>:p:h") . "/processstart.exe"
   call system(s:bin . " " . a:path)
endfunction
