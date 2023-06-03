package br.com.flaviogf.beam.example3;

import java.util.Arrays;
import java.util.List;

import org.apache.beam.sdk.Pipeline;
import org.apache.beam.sdk.options.PipelineOptions;
import org.apache.beam.sdk.options.PipelineOptionsFactory;
import org.apache.beam.sdk.transforms.Create;

public class App {
  public static void main(String[] args) {
    PipelineOptions options = PipelineOptionsFactory.fromArgs(args).create();

    Pipeline pipeline = Pipeline.create(options);

    List<String> words = Arrays.asList("Hello", "World");

    pipeline.apply(Create.of(words)).apply(Log.of());

    pipeline.run().waitUntilFinish();
  }
}
