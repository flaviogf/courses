package br.com.flaviogf.beam.example1;

import org.apache.beam.sdk.transforms.DoFn;
import org.apache.beam.sdk.transforms.PTransform;
import org.apache.beam.sdk.transforms.ParDo;
import org.apache.beam.sdk.values.PCollection;
import org.apache.beam.sdk.values.PDone;

public class PrintElements<T> extends PTransform<PCollection<T>, PDone> {
  public static <T> PrintElements<T> of() {
    return new PrintElements<T>();
  }

  private static class LogResultDoFn<T> extends DoFn<T, Void> {
    @ProcessElement
    public void process(@Element T element) {
      System.out.println(element);
    }
  }

  @Override
  public PDone expand(PCollection<T> input) {
    input.apply(ParDo.of(new LogResultDoFn<T>()));
    return PDone.in(input.getPipeline());
  }
}
