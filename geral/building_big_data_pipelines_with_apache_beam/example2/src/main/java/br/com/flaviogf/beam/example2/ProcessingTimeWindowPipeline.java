package br.com.flaviogf.beam.example2;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

import org.apache.beam.sdk.Pipeline;
import org.apache.beam.sdk.transforms.Count;
import org.apache.beam.sdk.transforms.Create;
import org.apache.beam.sdk.transforms.windowing.AfterProcessingTime;
import org.apache.beam.sdk.transforms.windowing.GlobalWindows;
import org.apache.beam.sdk.transforms.windowing.Repeatedly;
import org.apache.beam.sdk.transforms.windowing.Window;
import org.apache.beam.sdk.values.PCollection;
import org.joda.time.Duration;

public class ProcessingTimeWindowPipeline {
  public static void main(String[] args) throws IOException {
    ClassLoader loader = ProcessingTimeWindowPipeline.class.getClassLoader();
    String file = loader.getResource("lorem.txt").getFile();
    List<String> lines = Files.readAllLines(Paths.get(file), StandardCharsets.UTF_8);

    Pipeline pipeline = Pipeline.create();

    PCollection<String> input = pipeline.apply(Create.of(lines));

    PCollection<String> words = input.apply(Tokenize.of()).apply(WithDelay.of(Duration.millis(100)));

    PCollection<String> windowed = words.apply(
        Window.<String>into(new GlobalWindows())
            .triggering(
                Repeatedly.forever(
                    AfterProcessingTime.pastFirstElementInPane().plusDelayOf(Duration.standardSeconds(1))))
            .discardingFiredPanes());

    PCollection<Long> result = windowed.apply(Count.globally());

    result.apply(PrintElements.of());

    pipeline.run().waitUntilFinish();
  }
}
