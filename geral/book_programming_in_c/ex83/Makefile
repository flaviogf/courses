files = file1 file2

some_files: $(files)
	echo "Look at this variables: " $(files)
	touch some_files

file1:
	touch file1

file2:
	touch file2

clean:
	rm -rf file1 file2 some_files
