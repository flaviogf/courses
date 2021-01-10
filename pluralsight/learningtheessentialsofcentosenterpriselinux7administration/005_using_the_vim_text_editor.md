# Using the vim Text Editor

- touch
- nano
- vim
- vimtutor

```sh
touch newfile

ls -l newfile

> newfile1

ls -l newfile

touch newfile

ls -l newfile

stat newfile

touch -d '19 April 1973' newfile

sudo yum install nano -y

nano newfile

vimtutor

vim

vi
```

- H left
- J down
- K up
- L right
- :q
- :q!
- ~/.vimrc

```vim
set showmode
set number
set nonumber
set invnumber
set nohlsearch
set ai
set ts=4
set expandtab
abbr _sh #!/bin/bash
nmap <C-N> :set invnumber<CR>
```

```sh
vi ~/.vimrc
```

- SHIFT+O to insert above
- :e! to revert to the last save changes
- CTRL+] to autocomplete using abbr
