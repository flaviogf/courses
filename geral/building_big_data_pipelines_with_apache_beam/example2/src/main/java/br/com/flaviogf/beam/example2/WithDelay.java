package br.com.flaviogf.beam.example2;

import java.util.concurrent.TimeUnit;

import org.apache.beam.sdk.transforms.DoFn;
import org.apache.beam.sdk.transforms.PTransform;
import org.apache.beam.sdk.transforms.ParDo;
import org.apache.beam.sdk.values.PCollection;
import org.joda.time.Duration;

public class WithDelay<T> extends PTransform<PCollection<T>, PCollection<T>> {
  public static <T> WithDelay<T> of(Duration duration) {
    return new WithDelay<>(duration);
  }

  private static class DelayFn<T> extends DoFn<T, T> {
    private final Duration duration;

    public DelayFn(Duration duration) {
      this.duration = duration;
    }

    @ProcessElement
    public void process(@Element T element, OutputReceiver<T> out) {
      try {
        TimeUnit.MILLISECONDS.sleep(duration.getMillis());
      } catch(Exception ex) {
      }

      out.output(element);
    }
  }

  private final Duration duration;

  public WithDelay(Duration duration) {
    this.duration = duration;
  }
 
  @Override
  public PCollection<T> expand(PCollection<T> input) {
    return input.apply(ParDo.of(new DelayFn<>(duration)));
  }
}
