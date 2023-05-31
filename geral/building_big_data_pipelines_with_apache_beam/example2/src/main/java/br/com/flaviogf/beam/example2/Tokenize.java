package br.com.flaviogf.beam.example2;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import org.apache.beam.sdk.transforms.FlatMapElements;
import org.apache.beam.sdk.transforms.PTransform;
import org.apache.beam.sdk.transforms.SimpleFunction;
import org.apache.beam.sdk.values.PCollection;

public class Tokenize extends PTransform<PCollection<String>, PCollection<String>> {
  public static Tokenize of() {
    return new Tokenize();
  }

  @Override
  public PCollection<String> expand(PCollection<String> input) {
    return input.apply(FlatMapElements.via(new SimpleFunction<String, List<String>>() {
      public List<String> apply(String input) {
        return Arrays.stream(input.split("\\W+")).collect(Collectors.toList());
      }
    }));
  }
}
