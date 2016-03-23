" ProcessStart.vim - Execute System.Diagnostics.Process.Start
" Copyright (C) Retorillo <http://github.com/retorillo/> 
" Distributed under the MIT license

" Usage:
" :ProcessStart [{cmd} [{arg1} {arg2} ... ]]

if !exists("g:processStart#path")
   let g:processStart#path = ""
endif
if !exists("g:processStart#urlPattern")
   let g:processStart#urlPattern = "\\v(http|https):\\/\\/[-_.a-zA-Z0-9=*'!?#%&(){}|~/]+"
endif

command! -nargs=* -complete=file ProcessStart :call ProcessStart("<args>")
cabbrev processstart <c-r>=getcmdtype() == ":" && getcmdpos() == 1 ? "ProcessStart" : "processstart"<CR>
cabbrev ii <c-r>=getcmdtype() == ":" && getcmdpos() == 1 ? "ProcessStart" : "ii"<CR>
let s:bin = expand("<sfile>:p:h") . "\\processstart.exe"

function! s:ShellQuote(str)
   return "\"".shellescape(a:str)."\""
endfunction

function! ProcessStart(...)
   let l:arg = ""
   if a:0 == 1 && len(a:1) == 0
      " Start url that current line containts
      let l:urlm = matchlist(getline('.'), g:processStart#urlPattern)
      if len(l:urlm) == 0
         echo "URL not found. Overwrite g:processStart#urlPattern to improve URL detection"
         return 
      endif
      let l:arg = s:ShellQuote(l:urlm[0])
   else
      for a in a:000
         let l:arg .= s:ShellQuote(l:a)
      endfor
   endif
   let l:out = system(s:bin." ".s:ShellQuote("?".g:processStart#path)." ".l:arg)
   if len(l:out) > 0
      echo l:out
   endif
endfunction
