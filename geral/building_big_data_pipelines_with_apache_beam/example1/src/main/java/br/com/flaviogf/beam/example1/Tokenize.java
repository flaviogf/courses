package br.com.flaviogf.beam.example1;

import java.util.Arrays;
import java.util.List;
import java.util.function.Predicate;
import java.util.stream.Collectors;

import org.apache.beam.sdk.transforms.FlatMapElements;
import org.apache.beam.sdk.transforms.PTransform;
import org.apache.beam.sdk.values.PCollection;
import org.apache.beam.sdk.values.TypeDescriptors;

import com.google.common.base.Strings;

public class Tokenize extends PTransform<PCollection<String>, PCollection<String>> {
  public static Tokenize of() {
    return new Tokenize();
  }

  private static List<String> toWords(String input) {
    return Arrays.stream(input.split("\\W+"))
        .filter(((Predicate<String>) Strings::isNullOrEmpty).negate())
        .collect(Collectors.toList());
  }

  @Override
  public PCollection<String> expand(PCollection<String> input) {
    return input.apply(FlatMapElements.into(TypeDescriptors.strings()).via(Tokenize::toWords));
  }
}
