set nocompatible
filetype plugin on
set tabstop=2
set shiftwidth=2
set softtabstop=2
set expandtab
set wildmenu
set wildmode=full
set history=200
set mouse=a
set nocompatible
filetype plugin on
set incsearch

autocmd BufWritePost * call system("ctags -R")
