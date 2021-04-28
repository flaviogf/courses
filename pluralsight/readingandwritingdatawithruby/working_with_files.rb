def main()
    write "Ruby is awesome!"

    read
end

def write(message)
    File.open("file.txt", "a") do |f|
        f.write "#{message}\n"
    end
end

def read()
    File.open("file.txt") do |f|
        content = f.read

        puts content
    end
end

main
