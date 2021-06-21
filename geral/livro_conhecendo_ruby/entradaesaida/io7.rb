require "zip"
require "fileutils"

myzip = "teste.zip"

File.delete myzip if File.exists? myzip

Zip::File.open myzip, true do |zipfile|
  Dir.glob "*.txt" do |file|
    zipfile.add "txts/#{file}", file
  end
end

Zip::File.open myzip do |zipfile|
  zipfile.each do |file|
    dir = File.dirname file.name
    puts "Descompactando #{file.name} para #{dir}"
    FileUtils.mkpath dir unless File.exists? dir
    zipfile.extract file.name, file.name do |entry, file|
      puts "Arquivo #{file} existe apagando..."
      File.delete file
    end
  end
end
