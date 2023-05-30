package br.com.flaviogf.beam.example1;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

import org.apache.beam.sdk.Pipeline;
import org.apache.beam.sdk.transforms.Create;

public class FirstPipeline {
  public static void main(String[] args) throws IOException {
    ClassLoader loader = FirstPipeline.class.getClassLoader();
    String file = loader.getResource("lorem.txt").getFile();
    List<String> lines = Files.readAllLines(Paths.get(file), StandardCharsets.UTF_8);

    Pipeline pipeline = Pipeline.create();

    pipeline.apply(Create.of(lines)).apply(Tokenize.of()).apply(PrintElements.of());

    pipeline.run().waitUntilFinish();
  }
}
