package br.com.flaviogf.beam.example3;

import org.apache.beam.sdk.transforms.DoFn;
import org.apache.beam.sdk.transforms.PTransform;
import org.apache.beam.sdk.transforms.ParDo;
import org.apache.beam.sdk.values.PCollection;

public class Log<T> extends PTransform<PCollection<T>, PCollection<T>> {
  public static <T> Log<T> of() {
    return new Log<>();
  }

  @Override
  public PCollection<T> expand(PCollection<T> input) {
    return input.apply(ParDo.of(new LogFn<>()));
  }

  private static class LogFn<T> extends DoFn<T, T> {
    @ProcessElement
    public void process(@Element T element, OutputReceiver<T> out) {
      System.out.println(element);
      out.output(element);
    }
  }
}
